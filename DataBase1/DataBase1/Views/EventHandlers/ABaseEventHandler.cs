using System;

/// <summary>
/// Базовый класс для свойств во View для обработчиков событий
/// </summary>

namespace DataBase1.Views.EventHandlers
{
    public abstract class ABaseEventHandler
    {
        protected Action _handlerExecutor;

        //ctor
        public ABaseEventHandler(Action handlerExecutor)
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
        protected virtual void OnEvent(object sender, EventArgs e)
        {
            _handlerExecutor();
        }
    }
}
