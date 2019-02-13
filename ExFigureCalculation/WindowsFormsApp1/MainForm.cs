using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        //источник данных (коллекции фигур)
        private Context _context = new Context();
        //источник привязок
        private BindingSource _bsFigures = new BindingSource();

        public MainForm()
        {
            InitializeComponent();

            //установка привязок
            SetBindings();

            //загрузка данных
            LoadData();

            //настройка окна
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Пример";
        }

        private void SetBindings()
        {
            //устанавливаем тип источника данных
            _bsFigures.DataSource = typeof(List<Figure>);
            //подписываемся на изменение текущей выбранной фигуры
            _bsFigures.CurrentChanged += BsFigures_CurrentChanged;

            //делаем привязку для комбобокса
            _comboBoxFigures.DataSource = _bsFigures;
            //комбобокс будет отображать названия фигур из коллекции
            _comboBoxFigures.DisplayMember = nameof(Figure.Name);
        }

        private void BsFigures_CurrentChanged(object sender, EventArgs e)
        {
            //подготовка панели
            _panelOutput.Controls.Clear();
            //отображение UserControl связанной с соотв.фигурой
            _panelOutput.Controls.Add((_bsFigures.Current as Figure).Control);
        }

        private void LoadData()
        {
            _bsFigures.DataSource = _context.GetFigures();
        }

    }
}
