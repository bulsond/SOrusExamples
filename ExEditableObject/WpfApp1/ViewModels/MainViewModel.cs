using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Abstractions;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MainViewModel : IMainViewModel, INotifyPropertyChanged
    {
        private readonly IPersonRepository _repo;
        private Person _selectedPerson;

        public event PropertyChangedEventHandler PropertyChanged;

        //ctor
        public MainViewModel(IPersonRepository repository)
        {
            _repo = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task LoadData()
        {
            People = new ObservableCollection<Person>();

            var result = await _repo.GetPeopleOrderedByLastName();
            List<Person> people = result.ToList();
            for (int i = 0; i < people.Count; i++)
            {
                people[i].OrderNumber = i + 1;
                People.Add(people[i]);
            }

        }

        /// <summary>
        /// Коллекция для ListView
        /// </summary>
        public ObservableCollection<Person> People { get; private set; }


        /// <summary>
        /// Выделенный в ListView человек
        /// </summary>
        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                //отменяем редактирование предыдущ.
                _selectedPerson?.CancelEdit();

                _selectedPerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPerson)));

                //начинаем редактирование
                _selectedPerson?.BeginEdit();
            }
        }

        /// <summary>
        /// Кнопка Готово
        /// </summary>
        private ICommand _AddCommand;
        public ICommand AddCommand
        {
            get => _AddCommand = _AddCommand ?? new RelayCommand(OnAdd);
        }
        private async void OnAdd()
        {
            if (SelectedPerson == null) return;

            //заканчиваем редактирование
            SelectedPerson.EndEdit();
            //обновляем в БД
            await _repo.UpdatePerson(SelectedPerson);
            SelectedPerson = null;
            //перезагружаем список из БД
            await LoadData();
        }


        /// <summary>
        /// Кнопка Отмена
        /// </summary>
        private ICommand _CancelCommand;
        public ICommand CancelCommand
        {
            get => _CancelCommand = _CancelCommand ?? new RelayCommand(OnCancel);
        }
        private void OnCancel()
        {
            if (SelectedPerson == null) return;

            //отменяем редактирование
            SelectedPerson.CancelEdit();
        }
    }
}
