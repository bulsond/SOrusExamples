using System;
using System.Collections.Generic;
using System.Data;

namespace WindowsFormsApp1
{
    class DataContext
    {
        private List<Person> _people;
        //ctor
        public DataContext()
        {
            _people = new List<Person>
            {
                new Person { Name = "Иванов Григорий" },
                new Person { Name = "Иванов Максим" },
                new Person { Name = "Иванова Мария" },
                new Person { Name = "Иванова Мирослава" },
                new Person { Name = "Иванов Геннадий" },
                new Person { Name = "Иванова Наталья" },
                new Person { Name = "Сергеев Владимир" },
                new Person { Name = "Сергеева Виктория" },
                new Person { Name = "Сергеев Михаил" },
                new Person { Name = "Сергеев Григорий" },
                new Person { Name = "Серёгин Дмитрий" },
                new Person { Name = "Серёгина Дарья" },
            };
        }

        internal List<Person> GetPeople()
        {
            return _people;
        }

        internal DataView GetPeopleView()
        {
            DataTable table = new DataTable("People");

            DataColumn column = new DataColumn();
            column.DataType = typeof(String);
            column.ColumnName = "Name";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            foreach (var person in _people)
            {
                var row = table.NewRow();
                row["Name"] = person.Name;
                table.Rows.Add(row);
            }

            return new DataView(table);
        }

        internal DataSet GetPeopleSet()
        {
            DataColumn column = new DataColumn();
            column.DataType = typeof(String);
            column.ColumnName = "Name";
            column.ReadOnly = false;
            column.Unique = false;

            DataTable table = new DataTable("People");
            table.Columns.Add(column);

            foreach (var person in _people)
            {
                var row = table.NewRow();
                row["Name"] = person.Name;
                table.Rows.Add(row);
            }

            DataSet result = new DataSet();
            result.Tables.Add(table);

            return result;
        }
    }
}
