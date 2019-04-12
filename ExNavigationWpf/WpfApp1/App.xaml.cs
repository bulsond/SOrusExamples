using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Abstractions;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IAppController _controller;

        //ctor
        public App()
        {
            //вьюмодель окна программы
            IMainWindowViewModel mainVM = new MainWindowViewModel();
            //контроллер
            _controller = new AppController(mainVM);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //подписка на возникновение неперехваченных исключений
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //сообщения об ошибках будем писать в файл (его можно будет найти в папке с exe)
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt")));
            Trace.AutoFlush = true;

            //окно программы
            var mainWindow = new MainWindow();
            //привязка к окну её вьюмодели
            mainWindow.DataContext = _controller.MainWindowViewModel;
            //отображаем окно
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Title = "Пример простого шаблона программы";
            mainWindow.Show();

            //отображение начальной вьюшки
            _controller.ChangeCurrentView(CurrentViewTypes.Start);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //пишем в лог все неперехваченные ошибки
            Trace.WriteLine((e.ExceptionObject as Exception).Message);
        }
    }
}
