using ConsoleAppFlights1.Data;
using System;

namespace ConsoleAppFlights1.Ui.Commands
{
    class DestinationFlightsCommand : Command
    {
        private readonly IDataContext _data;

        //ctor
        public DestinationFlightsCommand(IDataContext data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("Введите город назначения: ");

            var input = Console.ReadLine();
            var flights = _data.GetFlightsByDestination(input);

            if (flights.Count == 0)
            {
                Console.WriteLine("Извините, на данное направление рейсов нет!");
                return;
            }

            Console.WriteLine("Возможные варианты рейсов:");
            Console.WriteLine("-----------------------------");

            flights.ForEach(Console.WriteLine);

            Console.WriteLine("-----------------------------");
        }
    }
}
