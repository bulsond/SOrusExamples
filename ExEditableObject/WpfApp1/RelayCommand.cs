using System;
using System.Windows.Input;

namespace WpfApp1
{
    public class RelayCommand<T> : ICommand
    {
        private Action<T> action;
        public RelayCommand(Action<T> action) => this.action = action;
        public bool CanExecute(object parameter) => true;
        #pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
        #pragma warning restore CS0067
        public void Execute(object parameter) => action((T)parameter);
    }

    public class RelayCommand : ICommand
    {
        private Action action;
        public RelayCommand(Action action) => this.action = action;
        public bool CanExecute(object parameter) => true;
        #pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
        #pragma warning restore CS0067
        public void Execute(object parameter) => action();
    }
}