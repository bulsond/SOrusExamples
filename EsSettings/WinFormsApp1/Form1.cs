using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private const string _FILE_NAME = "settings.txt";

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Пример";

            _buttonSaveInput.Click += ButtonSaveInput_Click;
            _buttonReadOutput.Click += ButtonReadOutput_Click;
        }

        /// <summary>
        /// Кнопка сохранения установок(значений контролов)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveInput_Click(object sender, EventArgs e)
        {
            //собираем значения
            var settings = new AppSettings
            {
                Number = Convert.ToInt32(Decimal.Round(_numericUpDownInput.Value, 0)),
                Message = _textBoxInput.Text,
                Date = _dateTimePickerInput.Value
            };
            //преобразуем в строку
            string line = AppSettings.GetSettingsLine(settings);

            //запоминаем
            try
            {
                File.WriteAllText(_FILE_NAME, line);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка записи в файл установок: {ex.Message}");
            }
        }

        /// <summary>
        /// Кнопка чтения установок(значений контролов)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReadOutput_Click(object sender, EventArgs e)
        {
            //читаем файл
            string line = String.Empty;
            try
            {
                line = File.ReadAllText(_FILE_NAME);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка чтения файла установок: {ex.Message}");
            }

            //пытаемся получить экземпляр класса установок
            if (AppSettings.TryParseSettingsLine(line, out AppSettings settings))
            {
                //присваиваем значения контролам
                _numericUpDownOutput.Value = settings.Number;
                _textBoxOutput.Text = settings.Message;
                _dateTimePickerOutput.Value = settings.Date;
            }
            else
            {
                MessageBox.Show("Не удалось прочитать все необходимые значения.");
            }

        }
    }
}
