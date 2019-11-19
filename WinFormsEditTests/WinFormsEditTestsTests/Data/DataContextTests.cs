using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsEditTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsEditTests.Models;

namespace WinFormsEditTests.Data.Tests
{
    [TestClass()]
    public class DataContextTests
    {
        [TestMethod()]
        public void DataContextTest()
        {
            string path = @"D:\challenges.xml";

            DataContext context = new DataContext(path);

            Assert.IsNotNull(context);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            string path = @"D:\challenges.xml";
            DataContext context = new DataContext(path);

            List<Challenge> challenges = context.GetAll();

            Assert.IsTrue(challenges.Count > 0);
        }

        [TestMethod()]
        [Ignore]
        public void AddTest()
        {
            string path = @"D:\challenges.xml";
            DataContext context = new DataContext(path);

            List<Answer> answers1 = new List<Answer>
            {
                new Answer { Value = "Первый ответ", IsCorrect = false },
                new Answer { Value = "Второй ответ", IsCorrect = false },
                new Answer { Value = "Третий ответ (правильный)", IsCorrect = true },
                new Answer { Value = "Четвертый ответ", IsCorrect = false },
                new Answer { Value = "Пятый ответ", IsCorrect = false },
                new Answer { Value = "Шестой ответ", IsCorrect = false },
            };

            List<Answer> answers2 = new List<Answer>
            {
                new Answer { Value = "Ответ первый", IsCorrect = false },
                new Answer { Value = "Ответ второй(правильный)", IsCorrect = true },
                new Answer { Value = "Ответ третий", IsCorrect = false },
                new Answer { Value = "Ответ четвертый(правильный)", IsCorrect = true },
                new Answer { Value = "Ответ пятый(правильный)", IsCorrect = true },
                new Answer { Value = "Ответ шестой", IsCorrect = false },
            };

            Question question1 = new Question(QuestionType.SingleSelect)
            {
                Title = "Первый вопрос",
                Value = "Первый вопрос первой задачи",
                Score = 9,
            };

            Question question2 = new Question(QuestionType.MultipleSelect)
            {
                Title = "Второй вопрос",
                Value = "Второй вопрос первой задачи",
                Score = 10,
            };

            question1.Answers.AddRange(answers1);
            question2.Answers.AddRange(answers2);

            Challenge challenge = new Challenge
            {
                Name = "Первая задача",
            };
            challenge.Questions.Add(question1);
            challenge.Questions.Add(question2);

            //сохраняем в файл
            context.Add(challenge);

            Assert.Inconclusive();

        }
    }
}