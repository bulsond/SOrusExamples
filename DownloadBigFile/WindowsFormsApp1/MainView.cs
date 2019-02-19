using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Presenters;

namespace WindowsFormsApp1
{
    public interface IMainView
    {
        //запуск скачивания файла
        event EventHandler DownloadFile;
        //отмена скачивания файла
        event EventHandler CancelDownloadFile;
        //выбрана папка для сохранения файла
        event EventHandler<string> FolderSelected;
        //выбран файл для скачивания
        event EventHandler<string> FileSelected;
    }

    public partial class MainView : Form, IMainView
    {
        private readonly MainPresenter _presenter;

        public event EventHandler DownloadFile;
        public event EventHandler CancelDownloadFile;
        public event EventHandler<string> FileSelected;
        public event EventHandler<string> FolderSelected;

        public MainView()
        {
            InitializeComponent();

            _presenter = new MainPresenter(this);

            //привязки
            SetBindings();
            //подписка на события у кнопок
            SetButtonsClickEvents();
            //подписка на события у радиокнопок
            SetRadioButtonsCheckedEvents();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Пример загрузки большого файла";
        }

        /// <summary>
        /// Установка привязок
        /// </summary>
        private void SetBindings()
        {
            _textBoxSaveFolder.DataBindings.Add(nameof(TextBox.Text),
                _presenter, nameof(MainPresenter.SaveFolder));

            _buttonStartDownload.DataBindings.Add(nameof(Button.Enabled),
                _presenter, nameof(MainPresenter.DownloadEnabled));

            _buttonCancelDownload.DataBindings.Add(nameof(Button.Enabled),
                _presenter, nameof(MainPresenter.CancelDownloadEnabled));

            _buttonSelectFolder.DataBindings.Add(nameof(Button.Enabled),
                _presenter, nameof(MainPresenter.SelectSaveFolderEnabled));

            _progressBar.DataBindings.Add(nameof(ProgressBar.Value),
                _presenter, nameof(MainPresenter.Progress));

            _labelProgress.DataBindings.Add(nameof(Label.Text),
                _presenter, nameof(MainPresenter.TextProgress));
        }

        /// <summary>
        /// Подписка на событие у кнопок
        /// </summary>
        private void SetButtonsClickEvents()
        {
            _buttonSelectFolder.Click += ButtonSelectFolder_Click;
            _buttonStartDownload.Click += (e, s) => DownloadFile?.Invoke(null, EventArgs.Empty);
            _buttonCancelDownload.Click += (e, s) => CancelDownloadFile?.Invoke(null, EventArgs.Empty);
        }

        /// <summary>
        /// Подписка на событие у радиокнопок
        /// </summary>
        private void SetRadioButtonsCheckedEvents()
        {
            _radioButton100Mb.CheckedChanged += (s, e) => OnCheckedChanged(s, e);
            _radioButton1Gb.CheckedChanged += (s, e) => OnCheckedChanged(s, e);
            _radioButton10Gb.CheckedChanged += (s, e) => OnCheckedChanged(s, e);

        }

        /// <summary>
        /// Вызов события смены выбранного для скачивания файла
        /// с передачей имени радиокнопки
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void OnCheckedChanged(object s, EventArgs e)
        {
            var rb = s as RadioButton;

            if (rb.Checked)
            {
                FileSelected?.Invoke(null, rb.Name);
            }
        }

        /// <summary>
        /// Выбора папки для сохранения скаченного файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelectFolder_Click(object sender, EventArgs e)
        {
            if (_folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FolderSelected?.Invoke(null, _folderBrowserDialog.SelectedPath);
            }
        }

    }

    
}
