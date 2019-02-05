using StudentsUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsUI.Abstractions
{
    public interface IDataContext
    {
        Task<IEnumerable<GroupModel>> GetGroups();
        Task<IEnumerable<StudentModel>> GetStudents();
    }
}
