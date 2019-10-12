using ConsoleAppFlights1.Ui.Commands;
using System;
using System.Collections.Generic;

namespace ConsoleAppFlights1.Ui
{
    /// <summary>
    /// Поставшик экранов меню (коллекций пунктов меню)
    /// </summary>
    class MenuService
    {
        //ссылка на наружный класс UI
        private readonly UserInterface _uI;
        //список всех возможных вариантов меню с ключами
        private Dictionary<string, MenuItem[]> _menus;

        //ctor
        public MenuService(UserInterface userInterface)
        {
            _uI = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
            SetMenus();
        }

        /// <summary>
        /// Формирование списка меню с ключами
        /// </summary>
        private void SetMenus()
        {
            _menus = new Dictionary<string, MenuItem[]>
            {
                ["start"] = new MenuItem[]
                {
                    MenuItem.CreateCommon("города", new DestinationsCommand(_uI.Data)),
                    MenuItem.CreateCommon("куда", new DestinationFlightsCommand(_uI.Data)),
                    MenuItem.CreateTransition("новый", () =>
                    {
                        _uI.MenuItems = GetMenuItems("new");
                        _uI.MenuHeader = GetMenuHeader("new");
                    }),
                    MenuItem.CreateTerminal("выход"),
                },
                ["new"] = new MenuItem[]
                {
                    MenuItem.CreateCommon("самолет", new NewFlightTypeCommand(_uI.Data, () =>
                    {
                        _uI.MenuItems = GetMenuItems("newSeats");
                        _uI.MenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateTransition("назад", () =>
                    {
                        _uI.MenuItems = GetMenuItems("start");
                        _uI.MenuHeader = GetMenuHeader("start");
                    }),
                },
                ["newSeats"] = new MenuItem[]
                {
                    MenuItem.CreateCommon("места", new NewFlightSeatsCommand(_uI.Data, () =>
                    {
                        _uI.MenuItems = GetMenuItems("newOthers");
                        _uI.MenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateTransition("назад", () =>
                    {
                        _uI.MenuItems = GetMenuItems("new");
                        _uI.MenuHeader = GetMenuHeader("new");
                    }),
                },
                ["newOthers"] = new MenuItem[]
                {
                    MenuItem.CreateCommon("номер", new NewFlightNumberCommand(_uI.Data, () =>
                    {
                        _uI.MenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateCommon("город", new NewFlightDestinationCommand(_uI.Data, () =>
                    {
                        _uI.MenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateCommon("сохранить", new NewFlightSaveCommand(_uI.Data, () =>
                    {
                        _uI.MenuItems = GetMenuItems("start");
                        _uI.MenuHeader = GetMenuHeader("start");
                    })),
                    MenuItem.CreateTransition("назад", () =>
                    {
                        _uI.MenuItems = GetMenuItems("start");
                        _uI.MenuHeader = GetMenuHeader("start");
                    }),
                },
            };
        }

        /// <summary>
        /// Получение необходимого списка пунктов меню по ключу
        /// </summary>
        /// <param name="key">ключ необходимой коллекции MenuItems</param>
        /// <returns></returns>
        public IEnumerable<MenuItem> GetMenuItems(string key)
        {
            if (String.IsNullOrEmpty(key)) throw new ArgumentException(nameof(key));
            return _menus[key];
        }

        /// <summary>
        /// Получение заголовка окна
        /// </summary>
        /// <param name="key">ключ необходимого заголовка</param>
        /// <returns></returns>
        public MenuHeader GetMenuHeader(string key)
        {
            if (String.IsNullOrEmpty(key)) throw new ArgumentException(nameof(key));

            var result = new MenuHeader();

            switch (key)
            {
                case "start":
                    result.ScreenTitle = "Главное меню";
                    result.ScreenInfo = String.Empty;
                    return result;
                case "new":
                    result.ScreenTitle = "Меню новый рейс";
                    result.ScreenInfo = _uI.Data.GetFlight().ToString();
                    return result;
                default:
                    return result;
            }
        }
    }
}
