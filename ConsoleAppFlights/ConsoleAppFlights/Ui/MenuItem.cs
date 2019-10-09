using ConsoleAppFlights.Ui.Commands;
using System;

namespace ConsoleAppFlights.Ui
{
    class MenuItem
    {
        public string Title { get; private set; }
        public bool IsTerminal { get; private set; }
        public Command Command { get; private set; }

        //ctor
        public MenuItem(string title, bool isTerminal, Command command)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException(nameof(title));

            Title = title;
            IsTerminal = isTerminal;
            Command = command ?? throw new ArgumentNullException(nameof(command));
        }

        public static MenuItem CreateTerminal(string title)
        {
            return new MenuItem(title, true, new DoNothingCommand());
        }

        public static MenuItem CreateCommon(string title, Command command)
        {
            return new MenuItem(title, false, command);
        }

        internal void Display()
        {
            Console.WriteLine(Title);
        }
    }   
}
