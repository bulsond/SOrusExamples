using System.Collections.Generic;

namespace WinFormsUi.Interfaces
{
    public interface IWordService
    {
        /// <summary>
        /// Получение списка слов из токенов текста
        /// </summary>
        /// <param name="tokens">список токенов текста</param>
        /// <returns>список слов</returns>
        List<IWord> GetWordsWithDuplicates(List<IToken> tokens);

        /// <summary>
        /// Получение списка слов без дубликатов из токенов текста
        /// </summary>
        /// <param name="tokens">список токенов текста</param>
        /// <returns>список слов без дубликатов</returns>
        List<IWord> GetWords(List<IToken> tokens);

        List<ITFIDFWord> GetTFIDFWords(List<IToken> tokens, int countSentences);
    }
}
