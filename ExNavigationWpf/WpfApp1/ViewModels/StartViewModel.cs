using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using WpfApp1.Abstractions;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class StartViewModel : IStartViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IAppController _appController;

        //ctor
        public StartViewModel(IAppController appController)
        {
            _appController = appController ?? throw new ArgumentNullException(nameof(appController));

            //команды
            EditCommand = new RelayCommand(OnEdit, CanEdit);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            CreateCommand = new RelayCommand(OnCreate, CanCreate);

            //загружаем из БД людей
            LoadPeople();
        }

        /// <summary>
        /// Список для ListView
        /// </summary>
        public ObservableCollection<Person> People { get; set; }

        /// <summary>
        /// Выбранный в ListView чел.
        /// </summary>
        private Person _SelectedPerson;
        public Person SelectedPerson
        {
            get => _SelectedPerson;
            set
            {
                _SelectedPerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPerson)));
                //перепроверка возможности выполнения команд
                (EditCommand as RelayCommand).RaiseCanExecuteChanged();
                (DeleteCommand as RelayCommand).RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Загрузка списка Людей
        /// </summary>
        private async void LoadPeople()
        {
            try
            {
                //получаем людей из БД
                var people = await _appController.DataContext.GetPeopleAsync();
                People = new ObservableCollection<Person>(people);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Загрузка списка людей: {ex.Message}");
            }
        }

        /// <summary>
        /// Кнопка Изменить
        /// </summary>
        public ICommand EditCommand { get; }
        private bool CanEdit()
        {
            return SelectedPerson != null;
        }
        private void OnEdit()
        {
            //передаем ссылку на выбранного чела
            _appController.ViewModelBag = SelectedPerson;
            //переходим к вьюшке редактирования чела
            _appController.ChangeCurrentView(CurrentViewTypes.Edit);
        }

        /// <summary>
        /// Кнопка Удалить
        /// </summary>
        public ICommand DeleteCommand { get; }
        private bool CanDelete()
        {
            return SelectedPerson != null;
        }
        private async void OnDelete()
        {
            string message = $"Вы согласны удалить: {SelectedPerson.FirstName} {SelectedPerson.LastName}?";
            //отображем вьюшку-сообщение и ждем выбор пользователя
            if (await _appController.IsMessageYesNoResult(message))
            {
                try
                {
                    await _appController.DataContext.RemovePerson(SelectedPerson.Id);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Удаление чела id={SelectedPerson.Id} вызвало ошибку: {ex.Message}");
                }

                //удаляем из отображаемого списка
                People.Remove(SelectedPerson);
                SelectedPerson = null;
            }
        }


        /// <summary>
        /// Кнопка Создать
        /// </summary>
        public ICommand CreateCommand { get; }
        private bool CanCreate()
        {
            return true;
        }
        private void OnCreate()
        {
            //создаем ссылку на нового чела
            _appController.ViewModelBag = new Person
            {
                FirstName = "<?>",
                LastName = "<?>",
                Birthdate = DateTime.Parse("01.01.1980")
            };
            //переходим к редактированию чела
            _appController.ChangeCurrentView(CurrentViewTypes.Edit);
        }
    }
}
