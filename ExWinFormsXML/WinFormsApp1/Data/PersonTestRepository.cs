using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Abstractions;
using WinFormsApp1.Models;

namespace WinFormsApp1.Data
{
    public class PersonTestRepository : IPersonRepository
    {
        private readonly List<Person> _people;

        //ctor
        public PersonTestRepository()
        {
            _people = new List<Person>
            {
                new Person { Id = 1, Name = "Андрей", Surename = "Миронов", Sex = "мужской", Birthday = DateTime.Parse("23.05.1989"), Weight = 86 },
                new Person { Id = 2, Name = "Владислав", Surename = "Смирнов", Sex = "мужской", Birthday = DateTime.Parse("03.12.1983"), Weight = 75 },
                new Person { Id = 3, Name = "Вера", Surename = "Брежнева", Sex = "женский", Birthday = DateTime.Parse("29.08.1998"), Weight = 55 },
            };
        }

        public Task<bool> AddPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));
            if (person.Id != 0)
                throw new ArgumentException(nameof(person));

            if (_people.Count == 0)
            {
                person.Id = 1;
            }
            else
            {
                person.Id = _people.Max(p => p.Id) + 1;
            }

            _people.Add(person);

            return Task.FromResult(true);
        }

        public Task<List<Person>> GetPeople()
        {
            return Task.FromResult(_people);
        }
    }
}
