using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpfApp1.Abstractions;
using WpfApp1.Models;

namespace WpfApp1.Data
{
    public class TestPersonRepository : IPersonRepository
    {
        private List<Person> _people;

        //ctor
        public TestPersonRepository()
        {
            _people = new List<Person>
            {
                new Person { Id = 1, FirstName = "Иван", LastName = "Петров" },
                new Person { Id = 2, FirstName = "Дмитрий", LastName = "Сидоров" },
                new Person { Id = 3, FirstName = "Вера", LastName = "Петрова" },
            };
        }

        public Task<IEnumerable<Person>> GetPeopleOrderedByLastName()
        {
            return Task.FromResult(_people.OrderBy(p => p.LastName).AsEnumerable());
        }

        public Task<bool> UpdatePerson(Person selectedPerson)
        {
            if (selectedPerson == null)
                throw new ArgumentNullException(nameof(selectedPerson));

            Person oldPerson = _people.FirstOrDefault(p => p.Id == selectedPerson.Id);
            if (oldPerson == null) return Task.FromResult(false);

            oldPerson.FirstName = selectedPerson.FirstName;
            oldPerson.LastName = selectedPerson.LastName;

            return Task.FromResult(true);
        }
    }
}
