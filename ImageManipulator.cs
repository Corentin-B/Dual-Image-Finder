using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dual_Image_Finder
{
    class ImageManipulator
    {
        public static Bitmap ResizeBitmap(Bitmap bitmapEnter, int resizeHeight, int resizeWidth)
        {
            Bitmap resizeImage = new Bitmap(resizeWidth, resizeHeight);
            using (Graphics graphics = Graphics.FromImage(resizeImage))
            {
                graphics.DrawImage(bitmapEnter, 0, 0, resizeWidth, resizeHeight);
            }

            return resizeImage;
        }
    }
}
