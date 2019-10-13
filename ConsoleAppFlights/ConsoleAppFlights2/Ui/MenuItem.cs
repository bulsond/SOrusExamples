using ConsoleAppFlights2.Ui.Commands;
using System;

namespace ConsoleAppFlights2.Ui
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
        /// <summary>
        /// Знак кот. относится к этому пункту меню
        /// </summary>
        public char HotKey { get; private set; }

        //ctor
        public MenuItem(string title, char hotkey, bool isTerminal, Command command)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException(nameof(title));

            Title = title;
            HotKey = hotkey;
            IsTerminal = isTerminal;
            Command = command ?? throw new ArgumentNullException(nameof(command));
        }

        /// <summary>
        /// Создание пункта меню для выхода из программы
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static MenuItem CreateTerminal(string title, char hotkey)
        {
            return new MenuItem(title, hotkey, true, new DoNothingCommand());
        }

        /// <summary>
        /// Создание пункта меню
        /// </summary>
        /// <param name="title"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static MenuItem CreateCommon(string title, char hotkey, Command command)
        {
            return new MenuItem(title, hotkey, false, command);
        }

        /// <summary>
        /// Создание пункта меню для перехода к др. экрану меню
        /// </summary>
        /// <param name="title"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static MenuItem CreateTransition(string title, char hotkey, Action action)
        {
            return new MenuItem(title, hotkey, false, new TransitionCommand(action));
        }

        /// <summary>
        /// Отображение названия пункта меню
        /// </summary>
        public void Display()
        {
            int pos = Title.IndexOf(HotKey);

            if (pos > 0)
                Console.Write(Title.Substring(0, pos));

            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(HotKey);
            Console.ForegroundColor = previousColor;

            if (pos < Title.Length - 1)
                Console.Write(Title.Substring(pos + 1));

            Console.WriteLine();
        }

        /// <summary>
        /// Проверка соответствия знаку этого пункта меню
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool MatchesKey(char key)
        {
            return char.ToLower(HotKey) == char.ToLower(key);
        }
    }
}
