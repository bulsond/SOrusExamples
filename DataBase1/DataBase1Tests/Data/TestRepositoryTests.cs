using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase1.Models;

namespace DataBase1.Data.Tests
{
    [TestClass()]
    public class TestRepositoryTests
    {
        [TestMethod()]
        public void TestRepositoryCtor()
        {
            var repo = new TestRepository();

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void GetAllStudents()
        {
            var repo = new TestRepository();

            List<StudentModel> students = repo.GetAllStudents();

            Assert.IsTrue(students.Count > 0);
            Assert.IsTrue(students[0].Id == 1);
        }

        [TestMethod]
        public void GetAllGroups()
        {
            var repo = new TestRepository();

            List<GroupModel> groups = repo.GetAllGroups();

            Assert.IsTrue(groups.Count > 0);
            Assert.IsTrue(groups[0].Id == 1);
        }

        [TestMethod]
        public void AddStudent()
        {
            var repo = new TestRepository();
            var group = repo.GetAllGroups().First();
            var student = new StudentModel
            {
                FirstName = "",
                LastName = "",
                Group = group,
                GroupNumber = group.Number
            };

            int result = repo.AddStudent(student);

            Assert.IsTrue(result > 0);
        }
    }
}