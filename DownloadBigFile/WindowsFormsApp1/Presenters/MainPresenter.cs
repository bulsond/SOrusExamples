using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1.Presenters
{
    public class MainPresenter : INotifyPropertyChanged
    {
        private const string _100MB_ = "https://speed.hetzner.de/100MB.bin";
        private const string _1GB_ = "https://speed.hetzner.de/1GB.bin";
        private const string _10GB_ = "https://speed.hetzner.de/10GB.bin";

        private readonly IMainView _mainView;
        private string _fileToDownload = _100MB_;
        private bool _isDownloading = false;
        private CancellationTokenSource _tokenSource;

        public event PropertyChangedEventHandler PropertyChanged;

        //ctor
        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));

            _mainView.FolderSelected += OnFolderSelected;
            _mainView.FileSelected += OnFileSelected;
            _mainView.DownloadFile += OnDownloadFile;
            _mainView.CancelDownloadFile += OnCancelDownloadFile;

            //кнопки
            CheckButtons();
        }

        /// <summary>
        /// Для прогрессбара
        /// </summary>
        private int _Progress;
        public int Progress
        {
            get => _Progress;
            set
            {
                _Progress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
            }
        }

        /// <summary>
        /// Для сообщения над прогрессбаром
        /// </summary>
        private string _TextProgress;
        public string TextProgress
        {
            get => _TextProgress;
            set
            {
                _TextProgress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextProgress)));
            }
        }

        /// <summary>
        /// Установка значений о прогрессе
        /// </summary>
        /// <param name="value"></param>
        private void SetProgress(int value)
        {
            Progress = value;
            TextProgress = $"{_fileToDownload} {value.ToString()}%";
        }

        /// <summary>
        /// Папка сохранения
        /// </summary>
        private string _SaveFolder;
        public string SaveFolder
        {
            get => _SaveFolder;
            set
            {
                _SaveFolder = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SaveFolder)));
                CheckButtons();
            }
        }

        /// <summary>
        /// Доступность кнопки выбора папки сохранения
        /// </summary>
        private bool _SelectSaveFolderEnabled;
        public bool SelectSaveFolderEnabled
        {
            get => _SelectSaveFolderEnabled;
            set
            {
                _SelectSaveFolderEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectSaveFolderEnabled)));
            }
        }

        /// <summary>
        /// Доступность кнопки запуска скачивания
        /// </summary>
        private bool _DownloadEnabled;
        public bool DownloadEnabled
        {
            get => _DownloadEnabled;
            set
            {
                _DownloadEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DownloadEnabled)));
            }
        }

        /// <summary>
        /// Доступность кнопки отмены скачивания
        /// </summary>
        private bool _CancelDownloadEnabled;
        public bool CancelDownloadEnabled
        {
            get => _CancelDownloadEnabled;
            set
            {
                _CancelDownloadEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CancelDownloadEnabled)));
            }
        }

        /// <summary>
        /// Вкл/выкл. кнопок
        /// </summary>
        private void CheckButtons()
        {
            if (_isDownloading)
            {
                SelectSaveFolderEnabled = false;
                DownloadEnabled = false;
                CancelDownloadEnabled = true;
            }
            else
            {
                SelectSaveFolderEnabled = true;
                DownloadEnabled = true;
                CancelDownloadEnabled = false;
            }

            if (!String.IsNullOrEmpty(SaveFolder) && 
                !String.IsNullOrEmpty(_fileToDownload) &&
                !_isDownloading)
            {
                DownloadEnabled = true;
            }
            else
            {
                DownloadEnabled = false;
            }
        }

        /// <summary>
        /// Событие выбора папки сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFolderSelected(object sender, string e)
        {
            SaveFolder = e;
        }

        /// <summary>
        /// События выбора размера файла для скачивания (радиокнопки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileSelected(object sender, string e)
        {
            if (e.Contains("1Gb"))
            {
                _fileToDownload = _1GB_;
            }
            else if (e.Contains("10Gb"))
            {
                _fileToDownload = _10GB_;
            }
            else
            {
                _fileToDownload = _100MB_;
            }
        }

        /// <summary>
        /// Событие запуска скачивания файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnDownloadFile(object sender, EventArgs e)
        {
            //кнопки
            _isDownloading = true;
            CheckButtons();

            //путь сохранения
            var file = _fileToDownload.Split('/').Last();
            var pathToSave = Path.Combine(SaveFolder, file);

            //токе отмены и прогресс
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;
            var progress = new Progress<int>(p => SetProgress(p));

            try
            {
                await DownloadService.DownloadAsync(_fileToDownload, pathToSave, progress, token);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка загрузки {ex.Message}");
            }
            finally
            {
                _tokenSource.Dispose();
                _tokenSource = null;

                _isDownloading = false;
                CheckButtons();
                Progress = 0;
                TextProgress = "";
            }
        }

        /// <summary>
        /// Событие отмены скачивания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelDownloadFile(object sender, EventArgs e)
        {
            //вызываем отмену
            _tokenSource.Cancel();
        }

    }
}
