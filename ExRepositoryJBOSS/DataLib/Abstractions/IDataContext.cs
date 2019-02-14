using System;

namespace DataLib.Abstractions
{
    public interface IDataContext : IDisposable
    {
        IConnection Connection { get; }
        ILabRepository LabRepository { get; }
        IKnchRepository KnchRepository { get; }
    }
}
