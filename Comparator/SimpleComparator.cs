using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dual_Image_Finder.Comparator
{
    class SimpleComparator
    {
        internal static double ImageComparator(InfoImage leftInfoImage, InfoImage rightInfoImage)
        {
            double equal = 0;
            double notequal = 0;

            Bitmap resizeRightInfoImage = ImageManipulator.ResizeBitmap(rightInfoImage.Bitmap, leftInfoImage.Bitmap.Height, leftInfoImage.Bitmap.Width);

            //TODO stream (IEnumerable) ?

            for (int i = 0; i < leftInfoImage.Bitmap.Width; i++)
            {
                for (int j = 0; j < leftInfoImage.Bitmap.Height; j++)
                {
                    string pixelLeft = leftInfoImage.Bitmap.GetPixel(i, j).Name.ToString();
                    string pixelRight = resizeRightInfoImage.GetPixel(i, j).Name.ToString();

                    if (pixelLeft == pixelRight)
                    {
                        equal++;
                    }
                    else
                    {
                        notequal++;
                    }
                }
            }

            if (equal == 0)
            {
                return 0;
            }
            else
            {
                return Math.Floor((equal / (equal + notequal)) * 100);
            }
        }
    }
}
