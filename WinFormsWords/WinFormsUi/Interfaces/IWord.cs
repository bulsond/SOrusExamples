using System.Collections.Generic;

namespace WinFormsUi.Interfaces
{
    public interface IWord
    {
        /// <summary>
        /// Длина слова
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Порядковые номера слова в общем массиве слов текста
        /// </summary>
        IEnumerable<int> OrderNumbers { get; }

        /// <summary>
        /// Позиции слова в тексте
        /// </summary>
        IEnumerable<int> Positions { get; }

        /// <summary>
        /// Значение слова
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Добавить дубликат слова, т.е. еще одну позицию и порядковый номер
        /// </summary>
        /// <param name="position">позиция в тексте такого же слова</param>
        /// <param name="orderNumber">порядковый номер слова в тексте</param>
        void AddDuplicate(int position, int orderNumber);
    }
}