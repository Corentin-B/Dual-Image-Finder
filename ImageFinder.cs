using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Dual_Image_Finder
{
    class ImageFinder
    {
        public List<InfoImage> GetImagesInFolder(string pathFolder)
        {
            string[] fileInFolder = Directory.GetFiles(pathFolder, "*.*g", SearchOption.AllDirectories);
            List<InfoImage> listInfoImages = new List<InfoImage>();

            foreach (string file in fileInFolder)
            {
                string name = Path.GetFileName(file);
                string path = file;
                bool deleted = false;

                InfoImage infoImage = new InfoImage(name, path, deleted); ;

                listInfoImages.Add(infoImage);
            }
            return listInfoImages;
        }
    }
}
