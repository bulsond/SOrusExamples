using System.Collections.Generic;

namespace WinFormsUi.Interfaces
{
    public interface ITFIDFWord
    {
        /// <summary>
        /// TF
        /// </summary>
        int TermFrequency { get; }

        /// <summary>
        /// IDF
        /// </summary>
        double InverseDocumentFrequency { get; }

        /// <summary>
        /// TF*IDF
        /// </summary>
        double TFIDF { get; }

        /// <summary>
        /// Порядковый номер слова при первом появлении в тексте
        /// </summary>
        int OrderNumber { get; }

        /// <summary>
        /// Значение слова
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Список позиций слова в тексте
        /// </summary>
        List<IWordPosition> Positions { get; }
    }
}
