using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Dual_Image_Finder
{
    class TComparator
    {
        private string folderPath;
        private readonly MainForm mainForm;
        private int comparisonRate;

        public TComparator(MainForm mainForm, string folderPath, int comparisonRate)
        {
            this.mainForm = mainForm;
            this.folderPath = folderPath;
            this.comparisonRate = comparisonRate;
        }

        public void ThreadSupervisor()
        {
            ImageFinder imageFinder = new ImageFinder();
            List<InfoImage> listInfoImage = imageFinder.GetImagesInFolder(folderPath);

            StartComparator(listInfoImage);
            mainForm.LeftInfoImage = listInfoImage[0];
        }

        private void StartComparator(List<InfoImage> listInfoImage)
        {
            bool loopControl = true;
            List<InfoImage> listInfoImageIntern = listInfoImage;

            while (loopControl)
            {
                if (LoopComparator(listInfoImage))
                {
                    //stop Thread and wait next iteration
                    mainForm.AutoEvent = new AutoResetEvent(false);
                    mainForm.AutoEvent.WaitOne();

                    listInfoImageIntern = UpdageList(listInfoImageIntern);
                }
                else
                {
                    loopControl = false;
                }
            }
        }

        private bool LoopComparator(List<InfoImage> listInfoImage)
        {
            int idLeftImage = 0;
            int idRightImage = 0;

            if (mainForm.LeftInfoImage != null)
            {
                InfoImage compareLeftInfoImage = mainForm.LeftInfoImage;
                idLeftImage = listInfoImage.FindIndex(image => image.Name.Equals(compareLeftInfoImage.Name));
            }
            if (mainForm.RightInfoImage != null)
            {
                InfoImage compareRightInfoImage = mainForm.RightInfoImage;
                idRightImage = listInfoImage.FindIndex(image => image.Name.Equals(compareRightInfoImage.Name));
            }

            Comparator comparator = new Comparator(mainForm);
            return comparator.ListImageComparator(listInfoImage, idLeftImage, idRightImage, comparisonRate);
        }

        private List<InfoImage> UpdageList(List<InfoImage> listInfoImage)
        {
            InfoImage updateLeftInfoImage = mainForm.LeftInfoImage;
            InfoImage updateRightInfoImage = mainForm.RightInfoImage;
            List<InfoImage> updateListInfoImage = listInfoImage;

            if (updateLeftInfoImage.Deleted == true)
            {
                updateListInfoImage[updateListInfoImage.FindIndex(ind => ind.Name.Equals(updateLeftInfoImage.Name))] = updateLeftInfoImage;
            }

            if (updateRightInfoImage.Deleted == true)
            {
                updateListInfoImage[updateListInfoImage.FindIndex(ind => ind.Name.Equals(updateRightInfoImage.Name))] = updateRightInfoImage;
            }

            return updateListInfoImage;
        }
    }
}
