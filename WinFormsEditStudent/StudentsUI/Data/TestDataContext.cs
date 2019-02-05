using StudentsUI.Abstractions;
using StudentsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsUI.Data
{
    public class TestDataContext : IDataContext
    {
        private static List<GroupModel> _groups;
        private static List<StudentModel> _students;

        //ctor
        public TestDataContext()
        {
            if (_groups == null || _students == null)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            _groups = new List<GroupModel>
            {
                new GroupModel { Id = 1, Title = "A1801" },
                new GroupModel { Id = 2, Title = "B1702" },
                new GroupModel { Id = 3, Title = "A1703" },
            };

            _students = new List<StudentModel>
            {
                new StudentModel { Id = 1, FirstName = "Иван",
                    LastName = "Смирнов", Group = _groups.Single(g => g.Id == 1) },
                new StudentModel { Id = 2, FirstName = "Сергей",
                    LastName = "Глазунов", Group = _groups.Single(g => g.Id == 3) },
                new StudentModel { Id = 3, FirstName = "Валерия",
                    LastName = "Крикалева", Group = _groups.Single(g => g.Id == 1) },
                new StudentModel { Id = 4, FirstName = "Дмитрий",
                    LastName = "Мураев", Group = _groups.Single(g => g.Id == 2) },
                new StudentModel { Id = 5, FirstName = "Ирина",
                    LastName = "Петрова", Group = _groups.Single(g => g.Id == 3) },
                new StudentModel { Id = 6, FirstName = "Семен",
                    LastName = "Новожилов", Group = _groups.Single(g => g.Id == 2) },
                new StudentModel { Id = 7, FirstName = "Анна",
                    LastName = "Смирнова", Group = _groups.Single(g => g.Id == 3) },
            };
        }

        public Task<IEnumerable<GroupModel>> GetGroups()
        {
            return Task.FromResult(_groups.AsEnumerable());
        }

        public Task<IEnumerable<StudentModel>> GetStudents()
        {
            return Task.FromResult(_students.AsEnumerable());
        }
    }
}
