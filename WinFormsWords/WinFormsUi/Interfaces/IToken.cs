namespace WinFormsUi.Interfaces
{
    public interface IToken
    {
        //значение токена
        string Value { get; }
        //позиция первого символа токена в тексте
        int Position { get; }
        //название токена
        string TokenName { get; }
        //инфо для отображения
        string TokenValue { get; }
    }
}
