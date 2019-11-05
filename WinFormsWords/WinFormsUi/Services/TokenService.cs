using System;
using System.Collections.Generic;
using WinFormsUi.Interfaces;
using WinFormsUi.Services.Tokens;

namespace WinFormsUi.Services
{
    public class TokenService : ITokenService
    {
        public TokenService()
        { }

        /// <summary>
        /// Получение коллекции токенов из текста
        /// </summary>
        /// <param name="text">текст для разбора</param>
        /// <returns>коллекция токенов</returns>
        public List<IToken> GetTokens(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException(nameof(text));

            //готовим результат
            List<IToken> tokens = new List<IToken>();

            //нумерация слов в тексте
            int wordsOrder = 0;
            //позиция первой буквы слова
            int wordPosition = 0;
            //для посимвольного набора слова
            List<char> wordChars = new List<char>();

            var chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                //извлекаем текущий символ
                var current = chars[i];

                if (Char.IsLetter(current))
                {
                    //если это первая буква слова
                    if (wordChars.Count == 0)
                    {
                        wordPosition = i;
                    }

                    //вносим букву в массив слова
                    wordChars.Add(current);

                    //если это последний символ в тексте, т.е. текст заканчивается на слове
                    //нужно добавить словный токен
                    if (i + 1 == chars.Length)
                    {
                        AddWordToken(wordChars, wordPosition, tokens, ++wordsOrder);
                    }
                }
                else
                {
                    //т.е. текущий символ не относится к слову
                    //и до этого у нас возможно собиралось слово
                    //и его нужно закрывать и создавать словный токен
                    if (wordChars.Count > 0)
                    {
                        AddWordToken(wordChars, wordPosition, tokens, ++wordsOrder);
                        //очищаем для следующего слова
                        wordChars.Clear();
                    }

                    //добавляем небуквенный токен
                    AddNotLetterToken(tokens, i, current);
                }
            }

            return tokens;
        }

        private void AddWordToken(List<char> wordChars, int position, List<IToken> tokens, int wordsOrder)
        {
            var array = wordChars.ToArray();
            var word = new String(array);
            tokens.Add(new WordToken(position, word, wordsOrder));
        }

        private void AddNotLetterToken(List<IToken> tokens, int i, char current)
        {
            if (Char.IsWhiteSpace(current))
            {
                tokens.Add(new SpaceToken(i));
                return;
            }

            if (Char.IsDigit(current))
            {
                tokens.Add(new NumberToken(i, current.ToString()));
                return;
            }

            //если это не пробел и не цифра, значит это какой-то знак
            tokens.Add(new SignToken(i, current.ToString()));
        }

        /// <summary>
        /// Подсчет количества предолжений в токенизированном тексте
        /// </summary>
        /// <param name="tokens">список токенов текста</param>
        /// <returns>количество предложений</returns>
        public int GetCountSentences(List<IToken> tokens)
        {
            if (tokens == null)
                throw new ArgumentException(nameof(tokens));

            int result = 0;
            for (int i = 0; i < tokens.Count; i++)
            {
                if (i + 1 == tokens.Count)
                {
                    result++;
                    break;
                }
                if (tokens[i].Value == "." && tokens[i + 1].TokenName == "space")
                {
                    result++;
                }
            }

            return result;
        }
    }
}
