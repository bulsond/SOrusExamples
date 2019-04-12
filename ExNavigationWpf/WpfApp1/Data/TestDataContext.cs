using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WpfApp1.Abstractions;
using WpfApp1.Models;

namespace WpfApp1.Data
{
    class TestDataContext : IDataContext
    {
        private readonly List<Person> _people;

        //ctor
        public TestDataContext()
        {
            _people = new List<Person>
            {
                new Person { Id = 1, FirstName = "Иван", LastName = "Сергеев", Birthdate = DateTime.Parse("19.02.1987") },
                new Person { Id = 2, FirstName = "Мария", LastName = "Макарова", Birthdate = DateTime.Parse("01.04.1983") },
                new Person { Id = 3, FirstName = "Ольга", LastName = "Голубкова", Birthdate = DateTime.Parse("01.07.1992") },
                new Person { Id = 4, FirstName = "Архип", LastName = "Ковалев", Birthdate = DateTime.Parse("08.10.1990") },
                new Person { Id = 5, FirstName = "Евгений", LastName = "Муравьев", Birthdate = DateTime.Parse("25.11.1982") },
            };
        }

        public Task<IEnumerable<Person>> GetPeopleAsync()
        {
            List<Person> people = new List<Person>();
            foreach (var p in _people)
            {
                var person = new Person
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthdate = p.Birthdate
                };
                people.Add(person);
            }

            return Task.FromResult(people.AsEnumerable());
        }

        public Task RemovePerson(int id)
        {
            if (id == 0) throw new ArgumentException(nameof(id));

            var person = _people.SingleOrDefault(p => p.Id == id);
            if (person == null)
            {
                Trace.WriteLine($"Не удалось найти чела с id={id} для удаления.");
                return Task.FromResult(0);
            }

            _people.Remove(person);
            return Task.FromResult(1);
        }

        public Task SavePersonAsync(Person currentPerson)
        {
            if (currentPerson == null)
                throw new ArgumentNullException(nameof(currentPerson));

            if (currentPerson.Id == 0)
            {
                AddPerson(currentPerson);
            }
            else
            {
                UpdatePerson(currentPerson);
            }

            return Task.FromResult(1);
        }

        private void AddPerson(Person currentPerson)
        {
            if (_people.Any())
            {
                currentPerson.Id = _people.Max(p => p.Id) + 1;
            }
            else
            {
                currentPerson.Id = 1;
            }

            _people.Add(currentPerson);
        }

        private void UpdatePerson(Person currentPerson)
        {
            var person = _people.SingleOrDefault(p => p.Id == currentPerson.Id);
            if (person == null)
            {
                Trace.WriteLine($"Не удалось найти чела с id={currentPerson.Id} для обновления.");
                return;
            }

            person.FirstName = currentPerson.FirstName;
            person.LastName = currentPerson.LastName;
            person.Birthdate = currentPerson.Birthdate;
        }
    }
}
