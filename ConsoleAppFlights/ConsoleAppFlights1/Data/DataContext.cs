using ConsoleAppFlights1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppFlights1.Data
{
    /// <summary>
    /// Контекст данных программы
    /// </summary>
    class DataContext
    {
        //список рейсов
        private List<Flight> _flights;
        //редактируемый рейс
        private Flight _flight;

        //ctor
        public DataContext()
        {
            _flights = new List<Flight>
            {
                new Flight("Sukhoi Superjet 100", 98, "A4-304", "Москва"),
                new Flight("Airbus A319", 116, "SU-6315", "Москва"),
                new Flight("Boeing 737-800", 186, "DP-509", "Москва"),
                new Flight("Airbus A319", 116, "SU-6317", "Краснодар"),
                new Flight("Sukhoi Superjet 100", 98, "A4-306", "Краснодар"),
                new Flight("Boeing 737-800", 186, "DP-204", "Сочи"),
                new Flight("Airbus A320-100/200", 192, "5N-6701", "Симферополь"),
                new Flight("EMBRAER EMB 190", 98, "U6-511", "Симферополь"),
                new Flight("Airbus A319", 116, "SU-6895", "Симферополь"),
                new Flight("Airbus A319", 116, "SU-6282", "Владивосток"),
                new Flight("EMBRAER EMB 190", 98, "N4-198", "Владивосток"),
                new Flight("Boeing 777-300",  330, "SU-6281", "Владивосток"),
            };
        }

        /// <summary>
        /// Получение текущего редактируемого рейса
        /// </summary>
        /// <returns></returns>
        internal Flight GetFlight()
        {
            if (_flight == null)
            {
                _flight = new Flight("?", 1, "?", "?");
            }
            return _flight;
        }

        /// <summary>
        /// Поиск рейсов по назначению
        /// </summary>
        /// <param name="destination">город назначения</param>
        /// <returns></returns>
        public List<Flight> GetFlightsByDestination(string destination)
        {
            if (string.IsNullOrEmpty(destination))
                throw new ArgumentException(nameof(destination));

            return _flights.Where(f => f.Destination.Equals(destination))
                           .ToList();
        }

        /// <summary>
        /// Вывод списка доступных городов (назначения)
        /// </summary>
        /// <returns></returns>
        public List<string> GetListDestinations()
        {
            return _flights.Select(f => f.Destination)
                           .Distinct()
                           .ToList();
        }

        /// <summary>
        /// Создание нового рейса, ввод типа
        /// </summary>
        /// <param name="type"></param>
        public void SetTypeFlight(string type)
        {
            if (String.IsNullOrEmpty(type)) throw new ArgumentNullException(nameof(type));
            if (_flight == null) throw new ArgumentNullException(nameof(_flight));

            _flight.Type = type;
        }

        /// <summary>
        /// Создание нового рейса, ввод посадочных мест
        /// </summary>
        /// <param name="seats"></param>
        internal void SetSeatsFlight(int seats)
        {
            if (seats <= 0) throw new ArgumentException(nameof(seats));
            if (_flight == null) throw new ArgumentNullException(nameof(_flight));

            _flight.Seats = seats;
        }

        /// <summary>
        /// Создание нового рейса, ввод номера рейса
        /// </summary>
        /// <param name="number"></param>
        internal void SetNumberFlight(string number)
        {
            if (String.IsNullOrEmpty(number)) throw new ArgumentNullException(nameof(number));
            if (_flight == null) throw new ArgumentNullException(nameof(_flight));

            _flight.Number = number;
        }

        /// <summary>
        /// Создание нового рейса, ввод пункта назначения
        /// </summary>
        /// <param name="dest"></param>
        internal void SetDestinationFlight(string dest)
        {
            if (String.IsNullOrEmpty(dest)) throw new ArgumentNullException(nameof(dest));
            if (_flight == null) throw new ArgumentNullException(nameof(_flight));

            _flight.Destination = dest;
        }


        /// <summary>
        /// Проверка нового рейса, что все данные введены
        /// </summary>
        /// <returns></returns>
        internal bool IsFlightCorrect()
        {
            return _flight != null &&
                !String.IsNullOrEmpty(_flight.Type) &&
                !String.IsNullOrEmpty(_flight.Number) &&
                !String.IsNullOrEmpty(_flight.Destination) &&
                _flight.Seats > 0;
        }

        /// <summary>
        /// Сохранение нового рейса
        /// </summary>
        internal void SaveFlight()
        {
            if (_flight == null) throw new ArgumentNullException(nameof(_flight));

            _flights.Add(_flight);
            _flight = null;
        }
    }
}
