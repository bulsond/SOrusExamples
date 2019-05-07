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
        private const string _ADDRESS_ = "https://news.yandex.ru/games.rss";
        //для взаимодействия с БД
        private readonly DataService _data = new DataService();

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Пример на получение RSS";

            this._buttonGet.Click += ButtonGet_Click;
            this._buttonClear.Click += ButtonClear_Click;
            this._buttonBD.Click += ButtonBD_Click;
        }

        private async void ButtonGet_Click(object sender, EventArgs e)
        {
            //создаем экземпляр сервиса
            //и получаем по нужному адресу записи
            var rssService = new RssService(_ADDRESS_);
            List<RssItem> items = rssService.GetRssItems();

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

                //запоминаем в БД
                await _data.SaveItems(items);
            }
            else
            {
                MessageBox.Show("Не удалось получить новые записи.");
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            this._richTextBoxFromYa.Text = String.Empty;
        }

        private async void ButtonBD_Click(object sender, EventArgs e)
        {
            //получаем данные из БД
            List<RssItem> items = await _data.GetItems();

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
                MessageBox.Show("Не удалось получить записи из БД.");
            }
        }
    }
}
