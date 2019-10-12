using System;

namespace ConsoleAppFlights1.Models
{
    class Plane
    {
        public string Type { get; set; }
        public int Seats { get; set; }

        //ctor
        public Plane(string type, int seats)
        {
            if (string.IsNullOrEmpty(type))
                throw new ArgumentException(nameof(type));
            if (seats <= 0)
                throw new ArgumentException(nameof(seats));

            Type = type;
            Seats = seats;
        }

        public override string ToString()
        {
            return $"Самолет: {Type}, посадочных мест: {Seats}";
        }
    }
}
