using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAngleSharp.Models;
using WinFormsAngleSharp.Services;

namespace WinFormsAngleSharp
{
    public partial class Form1 : Form
    {
        //экземляр сервиса
        IWebService _webService;

        public Form1()
        {
            InitializeComponent();

            //оформление формы
            this.Text = "Примерчик";
            this.StartPosition = FormStartPosition.CenterScreen;

            //инициализируем
            //_webService = new MockWebService(); //тестовый вариант сервиса
            _webService = new WikiWebService(); //реальный сервис

            //привязываемся к событию нажатия на кнопку
            this._buttonGet.Click += ButtonGet_Click;
        }

        private async void ButtonGet_Click(object sender, EventArgs e)
        {
            //
            _textBoxHeader.Text = String.Empty;
            _textBoxParagraphs.Text = String.Empty;
            _buttonGet.Enabled = false;

            try
            {
                //получаем данные
                var wikiInfo = await _webService.GetWikiPageAsync(_textBoxAddress.Text);

                //отображаем данные
                _textBoxHeader.Text = wikiInfo.Header;
                if (wikiInfo.Paragraphs.Any())
                {
                    var firstPara = true;
                    foreach (var para in wikiInfo.Paragraphs)
                    {
                        if (firstPara)
                        {
                            _textBoxParagraphs.Text = para;
                            firstPara = false;
                        }
                        else
                        {
                            _textBoxParagraphs.Text += Environment.NewLine + para;
                        }
                    }
                }
            }
            finally
            {
                _buttonGet.Enabled = true;
            }
        }
    }
}
