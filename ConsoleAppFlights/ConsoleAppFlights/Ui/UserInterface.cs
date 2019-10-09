using ConsoleAppFlights.Data;
using ConsoleAppFlights.Ui.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppFlights.Ui
{
    class UserInterface
    {
        //ссылка на сервис данных
        private readonly DataContext _data;
        //пункты меню
        private IEnumerable<MenuItem> _menuItems;
        //команда из выбранного пункта меню
        private Command _command;

        //ctor
        public UserInterface(DataContext data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));

            //заполняем меню
            _menuItems = new MenuItem[]
            {
                MenuItem.CreateCommon("города", new DestinationsCommand(_data)),
                MenuItem.CreateCommon("куда", new DestinationFlightsCommand(_data)),
                MenuItem.CreateTerminal("выход"),
            };
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
            Console.WriteLine("Наберите нужную команду:");
            Console.WriteLine();

            //проходим по списку и отображаем все пункты меню
            foreach (MenuItem menuItem in _menuItems)
                menuItem.Display();

            Console.WriteLine();
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
            return _menuItems.SingleOrDefault(m => m.Title.Equals(input));
        }

        /// <summary>
        /// Выполнение команды из выбранного пункта меню
        /// </summary>
        internal void ExecuteCommand()
        {
            //если пользователь ошибся с меню
            if (_command is DoNothingCommand)
            {
                Console.WriteLine("Неверная команда!");
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
