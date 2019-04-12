using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.Abstractions
{
    public interface IStartViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Person> People { get; set; }
        Person SelectedPerson { get; set; }

        ICommand EditCommand { get; }
        ICommand DeleteCommand { get; }
        ICommand CreateCommand { get; }
    }
}
