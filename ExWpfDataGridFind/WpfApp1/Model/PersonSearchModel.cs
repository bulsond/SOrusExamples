using System.ComponentModel;

namespace WpfApp1.Model
{
    public class PersonSearchModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private char _FirstNameLetter;
        public char FirstNameLetter
        {
            get => _FirstNameLetter;
            set
            {
                _FirstNameLetter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstNameLetter)));
            }
        }

        private char _LastNameLetter;
        public char LastNameLetter
        {
            get => _LastNameLetter;
            set
            {
                _LastNameLetter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastNameLetter)));
            }
        }

        private bool _IsSearchByName;
        public bool IsSearchByName
        {
            get => _IsSearchByName;
            set
            {
                _IsSearchByName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSearchByName)));
            }
        }


    }
}
