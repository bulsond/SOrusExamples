using System.Data;

namespace WindowsFormsApp1.Abstractions
{
    public interface IDataContext
    {
        DataSet GetPeople();
    }
}
