using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views
{
    public partial class MainView : Form
    {
        //источник данных для DGV
        private BindingSource _bsPeople = new BindingSource();

        public MainView()
        {
            InitializeComponent();

            //привязки
            SetBindings();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Пример";

            this.Load += MainView_Load;
            _buttonAddPerson.Click += ButtonAddPerson_Click;
        }

        /// <summary>
        /// Установка привязок
        /// </summary>
        private void SetBindings()
        {
            _dataGridViewPeople.AutoGenerateColumns = false;
            _dataGridViewPeople.DataSource = _bsPeople;

            _columnPersonName.DataPropertyName = nameof(Person.Name);
            _columnPersonSurename.DataPropertyName = nameof(Person.Surename);
            _columnPersonSex.DataPropertyName = nameof(Person.Sex);
            _columnPersonBirthday.DataPropertyName = nameof(Person.Birthday);
            _columnPersonWeight.DataPropertyName = nameof(Person.Weight);
        }

        /// <summary>
        /// Загружаем данные для DGV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainView_Load(object sender, EventArgs e)
        {
            //получем коллекцию людей
            List<Person> people = await Program.PersonRepository.GetPeople();

            //заполняем источник данных
            people.ForEach(p => _bsPeople.Add(p));
        }

        /// <summary>
        /// Добавление новой записи о человеке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonAddPerson_Click(object sender, EventArgs e)
        {
            using (var editView = new EditView())
            {
                //готовим форму
                editView.Owner = this;
                editView.StartPosition = FormStartPosition.CenterParent;
                editView.Text = "Создание новой записи";

                //назначаем экземпляр нового чела
                editView.CurrentPerson = new Person() { Birthday = DateTime.Now };

                //отображаем форму, ждем ответа
                if (editView.ShowDialog() == DialogResult.OK)
                {
                    //запоминаем
                    await Program.PersonRepository.AddPerson(editView.CurrentPerson);

                    //перезагружаем коллекцию людей
                    _bsPeople.Clear();
                    var people = await Program.PersonRepository.GetPeople();
                    people.ForEach(p => _bsPeople.Add(p));
                }
            }
        }
    }
}
