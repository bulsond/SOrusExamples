using System;
using System.Collections.Generic;

namespace WinFormsEditTests.Models
{
    public class QuestionTypeView
    {
        public QuestionType Type { get; }
        public string Name => Type.RussianName();

        public QuestionTypeView(QuestionType type)
        {
            Type = type;
        }

        /// <summary>
        /// Получить список типов вопросов
        /// </summary>
        /// <returns></returns>
        public static List<QuestionTypeView> GetListTypes()
        {
            List<QuestionTypeView> types = new List<QuestionTypeView>();

            foreach (QuestionType type in Enum.GetValues(typeof(QuestionType)))
            {
                if (type == QuestionType.None) continue;
                types.Add(new QuestionTypeView(type));
            }

            return types;
        }
    }
}
