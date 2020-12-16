using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Dual_Image_Finder
{
    class ImageFinder
    {
        public List<InfoImage> GetImagesInFolder(string PathFolder)
        {
            string[] FileInFolder = Directory.GetFiles(PathFolder, "*.*g", SearchOption.AllDirectories);
            List<InfoImage> listInfoImages = new List<InfoImage>();

            foreach (string File in FileInFolder)
            {
                InfoImage infoImage = new InfoImage();
                infoImage.Name = Path.GetFileName(File);
                infoImage.Path = File;

                Image image = Image.FromFile(File);
                Bitmap bitmapImage = new Bitmap(image);

                MemoryStream ms = new MemoryStream();
                bitmapImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                String imageBitmap = Convert.ToBase64String(ms.ToArray());
                ms.Position = 0;

                infoImage.Bitmap = imageBitmap;
                infoImage.Deleted = false;

                listInfoImages.Add(infoImage);
            }
            return listInfoImages;
        }
    }
}
