using ConsoleAppFlights1.Data;
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
        //ссылка на контекст данных
        private IDataContext _data;
        //список всех возможных вариантов меню с ключами
        private Dictionary<string, MenuItem[]> _menus;

        //текущий заголовок в окне
        public MenuHeader CurrentMenuHeader { get; private set; }
        //текущие пункты меню в окне
        public IEnumerable<MenuItem> CurrentMenuItems { get; private set; }

        //ctor
        public MenuService(IDataContext data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            //загружаем варианты меню
            SetMenus();
            //ставим начальный заголовок
            CurrentMenuHeader = GetMenuHeader("start");
            //загружаем начальный список пунктов меню
            CurrentMenuItems = GetMenuItems("start");

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
                    MenuItem.CreateCommon("города", new DestinationsCommand(_data)),
                    MenuItem.CreateCommon("куда", new DestinationFlightsCommand(_data)),
                    MenuItem.CreateTransition("новый", () =>
                    {
                        CurrentMenuItems = GetMenuItems("new");
                        CurrentMenuHeader = GetMenuHeader("new");
                    }),
                    MenuItem.CreateTerminal("выход"),
                },
                ["new"] = new MenuItem[]
                {
                    MenuItem.CreateCommon("самолет", new NewFlightTypeCommand(_data, () =>
                    {
                        CurrentMenuItems = GetMenuItems("newSeats");
                        CurrentMenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateTransition("назад", () =>
                    {
                        CurrentMenuItems = GetMenuItems("start");
                        CurrentMenuHeader = GetMenuHeader("start");
                    }),
                },
                ["newSeats"] = new MenuItem[]
                {
                    MenuItem.CreateCommon("места", new NewFlightSeatsCommand(_data, () =>
                    {
                        CurrentMenuItems = GetMenuItems("newOthers");
                        CurrentMenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateTransition("назад", () =>
                    {
                        CurrentMenuItems = GetMenuItems("new");
                        CurrentMenuHeader = GetMenuHeader("new");
                    }),
                },
                ["newOthers"] = new MenuItem[]
                {
                    MenuItem.CreateCommon("номер", new NewFlightNumberCommand(_data, () =>
                    {
                        CurrentMenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateCommon("город", new NewFlightDestinationCommand(_data, () =>
                    {
                        CurrentMenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateCommon("сохранить", new NewFlightSaveCommand(_data, () =>
                    {
                        CurrentMenuItems = GetMenuItems("start");
                        CurrentMenuHeader = GetMenuHeader("start");
                    })),
                    MenuItem.CreateTransition("назад", () =>
                    {
                        CurrentMenuItems = GetMenuItems("start");
                        CurrentMenuHeader = GetMenuHeader("start");
                    }),
                },
            };
        }

        /// <summary>
        /// Получение необходимого списка пунктов меню по ключу
        /// </summary>
        /// <param name="key">ключ необходимой коллекции MenuItems</param>
        /// <returns></returns>
        private IEnumerable<MenuItem> GetMenuItems(string key)
        {
            if (String.IsNullOrEmpty(key)) throw new ArgumentException(nameof(key));
            return _menus[key];
        }

        /// <summary>
        /// Получение заголовка окна
        /// </summary>
        /// <param name="key">ключ необходимого заголовка</param>
        /// <returns></returns>
        private MenuHeader GetMenuHeader(string key)
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
                    result.ScreenInfo = _data.GetFlight().ToString();
                    return result;
                default:
                    return result;
            }
        }
    }
}
