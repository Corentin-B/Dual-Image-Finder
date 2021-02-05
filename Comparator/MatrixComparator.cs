using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dual_Image_Finder.Comparator
{
    class MatrixComparator
    {
        internal static double ImageComparator(InfoImage leftInfoImage, InfoImage rightInfoImage)
        {
            double equal = 0;
            double notequal = 0;
            int matrixSize = 3;

            Bitmap resizeRightInfoImage = ImageManipulator.ResizeBitmap(rightInfoImage.Bitmap, leftInfoImage.Bitmap.Height, leftInfoImage.Bitmap.Width);

            int widthRest = leftInfoImage.Bitmap.Width % matrixSize;
            int heightRest = leftInfoImage.Bitmap.Width % matrixSize;

            for (int i = 0; i < leftInfoImage.Bitmap.Width - widthRest; i += matrixSize)
            {
                for (int j = 0; j < leftInfoImage.Bitmap.Height - heightRest; j += matrixSize)
                {
                    Bitmap leftBitmap = GetBitmapMatrix(leftInfoImage.Bitmap, i, j ,matrixSize);
                    Bitmap rightBitmap = GetBitmapMatrix(resizeRightInfoImage, i, j, matrixSize);

                    Color leftColor = GetAverageColor(leftBitmap);
                    Color RightColor = GetAverageColor(rightBitmap);

                    if (leftColor == RightColor)
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

        private static Bitmap GetBitmapMatrix(Bitmap bitmapEnter, int WidthPixelStart, int HeightPixelStart , int matrixSize)
        {
            Bitmap resizeImage = new Bitmap(matrixSize, matrixSize);
            using (Graphics graphics = Graphics.FromImage(resizeImage))
            {
                graphics.DrawImage(bitmapEnter, WidthPixelStart, HeightPixelStart, matrixSize, matrixSize);
            }

            return resizeImage;
        }

        //
        // Code from
        // https://gist.github.com/lukemeyer/3713450
        //
        private static Color GetAverageColor(Bitmap bmp)
        {

            //Used for tally
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel(x, y);

                    r += clr.R;
                    g += clr.G;
                    b += clr.B;

                    total++;
                }
            }

            //Calculate average
            r /= total;
            g /= total;
            b /= total;

            return Color.FromArgb(r, g, b);
        }
    }
}
