using DataLib.Abstractions;
using DataLib.Repositories;
using System;

namespace DataLib
{
    public class DataContext : IDataContext
    {
        //ctor
        public DataContext(IConnection connection)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));

            LabRepository = new LabRepository(Connection);
            KnchRepository = new KnchRepository(Connection);
        }

        public IConnection Connection { get; }
        public ILabRepository LabRepository { get; }
        public IKnchRepository KnchRepository { get; }

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.CloseConnection();
            }
        }
    }
}
