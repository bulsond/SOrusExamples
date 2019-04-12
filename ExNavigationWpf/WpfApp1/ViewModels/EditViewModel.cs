using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using WpfApp1.Abstractions;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class EditViewModel : IEditViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IAppController _appController;

        //ctor
        public EditViewModel(IAppController appController)
        {
            _appController = appController ?? throw new ArgumentNullException(nameof(appController));

            //команды
            BackCommand = new RelayCommand(OnBack, CanBack);
            SaveCommand = new RelayCommand(OnSave, CanSave);

            //получаем редактируемый экземпляр Person
            if (_appController.ViewModelBag == null
                || (CurrentPerson = (_appController.ViewModelBag as Person)) == null)
            {
                throw new ArgumentException(nameof(_appController.ViewModelBag));
            }
            else
            {
                _appController.ViewModelBag = null;
            }
            
        }

        /// <summary>
        /// Редактируемый чел
        /// </summary>
        private Person _СurrentPerson;
        public Person CurrentPerson
        {
            get => _СurrentPerson;
            set
            {
                _СurrentPerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPerson)));
            }
        }

        /// <summary>
        /// Кнопка Назад
        /// </summary>
        public ICommand BackCommand { get; }
        private bool CanBack()
        {
            return true;
        }
        private void OnBack()
        {
            _appController.ChangeCurrentView(CurrentViewTypes.Start);
        }

        /// <summary>
        /// Кнопка Сохранить
        /// </summary>
        public ICommand SaveCommand { get; }
        private bool CanSave()
        {
            return true;
        }
        private async void OnSave()
        {
            try
            {
                //сохраняем в БД
                await _appController.DataContext.SavePersonAsync(CurrentPerson);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Ошибка сохранения чела: {ex.Message}");
            }

            //возвращаемся назад
            _appController.ChangeCurrentView(CurrentViewTypes.Start);
        }

    }
}
