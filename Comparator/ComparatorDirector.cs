using Dual_Image_Finder.Comparator;
using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Dual_Image_Finder
{
    class ComparatorDirector
    {
        private readonly MainForm mainForm;

        public ComparatorDirector(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public bool ListImageComparator(List<InfoImage> listInfoImages, int idLeftImage, int idRightImage, int comparisonRate, bool useMatrix)
        {
            int startImage = idLeftImage;
            mainForm.UpdateLabelNbImgScanned((startImage + 1).ToString() + " / " + listInfoImages.Count);

            for (int i = startImage; i < listInfoImages.Count; i++)
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

                    InfoImage rightInfoImage = GetInfoImageBitmap(listInfoImages[j]);

                    UpdateSearching(listInfoImages[i], listInfoImages[j]);
                    double comparatorPercent;

                    if (useMatrix)
                    {
                        comparatorPercent = MatrixComparator.ImageComparator(leftInfoImage, rightInfoImage);
                    }
                    else
                    {
                        comparatorPercent = SimpleComparator.ImageComparator(leftInfoImage, rightInfoImage);
                    }

                    mainForm.UpdateLabelPercentage(comparatorPercent.ToString() + "%");

                    if (comparatorPercent >= comparisonRate)
                    {
                        return true;
                    }
                }

                mainForm.UpdateLabelNbImgScanned((i + 1).ToString() + " / " + listInfoImages.Count);
            }
            return false;
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

        private void UpdateSearching(InfoImage leftInfoImage, InfoImage rightInfoImage)
        {
            mainForm.LeftInfoImage = leftInfoImage;
            mainForm.RightInfoImage = rightInfoImage;
            mainForm.UpdateLabelPercentage("Searching");
        }
    }
}
