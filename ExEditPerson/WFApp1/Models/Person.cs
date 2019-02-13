using System;
using System.ComponentModel;

namespace WFApp1.Models
{
    public class Person : IDataErrorInfo
    {

        public static readonly string Dummy = "<?>";
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        #region Реализация IDataErrorInfo
        public string _Error;
        public string Error => _Error;
        public string this[string columnName]
        {
            get
            {
                if (columnName.Equals(nameof(FirstName)) && String.IsNullOrEmpty(FirstName))
                {
                    _Error = "FirstName";
                    return "Имя не может быть пустым";
                }

                if (columnName.Equals(nameof(FirstName)) && FirstName.Contains(Dummy))
                {
                    _Error = "FirstName";
                    return "Укажите имя";
                }

                if (columnName.Equals(nameof(LastName)) && String.IsNullOrEmpty(LastName))
                {
                    _Error = "LastName";
                    return "Фамилия не может быть пустой";
                }

                if (columnName.Equals(nameof(LastName)) && LastName.Contains(Dummy))
                {
                    _Error = "LastName";
                    return "Укажите фамилию";
                }

                _Error = String.Empty;
                return _Error;
            }
        } 
        #endregion
    }
}
