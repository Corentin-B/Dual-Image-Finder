using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Dual_Image_Finder
{
    class Comparator
    {
        private readonly MainForm mainForm;

        public Comparator(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public void ListImageComparator(List<InfoImage> listInfoImages, int idLeftImage, int idRightImage)
        {
            int startImage = idLeftImage;

            //Démarer la recherche en fonction des images actuelles
            for (int i = startImage; i < listInfoImages.Count; i++)
            {
                if (!listInfoImages[i].Deleted)
                {
                    InfoImage leftInfoImage = listInfoImages[i];
                    Image imageLeft = Image.FromFile(leftInfoImage.Path);
                    leftInfoImage.Bitmap = new Bitmap(imageLeft);

                    for (int j = i + 1; j < listInfoImages.Count; j++)
                    {
                        if (i <= startImage && j <= idRightImage)
                        {
                            j = idRightImage;
                            continue;
                        }
                        else if (i == j)
                        {
                            continue;
                        }
                        else if (listInfoImages[j].Deleted)
                        {
                            continue;
                        }

                        InfoImage rightInfoImage = listInfoImages[j];
                        Image imageRight = Image.FromFile(rightInfoImage.Path);
                        rightInfoImage.Bitmap = new Bitmap(imageRight);

                        Console.WriteLine(ImageComparator(rightInfoImage, leftInfoImage));

                        mainForm.LeftInfoImage = listInfoImages[i];
                        mainForm.RightInfoImage = listInfoImages[j];
                    }
                }
                mainForm.UpdateLabelNbImgScanned((startImage + i + 1).ToString());
            }
        }

        private string ImageComparator(InfoImage leftInfoImage, InfoImage rightInfoImage)
        {
            double equal = 0;
            double notequal = 0;

            Bitmap resizeRightInfoImage = ResizeBitmap(rightInfoImage.Bitmap, leftInfoImage.Bitmap.Height, leftInfoImage.Bitmap.Width);

            Console.WriteLine(leftInfoImage.Name + " - " + rightInfoImage.Name);
            Console.WriteLine(leftInfoImage.Bitmap.Width + " x " + leftInfoImage.Bitmap.Height);
            Console.WriteLine(rightInfoImage.Bitmap.Width + " x " + rightInfoImage.Bitmap.Height + " --- " + resizeRightInfoImage.Width + " x " + resizeRightInfoImage.Height);

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

            if (notequal == 0)
            {
                return "100%";
            } 
            else if(equal == 0) {
                return "0%";
            }
            else
            {
                if (equal > notequal)
                {
                    return Convert.ToString(100 - ((notequal * 100) / equal)).Substring(0, 5) + "%";
                }
                else
                {
                    return Convert.ToString((equal * 100) / notequal).Substring(0, 5) + "%";
                }
            }
        }

        private Bitmap ResizeBitmap(Bitmap bitmapEnter, int resizeHeight, int resizeWidth)
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
