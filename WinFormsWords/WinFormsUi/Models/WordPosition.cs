using System;
using WinFormsUi.Interfaces;

namespace WinFormsUi.Models
{
    //для отображения позиций слова в тексте
    public class WordPosition : IWordPosition
    {
        public int Start { get; private set; }
        public int End => Start + Delta;
        public int Delta { get; private set; }

        public WordPosition(int startPosition, int wordLength)
        {
            if (startPosition < 0)
                throw new ArgumentException(nameof(startPosition));
            if (wordLength <= 0)
                throw new ArgumentException(nameof(wordLength));

            Start = startPosition;
            Delta = wordLength;
        }
    }
}
