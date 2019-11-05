namespace WinFormsUi.Interfaces
{
    public interface IMainPresenter
    {
        IMainForm Form { get; }
        ITokenService TokenService { get; }
        IWordService WordService { get; }
    }
}
