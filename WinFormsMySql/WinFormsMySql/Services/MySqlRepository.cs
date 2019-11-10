using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using WinFormsMySql.Interfaces;
using WinFormsMySql.Models;
using WinFormsMySql.Utils;

namespace WinFormsMySql.Services
{
    class MySqlRepository : IEmployeeRepository
    {
        public MySqlRepository()
        { }

        private MySqlConnection GetConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings["MySqlConn"].ToString();
            var builder = new MySqlConnectionStringBuilder(cs);
            //чтоб избежать проблем с русским языком
            builder.CharacterSet = "utf8";
            return new MySqlConnection(builder.ConnectionString);
        }

        public async Task<Result<List<Employee>>> GetEmployees()
        {
            var list = new List<Employee>();

            try
            {
                using (var con = GetConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM employees";
                    con.Open();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var emp = new Employee(reader.GetInt32(0));
                            emp.FirstName = reader.GetString(1);
                            emp.LastName = reader.GetString(2);
                            emp.Phone = reader.GetString(3);

                            list.Add(emp);
                        }
                    }
                }

            }
            catch (MySqlException ex)
            {
                return new Result<List<Employee>>(GetUserFriendlyErrorMessage(ex));
            }
            catch (Exception ex)
            {
                return new Result<List<Employee>>(ex.Message);
            }

            return new Result<List<Employee>>(list);
        }

        public async Task<Result<int>> AddEmployee(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            int result = 0;
            try
            {
                using (var con = GetConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO employees (first_name, last_name, phone)" +
                        " VALUES(@firstName, @lastName, @phone)";

                    cmd.Parameters.Add(new MySqlParameter("@firstName", MySqlDbType.VarChar, 200)
                    { Value = employee.FirstName });

                    cmd.Parameters.Add(new MySqlParameter("@lastName", MySqlDbType.VarChar, 300)
                    { Value = employee.LastName });

                    cmd.Parameters.Add(new MySqlParameter("@phone", MySqlDbType.VarChar, 45)
                    {
                        Value = employee.Phone ?? (object)System.DBNull.Value
                    });

                    con.Open();
                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (MySqlException ex)
            {
                return new Result<int>(GetUserFriendlyErrorMessage(ex));
            }
            catch (Exception ex)
            {
                return new Result<int>(ex.Message);
            }

            return new Result<int>(result);
        }

        public async Task<Result<int>> RemoveEmployee(int id)
        {
            if (id <= 0)
                throw new ArgumentException(nameof(id));

            int result = 0;
            try
            {
                using (var con = GetConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM employees WHERE id =@id";

                    cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32)
                    { Value = id });

                    con.Open();
                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (MySqlException ex)
            {
                return new Result<int>(GetUserFriendlyErrorMessage(ex));
            }
            catch (Exception ex)
            {
                return new Result<int>(ex.Message);
            }

            return new Result<int>(result);
        }

        public async Task<Result<int>> UpdateEmployee(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            int result = 0;
            try
            {
                using (var con = GetConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE employees" +
                        " SET first_name = @firstName, last_name = @lastName, phone = @phone" +
                        " WHERE id =@id";

                    cmd.Parameters.Add(new MySqlParameter("@firstName", MySqlDbType.VarChar, 200)
                    { Value = employee.FirstName });

                    cmd.Parameters.Add(new MySqlParameter("@lastName", MySqlDbType.VarChar, 300)
                    { Value = employee.LastName });

                    cmd.Parameters.Add(new MySqlParameter("@phone", MySqlDbType.VarChar, 45)
                    {
                        Value = employee.Phone ?? (object)System.DBNull.Value
                    });

                    cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32)
                    { Value = employee.Id });

                    con.Open();
                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (MySqlException ex)
            {
                return new Result<int>(GetUserFriendlyErrorMessage(ex));
            }
            catch (Exception ex)
            {
                return new Result<int>(ex.Message);
            }

            return new Result<int>(result);
        }

        private string GetUserFriendlyErrorMessage(MySqlException ex)
        {
            var message = String.Empty;
            switch (ex.Number)
            {
                case 0:
                    if (ex.InnerException.Message.Contains("Unknown"))
                    {
                        message = "Неверное название схемы или таблицы.";
                    }
                    else if (ex.InnerException.Message.Contains("Access"))
                    {
                        message = "Неверное имя или пароль доступа.";
                    }
                    else
                    {
                        message = ex.Message;
                    }
                    break;
                case 1042:
                    message = "Сервер по указанному адресу не доступен." +
                        "\nОшибка ожидания.";
                    break;
                case 1045:
                    message = "Неверное имя пользователя или пароль, " +
                        "\nпожалуйста, попробуйте еще раз.";
                    break;
                default:
                    message = ex.Message;
                    break;
            }
            return message;
        }
    }
}
