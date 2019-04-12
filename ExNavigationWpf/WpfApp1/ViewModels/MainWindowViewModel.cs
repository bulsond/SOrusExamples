using System.ComponentModel;
using WpfApp1.Abstractions;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel : IMainWindowViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Отображение вьюшек
        /// </summary>
        private object _CurrentView;
        public object CurrentView
        {
            get => _CurrentView;
            set
            {
                _CurrentView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentView)));
            }
        }

        /// <summary>
        /// Отображение вьюшки-сообщения
        /// </summary>
        private object _MessageView;
        public object MessageView
        {
            get => _MessageView;
            set
            {
                _MessageView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MessageView)));
            }
        }
    }
}
