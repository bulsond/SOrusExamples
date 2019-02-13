using System;

namespace WindowsFormsApp1.Presenters.EventHandlers
{
    public class SimpleEventHandler
    {
        private Action _handlerExecutor;

        //ctor
        public SimpleEventHandler(Action handlerExecutor)
        {
            _handlerExecutor = handlerExecutor ??
                throw new ArgumentNullException(nameof(handlerExecutor));

            Handler = new EventHandler(OnEvent);
        }

        /// <summary>
        /// Ссылка на метод,
        /// который буден вызван при возникновении события у целевого контрола 
        /// </summary>
        public EventHandler Handler { get; private set; }

        /// <summary>
        /// Вызов по событию исполняемого метода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEvent(object sender, EventArgs e)
        {
            _handlerExecutor();
        }
    }
}
