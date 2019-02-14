using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Data
{
    //класс для работы с БД
    class DataContext
    {
        public async Task<List<Device>> GetDevicesAsync()
        {
            DataTable table = await GetTableDevicesAsync();

            var result = new List<Device>();
            foreach (DataRow row in table.Rows)
            {
                var address = row["Address"].ToString();
                var port = row["Port"].ToString();
                var name = row["Name"].ToString();

                //если данные верны
                if (IsCorrect(address, port, name))
                {
                    result.Add(new Device { IpAddress = address, Port = port, Name = name });
                }
            }

            return result;
        }

        private bool IsCorrect(string address, string port, string name)
        {
            //здесь делаем вашу проверку
            //c помощью вашего
            //Regex regIP = new Regex("...");

            //проверка пройдена
            return true;
        }

        //это чисто моделирование получения ответа от БД
        //у вас должен быть запрос к реальной базе
        //и получение таблицы, ну или сразу коллекции чего-то там
        private Task<DataTable> GetTableDevicesAsync()
        {
            var columnAddress = new DataColumn("Address", typeof(string));
            var columnPort = new DataColumn("Port", typeof(string));
            var columnName = new DataColumn("Name", typeof(string));

            var result = new DataTable("Devices");
            result.Columns.Add(columnAddress);
            result.Columns.Add(columnPort);
            result.Columns.Add(columnName);

            var row = result.NewRow();
            row["Address"] = "192.168.0.10";
            row["Port"] = "4001";
            row["Name"] = "2-100-100";
            result.Rows.Add(row);

            row = result.NewRow();
            row["Address"] = "192.168.0.22";
            row["Port"] = "8080";
            row["Name"] = "1-10-101";
            result.Rows.Add(row);

            row = result.NewRow();
            row["Address"] = "192.168.0.101";
            row["Port"] = "4002";
            row["Name"] = "1-101-102";
            result.Rows.Add(row);

            return Task.FromResult(result);
        }
    }
}
