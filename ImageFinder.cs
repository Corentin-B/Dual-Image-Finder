using Dual_Image_Finder.Models;
using System.Collections.Generic;
using System.IO;

namespace Dual_Image_Finder
{
    class ImageFinder
    {
        public static List<InfoImage> GetImagesInFolder(string pathFolder)
        {
            string[] fileInFolder = Directory.GetFiles(pathFolder, "*.*g", SearchOption.TopDirectoryOnly);
            List<InfoImage> listInfoImages = new List<InfoImage>();

            foreach (string file in fileInFolder)
            {
                string name = Path.GetFileName(file);
                string path = file;

                InfoImage infoImage = new InfoImage(name, path);

                listInfoImages.Add(infoImage);
            }
            return listInfoImages;
        }
    }
}
