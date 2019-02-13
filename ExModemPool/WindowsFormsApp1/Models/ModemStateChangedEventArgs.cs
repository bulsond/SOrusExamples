using System;

namespace WindowsFormsApp1.Models
{
    public class ModemStateChangedEventArgs : EventArgs
    {
        //ctor
        public ModemStateChangedEventArgs(string message,
            ModemStatesType oldState, ModemStatesType newState)
        {
            Message = message;
            OldState = oldState;
            NewState = newState;
        }

        public string Message { get; private set; }
        public ModemStatesType OldState { get; private set; }
        public ModemStatesType NewState { get; private set; }
    }
}
