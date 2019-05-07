using MySql.Data.MySqlClient;
using RssYandexUi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RssYandexUi.Services
{
    class DataService
    {
        private MySqlConnection GetConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

            //по-идее строку соединения нужно извлекать из конф.файла
            //а не как делается здесь
            builder.Server = "192.168.0.250";
            builder.Port = 3306;
            builder.Database = "games_rss";
            builder.UserID = "admin";
            builder.Password = "Mysql17";
            //!!!Важно при создании БД и таблиц указать кодировку utf8
            //и здесь тоже указать кодировку
            builder.CharacterSet = "utf8";

            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            return connection;
        }

        /// <summary>
        /// Сохранение записей в БД
        /// </summary>
        /// <param name="items"></param>
        internal async Task SaveItems(List<RssItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
            {
                //ищем запись с таким же Id
                RssItem oldItem = await GetItemById(item.Id);
                //если такая же запись уже есть пропускаем ее
                if (oldItem != null) continue;

                //запоминаем
                await SaveItem(item);
            }
        }

        /// <summary>
        /// Поиск записи по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<RssItem> GetItemById(string id)
        {
            RssItem result = null;

            try
            {
                using (var connection = GetConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM items WHERE id = @id";
                    command.Parameters.AddWithValue("id", id);

                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        result = new RssItem
                        {
                            Id = reader.GetFieldValue<string>(0),
                            Title = reader.GetFieldValue<string>(1),
                            Description = reader.GetFieldValue<string>(2),
                            Date = reader.GetFieldValue<DateTime>(3),
                            Link = new Uri(reader.GetFieldValue<string>(4))
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка в {nameof(GetItemById)}: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Сохранение новой записи
        /// </summary>
        /// <param name="item"></param>
        private async Task<int> SaveItem(RssItem item)
        {
            int result = 0;

            try
            {
                using (var connection = GetConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO items (id, title, description, date, link)" +
                        " VALUES (@id, @title, @description, @date, @link)";
                    command.Parameters.AddWithValue("id", item.Id);
                    command.Parameters.AddWithValue("title", item.Title);
                    command.Parameters.AddWithValue("description", item.Description);
                    command.Parameters.AddWithValue("date", item.Date);
                    command.Parameters.AddWithValue("link", item.Link);

                    await connection.OpenAsync();
                    result = await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка в {nameof(SaveItem)}: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Извлечение всех записей
        /// </summary>
        /// <returns></returns>
        internal async Task<List<RssItem>> GetItems()
        {
            var result = new List<RssItem>();

            try
            {
                using (var connection = GetConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM items ORDER BY date";

                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var item = new RssItem
                        {
                            Id = reader.GetFieldValue<string>(0),
                            Title = reader.GetFieldValue<string>(1),
                            Description = reader.GetFieldValue<string>(2),
                            Date = reader.GetFieldValue<DateTime>(3),
                            Link = new Uri(reader.GetFieldValue<string>(4))
                        };

                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка в {nameof(GetItems)}: {ex.Message}");
            }

            return result;
        }
    }
}
