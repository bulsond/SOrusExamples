using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsUi.Interfaces;

namespace WinFormsUi.Models
{
    //класс слова для отображения в таблицах
    public class TFIDFWord : ITFIDFWord
    {
        private readonly IWord _currentWord;

        public int TermFrequency { get; private set; }
        public double InverseDocumentFrequency { get; private set; }
        public double TFIDF { get; private set; }
        public string Value => _currentWord.Value;
        public int OrderNumber => _currentWord.OrderNumbers.First();
        public List<IWordPosition> Positions { get; private set; }

        //ctor
        private TFIDFWord(IWord word, int textCountSentences)
        {
            _currentWord = word;
            CalculatePositions();
            СalculateProperties(textCountSentences);
        }

        //создание списка позиций слова в тексте
        private void CalculatePositions()
        {
            Positions = new List<IWordPosition>();

            foreach (var p in _currentWord.Positions)
            {
                var position = new WordPosition(p, _currentWord.Length);
                Positions.Add(position);
            }
        }

        //вычисление свойств
        private void СalculateProperties(int textCountSentences)
        {
            this.TermFrequency = _currentWord.Positions.Count();

            // TODO: Здесь не совсем верное вычисление!
            // В числителе должно быть кол-во документов из корпуса,
            // здесь же берется количество предложений в тексте.
            // В знаменателе должно быть количество документов, в кот. встречается слово
            // здесь же берется просто общее количество появления слов в тексте, 
            // что фактически опять же является TF. Требуется подправить!
            // см. http://www.primaryobjects.com/2013/09/13/tf-idf-in-c-net-for-machine-learning-term-frequency-inverse-document-frequency/
            this.InverseDocumentFrequency =
                Math.Log((double)textCountSentences / ((double)1 + _currentWord.Positions.Count()));

            this.TFIDF = this.TermFrequency * this.InverseDocumentFrequency;
        }

        /// <summary>
        /// Создание экземпляра класса на основе экземпляра Word
        /// </summary>
        /// <param name="word">экземпляр реализующий IWord</param>
        /// <param name="textCountWords">общее количество предложений в тексте</param>
        /// <returns>экземпляр TFIDFWord</returns>
        public static TFIDFWord CreateFromWord(IWord word, int textCountSentences)
        {
            if (word is null)
                throw new ArgumentNullException(nameof(word));
            if (textCountSentences <= 0)
                throw new ArgumentException(nameof(textCountSentences));

            return new TFIDFWord(word, textCountSentences);
        }
    }
}
