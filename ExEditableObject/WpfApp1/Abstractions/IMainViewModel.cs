using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.Abstractions
{
    public interface IMainViewModel
    {
        ObservableCollection<Person> People { get; }
        Person SelectedPerson { get; set; }

        ICommand AddCommand { get; }
        ICommand CancelCommand { get; }

        Task LoadData();
    }
}
