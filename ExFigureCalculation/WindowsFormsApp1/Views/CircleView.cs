using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Views
{
    public partial class CircleView : UserControl
    {
        //источник привязок
        private BindingSource _bs = new BindingSource();

        public CircleView()
        {
            InitializeComponent();

            //установка привязок
            SetBindings();
        }

        private void SetBindings()
        {
            //тип данных
            _bs.DataSource = typeof(Circle);

            //привязка для текстбокса Радиуса
            var radiusBinding = new Binding("Text", _bs, nameof(Circle.Radius),
                true, DataSourceUpdateMode.OnPropertyChanged);
            _textBoxRadius.DataBindings.Add(radiusBinding);

            //привязка для текстбокса Диаметра
            var diameterBinding = new Binding("Text", _bs, nameof(Circle.Diameter),
                true, DataSourceUpdateMode.OnPropertyChanged);
            _textBoxDiameter.DataBindings.Add(diameterBinding);

            //привязка для вывода площади фигуры
            var labelBinding = new Binding("Text", _bs, nameof(Circle.Area),
                true, DataSourceUpdateMode.OnPropertyChanged, 0, "f4");
            _labelArea.DataBindings.Add(labelBinding);
        }

        /// <summary>
        /// Рабочая окружность
        /// </summary>
        public Circle Circle
        {
            get => _bs.Current as Circle;
            set
            {
                _bs.Clear();
                _bs.Add(value);
            }
        }
    }
}
