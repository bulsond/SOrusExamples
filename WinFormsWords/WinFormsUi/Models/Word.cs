using System;
using System.Collections.Generic;
using WinFormsUi.Interfaces;

namespace WinFormsUi.Models
{
    //корневой класс слова
    public class Word : IWord
    {
        //позиции слова в тексте
        private HashSet<int> _positions;
        public IEnumerable<int> Positions => _positions;
        //порядковые номера слова в общем массиве слов текста
        private HashSet<int> _orderNumbers;
        public IEnumerable<int> OrderNumbers => _orderNumbers;
        //значение слова
        public string Value { get; private set; }
        //длина слова
        public int Length => Value.Length;

        public Word(string value, int position, int orderNumber)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(nameof(value));

            Value = value;
            _positions = new HashSet<int>();
            _orderNumbers = new HashSet<int>();

            AddDuplicate(position, orderNumber);
        }

        public void AddDuplicate(int position, int orderNumber)
        {
            if (position < 0)
                throw new ArgumentException(nameof(position));
            if (orderNumber < 0)
                throw new ArgumentException(nameof(orderNumber));

            _positions.Add(position);
            _orderNumbers.Add(orderNumber);
        }
    }
}
