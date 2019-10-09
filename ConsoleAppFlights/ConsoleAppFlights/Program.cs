using ConsoleAppFlights.Data;
using ConsoleAppFlights.Ui;

namespace ConsoleAppFlights
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface(new DataContext());

            while (ui.ReadCommand())
            {
                ui.ExecuteCommand();
            }
        }
    }
}
