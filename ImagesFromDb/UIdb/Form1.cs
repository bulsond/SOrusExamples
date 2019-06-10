using System.Collections.Generic;
using System.Windows.Forms;
using UIdb.Abstractions;
using UIdb.Data;
using UIdb.Models;

namespace UIdb
{
    public partial class Form1 : Form
    {
        private IDataContext _data;
        private BindingSource _bsPics = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            this.Text = "Пример получения изображений из SQLite";
            this.StartPosition = FormStartPosition.CenterScreen;

            //установка привязок
            SetBindings();
            //загрузка данных
            LoadData();
        }

        private void SetBindings()
        {
            //тип источника
            _bsPics.DataSource = typeof(List<Picture>);

            //привязка к ListBox
            _listBoxNames.ValueMember = nameof(Picture.Id);
            _listBoxNames.DisplayMember = nameof(Picture.Name);
            _listBoxNames.DataSource = _bsPics;

            //привязка к PictureBox
            _pictureBoxOutput.DataBindings.Add("Image", _bsPics, nameof(Picture.Pic));

            //привязка к TextBox
            _textBoxDesc.DataBindings.Add("Text", _bsPics, nameof(Picture.Description));
        }

        private async void LoadData()
        {
            //тестовая БД
            //_data = new TestDataContext();

            //реальная БД
            _data = new SQLiteDataContext();

            //получаем данные и заполняем источник привязки
            var pics = await _data.GetPictures();
            pics.ForEach(p => _bsPics.Add(p));
        }
    }
}
