using DataBase1.Models;
using System.Collections.Generic;

namespace DataBase1.Data
{
    public interface IRepository
    {
        List<StudentModel> GetAllStudents();
        List<GroupModel> GetAllGroups();
        int AddStudent(StudentModel student);
        List<StudentModel> GetStudentsByGroup(string number);
        int UpdateStudent(StudentModel student);
    }
}
