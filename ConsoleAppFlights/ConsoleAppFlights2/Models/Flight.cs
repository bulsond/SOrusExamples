using System;

namespace ConsoleAppFlights2.Models
{
    class Flight : Plane
    {
        public string Number { get; set; }
        public string Destination { get; set; }

        //ctor
        public Flight(string type, int seats, string number, string destination)
            : base(type, seats)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentException(nameof(number));
            if (string.IsNullOrEmpty(destination))
                throw new ArgumentException(nameof(destination));

            Number = number;
            Destination = destination;
        }

        public override string ToString()
        {
            return base.ToString() + $"; Рейс: {Number}, пункт назначения: {Destination}";
        }
    }
}
