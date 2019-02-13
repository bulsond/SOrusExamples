using System;

namespace WindowsFormsApp1.Models
{
    public class PhoneNumberStateChangedEventArgs : EventArgs
    {
        //ctor
        public PhoneNumberStateChangedEventArgs(string message,
            NumberStatesType oldState, NumberStatesType newState)
        {
            Message = message;
            OldState = oldState;
            NewState = newState;
        }

        public string Message { get; private set; }
        public NumberStatesType OldState { get; private set; }
        public NumberStatesType NewState { get; private set; }
    }
}
