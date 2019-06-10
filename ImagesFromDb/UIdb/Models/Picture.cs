using System.Drawing;
using System.IO;

namespace UIdb.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Pic { get; set; }

        public void SetPicFromBlob(Stream blob)
        {
            Pic = Image.FromStream(blob);
        }
    }
}
