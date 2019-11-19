using System;
using System.Collections.Generic;

namespace WinFormsEditTests.Models
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public class Question
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }
        public QuestionType Type { get; set; }
        public List<Answer> Answers { get; }

        public Question() : this(QuestionType.None)
        { }
        public Question(QuestionType questionType)
        {
            Type = questionType;
            Answers = new List<Answer>();
        }
    }
}
