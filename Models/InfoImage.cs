using System.Drawing;

namespace Dual_Image_Finder.Models
{
    class InfoImage
    {
        //TODO builder

        public string Name { get; set; }
        public string Path { get; set; }
        public bool DeletedOrMove { get; set; }
        public Bitmap Bitmap { get; set; }

        public InfoImage(string name, string path, bool deleted)
        {
            Name = name;
            Path = path;
            DeletedOrMove = deleted;
        }
    }
}
