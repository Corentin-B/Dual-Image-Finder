using Dual_Image_Finder.Models;
using System.Collections.Generic;
using System.Threading;

namespace Dual_Image_Finder
{
    class TComparator
    {
        private string folderPath;
        private readonly MainForm mainForm;
        private int comparisonRate;
        private bool auto;
        private bool deleteRequire;

        public TComparator(MainForm mainForm, string folderPath, int comparisonRate, bool auto, bool deleteRequire)
        {
            this.mainForm = mainForm;
            this.folderPath = folderPath;
            this.comparisonRate = comparisonRate;
            this.auto = auto;
            this.deleteRequire = deleteRequire;
        }

        public void ThreadSupervisor()
        {
            ImageFinder imageFinder = new ImageFinder();
            List<InfoImage> listInfoImage = imageFinder.GetImagesInFolder(folderPath);

            LoopComparator(listInfoImage);

            mainForm.ShowStartButton();
        }

        private void LoopComparator(List<InfoImage> listInfoImage)
        {
            bool loopControl = true;
            List<InfoImage> listInfoImageIntern = listInfoImage;

            while (loopControl)
            {
                if (StartComparator(listInfoImage))
                {
                    if (auto)
                    {
                        AutoMoveOrDelete();
                    }
                    else
                    {
                        WaitUser();
                    }
                    listInfoImageIntern = UpdateList(listInfoImageIntern);
                }
                else
                {
                    loopControl = false;
                }
            }
        }

        private bool StartComparator(List<InfoImage> listInfoImage)
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

        private List<InfoImage> UpdateList(List<InfoImage> listInfoImage)
        {
            InfoImage updateLeftInfoImage = mainForm.LeftInfoImage;
            InfoImage updateRightInfoImage = mainForm.RightInfoImage;
            List<InfoImage> updateListInfoImage = listInfoImage;

            if (updateLeftInfoImage.DeletedOrMove == true)
            {
                int idLeftImage = listInfoImage.FindIndex(image => image.Name.Equals(updateLeftInfoImage.Name));
                updateListInfoImage.RemoveAt(idLeftImage);
            }

            if (updateRightInfoImage.DeletedOrMove == true)
            {
                int idRightImage = listInfoImage.FindIndex(image => image.Name.Equals(updateRightInfoImage.Name));
                updateListInfoImage.RemoveAt(idRightImage);
            }

            return updateListInfoImage;
        }

        private void AutoMoveOrDelete()
        {
            MoveDeleteImage moveDeleteImage = new MoveDeleteImage();
            if (deleteRequire)
            {
                mainForm.RemoveRightImage();
                mainForm.RightInfoImage.Bitmap = null;

                moveDeleteImage.DeleteImage(mainForm.RightInfoImage.Path);
                mainForm.RightInfoImage.DeletedOrMove = true;
            }
            else
            {
                mainForm.RemoveRightImage();
                mainForm.RightInfoImage.Bitmap = null;

                moveDeleteImage.MoveImage(mainForm.RightInfoImage.Path, folderPath, mainForm.RightInfoImage.Name);
                mainForm.RightInfoImage.DeletedOrMove = true;
            }
        }

        private void WaitUser()
        {
            mainForm.ShowButton();
            //stop Thread and wait next iteration
            mainForm.AutoEvent = new AutoResetEvent(false);
            mainForm.AutoEvent.WaitOne();
        }
    }
}
