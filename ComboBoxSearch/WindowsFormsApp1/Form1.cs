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
        private BindingSource _bsPeople = new BindingSource();
        private DataContext _dataContext = new DataContext();
        private List<Person> _people;

        public Form1()
        {
            InitializeComponent();

            //Привязки
            SetBindings();
            //Загрузка данных
            LoadData();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Пример";

            textBoxFilter.TextChanged += TextBoxFilter_TextChanged;
        }

        private void SetBindings()
        {
            _bsPeople.DataSource = typeof(List<Person>);
            comboBoxPeople.DataSource = _bsPeople;
            comboBoxPeople.DisplayMember = "Name";
        }

        private void LoadData()
        {
            _people = _dataContext.GetPeople();

            var fPeople = new FilteredBindingList<Person>();
            _people.ForEach(p => fPeople.Add(p));
            _bsPeople.DataSource = fPeople;
        }

        private void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            var filter = textBoxFilter.Text;
            if (String.IsNullOrEmpty(filter) || String.IsNullOrWhiteSpace(filter))
            {
                _bsPeople.RemoveFilter();
                return;
            }

            _bsPeople.RemoveFilter();
            _bsPeople.Filter = $"Name LIKE '{filter}%'";
        }

    }
}
