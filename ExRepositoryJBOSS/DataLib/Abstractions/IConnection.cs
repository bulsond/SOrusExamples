using System.Threading.Tasks;

namespace DataLib.Abstractions
{
    public interface IConnection
    {
        string IpAddress { get; }
        string Port { get; }
        string Sid { get; }
        int UserId { get; }
        string UserName { get; }

        //разделитель в строке результата
        char[] Separators { get; }

        //закрытие соединения с сервером
        //возможно понадобится...
        void CloseConnection();

        Task<string[]> GetDataAsync(string sqlRequest);
        Task<int> UpdateDataAsync(string sqlRequest);
    }
}
