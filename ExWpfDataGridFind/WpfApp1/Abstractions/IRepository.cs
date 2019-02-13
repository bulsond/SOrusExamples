using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Abstractions
{
    public interface IRepository
    {
        Task<List<PersonModel>> GetPeopleAsync();
        Task<List<PersonModel>> SearchPeopleAsync(PersonSearchModel searchPerson);
    }
}
