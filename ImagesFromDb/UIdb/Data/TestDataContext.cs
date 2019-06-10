using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using UIdb.Abstractions;
using UIdb.Models;

namespace UIdb.Data
{
    class TestDataContext : IDataContext
    {
        public Task<List<Picture>> GetPictures()
        {
            List<Picture> result = new List<Picture>
            {
                new Picture { Id = 1, Name = "Картинка 1", Description = "Первая картинка",
                    Pic = Image.FromFile(@"Data\cat1.jpg") },
                new Picture { Id = 2, Name = "Картинка 2", Description = "Вторая картинка",
                    Pic = Image.FromFile(@"Data\cat2.jpg") },
                new Picture { Id = 3, Name = "Картинка 3", Description = "Третья картинка",
                    Pic = Image.FromFile(@"Data\cat3.jpg") },
            };

            return Task.FromResult(result);
        }
    }
}
