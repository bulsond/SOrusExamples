using ConsoleAppFlights2.Data;
using System;

namespace ConsoleAppFlights2.Ui.Commands
{
    class NewFlightNumberCommand : Command
    {
        private readonly IDataContext _data;
        private readonly Action _action;

        public NewFlightNumberCommand(IDataContext data, Action action)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public override void Execute()
        {
            var hasError = true;
            string number = String.Empty;
            do
            {
                Console.Write("Номер рейса: ");

                number = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(number) && number.Length > 2)
                {
                    hasError = false;
                }
                else
                {
                    Console.WriteLine("Номер рейса должен быть больше двух знаков!");
                }

            } while (hasError);

            _data.SetNumberFlight(number);
            Console.WriteLine($"Номер рейса {number} сохранен.");

            _action();
        }
    }
}
