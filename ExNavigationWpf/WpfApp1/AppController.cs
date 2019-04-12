using System;
using System.Threading.Tasks;
using WpfApp1.Abstractions;
using WpfApp1.Data;
using WpfApp1.ViewModels;
using WpfApp1.Views;
using WpfApp1.Views.Messages;

namespace WpfApp1
{
    class AppController : IAppController
    {
        //ctor
        public AppController(IMainWindowViewModel mainWindowVM)
        {
            MainWindowViewModel = mainWindowVM ?? throw new ArgumentNullException(nameof(mainWindowVM));

            //подключаем тестовый источник данных
            DataContext = new TestDataContext();
        }

        public IDataContext DataContext { get; }
        public IMainWindowViewModel MainWindowViewModel { get; }
        public object ViewModelBag { get; set; }

        public void ChangeCurrentView(CurrentViewTypes viewType)
        {
            switch (viewType)
            {
                case CurrentViewTypes.Start:
                    IStartViewModel sVM = new StartViewModel(this);
                    StartView sV = new StartView();
                    //привязка
                    sV.DataContext = sVM;
                    //отображение
                    MainWindowViewModel.CurrentView = sV;
                    break;
                case CurrentViewTypes.Edit:
                    IEditViewModel eVM = new EditViewModel(this);
                    EditView eV = new EditView();
                    //привязка
                    eV.DataContext = eVM;
                    //отображение
                    MainWindowViewModel.CurrentView = eV;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType));
            }
        }

        public async Task<bool> IsMessageYesNoResult(string message)
        {
            //создаем и отображаем сообщение пользователю
            var yN = new YesNoMessage();
            yN.Text = message;
            MainWindowViewModel.MessageView = yN;

            //получаем результат и убираем сообщение
            bool result = await yN.GetResult();
            MainWindowViewModel.MessageView = null;

            return result;
        }
    }
}
