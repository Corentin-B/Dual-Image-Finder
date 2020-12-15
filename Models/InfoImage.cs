using System.Drawing;

namespace Dual_Image_Finder.Models
{
    class InfoImage
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Bitmap { get; set; }
        public bool Deleted { get; set; }

        public InfoImage(string name, string path, string bitmap, bool deleted)
        {
            Name = name;
            Path = path;
            Bitmap = bitmap;
            Deleted = deleted;
        }

        public InfoImage()
        {
        }
    }
}
