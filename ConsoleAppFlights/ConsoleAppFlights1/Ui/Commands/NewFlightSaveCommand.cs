using ConsoleAppFlights1.Data;
using System;

namespace ConsoleAppFlights1.Ui.Commands
{
    class NewFlightSaveCommand : Command
    {
        private readonly IDataContext _data;
        private readonly Action _action;

        public NewFlightSaveCommand(IDataContext data, Action action)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public override void Execute()
        {
            //проверяем заполнение всех данных по рейсу
            if (!_data.IsFlightCorrect())
            {
                Console.WriteLine("Не все данные по рейсу введены, сохранение невозможно!");
                return;
            }

            Console.WriteLine(_data.GetFlight().ToString());

            var hasError = true;
            string answ = String.Empty;
            do
            {
                Console.Write("Сохранить, да/нет: ");

                answ = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(answ) && (answ.Equals("да") || answ.Equals("нет")))
                {
                    hasError = false;
                }
                else
                {
                    Console.WriteLine("Варианты ответа, да или нет!");
                }

            } while (hasError);

            if (answ.Equals("да"))
            {

                _data.SaveFlight();
                Console.WriteLine($"Рейс сохранен.");

                _action();
                return;
            }

            Console.WriteLine("Сохранение рейса отменено.");
        }
    }
}
