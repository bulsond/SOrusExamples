using RssYandexUi.Models;
using RssYandexUi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssYandexUi
{
    public partial class Form1 : Form
    {
        //для работы с Yandex
        private readonly RssService _rssService = new RssService("https://news.yandex.ru/games.rss");
        //для взаимодействия с БД
        private readonly DataService _data = new DataService();
        //состояния интерфейса
        private enum State { Busy, Free };

        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            Text = "Пример на получение RSS";

            _buttonGet.Click += ButtonGet_Click;
            _buttonClear.Click += ButtonClear_Click;
            _buttonBD.Click += ButtonBD_Click;
        }

        /// <summary>
        /// Получение записей из RSS Яндекса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonGet_Click(object sender, EventArgs e)
        {
            _richTextBoxFromYa.Text = String.Empty;
            ChangeState(State.Busy);

            try
            {
                //получаем и отображаем записи от яндекса
                var items = await _rssService.GetRssItems();
                ShowItems(items, "Не удалось получить новые записи.");

                //запоминаем в БД
                await _data.SaveItems(items);
            }
            finally
            {
                ChangeState(State.Free);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            _richTextBoxFromYa.Text = String.Empty;
        }

        /// <summary>
        /// Извлечение записией из БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonBD_Click(object sender, EventArgs e)
        {
            _richTextBoxFromYa.Text = String.Empty;
            ChangeState(State.Busy);

            try
            {
                //получаем данные из БД и отображаем их
                ShowItems(await _data.GetItems(), "Не удалось получить записи из БД.");
            }
            finally
            {
                ChangeState(State.Free);
            }
        }

        /// <summary>
        /// Отображение записей
        /// </summary>
        /// <param name="items"></param>
        /// <param name="errorMessage"></param>
        private void ShowItems(List<RssItem> items, string errorMessage)
        {
            //если что-то есть
            if (items.Any())
            {
                //отображаем
                foreach (var item in items)
                {
                    this._richTextBoxFromYa.AppendText(item.ToString());
                    this._richTextBoxFromYa.AppendText(Environment.NewLine);
                    this._richTextBoxFromYa.AppendText(Environment.NewLine);
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        /// <summary>
        /// Вкл./Выкл. кнопок
        /// </summary>
        /// <param name="state"></param>
        private void ChangeState(State state)
        {
            switch (state)
            {
                case State.Busy:
                    _buttonGet.Enabled = false;
                    _buttonClear.Enabled = false;
                    _buttonBD.Enabled = false;
                    break;
                case State.Free:
                    _buttonGet.Enabled = true;
                    _buttonClear.Enabled = true;
                    _buttonBD.Enabled = true;
                    break;
            }
        }
    }
}
