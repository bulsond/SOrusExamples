using ConsoleAppFlights1.Data;
using System;

namespace ConsoleAppFlights1.Ui.Commands
{
    class NewFlightTypeCommand : Command
    {
        private readonly IDataContext _data;
        private readonly Action _action;

        public NewFlightTypeCommand(IDataContext data, Action action)
        {
            _data = data ?? throw new ArgumentException(nameof(data));
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public override void Execute()
        {
            bool hasError = true;
            string input = String.Empty;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(_data.GetFlight());
                Console.WriteLine();
                Console.Write("Введите тип самолета: ");
                input = Console.ReadLine();
                if (input.Length > 3) hasError = false;

            } while (hasError);

            //запоминаем данные
            _data.SetTypeFlight(input);

            //выполняе переход к след.меню
            _action();
        }
    }
}
