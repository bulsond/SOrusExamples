using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    [Serializable]
    public class Person : IDataErrorInfo
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public int Weight { get; set; }

        //эти свойства я убрал, чтоб слегка облегчить пример
        //public string Country { get; set; }
        //public string City { get; set; }
        //public int Height { get; set; }
        //public string HairColor { get; set; }
        //public string EyeColor { get; set; }
        //public string ZodiacSign { get; set; }

        #region Реализация IDataErrorInfo
        public string Error => String.Empty;
        public string this[string columnName]
        {
            get
            {
                if (columnName.Equals(nameof(Name)) && String.IsNullOrEmpty(Name))
                {
                    return "Введите имя";
                }

                if (columnName.Equals(nameof(Name)) && Name.Any(c => Char.IsDigit(c)))
                {
                    return "Имя не должно содержать цифры";
                }

                if (columnName.Equals(nameof(Surename)) && String.IsNullOrEmpty(Surename))
                {
                    return "Введите фамилию";
                }

                if (columnName.Equals(nameof(Surename)) && Surename.Any(c => Char.IsDigit(c)))
                {
                    return "Фамилия не должна содержать цифры";
                }

                if (columnName.Equals(nameof(Sex)) && String.IsNullOrEmpty(Sex))
                {
                    return "Выберите пол";
                }

                if (columnName.Equals(nameof(Weight)) && Weight <= 5)
                {
                    return "Введите вес в килограммах";
                }

                if (columnName.Equals(nameof(Birthday)) &&
                    (Birthday <= DateTime.Now.AddYears(-100) || Birthday > DateTime.Now.AddYears(-1)))
                {
                    return "Введите дату рождения правильно";
                }

                return String.Empty;
            }
        }
        #endregion
    }
}
