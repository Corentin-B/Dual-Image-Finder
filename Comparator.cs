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

        public bool ListImageComparator(List<InfoImage> listInfoImages, int idLeftImage, int idRightImage, int comparisonRate)
        {
            int startImage = idLeftImage;
            mainForm.UpdateLabelNbImgScanned((startImage + 1).ToString() + " /" + listInfoImages.Count);

            //Démarer la recherche en fonction des images actuelles
            for (int i = startImage; i < listInfoImages.Count; i++)
            {
                if (!listInfoImages[i].DeletedOrMove)
                {
                    InfoImage leftInfoImage = GetInfoImageBitmap(listInfoImages[i]);

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
                        else if (listInfoImages[j].DeletedOrMove)
                        {
                            continue;
                        }

                        InfoImage rightInfoImage = GetInfoImageBitmap(listInfoImages[j]);

                        mainForm.LeftInfoImage = listInfoImages[i];
                        mainForm.RightInfoImage = listInfoImages[j];
                        mainForm.UpdateLabelPercentage("Searching");

                        double comparatorPercent = ImageComparator(rightInfoImage, leftInfoImage);

                        mainForm.UpdateLabelPercentage(comparatorPercent.ToString() + "%");

                        if (comparatorPercent >= comparisonRate)
                        {
                            return true;
                        }
                    }
                }
                mainForm.UpdateLabelNbImgScanned((i + 1).ToString() + " /" + listInfoImages.Count);
            }
            return false;
        }

        private double ImageComparator(InfoImage leftInfoImage, InfoImage rightInfoImage)
        {
            double equal = 0;
            double notequal = 0;

            Bitmap resizeRightInfoImage = ResizeBitmap(rightInfoImage.Bitmap, leftInfoImage.Bitmap.Height, leftInfoImage.Bitmap.Width);

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
                return 100;
            }
            else if (equal == 0)
            {
                return 0;
            }
            else
            {
                if (equal > notequal)
                {
                    return Math.Floor(100 - ((notequal * 100) / equal));
                }
                else
                {
                    return Math.Floor((equal * 100) / notequal);
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

        private InfoImage GetInfoImageBitmap(InfoImage infoImage)
        {
            InfoImage newInfoImage = infoImage;

            using (var bmpTemp = new Bitmap(infoImage.Path))
            {
                newInfoImage.Bitmap = new Bitmap(bmpTemp);
            }

            return newInfoImage;
        }
    }
}
