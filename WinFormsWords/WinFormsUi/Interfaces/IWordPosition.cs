namespace WinFormsUi.Interfaces
{
    public interface IWordPosition
    {
        
        /// <summary>
        /// Позиция первой буквы слова в тексте
        /// </summary>
        int Start { get; }
        /// <summary>
        /// Позиция последней буквы слова
        /// </summary>
        int End { get; }
        /// <summary>
        /// Разница м.ними, фактически длина слова
        /// </summary>
        int Delta { get; }
    }
}