using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinFormsApp1.Abstractions;
using WinFormsApp1.Models;

namespace WinFormsApp1.Data
{
    public class PersonXmlRepository : IPersonRepository
    {
        private readonly string _path;
        private List<Person> _people;

        //ctor
        public PersonXmlRepository(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException(nameof(path));

            _path = path;
            _people = new List<Person>();
        }

        /// <summary>
        /// Запись в XML файл
        /// </summary>
        private void WriteFile()
        {
            var serializer = new XmlSerializer(typeof(List<Person>));

            using (var writer = new StreamWriter(_path, false))
            {
                serializer.Serialize(writer, _people);
            }
        }

        /// <summary>
        /// Чтение из XML файла
        /// </summary>
        private void ReadFile()
        {
            var contents = String.Empty;

            if (File.Exists(_path))
            {
                contents = File.ReadAllText(_path);
            }

            if (String.IsNullOrEmpty(contents))
            {
                return;
            }

            var serializer = new XmlSerializer(typeof(List<Person>));
            using (var reader = new StringReader(contents))
            {
                var records = (List<Person>)serializer.Deserialize(reader);

                _people.Clear();
                _people.AddRange(records);
            }
        }


        /// <summary>
        /// Добавление нового человека
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<bool> AddPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));
            if (person.Id != 0)
                throw new ArgumentException(nameof(person));

            //назначаем Id
            if (_people.Count == 0)
            {
                person.Id = 1;
            }
            else
            {
                person.Id = _people.Max(p => p.Id) + 1;
            }

            //добавляем в коллекцию
            _people.Add(person);

            //пишем в файл
            try
            {
                await Task.Run(() => WriteFile());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка {ex.Message} записи файла {_path}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Получение всей коллекции людей
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetPeople()
        {
            try
            {
                await Task.Run(() => ReadFile());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка {ex.Message} чтения файла {_path}");
            }

            return _people;
        }
    }
}
