using DataBase1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataBase1.Data
{
    public class TestRepository : IRepository
    {
        private List<GroupModel> _groups;
        private List<StudentModel> _students;

        private const string _nameDir = @"Data\TestData";
        private const string _fileGroup = "Groups.txt";
        private const string _fileFN = "FirstNames.txt";
        private const string _fileLN = "LastNames.txt";
        private string _workingPath;

        //ctor
        public TestRepository()
        {
            _workingPath = Path.Combine(Environment.CurrentDirectory, _nameDir);

            LoadData();
        }

        /// <summary>
        /// Загрузка данных из текстовых файлов
        /// </summary>
        private void LoadData()
        {
            var rnd = new Random();
            var lgroups = File.ReadAllLines(Path.Combine(_workingPath, _fileGroup));
            var fnames = File.ReadAllLines(Path.Combine(_workingPath, _fileFN));
            var lnames = File.ReadAllLines(Path.Combine(_workingPath, _fileLN));

            _students = (from fn in fnames
                                 from ln in lnames
                                 let gr = lgroups[rnd.Next(0, lgroups.Length)]
                                 select new StudentModel
                                 {
                                     FirstName = fn,
                                     LastName = ln,
                                     GroupNumber = gr
                                 }).ToList();

            //перетасовываем студентов
            Shuffle(rnd, _students);

            //группы
            _groups = new List<GroupModel>();
            foreach (var line in lgroups)
            {
                var gm = new GroupModel
                {
                    Number = line
                };
                _groups.Add(gm);
            }

            //перетасовываем группы
            Shuffle(rnd, _groups);

            //назначаем Id & связь
            GetAllGroups();
            GetAllStudents();
        }

        /// <summary>
        /// Перетасовка коллекций
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rnd"></param>
        /// <param name="list"></param>
        private static void Shuffle<T>(Random rnd, IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Получить все группы
        /// </summary>
        /// <returns></returns>
        public List<GroupModel> GetAllGroups()
        {
            if (_groups[0].Id > 0) return _groups;

            for (int i = 0; i < _groups.Count; i++)
            {
                _groups[i].Id = i + 1;
            }

            return _groups;
        }

        /// <summary>
        /// Получить всех студентов
        /// </summary>
        /// <returns></returns>
        public List<StudentModel> GetAllStudents()
        {
            if (_students[0].Id > 0 && _students[0].Group != null) return _students; 

            //пронумеруем группы
            GetAllGroups();

            //назначим Id и группу
            for (int i = 0; i < _students.Count; i++)
            {
                _students[i].Id = i + 1;
                _students[i].Group = _groups.First(g => g.Number.Equals(_students[i].GroupNumber));
            }

            return _students;
        }

        /// <summary>
        /// Добавление нового студента
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int AddStudent(StudentModel student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            if (String.IsNullOrEmpty(student.GroupNumber)) throw new ArgumentNullException(nameof(student.GroupNumber));

            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);

            return student.Id;
        }

        /// <summary>
        /// Получение списка студентов нужной группы
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<StudentModel> GetStudentsByGroup(string number)
        {
            if (String.IsNullOrEmpty(number)) throw new ArgumentNullException(nameof(number));

            return _students.Where(s =>
            {
                if (String.IsNullOrEmpty(s.GroupNumber)) return false;
                return s.GroupNumber.Equals(number);
            }).ToList();
        }

        /// <summary>
        /// Обновление данных по студенту
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int UpdateStudent(StudentModel student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            if (student.Group == null) throw new ArgumentNullException(nameof(student.Group));

            var eStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (eStudent == null) return 0;

            eStudent.FirstName = student.FirstName;
            eStudent.LastName = student.LastName;
            eStudent.Group = student.Group;
            eStudent.GroupNumber = student.GroupNumber;

            return 1;
        }
    }
}
