using System.ComponentModel;

namespace WpfApp1.Abstractions
{
    public interface IMainWindowViewModel : INotifyPropertyChanged
    {
        //отображаемая вьюха
        object CurrentView { get; set; }
        //отображаемое сообщение
        object MessageView { get; set; }
    }
}