using ConsoleAppFlights1.Data;
using System;

namespace ConsoleAppFlights1.Ui.Commands
{
    class NewFlightSeatsCommand : Command
    {
        private readonly IDataContext _data;
        private readonly Action _action;

        public NewFlightSeatsCommand(IDataContext data, Action action)
        {
            _data = data ?? throw new ArgumentException(nameof(data));
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public override void Execute()
        {
            bool hasError = true;
            string input = String.Empty;
            int seats = 0;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(_data.GetFlight());
                Console.WriteLine();
                Console.Write("Введите количество посадочных мест в самолете: ");

                input = Console.ReadLine();
                hasError = !int.TryParse(input, out seats);
                if (seats <= 0) hasError = true;
            } while (hasError);

            //запоминаем данные
            _data.SetSeatsFlight(seats);

            //выполняе переход к след.меню
            _action();
        }
    }
}
