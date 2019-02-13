using System;
using System.ComponentModel;

namespace WindowsFormsApp1.Models
{
    public enum NumberStatesType
    {
        WaitingCall, //ожидает набора на него
        Calling, //происходит звонок и соединение с этим номером
        Called //этот номер обзвонен
    }

    public class PhoneNumber : INotifyPropertyChanged
    {
        //ctor
        public PhoneNumber(string number)
        {
            if (String.IsNullOrEmpty(number)) throw new ArgumentException(nameof(number));

            Number = number;
            OutputNumber = Number;
            State = NumberStatesType.WaitingCall;
        }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// Отображаемое в списке номеров
        /// </summary>
        private string _OutputNumber;
        public string OutputNumber
        {
            get => _OutputNumber;
            set
            {
                _OutputNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OutputNumber)));
            }
        }

        /// <summary>
        /// Состояние номера
        /// </summary>
        public NumberStatesType State { get; private set; }

        /// <summary>
        /// Событие изменения номера
        /// </summary>
        public event EventHandler<PhoneNumberStateChangedEventArgs> NumberStateChanged;

        //INPC
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Изменение состояние номера
        /// </summary>
        /// <param name="stateChangedEventArgs"></param>
        public void ChangeNumberState(PhoneNumberStateChangedEventArgs stateChangedEventArgs)
        {
            if (stateChangedEventArgs == null)
                throw new ArgumentNullException(nameof(stateChangedEventArgs));

            //изменяем состояние
            this.State = stateChangedEventArgs.NewState;
            //вызываем событие
            NumberStateChanged?.Invoke(this, stateChangedEventArgs);
        }
    }
}
