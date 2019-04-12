using System.Threading.Tasks;

namespace WpfApp1.Abstractions
{
    //типы вьюшек
    public enum CurrentViewTypes
    {
        Start,
        Edit,
    }

    public interface IAppController
    {
        //контекст данных приложения
        IDataContext DataContext { get; }
        //вьюмодель гл.окна
        IMainWindowViewModel MainWindowViewModel { get; }
        //отображение нужной вьюшки
        void ChangeCurrentView(CurrentViewTypes viewType);
        //для передачи данных между вьюмоделями
        object ViewModelBag { get; set; }
        //запрос к пользователю на согласие
        Task<bool> IsMessageYesNoResult(string message);
    }
}
