using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WindowsFormsApp1.Presenters.EventHandlers
{
    public class ButtonEventHandler : SimpleEventHandler, INotifyPropertyChanged
    {
        private Func<bool> _setterEnableProperty;

        //ctor
        public ButtonEventHandler(Action handlerExecutor) : this(handlerExecutor, null)
        {
        }
        public ButtonEventHandler(Action handlerExecutor, Func<bool> setterEnableProperty) : base(handlerExecutor)
        {
            if (setterEnableProperty == null)
            {
                _setterEnableProperty = () => true;
            }
            else
            {
                _setterEnableProperty = setterEnableProperty;
            }
        }


        /// <summary>
        /// Доступность кнопки для нажатия
        /// </summary>
        private bool _Enabled = true;
        public bool Enabled
        {
            get => _Enabled;
            private set
            {
                _Enabled = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Инициализация проверки доступности кнопки
        /// </summary>
        public void CheckEnabled()
        {
            Enabled = _setterEnableProperty();
        }


        //INPC
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
