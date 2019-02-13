namespace WindowsFormsApp1.Abstractions
{
    public interface IAppController
    {
        IMainView GetMainView();

        IDataContext DataContext { get; }
    }
}
