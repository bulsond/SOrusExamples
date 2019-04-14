using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string _key;
        
        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //заполняем комбобокс
            _comboBoxKeys.Items.AddRange(new string[] { "F5", "F6", "F7", "F8", "F9", "F10" });

            //читаем из конфигурации значение горячей клавиши
            _key = Properties.Settings.Default.StartButton;

            //находим в комбобоксе выбранную ранее клавишу
            if (!String.IsNullOrEmpty(_key))
            {
                _comboBoxKeys.SelectedIndex = _comboBoxKeys.Items.IndexOf(_key);
            }

            //подписываемся на событие изменения выбора
            _comboBoxKeys.SelectedIndexChanged += ComboBoxKeys_SelectedIndexChanged;
        }

        //обработчик выбора в комбобоксе
        private void ComboBoxKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            //получаем выбранное значение
            _key = _comboBoxKeys.Items[_comboBoxKeys.SelectedIndex].ToString();

            //запоминаем в выбранное значение
            Properties.Settings.Default.StartButton = _key;
            Properties.Settings.Default.Save();

            MessageBox.Show($"Вы выбрали клавишу: {_key}");
        }

        //переопределяем метод ловящий нажатия клавиш
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //используем конвертер чтоб значение Keys преобразовать к строке
            KeysConverter kc = new KeysConverter();
            //если пользователь нажал выбранную клавишу
            //запускаем метод связанный с ней
            if (kc.ConvertToString(keyData) == _key)
            {
                RunMethodHotKey();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //метод связанный с горячей клавишей
        private void RunMethodHotKey()
        {
            MessageBox.Show($"Вы нажали клавишу: {_key}");
        }
    }
}
