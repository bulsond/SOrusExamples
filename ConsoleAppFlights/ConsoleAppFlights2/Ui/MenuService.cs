using ConsoleAppFlights2.Data;
using ConsoleAppFlights2.Ui.Commands;
using System;
using System.Collections.Generic;

namespace ConsoleAppFlights2.Ui
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
                    MenuItem.CreateCommon("1) Пункты назначения", '1', new DestinationsCommand(_data)),
                    MenuItem.CreateCommon("2) Рейсы в пункт назначения", '2', new DestinationFlightsCommand(_data)),
                    MenuItem.CreateTransition("3) Создать новый рейс", '3', () =>
                    {
                        CurrentMenuItems = GetMenuItems("new");
                        CurrentMenuHeader = GetMenuHeader("new");
                    }),
                    MenuItem.CreateTerminal("4) Выход из программы", '4'),
                },
                ["new"] = new MenuItem[]
                {
                    MenuItem.CreateCommon("1) Тип самолёта", '1', new NewFlightTypeCommand(_data, () =>
                    {
                        CurrentMenuItems = GetMenuItems("newSeats");
                        CurrentMenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateTransition("2) Назад в главное меню", '2', () =>
                    {
                        CurrentMenuItems = GetMenuItems("start");
                        CurrentMenuHeader = GetMenuHeader("start");
                    }),
                },
                ["newSeats"] = new MenuItem[]
                {
                    MenuItem.CreateCommon("1) Количество посадочных мест", '1', new NewFlightSeatsCommand(_data, () =>
                    {
                        CurrentMenuItems = GetMenuItems("newOthers");
                        CurrentMenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateTransition("2) Назад к типу самолета", '2', () =>
                    {
                        CurrentMenuItems = GetMenuItems("new");
                        CurrentMenuHeader = GetMenuHeader("new");
                    }),
                },
                ["newOthers"] = new MenuItem[]
                {
                    MenuItem.CreateCommon("1) Номер рейса", '1', new NewFlightNumberCommand(_data, () =>
                    {
                        CurrentMenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateCommon("2) Пункт назначения", '2', new NewFlightDestinationCommand(_data, () =>
                    {
                        CurrentMenuHeader = GetMenuHeader("new");
                    })),
                    MenuItem.CreateCommon("3) Сохранить рейс", '3', new NewFlightSaveCommand(_data, () =>
                    {
                        CurrentMenuItems = GetMenuItems("start");
                        CurrentMenuHeader = GetMenuHeader("start");
                    })),
                    MenuItem.CreateTransition("4) Назад в главное меню", '4', () =>
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
