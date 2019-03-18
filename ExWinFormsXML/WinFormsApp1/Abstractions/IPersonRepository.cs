using System.Collections.Generic;
using System.Threading.Tasks;
using WinFormsApp1.Models;

namespace WinFormsApp1.Abstractions
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPeople();
        Task<bool> AddPerson(Person person);
    }
}
