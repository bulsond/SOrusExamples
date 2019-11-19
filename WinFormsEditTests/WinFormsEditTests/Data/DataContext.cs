using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using WinFormsEditTests.Models;

namespace WinFormsEditTests.Data
{
    /// <summary>
    /// Контекст данных приложения
    /// (запись/чтение данных в/из файла xml)
    /// </summary>
    public class DataContext
    {
        //путь к файлу
        private readonly string _pathToFile;
        //задания
        private readonly List<Challenge> _сhallenges;

        /// <summary>
        /// Ctor Контекст данных приложения
        /// </summary>
        /// <param name="pathToFile">путь к файлу хранения данных программы</param>
        public DataContext(string pathToFile)
        {
            if (string.IsNullOrEmpty(pathToFile))
                throw new ArgumentException(nameof(pathToFile));

            _pathToFile = pathToFile;
            _сhallenges = new List<Challenge>();
            ReadFile();
        }

        /// <summary>
        /// Чтение из XML файла
        /// </summary>
        private void ReadFile()
        {
            var contents = String.Empty;

            if (File.Exists(_pathToFile))
            {
                contents = File.ReadAllText(_pathToFile);
            }

            if (String.IsNullOrEmpty(contents))
            {
                return;
            }

            var serializer = new XmlSerializer(_сhallenges.GetType());
            using (var reader = new StringReader(contents))
            {
                var records = (List<Challenge>)serializer.Deserialize(reader);

                _сhallenges.Clear();
                _сhallenges.AddRange(records);
            }
        }

        /// <summary>
        /// Запись в XML файл
        /// </summary>
        private void WriteFile()
        {
            var serializer = new XmlSerializer(_сhallenges.GetType());

            using (var writer = new StreamWriter(_pathToFile, false))
            {
                serializer.Serialize(writer, _сhallenges);
            }
        }

        /// <summary>
        /// Получить полный список заданий
        /// </summary>
        /// <returns></returns>
        public List<Challenge> GetAll()
        {
            return _сhallenges;
        }

        /// <summary>
        /// Добавить новое задание
        /// </summary>
        /// <param name="challenge"></param>
        public void Add(Challenge challenge)
        {
            if (challenge is null)
                throw new ArgumentNullException(nameof(challenge));

            if (_сhallenges.Count == 0)
            {
                challenge.Id = 1;
            }
            else
            {
                challenge.Id = _сhallenges.Max(c => c.Id) + 1;
            }

            _сhallenges.Add(challenge);
            WriteFile();
        }

        /// <summary>
        /// Получение задания
        /// </summary>
        /// <param name="name">имя задания</param>
        /// <returns>экземпляр задания</returns>
        public Challenge GetChallenge(string name)
        {
            //готовим результат
            var result = new Challenge();
            //ищем такую задачу
            var ch = _сhallenges.FirstOrDefault(c => c.Name.Equals(name));
            if (ch != null) result = ch;

            return result;
        }

        /// <summary>
        /// Получение вопроса
        /// </summary>
        /// <param name="challengeName">имя задания</param>
        /// <param name="questionName">название вопроса</param>
        /// <returns>экземпляр вопроса</returns>
        public Question GetQuestion(string challengeName, string questionName)
        {
            if (string.IsNullOrEmpty(challengeName))
                throw new ArgumentException(nameof(challengeName));

            if (string.IsNullOrEmpty(questionName))
                throw new ArgumentException(nameof(questionName));

            //готовим результат
            var result = new Question(QuestionType.None) { Title = "Не найден такой вопрос" };
            //ищем такую задачу
            var ch = _сhallenges.FirstOrDefault(c => c.Name.Equals(challengeName));
            if (ch is null) return result;
            //ищем такой вопрос
            var question = ch.Questions.FirstOrDefault(q => q.Title.Equals(questionName));
            if (question != null) result = question;

            return result;
        }

        /// <summary>
        /// Сохранение данных (с перечитыванием файла)
        /// </summary>
        public void Save()
        {
            WriteFile();
            ReadFile();
        }

        /// <summary>
        /// Добавление нового задания
        /// </summary>
        /// <param name="challenge">экземпляр задания</param>
        public void AddChallenge(Challenge challenge)
        {
            if (challenge is null)
                throw new ArgumentNullException(nameof(challenge));

            _сhallenges.Add(challenge);
            Save();
        }
    }
}
