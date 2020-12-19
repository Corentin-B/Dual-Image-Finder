using Dual_Image_Finder.Models;
using System.Collections.Generic;

namespace Dual_Image_Finder
{
    class TComparator
    {
        private string folderPath;
        private readonly MainForm mainForm;


        public TComparator(MainForm mainForm, string folderPath)
        {
            this.mainForm = mainForm;
            this.folderPath = folderPath;
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
            int idLeftImage = 0;
            int idRightImage = 0;

            if (mainForm.LeftInfoImage != null)
            {
                idLeftImage = listInfoImage.FindIndex(image => image.Name == mainForm.LeftInfoImage.Name);
            }
            if (mainForm.RightInfoImage != null)
            {
                idRightImage = listInfoImage.FindIndex(image => image.Name == mainForm.LeftInfoImage.Name);
            }

            Comparator comparator = new Comparator(mainForm);
            comparator.ListImageComparator(listInfoImage, idLeftImage, idRightImage);
        }
    }
}
