using System;
using System.ComponentModel;

namespace WpfApp1.Model
{
    public class PersonModel : INotifyPropertyChanged
    {
        //ctor
        public PersonModel(int id)
        {
            if (id <= 0) throw new ArgumentException(nameof(id));
            Id = id;
        }

        public int Id { get; private set; }

        private int _OrderNumber;
        public int OrderNumber
        {
            get => _OrderNumber;
            set
            {
                _OrderNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrderNumber)));
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set
            {
                _FirstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
            }
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set
            {
                _LastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
            }
        }

        public string FullName => $"{LastName} {FirstName}";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
