namespace WinFormsMySql.Models
{
    public class Employee
    {
        public int Id { get; set; }
        //порядковый номер для отображения в DGV
        public int OrderNumber { get; set; }
        //имя
        public string FirstName { get; set; }
        //фамилия
        public string LastName { get; set; }
        public string Phone { get; set; }

        public Employee(int id, string firstName = "<?>", string lastName = "<?>", string phone = "<?>")
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        /// <summary>
        /// Получение клонированного экземпляра
        /// </summary>
        /// <param name="employee">существующий экземпляр</param>
        /// <returns>клон существующего сотрудника</returns>
        public static Employee GetClone(Employee employee)
        {
            if (employee is null)
                throw new System.ArgumentNullException(nameof(employee));

            return new Employee(employee.Id)
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Phone = employee.Phone,
            };
        }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName}";
        }
    }
}
