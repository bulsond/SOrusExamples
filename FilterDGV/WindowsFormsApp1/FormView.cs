using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Abstractions;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Data.Models;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class FormView : Form
    {
        //работа с БД
        private readonly IDataContext _dataContext = new TestDataContext();
        //источник привязки для DGV
        private readonly BindingSource _bsPeople = new BindingSource();
        //объект формирования выборок для DGV
        private readonly FilterDgv _filterDgv = new FilterDgv();

        public FormView()
        {
            InitializeComponent();

            //привязки
            SetBindings();
            //загрузка Людей
            LoadData();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Пример фильтрации в DGV";
        }

        /// <summary>
        /// Установка привязок
        /// </summary>
        private void SetBindings()
        {
            //DGV
            _bsPeople.DataSource = typeof(List<Person>);
            _dataGridViewPeople.AutoGenerateColumns = false;
            _dataGridViewPeople.DataSource = _bsPeople;

            //текстбоксы для выборки
            var bFN = new Binding("Text", _filterDgv, nameof(FilterDgv.FirstName));
            bFN.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _textBoxFindFirstName.DataBindings
                                 .Add(bFN);

            var bLN = new Binding("Text", _filterDgv, nameof(FilterDgv.LastName));
            bLN.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _textBoxFindLastName.DataBindings
                                .Add(bLN);

            var bAg = new Binding("Text", _filterDgv, nameof(FilterDgv.Age));
            bAg.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            _textBoxFindAge.DataBindings
                           .Add(bAg);
        }

        /// <summary>
        /// Загрузка данных в DGV
        /// </summary>
        private void LoadData()
        {
            DataSet data = _dataContext.GetPeople();
            _bsPeople.DataSource = data.Tables[0];

            //подписка на событие изменение свойств у фильтрующего объекта
            _filterDgv.PropertyChanged += _filterDgv_PropertyChanged;
        }

        /// <summary>
        /// Обработчик события изменения свойств у фильтрующего объекта
        /// Формирование и применения фильтра к DGV через BindingSource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _filterDgv_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var filters = new List<string>();

            //организуем список условий
            if (!String.IsNullOrEmpty(_filterDgv.FirstName))
            {
                filters.Add($"{nameof(Person.FirstName)} LIKE '{_filterDgv.FirstName}%'");
            }
            if (!String.IsNullOrEmpty(_filterDgv.LastName))
            {
                filters.Add($"{nameof(Person.LastName)} LIKE '{_filterDgv.LastName}%'");
            }
            if (_filterDgv.Age > 0)
            {
                filters.Add($"{nameof(Person.Age)} > {_filterDgv.Age}");
            }

            //удаляем предыдущий фильтр
            _bsPeople.RemoveFilter();

            //назначаем фильтрацию
            if (filters.Count == 1)
            {
                _bsPeople.Filter = filters.First();
            }
            else if (filters.Count > 1)
            {
                _bsPeople.Filter = String.Join(" AND ", filters);
            }
            else
            { }
        }
    }
}
