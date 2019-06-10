using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading.Tasks;
using UIdb.Abstractions;
using UIdb.Models;

namespace UIdb.Data
{
    class SQLiteDataContext : IDataContext
    {
        private const string _PathToFile_ = @"Data\imagesdb.sqlite";

        /// <summary>
        /// Создание соединения с файлом БД
        /// </summary>
        /// <returns></returns>
        private SQLiteConnection GetConnection()
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = _PathToFile_;

            return new SQLiteConnection(builder.ConnectionString);
        }

        /// <summary>
        /// Получение всего списка картинок
        /// </summary>
        /// <returns></returns>
        public async Task<List<Picture>> GetPictures()
        {
            var result = new List<Picture>();

            using (SQLiteConnection cn = GetConnection())
            using (SQLiteCommand cm = cn.CreateCommand())
            {
                cm.CommandText = "SELECT * FROM images;";
                await cn.OpenAsync();

                using (var reader = await cm.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var picture = GetPictureFromRow(reader);
                            result.Add(picture);
                        }
                    }
                }

            }

            return result;
        }

        /// <summary>
        /// Создание экземпляра Picture
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Picture GetPictureFromRow(DbDataReader reader)
        {
            var result = new Picture
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2)
            };

            result.SetPicFromBlob(reader.GetStream(3));

            return result;
        }
    }
}
