using ConsoleAppFlights1.Data;
using System;

namespace ConsoleAppFlights1.Ui.Commands
{
    class DestinationsCommand : Command
    {
        private readonly DataContext _data;

        //ctor
        public DestinationsCommand(DataContext data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Возможные направления полета:");
            Console.WriteLine("-----------------------------");

            _data.GetListDestinations().ForEach(Console.WriteLine);

            Console.WriteLine("-----------------------------");
        }
    }
}
