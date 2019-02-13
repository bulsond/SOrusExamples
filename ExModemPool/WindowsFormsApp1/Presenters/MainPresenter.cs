using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp1.Abstractions;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Presenters.EventHandlers;

namespace WindowsFormsApp1.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private bool _isCalling = false;

        public IAppController Controller { get; private set; }
        public IMainView View { get; private set; }

        //ctor
        public MainPresenter(IAppController controller, IMainView view)
        {
            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
            View = view ?? throw new ArgumentNullException(nameof(view));

            View.StartCalling = new ButtonEventHandler(OnStartCalling, CanStartCalling);
            View.CancelCalling = new ButtonEventHandler(OnCancelCalling, CanCancelCalling);

            //подгружаем данные
            LoadData();
        }

        private void LoadData()
        {
            View.Modems = Controller.DataContext.GetModems();
            View.PhoneNumbers = Controller.DataContext.GetPhoneNumbers();

            View.AddLogRecord($"В работе всего модемов: {View.Modems.Count}");
            View.AddLogRecord($"Всего телефонных номеров: {View.PhoneNumbers.Count}");
        }

        /// <summary>
        /// Доступность Кнопки отмены обзвона
        /// </summary>
        /// <returns></returns>
        private bool CanCancelCalling()
        {
            return _isCalling;
        }

        /// <summary>
        /// Кнопка отмены обзвона
        /// </summary>
        private void OnCancelCalling()
        {
            _isCalling = false;
            View.CancelCalling.CheckEnabled();
        }

        /// <summary>
        /// Доступность кнопки запуска обзвона
        /// </summary>
        /// <returns></returns>
        private bool CanStartCalling()
        {
            return !_isCalling;
        }

        /// <summary>
        /// Кнопка запуска обзвона
        /// </summary>
        private async void OnStartCalling()
        {
            //флаг обзвона
            _isCalling = true;
            //кнопки
            View.CancelCalling.CheckEnabled();
            View.StartCalling.CheckEnabled();

            //подписка на события
            SubscribeToEventsInModemAndNumbers();

            //пока есть в коллекции необзвоненные телефоны
            while (View.PhoneNumbers.Any(n => n.State != NumberStatesType.Called))
            {
                //проверяем флаг обзвона
                if (!_isCalling)
                {
                    View.AddLogRecord("Обзвон прерван!");
                    break;
                }

                //создаем для каждого модема задачу обзвона
                var tasks = new List<Task>();
                foreach (var modem in View.Modems)
                {
                    tasks.Add(Calling(modem));
                }
                //ждем завершения всех задач обзвона
                await Task.WhenAll(tasks);
            }

            //отписка от событий
            UnsubscribeToEventsInModemAndNumbers();

            //если обзвон не был отменен, значит он закончен
            if (_isCalling)
            {
                View.AddLogRecord("Обзвон закончен!");
                _isCalling = false;
            }

            //кнопки
            View.CancelCalling.CheckEnabled();
            View.StartCalling.CheckEnabled();
        }

        /// <summary>
        /// Звонок по номеру через выбранный модем
        /// </summary>
        /// <param name="modem"></param>
        /// <returns></returns>
        private async Task Calling(Modem modem)
        {
            //находим свободный номер
            var number = View.PhoneNumbers.FirstOrDefault(n => n.State == NumberStatesType.WaitingCall);
            if (number == null) return;

            //звоним на номер
            await modem.CallNumberAsync(number);
        }

        /// <summary>
        /// Подписка на события от модемов и номеров
        /// </summary>
        private void SubscribeToEventsInModemAndNumbers()
        {
            //подписываемся на события модемов
            foreach (var modem in View.Modems)
            {
                modem.ModemStateChanged += Modem_ModemStateChanged;
            }

            //подписываемся на события номеров
            foreach (var number in View.PhoneNumbers)
            {
                number.NumberStateChanged += Number_NumberStateChanged;
            }
        }

        /// <summary>
        /// Отписка от событий от модемов и номеров
        /// </summary>
        private void UnsubscribeToEventsInModemAndNumbers()
        {
            //отписываемся на события модемов
            foreach (var modem in View.Modems)
            {
                modem.ModemStateChanged -= Modem_ModemStateChanged;
            }

            //отписываемся на события номеров
            foreach (var number in View.PhoneNumbers)
            {
                number.NumberStateChanged -= Number_NumberStateChanged;
            }
        }

        /// <summary>
        /// Обработчик события изменения состояния у номера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Number_NumberStateChanged(object sender, PhoneNumberStateChangedEventArgs e)
        {
            var number = sender as PhoneNumber;
            //отображаем в списке номеров состояние этого номера
            View.ChangeNumberOutput(number, e);
        }

        /// <summary>
        /// Обработчик события изменения состояния у модема
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modem_ModemStateChanged(object sender, ModemStateChangedEventArgs e)
        {
            //пишем в лог
            View.AddLogRecord(e.Message);
        }

    }
}
