using DataLib.Abstractions;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataLibTests.Moks
{
    class MockConnection : IConnection
    {
        //здесь используется фейковый класс, кот. просто отдает
        //тестовые данные, вам же нужно будет написать свой
        //который будет реально отправлять запросы и получать результаты
        MockOracleServerConnection _oracleServer = new MockOracleServerConnection();

        //ctor
        public MockConnection(string ipAddress, string port,
            string sid, string userName, int userId)
        {
            IpAddress = ipAddress;
            Port = port;
            Sid = sid;
            UserName = userName;
            UserId = userId;
        }

        public string IpAddress { get; }
        public string Port { get; }
        public string Sid { get; }
        public int UserId { get; }
        public string UserName { get; }

        public char[] Separators => new[] { ';' };


        public void CloseConnection()
        {
            //здесь как бы закрываем соединение
            Debug.WriteLine("Соединение с сервером закрыто");
        }

        public Task<string[]> GetDataAsync(string sqlRequest)
        {
            string[] result = _oracleServer.Getdata(sqlRequest);
            return Task.FromResult(result);
        }

        public Task<int> UpdateDataAsync(string sqlRequest)
        {
            int result = _oracleServer.Updatedata(sqlRequest, UserId, UserName);
            return Task.FromResult(result);
        }
    }
}
