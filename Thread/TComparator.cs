using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Dual_Image_Finder
{
    class TComparator
    {
        private string folderPath;

        public TComparator(string folderPath)
        {
            this.folderPath = folderPath;
        }

        public void ThreadSupervisor()
        {
            ImageFinder imageFinder = new ImageFinder();
            List<InfoImage> listInfoImage = imageFinder.GetImagesInFolder(folderPath);

            ImageComparator(listInfoImage);
        }

        private void ImageComparator(List<InfoImage> listInfoImages)
        {
            for (int i = 0; i < listInfoImages.Count; i++)
            {
                Console.WriteLine(listInfoImages[i].Deleted);

                for (int j = i+1; j < listInfoImages.Count; j++)
                {
                    if (listInfoImages[i].Equals(listInfoImages[j]))
                    {
                        Console.WriteLine(true);
                    }
                }
            }
        }
    }
}
