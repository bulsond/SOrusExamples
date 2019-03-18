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
using WinFormsApp1.Models;

namespace WinFormsApp1.Views
{
    public partial class EditView : Form
    {
        private BindingSource _bsPerson = new BindingSource();

        public EditView()
        {
            InitializeComponent();

            //привязки
            SetBindings();

            //роли кнопок
            this.AcceptButton = _buttonOK;
            this.CancelButton = _buttonCancel;

            //кнопка ОК отдает результат
            _buttonOK.Click += (s, e) => this.DialogResult = DialogResult.OK;

            //радиокнопки
            _radioButtonMale.CheckedChanged += RadioButton_CheckedChanged;
            _radioButtonFemale.CheckedChanged += RadioButton_CheckedChanged;
        }

        /// <summary>
        /// Текущий редактируемый чел
        /// </summary>
        public Person CurrentPerson
        {
            get => _bsPerson.Current as Person;
            set => _bsPerson.Add(value);
        }

        /// <summary>
        /// Установка привязок
        /// </summary>
        private void SetBindings()
        {
            _textBoxName.DataBindings.Add("Text", _bsPerson, nameof(Person.Name),
                                           true, DataSourceUpdateMode.OnPropertyChanged);

            _textBoxSurename.DataBindings.Add("Text", _bsPerson, nameof(Person.Surename),
                                             true, DataSourceUpdateMode.OnPropertyChanged);

            _textBoxWeight.DataBindings.Add("Text", _bsPerson, nameof(Person.Weight),
                                             true, DataSourceUpdateMode.OnPropertyChanged);

            _textBoxSex.DataBindings.Add("Text", _bsPerson, nameof(Person.Sex),
                                             true, DataSourceUpdateMode.OnPropertyChanged);

            _dateTimePickerBirthday.DataBindings.Add("Text", _bsPerson, nameof(Person.Birthday),
                                                     true, DataSourceUpdateMode.OnPropertyChanged);

            //отображение ошибок
            _errorProvider.DataSource = _bsPerson;

            //доступность кнопки OK через событие изменения свойств чела
            _bsPerson.CurrentItemChanged += _bsPerson_CurrentItemChanged;
        }

        /// <summary>
        /// Проверка значения свойств чела и вкл./выкл. кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _bsPerson_CurrentItemChanged(object sender, EventArgs e)
        {
            string error = String.Empty;
            //пробегаем по всем свойствам чела и собираем значения ошибок
            foreach (var prop in CurrentPerson.GetType().GetProperties())
            {
                error += CurrentPerson[prop.Name];
            }

            //вкл./выкл. кнопки ОК
            _buttonOK.Enabled = String.IsNullOrEmpty(error);
            //Debug.WriteLine($"error: {error}");
        }

        /// <summary>
        /// Радиокнопки, присвоение пола челу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb.Checked)
            {
                if (rb.Text.Equals("М"))
                {
                    _textBoxSex.Text = "мужской";
                }
                else
                {
                    _textBoxSex.Text = "женский";
                }
            }
        }

    }
}
