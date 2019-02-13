using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFApp1.Models;

namespace WFApp1
{
    public partial class EditForm : Form
    {
        private BindingSource _bsPerson = new BindingSource();

        public EditForm()
        {
            InitializeComponent();

            //привязки
            SetBindings();

            //устанавливаем роли для кнопок
            this.CancelButton = buttonCancel;
            this.AcceptButton = buttonOK;

            //кнопка ОК отдает нужный результат
            buttonOK.Click += (s, e) => this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Установка привязок
        /// </summary>
        private void SetBindings()
        {
            //определяем тип источника
            _bsPerson.DataSource = typeof(Person);

            //привязка к текстбоксам
            textBoxFirstName.DataBindings.Add("Text", _bsPerson, nameof(Person.FirstName), true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxLastName.DataBindings.Add("Text", _bsPerson, nameof(Person.LastName), true, DataSourceUpdateMode.OnPropertyChanged);

            //привязываем отображение ошибок ввода
            errorProvider.DataSource = _bsPerson;

            //доступность кнопки через событие изменения свойств чела
            _bsPerson.CurrentItemChanged += _bsPerson_CurrentItemChanged;
        }

        private void _bsPerson_CurrentItemChanged(object sender, EventArgs e)
        {
            string error = String.Empty;
            //пробегаем по всем текстбоксам и собираем значения их ошибок
            foreach (var textBox in this.Controls.OfType<TextBox>())
            {
                //собираем сообщения об ошибках
                error += errorProvider.GetError(textBox);
            }

            //вкл./выкл. кнопки ОК
            buttonOK.Enabled = String.IsNullOrEmpty(error);
        }


        /// <summary>
        /// Редактируемый чел
        /// </summary>
        public Person CurrentPerson
        {
            get => _bsPerson.Current as Person;
            set
            {
                _bsPerson.Clear();
                _bsPerson.Add(value);
            }
        }
    }
}
