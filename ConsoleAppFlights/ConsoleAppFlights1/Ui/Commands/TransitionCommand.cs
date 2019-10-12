using System;

namespace ConsoleAppFlights1.Ui.Commands
{
    class TransitionCommand : Command
    {
        private readonly Action _action;

        //ctor
        public TransitionCommand(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public override void Execute()
        {
            _action();
        }
    }
}
