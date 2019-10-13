using ConsoleAppFlights2.Data;
using System;

namespace ConsoleAppFlights2.Ui.Commands
{
    class DestinationsCommand : Command
    {
        private readonly IDataContext _data;

        //ctor
        public DestinationsCommand(IDataContext data)
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
