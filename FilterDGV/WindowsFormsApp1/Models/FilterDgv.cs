using System.ComponentModel;

namespace WindowsFormsApp1.Models
{
    class FilterDgv : INotifyPropertyChanged
    {

        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set
            {
                _FirstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
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
            }
        }


        private int _Age;
        public int Age
        {
            get => _Age;
            set
            {
                _Age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Age)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
