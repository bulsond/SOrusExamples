using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Abstractions;
using WpfApp1.Model;

namespace WpfApp1.Data
{
    class TestRepository : IRepository
    {
        private List<PersonModel> _people;

        public Task<List<PersonModel>> GetPeopleAsync()
        {
            if (_people == null)
            {
                _people = new List<PersonModel>
                {
                    new PersonModel(1) { FirstName = "Александр", LastName = "Большой" },
                    new PersonModel(2) { FirstName = "Александр", LastName = "Горький" },
                    new PersonModel(3) { FirstName = "Александр", LastName = "Высокий" },
                    new PersonModel(4) { FirstName = "Владимир", LastName = "Горячев" },
                    new PersonModel(5) { FirstName = "Владимир", LastName = "Бондаренко" },
                    new PersonModel(6) { FirstName = "Кирилл", LastName = "Гвоздев" },
                    new PersonModel(7) { FirstName = "Кирилл", LastName = "Гундяев" },
                    new PersonModel(8) { FirstName = "Федор", LastName = "Емельяненко" },
                    new PersonModel(9) { FirstName = "Борис", LastName = "Гундяев" },
                };
            }

            return Task.FromResult(_people);
        }

        public Task<List<PersonModel>> SearchPeopleAsync(PersonSearchModel searchPerson)
        {
            if (searchPerson == null) throw new ArgumentNullException(nameof(searchPerson));
            List<PersonModel> result = null;

            if (searchPerson.FirstNameLetter != '?' && searchPerson.LastNameLetter != '?')
            {
                //поиск по фамилии и имени
                string fName = searchPerson.FirstNameLetter.ToString();
                string lName = searchPerson.LastNameLetter.ToString();

                result = _people.Where(p => p.FirstName.StartsWith(fName) && p.LastName.StartsWith(lName))
                                .ToList();
            }
            else if (searchPerson.FirstNameLetter != '?' && searchPerson.LastNameLetter == '?')
            {
                //поиск по имени
                string fName = searchPerson.FirstNameLetter.ToString();

                result = _people.Where(p => p.FirstName.StartsWith(fName))
                                .ToList();
            }
            else if (searchPerson.FirstNameLetter == '?' && searchPerson.LastNameLetter != '?')
            {
                //поиск по фамилии
                string lName = searchPerson.LastNameLetter.ToString();

                result = _people.Where(p => p.LastName.StartsWith(lName))
                                .ToList();
            }
            else
            {
                result = new List<PersonModel>();
            }

            return Task.FromResult(result);
        }
    }
}
