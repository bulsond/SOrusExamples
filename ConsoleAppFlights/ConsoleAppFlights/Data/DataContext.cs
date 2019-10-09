using ConsoleAppFlights.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppFlights.Data
{
    class DataContext
    {
        private List<Flight> _flights;

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
    }
}
