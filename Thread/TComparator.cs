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

            while (loopControl)
            {
                if (LoopComparator(listInfoImage))
                {
                    //stop Thread and wait next iteration
                    mainForm.AutoEvent = new AutoResetEvent(false);
                    Console.WriteLine("Before WaitOne");
                    mainForm.AutoEvent.WaitOne();
                    Console.WriteLine("After WaitOne");
                }
                else
                {
                    loopControl = false;
                }
                Console.WriteLine("Continue Thread");
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
    }
}
