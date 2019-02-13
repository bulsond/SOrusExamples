using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public class MainViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        //ctor
        public MainViewModel()
        {
            SetRadioButtons();
            AnimalType = "NotAnimal";
        }

        private void SetRadioButtons()
        {
            RadioButtons = new List<RadioButtonViewModel>
            {
                new RadioButtonViewModel("NotAnimal", OnCheckRadioButton, OnAssignToRadioButton),
                new RadioButtonViewModel("Cow", OnCheckRadioButton, OnAssignToRadioButton),
                new RadioButtonViewModel("Dog", OnCheckRadioButton, OnAssignToRadioButton),
                new RadioButtonViewModel("Cat", OnCheckRadioButton, OnAssignToRadioButton),
            };
        }

        private bool OnCheckRadioButton(string arg)
        {
            return AnimalType.Equals(arg);
        }

        private void OnAssignToRadioButton(string obj)
        {
            AnimalType = obj;
        }

        public List<RadioButtonViewModel> RadioButtons { get; set; }


        #region Старый вариант
        //public bool NotAnimalSelected
        //{
        //    get => AnimalType.Equals("NotAnimal");
        //    set => AnimalType = "NotAnimal";
        //}

        //public bool CowSelected
        //{
        //    get => AnimalType.Equals("Cow");
        //    set => AnimalType = "Cow";
        //}

        //public bool DogSelected
        //{
        //    get => AnimalType.Equals("Dog");
        //    set => AnimalType = "Dog";
        //}

        //public bool CatSelected
        //{
        //    get => AnimalType.Equals("Cat");
        //    set => AnimalType = "Cat";
        //} 
        #endregion


        private string _AnimalType;
        public string AnimalType
        {
            get => _AnimalType;
            set
            {
                _AnimalType = value;

                #region Старый вариант
                //OnPropertyChanged("NotAnimalSelected");
                //OnPropertyChanged("CowSelected");
                //OnPropertyChanged("DogSelected");
                //OnPropertyChanged("CatSelected");
                //OnPropertyChanged("Name"); 
                #endregion

                foreach (var rb in RadioButtons)
                {
                    rb.RaisePropertyChanged();
                }

                OnPropertyChanged("Name");
            }
        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        //IDEI
        public string Error => String.Empty;
        public string this[string columnName]
        {
            get
            {
                if (RadioButtons[0].RadioButtonValue) return String.Empty;

                if (String.IsNullOrEmpty(Name) || Name.Trim().Length <= 3)
                {
                    return "Кличка не может быть короче 4-х символов";
                }
                return String.Empty;
            }
        }

        //INPC
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
