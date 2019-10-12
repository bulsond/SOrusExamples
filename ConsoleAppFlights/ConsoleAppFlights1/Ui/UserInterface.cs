using ConsoleAppFlights1.Data;
using ConsoleAppFlights1.Ui.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppFlights1.Ui
{
    /// <summary>
    /// Интерфейс программы
    /// </summary>
    class UserInterface
    {
        //команда из выбранного пункта меню
        private Command _command;
        //ссылка на сервис меню
        private readonly MenuService _menuService;

        //контекс данных программы
        public DataContext Data { get; private set; }
        //заголовок
        public MenuHeader MenuHeader { get; set; }
        //текущий список пунктов меню
        public IEnumerable<MenuItem> MenuItems { get; set; }

        //ctor
        public UserInterface(DataContext data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
            _menuService = new MenuService(this);

            //заголовок
            Console.Title = "Программа Рейсы";
            MenuHeader = _menuService.GetMenuHeader("start");
            //получаем начальный список пунктов меню
            MenuItems = _menuService.GetMenuItems("start");
        }

        /// <summary>
        /// Отображение меню, выбор пункта меню
        /// </summary>
        /// <returns></returns>
        internal bool ReadCommand()
        {
            //отображаем меню
            ShowMenu();

            //получаем польз. ввод
            MenuItem selectedMenuItem = SelectMenuItem();
            //если пользователь ошибся с меню
            if (selectedMenuItem == null)
            {
                _command = new DoNothingCommand();
                return true;
            }

            //если выход
            if (selectedMenuItem.IsTerminal)
                return false;

            //если выбран пункт меню
            _command = selectedMenuItem.Command;
            return true;
        }

        /// <summary>
        /// Отображение списка меню
        /// </summary>
        private void ShowMenu()
        {
            Console.Clear();
            if (!String.IsNullOrEmpty(MenuHeader.ScreenTitle))
            {
                Console.WriteLine(MenuHeader.ScreenTitle);
            }
            if (!String.IsNullOrEmpty(MenuHeader.ScreenInfo))
            {
                Console.WriteLine(MenuHeader.ScreenInfo);
            }

            Console.WriteLine("-----------");

            //проходим по списку и отображаем все пункты меню
            foreach (MenuItem menuItem in MenuItems)
                menuItem.Display();

            Console.WriteLine("-----------");
            Console.WriteLine();
            Console.Write("Наберите нужную команду: ");
        }

        /// <summary>
        /// Получение польз.ввода и выбор пункта меню
        /// </summary>
        /// <returns></returns>
        private MenuItem SelectMenuItem()
        {
            //ждем польз. ввод
            string input = Console.ReadLine();
            //пытаем найти нужный пункт меню
            return MenuItems.SingleOrDefault(m => m.Title.Equals(input));
        }

        /// <summary>
        /// Выполнение команды из выбранного пункта меню
        /// </summary>
        internal void ExecuteCommand()
        {
            //если пользователь ошибся с командой в меню
            if (_command is DoNothingCommand)
            {
                Console.WriteLine("Неверная команда!");
            }
            else if (_command is TransitionCommand)
            {
                //случай перехода к след.меню
                _command.Execute();
                return;
            }
            else
            {
                //иначе выполняем команду
                _command.Execute();
            }

            Console.WriteLine();
            Console.Write("Нажмите ВВОД для продолжения...");
            Console.ReadLine();
        }
    }
}
