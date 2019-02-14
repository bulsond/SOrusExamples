using DataLib.Models;

namespace DataLib.Abstractions
{
    public interface IKnchRepository : IRepository<Knch>
    {
        IConnection Connection { get; }

        //здесь можно добавить объявление необходимых методов
        //актуальных для данной сущности
    }
}
