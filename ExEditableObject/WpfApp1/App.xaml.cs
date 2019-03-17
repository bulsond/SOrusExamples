using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Abstractions;
using WpfApp1.Data;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IPersonRepository _repo;
        private IMainViewModel _vm;

        //ctor
        public App()
        {
            _repo = new TestPersonRepository();
            _vm = new MainViewModel(_repo);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            await _vm.LoadData();
            new MainWindow() { DataContext = _vm }.Show();
        }

    }
}
