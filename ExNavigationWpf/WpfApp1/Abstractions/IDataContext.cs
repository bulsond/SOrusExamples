using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Abstractions
{
    public interface IDataContext
    {
        Task<IEnumerable<Person>> GetPeopleAsync();
        Task SavePersonAsync(Person currentPerson);
        Task RemovePerson(int id);
    }
}