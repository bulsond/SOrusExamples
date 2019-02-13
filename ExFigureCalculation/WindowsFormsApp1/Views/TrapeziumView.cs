using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    public partial class TrapeziumView : UserControl
    {
        private BindingSource _bs = new BindingSource();

        public TrapeziumView()
        {
            InitializeComponent();

            SetBindings();
        }

        private void SetBindings()
        {
            _bs.DataSource = typeof(Models.Trapezium);

            var upper = new Binding("Text", _bs, nameof(Models.Trapezium.UpperBase),
                true, DataSourceUpdateMode.OnPropertyChanged);
            _textBoxUpper.DataBindings.Add(upper);

            var lower = new Binding("Text", _bs, nameof(Models.Trapezium.LowerBase),
                true, DataSourceUpdateMode.OnPropertyChanged);
            _textBoxLower.DataBindings.Add(lower);

            var height = new Binding("Text", _bs, nameof(Models.Trapezium.Height),
                true, DataSourceUpdateMode.OnPropertyChanged);
            _textBoxHeight.DataBindings.Add(height);

            var labelBinding = new Binding("Text", _bs, "Area",
                true, DataSourceUpdateMode.OnPropertyChanged, 0, "f4");
            _labelArea.DataBindings.Add(labelBinding);
        }

        public Models.Trapezium Trapezium
        {
            get => _bs.Current as Models.Trapezium;
            set
            {
                _bs.Clear();
                _bs.Add(value);
            }
        }
    }
}
