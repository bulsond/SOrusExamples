using ConsoleAppFlights2.Data;
using ConsoleAppFlights2.Ui;

namespace ConsoleAppFlights2
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new UserInterface(new DataContext());

            while (ui.ReadCommand())
            {
                ui.ExecuteCommand();
            }
        }
    }
}
