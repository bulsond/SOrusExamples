using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Services;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1
{
    public partial class MainView : Form
    {
        //класс работы с БД
        private readonly DataContext _data = new DataContext();
        //флаг загрузки формы
        private bool _isFirsLoading = true;
        //флаг опроса всех нод
        private bool _isChecking = false;

        public MainView()
        {
            InitializeComponent();

            //загрузка данных
            LoadData();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Пример";

            //подписка
            _treeViewDevices.AfterSelect += TreeViewIpAddresses_AfterSelect;
            _buttonCheckAll.Click += ButtonCheckAll_Click;
            _buttonCancel.Click += ButtonCancel_Click;
        }

        

        /// <summary>
        /// Загрузка данных из БД
        /// Создание нод для TreeView
        /// </summary>
        private async void LoadData()
        {
            //получаем коллекцию устройств из БД
            List<Device> devices = await _data.GetDevicesAsync();

            //создаем ноды и наполняем TreeView
            foreach (var device in devices)
            {
                var node = new DeviceTreeNode(device);
                node.ImageIndex = 0;
                node.SelectedImageIndex = 1;
                _treeViewDevices.Nodes.Add(node);
            }
        }

        /// <summary>
        /// Выбор ноды в TreeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TreeViewIpAddresses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //надо ли что-то делать
            if (_isFirsLoading || _isChecking)
            {
                _isFirsLoading = false;
                return;
            }

            await ConnectToDevice(_treeViewDevices.SelectedNode);
        }

        /// <summary>
        /// Соединение с выделенным устройством
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private async Task ConnectToDevice(TreeNode node)
        {
            //приводим ноду к нашему типу
            var devNode = node as DeviceTreeNode;

            //пытаемся соединиться
            var modbus = new Modbus(devNode.Device.IpAddress, devNode.Device.Port);
            bool connected = await Task.Run(() => modbus.OpenTCP());

            if (connected)
            {
                Debug.WriteLine($"Адрес {devNode.Device.IpAddress} доступен");
                devNode.SelectedImageIndex = 2;
                modbus.CloseTCP();
            }
            else
            {
                Debug.WriteLine($"Адрес {devNode.Device.IpAddress} недоступен");
                devNode.SelectedImageIndex = 3;
            }
        }

        /// <summary>
        /// Опрос всех устройств
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonCheckAll_Click(object sender, EventArgs e)
        {
            _isChecking = true;
            _buttonCancel.Enabled = true;
            _buttonCheckAll.Enabled = false;

            foreach (TreeNode node in _treeViewDevices.Nodes)
            {
                if (!_isChecking) break;

                // выделяем ноду
                _treeViewDevices.SelectedNode = node;
                //пытаемся соединится
                await ConnectToDevice(node);
                //пауза чтоб успела отобразиться иконка
                await Task.Delay(500);
            }

            _isChecking = false;
            _buttonCancel.Enabled = false;
            _buttonCheckAll.Enabled = true;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            _isChecking = false;
        }
    }
}
