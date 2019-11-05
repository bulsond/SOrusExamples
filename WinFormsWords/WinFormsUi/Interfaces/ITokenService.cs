using System.Collections.Generic;

namespace WinFormsUi.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Подсчет количества предолжений в токенизированном тексте
        /// </summary>
        /// <param name="tokens">список токенов текста</param>
        /// <returns>количество предложений</returns>
        int GetCountSentences(List<IToken> tokens);

        /// <summary>
        /// Получение коллекции токенов из текста
        /// </summary>
        /// <param name="text">текст для разбора</param>
        /// <returns>коллекция токенов</returns>
        List<IToken> GetTokens(string text);
    }
}