using System.Collections.Generic;
using System.Threading.Tasks;
using UIdb.Models;

namespace UIdb.Abstractions
{
    public interface IDataContext
    {
        Task<List<Picture>> GetPictures();
    }
}
