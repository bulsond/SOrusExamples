using System;

namespace WinFormsEditTests.Models
{
    /// <summary>
    /// Тип вопроса
    /// </summary>
    public enum QuestionType
    {
        None,
        SingleSelect, //одиночный выбор
        MultipleSelect, //множественный выбор
    }

    public static class QuestionTypeExtensions
    {
        public static string RussianName(this QuestionType type)
        {
            switch (type)
            {
                case QuestionType.None:
                    return "Неизвестно";
                case QuestionType.SingleSelect:
                    return "Одиночный выбор";
                case QuestionType.MultipleSelect:
                    return "Множественный выбор";
                default:
                    throw new ArgumentException(nameof(type));
            }
        }
    }
}
