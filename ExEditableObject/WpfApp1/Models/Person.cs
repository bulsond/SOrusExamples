using System.ComponentModel;

namespace WpfApp1.Models
{
    public class Person : INotifyPropertyChanged, IEditableObject
    {
        //ссылка на экземпляр хранения предыд.значений на время редактирования
        private Person _tempValues;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        private int _OrderNumber;
        public int OrderNumber
        {
            get => _OrderNumber;
            set
            {
                _OrderNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrderNumber)));
            }
        }


        private string _FirstName;
        public string FirstName
        {
            get => _FirstName;
            set
            {
                _FirstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set
            {
                _LastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }

        #region Реализация IEditableObject

        /// <summary>
        /// Когда начинается редактирование
        /// </summary>
        public void BeginEdit()
        {
            _tempValues = new Person
            {
                Id = this.Id,
                OrderNumber = this.OrderNumber,
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }

        /// <summary>
        /// Когда редактирование завершено
        /// </summary>
        public void EndEdit()
        {
            _tempValues = null;
        }

        /// <summary>
        /// Когда редактирование отменяется
        /// </summary>
        public void CancelEdit()
        {
            if (_tempValues == null) return;

            this.Id = _tempValues.Id;
            this.OrderNumber = _tempValues.OrderNumber;
            this.FirstName = _tempValues.FirstName;
            this.LastName = _tempValues.LastName;
        } 
        #endregion
    }

}
