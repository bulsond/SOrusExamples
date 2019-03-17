using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Abstractions
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeopleOrderedByLastName();
        Task<bool> UpdatePerson(Person selectedPerson);
    }
}
