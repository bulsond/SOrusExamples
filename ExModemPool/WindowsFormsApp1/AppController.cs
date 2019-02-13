using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Abstractions;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Presenters;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1
{
    public class AppController : IAppController
    {
        private IMainView _mainView;

        //ctor
        public AppController()
        {
            DataContext = new DataContext();
        }

        public IMainView GetMainView()
        {
            if (_mainView != null) return _mainView;

            _mainView = new MainView();
            var presenter = new MainPresenter(this, _mainView);

            (_mainView as Form).StartPosition = FormStartPosition.CenterScreen;
            (_mainView as Form).Text = "Модемы";

            return _mainView;
        }

        public IDataContext DataContext { get; private set; }
    
    }
}
