using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Abstractions;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Presenters.EventHandlers;

namespace WindowsFormsApp1.Views
{
    public partial class MainView : Form, IMainView
    {
        private BindingSource _bsModems = new BindingSource();
        private BindingSource _bsPhoneNumbers = new BindingSource();
        private BindingSource _bsLogs = new BindingSource();
        private BindingSource _bsStartCalling = new BindingSource();
        private BindingSource _bsCancelCalling = new BindingSource();
        
        public MainView()
        {
            InitializeComponent();

            SetBindings();
            SetFirstLogRecord();
        }

        /// <summary>
        /// Установка привязок
        /// </summary>
        private void SetBindings()
        {
            _bsModems.DataSource = typeof(List<Modem>);
            _listBoxModems.DataSource = _bsModems;
            _listBoxModems.DisplayMember = nameof(Modem.Name);

            _bsPhoneNumbers.DataSource = typeof(List<PhoneNumber>);
            _listBoxPhoneNumbers.DataSource = _bsPhoneNumbers;
            _listBoxPhoneNumbers.DisplayMember = nameof(PhoneNumber.OutputNumber);

            _bsLogs.DataSource = typeof(List<LogRecord>);
            _listBoxLogs.DataSource = _bsLogs;
            _listBoxLogs.DisplayMember = nameof(LogRecord.Message);

            _bsStartCalling.DataSource = typeof(ButtonEventHandler);
            _buttonStartCalling.DataBindings.Add("Enabled", _bsStartCalling,
                nameof(ButtonEventHandler.Enabled));

            _bsCancelCalling.DataSource = typeof(ButtonEventHandler);
            _buttonCancelCalling.DataBindings.Add("Enabled", _bsCancelCalling,
                nameof(ButtonEventHandler.Enabled));
        }

        /// <summary>
        /// Добавление начальных записей в журнал
        /// </summary>
        private void SetFirstLogRecord()
        {
            var logs = new List<LogRecord> { new LogRecord(1, "Программа запущена") };
            _bsLogs.DataSource = logs;
        }

        /// <summary>
        /// Добавление записи в журнал
        /// </summary>
        /// <param name="logMessage"></param>
        public void AddLogRecord(string logMessage)
        {
            if (String.IsNullOrEmpty(logMessage)) throw new ArgumentNullException(nameof(logMessage));

            int nextId = _bsLogs.Count + 1;
            _bsLogs.Add(new LogRecord(nextId, logMessage));

            _bsLogs.MoveLast();
        }

        /// <summary>
        /// Изменение отображаемого состояния номера в списке номеров
        /// </summary>
        /// <param name="number"></param>
        /// <param name="e"></param>
        public void ChangeNumberOutput(PhoneNumber number, PhoneNumberStateChangedEventArgs e)
        {
            if (number == null) throw new ArgumentNullException(nameof(number));
            if (e == null) throw new ArgumentNullException("Аргумент состояния пуст!");

            _bsPhoneNumbers.Position = _bsPhoneNumbers.IndexOf(number);
            number.OutputNumber = e.Message;
        }

        /// <summary>
        /// Модемы
        /// </summary>
        public List<Modem> Modems
        {
            get => _bsModems.List as List<Modem>;
            set
            {
                _bsModems.Clear();
                _bsModems.DataSource = value;
            }
        }

        /// <summary>
        /// Телефонные номера
        /// </summary>
        public List<PhoneNumber> PhoneNumbers
        {
            get => _bsPhoneNumbers.List as List<PhoneNumber>;
            set
            {
                _bsPhoneNumbers.Clear();
                _bsPhoneNumbers.DataSource = value;
            }
        }

        /// <summary>
        /// Кнопка запуска
        /// </summary>
        public ButtonEventHandler StartCalling
        {
            get => _bsStartCalling.Current as ButtonEventHandler;
            set
            {
                if (_bsStartCalling.Count > 0) return;

                _bsStartCalling.Add(value);
                _buttonStartCalling.Click += value.Handler;
                value.CheckEnabled();
            }
        }

        /// <summary>
        /// Кнопка отмены
        /// </summary>
        public ButtonEventHandler CancelCalling
        {
            get => _bsCancelCalling.Current as ButtonEventHandler;
            set
            {
                if (_bsCancelCalling.Count > 0) return;

                _bsCancelCalling.Add(value);
                _buttonCancelCalling.Click += value.Handler;
                value.CheckEnabled();
            }
        }
    }
}
