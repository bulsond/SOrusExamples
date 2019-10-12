using ConsoleAppFlights1.Ui.Commands;
using System;

namespace ConsoleAppFlights1.Ui
{
    /// <summary>
    /// Пункт меню
    /// </summary>
    class MenuItem
    {
        /// <summary>
        /// Название пункта меню
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// Флаг выходного пункта меню
        /// </summary>
        public bool IsTerminal { get; private set; }
        /// <summary>
        /// Команда с кот. связан этот пункт меню
        /// </summary>
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

        /// <summary>
        /// Создание пункта меню для выхода из программы
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static MenuItem CreateTerminal(string title)
        {
            return new MenuItem(title, true, new DoNothingCommand());
        }

        /// <summary>
        /// Создание пункта меню
        /// </summary>
        /// <param name="title"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static MenuItem CreateCommon(string title, Command command)
        {
            return new MenuItem(title, false, command);
        }

        /// <summary>
        /// Создание пункта меню для перехода к др. экрану меню
        /// </summary>
        /// <param name="title"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static MenuItem CreateTransition(string title, Action action)
        {
            return new MenuItem(title, false, new TransitionCommand(action));
        }

        /// <summary>
        /// Отображение названия пункта меню
        /// </summary>
        internal void Display()
        {
            Console.WriteLine(Title);
        }
    }
}
