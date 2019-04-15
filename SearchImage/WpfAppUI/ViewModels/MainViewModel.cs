using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Resources;
using WpfAppUI.Models;
using WpfAppUI.Services;

namespace WpfAppUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IMainWindow _mainWindow;
        private string _pathOriginalImage;

        //ctor
        public MainViewModel(IMainWindow mainWindow)
        {
            _mainWindow = mainWindow;

            ///!!! Убрана возможность задавать изображение для поиска
            ///принудительно ищем изображение флажка из Assets
            SampleImage = GetFlagImage();
        }

        

        /// <summary>
        /// Флаг запуска поиска, для выкл./вкл. кнопок
        /// </summary>
        private bool _IsSearching;
        public bool IsSearching
        {
            get => _IsSearching;
            set
            {
                _IsSearching = value;
                SelectSampleCommand.RaiseCanExecuteChanged();
                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Исходное изображение (поле игры)
        /// </summary>
        public string OriginalImage
        {
            get => @"~\..\Assets\Original.jpg";
        }

        /// <summary>
        /// Образец для поиска
        /// </summary>
        private string _SampleImage;
        public string SampleImage
        {
            get => _SampleImage;
            set
            {
                _SampleImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SampleImage)));
                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Текстовое сообщение о процессе
        /// </summary>
        private string _Message;
        public string Message
        {
            get => _Message;
            set
            {
                _Message = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
            }
        }

        /// <summary>
        /// Список найденных мест для ListBox
        /// </summary>
        private List<FoundPlace> _Places;
        public List<FoundPlace> Places
        {
            get { return _Places; }
            set
            {
                _Places = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Places)));
            }
        }

        private FoundPlace _SelectedPlace;
        public FoundPlace SelectedPlace
        {
            get => _SelectedPlace;
            set
            {
                _SelectedPlace = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPlace)));
                _mainWindow.DrawPlace(_SelectedPlace);
            }
        }

        /// <summary>
        /// Кнопка Выбрать
        /// </summary>
        private RelayCommand _SelectSampleCommand;
        public RelayCommand SelectSampleCommand
        {
            get => _SelectSampleCommand = _SelectSampleCommand ?? new RelayCommand(OnSelectSample, CanSelectSample);
        }
        private bool CanSelectSample()
        {
            //if (IsSearching)
            //{
            //    return false;
            //}
            //return true;

            ///!!! Убрана возможность задавать изображение для поиска
            ///принудительно ищем изображение флажка из Assets
            return false;
        }
        private void OnSelectSample()
        {
            string file = _mainWindow.SelectSample();
            if (String.IsNullOrEmpty(file)) return;

            SampleImage = file;
        }

        /// <summary>
        /// Кнопка Искать
        /// </summary>
        private RelayCommand _SearchCommand;
        public RelayCommand SearchCommand
        {
            get => _SearchCommand = _SearchCommand ?? new RelayCommand(OnSearch, CanSearch);
        }
        private bool CanSearch()
        {
            if (String.IsNullOrEmpty(SampleImage) || IsSearching)
            {
                return false;
            }
            return true;
        }
        private async void OnSearch()
        {
            Message = "Ждите...";
            IsSearching = true;
            AforgeService service = new AforgeService();

            try
            {
                using (OverrideCursor cursor = OverrideCursor.GetWaitOverrideCursor())
                {
                    string pathOrigin = GetOriginalImage();
                    bool isContains = await service.IsContains(pathOrigin, SampleImage);
                    if (isContains)
                    {
                        Places = service.GetPlaces();
                    }
                    else
                    {
                        Places = new List<FoundPlace>();
                    }
                }
            }
            catch (Exception ex)
            {
                var message = $"Возникла ошибка: {ex.Message}";
                _mainWindow.ShowMessage(message, "Ошибка");
            }
            finally
            {
                Message = $"Найдено мест: {service.CountMatchings}";
                IsSearching = false;
            }
        }

        /// <summary>
        /// Получение пути к оригинальному изображению (полю игры)
        /// </summary>
        /// <returns></returns>
        private string GetOriginalImage()
        {
            if (!String.IsNullOrEmpty(_pathOriginalImage) && File.Exists(_pathOriginalImage))
            {
                return _pathOriginalImage;
            }

            _pathOriginalImage = Path.Combine(Path.GetTempPath(), "Original.jpg");


            Uri imgUri = new Uri("pack://application:,,,/Assets/Original.jpg");
            StreamResourceInfo imgStream = Application.GetResourceStream(imgUri);

            using (Stream imgs = imgStream.Stream)
            using (FileStream fs = File.Create(_pathOriginalImage))
            {
                byte[] ar = new byte[imgs.Length];
                imgs.Read(ar, 0, ar.Length);

                fs.Write(ar, 0, ar.Length);
            }

            return _pathOriginalImage;
        }

        /// <summary>
        /// Получение пути к изображению флажка
        /// </summary>
        /// <returns></returns>
        private string GetFlagImage()
        {
            string result = Path.Combine(Path.GetTempPath(), "Flag.jpg");

            Uri imgUri = new Uri("pack://application:,,,/Assets/Flag.jpg");
            StreamResourceInfo imgStream = Application.GetResourceStream(imgUri);

            using (Stream imgs = imgStream.Stream)
            using (FileStream fs = File.Create(result))
            {
                byte[] ar = new byte[imgs.Length];
                imgs.Read(ar, 0, ar.Length);

                fs.Write(ar, 0, ar.Length);
            }

            return result;
        }

        /// <summary>
        /// IDisposable
        /// </summary>
        public void Dispose()
        {
            if (!String.IsNullOrEmpty(_pathOriginalImage) && File.Exists(_pathOriginalImage))
            {
                File.Delete(_pathOriginalImage);
            }
        }
    }
}
