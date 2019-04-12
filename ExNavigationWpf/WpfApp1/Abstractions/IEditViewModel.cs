using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.Abstractions
{
    public interface IEditViewModel : INotifyPropertyChanged
    {
        Person CurrentPerson { get; set; }

        ICommand BackCommand { get; }
        ICommand SaveCommand { get; }
    }
}
