using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dual_Image_Finder
{
    class Comparator
    {
        public void ImageComparator(List<InfoImage> listInfoImages)
        {
            for (int i = 0; i < listInfoImages.Count; i++)
            {
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
