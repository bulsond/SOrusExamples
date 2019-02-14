using DataLib.Models;

namespace DataLib.Abstractions
{
    public interface ILabRepository : IRepository<Lab>
    {
        IConnection Connection { get; }

        //здесь можно добавить объявление необходимых методов
        //актуальных для данной сущности
    }
}
