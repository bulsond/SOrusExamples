using System.Collections.Generic;
using System.Threading.Tasks;
using WinFormsMySql.Models;
using WinFormsMySql.Utils;

namespace WinFormsMySql.Interfaces
{
    public interface IEmployeeRepository
    {
        //получение всех
        Task<Result<List<Employee>>> GetEmployees();
        //добавление
        Task<Result<int>> AddEmployee(Employee employee);
        //удаление
        Task<Result<int>> RemoveEmployee(int id);
        //обновление
        Task<Result<int>> UpdateEmployee(Employee emp);
    }
}
