using ConsoleAppFlights2.Data;
using ConsoleAppFlights2.Ui.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppFlights2.Ui
{
    /// <summary>
    /// Интерфейс программы
    /// </summary>
    class UserInterface
    {
        //контекс данных программы
        private IDataContext _data;
        //команда из выбранного пункта меню
        private Command _command;
        //ссылка на сервис меню
        private readonly MenuService _menuService;

        //заголовок отображемого окна
        private MenuHeader MenuHeader => _menuService.CurrentMenuHeader;
        //список пунктов меню
        private IEnumerable<MenuItem> MenuItems => _menuService.CurrentMenuItems;

        //ctor
        public UserInterface(IDataContext data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _menuService = new MenuService(_data);

            //заголовок
            Console.Title = "Программа Рейсы";
        }

        /// <summary>
        /// Отображение меню, выбор пункта меню
        /// </summary>
        /// <returns></returns>
        public bool ReadCommand()
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

            Console.WriteLine("---------------------------------");

            //проходим по списку и отображаем все пункты меню
            foreach (MenuItem menuItem in MenuItems)
                menuItem.Display();

            Console.WriteLine();
            Console.WriteLine("Введите номер нужного пункта меню.");
            Console.WriteLine("---------------------------------");
        }

        /// <summary>
        /// Получение польз.ввода и выбор пункта меню
        /// </summary>
        /// <returns></returns>
        private MenuItem SelectMenuItem()
        {
            //ждем польз. ввод
            ConsoleKeyInfo key = Console.ReadKey(true);
            //пытаем найти нужный пункт меню
            return MenuItems.SingleOrDefault(item => item.MatchesKey(key.KeyChar));
        }

        /// <summary>
        /// Выполнение команды из выбранного пункта меню
        /// </summary>
        public void ExecuteCommand()
        {
            //если пользователь ошибся с командой в меню
            if (_command is DoNothingCommand)
            {
                Console.WriteLine("Неверный номер пункта меню!");
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
