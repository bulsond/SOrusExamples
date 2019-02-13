using System;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public enum ModemStatesType
    {
        Free, //модем свободен
        Busy, //модем занят
    }

    public class Modem
    {
        //для моделирования работы модема, в реальном прил. не нужно!
        private static Random _random = new Random();
        
        //ctor
        public Modem(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));

            Name = name;
            State = ModemStatesType.Free;
        }

        /// <summary>
        /// Название модема
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Состояние модема
        /// </summary>
        public ModemStatesType State { get; private set; }

        /// <summary>
        /// Событие изменения состояния модема
        /// </summary>
        public event EventHandler<ModemStateChangedEventArgs> ModemStateChanged;

        /// <summary>
        /// Изменение состояния модема
        /// </summary>
        /// <param name="stateChangedEventArgs"></param>
        public void ChangeModemState(ModemStateChangedEventArgs stateChangedEventArgs)
        {
            if (stateChangedEventArgs == null)
                throw new ArgumentNullException(nameof(stateChangedEventArgs));

            //изменяем состояние
            this.State = stateChangedEventArgs.NewState;
            //вызываем событие
            ModemStateChanged?.Invoke(this, stateChangedEventArgs);
        }

        /// <summary>
        /// Звонок модема на необходимый номер
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public async Task CallNumberAsync(PhoneNumber number)
        {
            if (number == null) throw new ArgumentNullException(nameof(number));

            //изменяем статус у номера
            var numberStateArgs =
                new PhoneNumberStateChangedEventArgs($"{number.Number} набирается...",
                number.State, NumberStatesType.Calling);
            number.ChangeNumberState(numberStateArgs);

            //изменяем статус у модема
            var modemStatusArgs =
                new ModemStateChangedEventArgs($"{this.Name} набирает {number.Number}",
                this.State, ModemStatesType.Busy);
            this.ChangeModemState(modemStatusArgs);

            //>>>Начало моделирования работы модема
            //типа набираем номер и ждем ответа
            await Task.Delay(TimeSpan.FromSeconds(1));
            //номер может быть занят
            bool numberIsBusy = _random.Next(10) % 2 == 0 ? true : false;
            if (numberIsBusy)
            {
                //изменяем статус у номера
                numberStateArgs =
                    new PhoneNumberStateChangedEventArgs($"{number.Number} занят!",
                    number.State, NumberStatesType.WaitingCall);
                number.ChangeNumberState(numberStateArgs);

                //изменяем статус у модема
                modemStatusArgs =
                    new ModemStateChangedEventArgs($"{this.Name} номер {number.Number} занят!",
                    this.State, ModemStatesType.Free);
                this.ChangeModemState(modemStatusArgs);

                //выходим
                return;
            }

            //типа соединяемся
            //изменяем статус у номера
            numberStateArgs =
                new PhoneNumberStateChangedEventArgs($"{number.Number} соединение...",
                number.State, NumberStatesType.Calling);
            number.ChangeNumberState(numberStateArgs);

            //изменяем статус у модема
            modemStatusArgs =
                new ModemStateChangedEventArgs($"{this.Name} соединяется по {number.Number}...",
                this.State, ModemStatesType.Busy);
            this.ChangeModemState(modemStatusArgs);

            await Task.Delay(TimeSpan.FromSeconds(1));

            //типа соединились и идет приемо-передача данных
            //изменяем статус у номера
            numberStateArgs =
                new PhoneNumberStateChangedEventArgs($"{number.Number} cоединение установлено.",
                number.State, NumberStatesType.Calling);
            number.ChangeNumberState(numberStateArgs);

            //изменяем статус у модема
            modemStatusArgs =
                new ModemStateChangedEventArgs($"{this.Name} соединение установлено по {number.Number}.",
                this.State, ModemStatesType.Busy);
            this.ChangeModemState(modemStatusArgs);

            await Task.Delay(TimeSpan.FromSeconds(3));

            //типа приемо-передача данных закончена
            //изменяем статус у номера
            numberStateArgs =
                new PhoneNumberStateChangedEventArgs($"{number.Number} обзвонен!",
                number.State, NumberStatesType.Called);
            number.ChangeNumberState(numberStateArgs);

            //изменяем статус у модема
            modemStatusArgs =
                new ModemStateChangedEventArgs($"{this.Name} звонок закончен по {number.Number}.",
                this.State, ModemStatesType.Free);
            this.ChangeModemState(modemStatusArgs);
            //<<<Конец моделирования работы модема
        }

    }
}
