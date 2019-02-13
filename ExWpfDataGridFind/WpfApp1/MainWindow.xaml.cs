using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Abstractions;
using WpfApp1.Data;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Источник данных
        /// </summary>
        private readonly IRepository _repository = new TestRepository();

        //INPC
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            LoadData();
        }

        /// <summary>
        /// Список Людей
        /// </summary>
        public ObservableCollection<PersonModel> People { get; set; }

        /// <summary>
        /// Поисковый объект
        /// </summary>
        private PersonSearchModel _SearchPerson;
        public PersonSearchModel SearchPerson
        {
            get => _SearchPerson;
            set
            {
                _SearchPerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchPerson)));
            }
        }

        /// <summary>
        /// Начальная загрузка данных
        /// </summary>
        private async void LoadData()
        {
            var people = await _repository.GetPeopleAsync();

            people = SetOrderNumbers(people);

            People = new ObservableCollection<PersonModel>(people);
            SearchPerson = new PersonSearchModel { FirstNameLetter = '?', LastNameLetter = '?' };
        }

        /// <summary>
        /// Сортировка и нумеровывание по порядку Людей
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        private static List<PersonModel> SetOrderNumbers(List<PersonModel> people)
        {
            var pp = people.OrderBy(p => p.LastName).ToList();

            for (int i = 0; i < pp.Count; i++)
            {
                pp[i].OrderNumber = i + 1;
            }

            return pp;
        }

        /// <summary>
        /// Клавиши букв поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonLetter_Click(object sender, RoutedEventArgs e)
        {
            //получаем кнопку и букву на ней
            var button = sender as Button;
            var letter = button.Content.ToString();

            //в зависимости от чексбокса
            if (SearchPerson.IsSearchByName)
            {
                //искать начинаем с имени
                if (SearchPerson.FirstNameLetter == '?')
                {
                    SearchPerson.FirstNameLetter = letter[0];
                }
                else
                {
                    //иначе добавляем букву для фамилии
                    SearchPerson.LastNameLetter = letter[0];
                }
            }
            else
            {
                //искать начинаем с фамилии
                if (SearchPerson.LastNameLetter == '?')
                {
                    SearchPerson.LastNameLetter = letter[0];
                }
                else
                {
                    //иначе добавляем букву для имени
                    SearchPerson.FirstNameLetter = letter[0];
                }
            }

            //обновление списка Людей
            await UpdatePeople();
        }

        /// <summary>
        /// Обновление отображаемого списка Людей
        /// </summary>
        /// <returns></returns>
        private async Task UpdatePeople()
        {
            List<PersonModel> people = null;

            //если искать нечего, то просто перечитываем весь список Людей
            if (SearchPerson.FirstNameLetter == '?' && SearchPerson.LastNameLetter == '?')
            {
                people = await _repository.GetPeopleAsync();
            }
            else
            {
                //иначе пытаемся искать
                people = await _repository.SearchPeopleAsync(SearchPerson);
            }

            if (people.Count == 0)
            {
                MessageBox.Show("Таких не найдено!", "Результат поиска",
                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //ButtonClearSearch_Click(null, null);
                return;
            }

            //отсортируем и пронумеруем
            people = SetOrderNumbers(people);

            //отобразим
            People.Clear();
            people.ForEach(p => People.Add(p));
        }

        /// <summary>
        /// Кнопка очистки поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonClearSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchPerson.FirstNameLetter = '?';
            SearchPerson.LastNameLetter = '?';
            SearchPerson.IsSearchByName = false;

            await UpdatePeople();
        }
    }
}
