using ConsoleAppFlights1.Data;
using System;

namespace ConsoleAppFlights1.Ui.Commands
{
    class NewFlightDestinationCommand : Command
    {
        private readonly IDataContext _data;
        private readonly Action _action;

        public NewFlightDestinationCommand(IDataContext data, Action action)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public override void Execute()
        {
            var hasError = true;
            string dest = String.Empty;
            do
            {
                Console.Write("Пункт назначения (город): ");

                dest = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(dest) && dest.Length > 3)
                {
                    hasError = false;
                }
                else
                {
                    Console.WriteLine("Пункт назначения больше трех знаков!");
                }

            } while (hasError);

            _data.SetDestinationFlight(dest);
            Console.WriteLine($"Пункт назначения {dest} сохранен.");

            _action();
        }
    }
}
