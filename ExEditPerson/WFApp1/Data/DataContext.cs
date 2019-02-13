using System;
using System.Collections.Generic;
using System.Linq;
using WFApp1.Models;

namespace WFApp1.Data
{
    class DataContext
    {
        private List<Person> _people;

        //ctor
        public DataContext()
        {
            _people = new List<Person>
            {
                new Person { Id = 1, FirstName = "Миша", LastName = "Иванов" },
                new Person { Id = 2, FirstName = "Вика", LastName = "Семенова" },
                new Person { Id = 3, FirstName = "Дима", LastName = "Петров" },
            };
        }

        internal List<Person> GetPeople()
        {
            return _people;
        }

        internal void UpdatePerson(Person currentPerson)
        {
            if (currentPerson == null) throw new ArgumentNullException(nameof(currentPerson));

            var person = _people.SingleOrDefault(p => p.Id == currentPerson.Id);
            if (person == null) return;

            person.FirstName = currentPerson.FirstName;
            person.LastName = currentPerson.LastName;
        }

        internal void Remove(int id)
        {
            var person = _people.SingleOrDefault(p => p.Id == id);
            if (person == null) return;

            _people.Remove(person);
        }

        internal void AddPerson(Person person)
        {
            if (person == null) throw new ArgumentNullException(nameof(person));

            if (_people.Count == 0)
                person.Id = 1;
            else
                person.Id = _people.Max(p => p.Id) + 1;

            _people.Add(person);
        }
    }
}
