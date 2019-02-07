using System;
using System.Collections.Generic;
using System.Data;
using WindowsFormsApp1.Abstractions;
using WindowsFormsApp1.Data.Models;

namespace WindowsFormsApp1.Data
{
    class TestDataContext : IDataContext
    {
        private static List<Person> _people;

        //ctor
        public TestDataContext()
        {
            _people = new List<Person>
            {
                new Person { Id = 1, LastName = "Иванов", FirstName = "Григорий", Age = 25 },
                new Person { Id = 2, LastName = "Иванов", FirstName = "Дмитрий", Age = 15 },
                new Person { Id = 3, LastName = "Иванова", FirstName = "Дарья", Age = 34 },
                new Person { Id = 4, LastName = "Миронов", FirstName = "Сергей", Age = 26 },
                new Person { Id = 5, LastName = "Миронова", FirstName = "Фаина", Age = 17 },
                new Person { Id = 6, LastName = "Миронова", FirstName = "Анна", Age = 47 },
                new Person { Id = 7, LastName = "Савченко", FirstName = "Юлия", Age = 17 },
                new Person { Id = 8, LastName = "Савченко", FirstName = "Аркадий", Age = 22 },
                new Person { Id = 9, LastName = "Дроздов", FirstName = "Виктор", Age = 25 },
                new Person { Id = 10, LastName = "Кудрявцев", FirstName = "Вячеслав", Age = 32 },
                new Person { Id = 11, LastName = "Кулешов", FirstName = "Сергей", Age = 41 },
            };
        }

        public DataSet GetPeople()
        {
            DataTable table = new DataTable("People");

            DataColumn columnID = new DataColumn();
            columnID.DataType = typeof(int);
            columnID.ColumnName = "Id";
            columnID.ReadOnly = false;
            columnID.Unique = true;

            table.Columns.Add(columnID);

            DataColumn columnFN = new DataColumn();
            columnFN.DataType = typeof(String);
            columnFN.ColumnName = "FirstName";
            columnFN.ReadOnly = false;
            columnFN.Unique = false;

            table.Columns.Add(columnFN);

            DataColumn columnLN = new DataColumn();
            columnLN.DataType = typeof(String);
            columnLN.ColumnName = "LastName";
            columnLN.ReadOnly = false;
            columnLN.Unique = false;

            table.Columns.Add(columnLN);

            DataColumn columnAge = new DataColumn();
            columnAge.DataType = typeof(int);
            columnAge.ColumnName = "Age";
            columnAge.ReadOnly = false;
            columnAge.Unique = false;

            table.Columns.Add(columnAge);

            LoadDataToTablePeople(table);

            DataSet result = new DataSet();
            result.Tables.Add(table);

            return result;
        }

        private void LoadDataToTablePeople(DataTable table)
        {
            foreach (var person in _people)
            {
                var row = table.NewRow();
                row["Id"] = person.Id;
                row["FirstName"] = person.FirstName;
                row["LastName"] = person.LastName;
                row["Age"] = person.Age;

                table.Rows.Add(row);
            }
        }
    }
}
