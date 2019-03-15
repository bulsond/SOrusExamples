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
    public partial class MainForm : Form
    {
        private BindingSource _bsPeople = new BindingSource();

        public MainForm()
        {
            InitializeComponent();

            //привязки
            SetBindings();
            //загрузка данных
            LoadData();

            this.CenterToScreen();
            this.Text = "Пример";

            this.buttonEdit.Click += ButtonEdit_Click;
            this.buttonAdd.Click += ButtonAdd_Click;
            this.buttonRemove.Click += ButtonRemove_Click;
        }

        /// <summary>
        /// Установка привязок
        /// </summary>
        private void SetBindings()
        {
            //выключаем автогенерацию колонок
            dataGridViewPeople.AutoGenerateColumns = false;
            //привязываем источник данных
            dataGridViewPeople.DataSource = _bsPeople;
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private void LoadData()
        {
            //получаем список людей из БД
            List<Person> people = Program.Context.GetPeople();

            //заполнение данными
            _bsPeople.Clear();
            people.ForEach(p => _bsPeople.Add(p));
        }

        /// <summary>
        /// Отображение окна редактирования чела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            using (var editForm = new EditForm())
            {
                editForm.Owner = this;
                editForm.StartPosition = FormStartPosition.CenterParent;

                //выбранный в таблице чел
                var selectedPerson = _bsPeople.Current as Person;

                //создаем редактируемую копию
                editForm.CurrentPerson = new Person
                {
                    Id = selectedPerson.Id,
                    FirstName = selectedPerson.FirstName,
                    LastName = selectedPerson.LastName
                };

                //отображаем форму и ждем результат
                editForm.Text = $"Редактирование {selectedPerson.FirstName} {selectedPerson.LastName}";
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    //изменяем данные в БД
                    Program.Context.UpdatePerson(editForm.CurrentPerson);

                    //перезагружаем данные в таблицу
                    LoadData();
                }
            }
        }

        /// <summary>
        /// Удаление выбранного чела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            //выбранный в таблице чел
            var selectedPerson = _bsPeople.Current as Person;

            string message = $"Вы согласны удалить {selectedPerson.FirstName} {selectedPerson.LastName}?";
            string caption = "Запрос на удаление человека";

            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //удаляем из БД
                Program.Context.Remove(selectedPerson.Id);

                //перечитываем данные из БД
                LoadData();
            }
        }

        /// <summary>
        /// Создание нового чела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new EditForm())
            {
                editForm.Owner = this;
                editForm.StartPosition = FormStartPosition.CenterParent;

                //создаем редактируемую человека
                editForm.CurrentPerson = new Person
                {
                    FirstName = Person.Dummy,
                    LastName = Person.Dummy
                };

                //отображаем форму и ждем результат
                editForm.Text = $"Создание нового человека";
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    //изменяем данные в БД
                    Program.Context.AddPerson(editForm.CurrentPerson);

                    //перезагружаем данные в таблицу
                    LoadData();
                }
            }
        }
    }
}
