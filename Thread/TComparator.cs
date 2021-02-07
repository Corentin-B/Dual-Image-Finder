using Dual_Image_Finder.Models;
using System.Collections.Generic;
using System.Threading;

namespace Dual_Image_Finder
{
    class TComparator
    {
        private ImageParameters imageParameters;

        public TComparator(ImageParameters imageParameters)
        {
            this.imageParameters = imageParameters;
        }

        public void ThreadSupervisor()
        {
            List<InfoImage> listInfoImage = ImageFinder.GetImagesInFolder(imageParameters.FolderPath);

            if (listInfoImage.Count == 0)
            {
                imageParameters.MainForm.NoImageFind();
                return;
            }

            LoopComparator(listInfoImage);

            imageParameters.MainForm.ShowStartButton();
        }

        private void LoopComparator(List<InfoImage> listInfoImage)
        {
            bool loopControl = true;
            List<InfoImage> listInfoImageIntern = listInfoImage;

            while (loopControl)
            {
                if (StartComparator(listInfoImageIntern))
                {
                    if (imageParameters.Auto)
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

            if (imageParameters.MainForm.LeftInfoImage != null)
            {
                InfoImage compareLeftInfoImage = imageParameters.MainForm.LeftInfoImage;
                idLeftImage = listInfoImage.FindIndex(image => image.Name.Equals(compareLeftInfoImage.Name));
            }
            if (imageParameters.MainForm.RightInfoImage != null)
            {
                InfoImage compareRightInfoImage = imageParameters.MainForm.RightInfoImage;
                idRightImage = listInfoImage.FindIndex(image => image.Name.Equals(compareRightInfoImage.Name));
            }

            ComparatorDirector comparator = new ComparatorDirector(imageParameters.MainForm);
            return comparator.ListImageComparator(listInfoImage, idLeftImage, idRightImage, imageParameters.ComparisonRate, imageParameters.UseMatrice);
        }

        private List<InfoImage> UpdateList(List<InfoImage> listInfoImage)
        {
            InfoImage updateLeftInfoImage = imageParameters.MainForm.LeftInfoImage;
            InfoImage updateRightInfoImage = imageParameters.MainForm.RightInfoImage;
            List<InfoImage> updateListInfoImage = listInfoImage;

            if (updateLeftInfoImage.DeletedOrMove == true)
            {
                int idLeftImage = listInfoImage.FindIndex(image => image.Name.Equals(updateLeftInfoImage.Name));
                updateListInfoImage.RemoveAt(idLeftImage);
            }

            if (updateRightInfoImage.DeletedOrMove == true)
            {
                imageParameters.MainForm.RemoveRightImage();
                int idRightImage = listInfoImage.FindIndex(image => image.Name.Equals(updateRightInfoImage.Name));
                updateListInfoImage.RemoveAt(idRightImage);
            }

            return updateListInfoImage;
        }

        private void AutoMoveOrDelete()
        {
            MoveDeleteImage moveDeleteImage = new MoveDeleteImage();
            if (imageParameters.DeleteRequire)
            {
                imageParameters.MainForm.RemoveRightImage();
                imageParameters.MainForm.RightInfoImage.Bitmap = null;

                moveDeleteImage.DeleteImage(imageParameters.MainForm.RightInfoImage.Path);
                imageParameters.MainForm.RightInfoImage.DeletedOrMove = true;
            }
            else
            {
                imageParameters.MainForm.RemoveRightImage();
                imageParameters.MainForm.RightInfoImage.Bitmap = null;

                moveDeleteImage.MoveImage(imageParameters.MainForm.RightInfoImage.Path, imageParameters.FolderPath, imageParameters.MainForm.RightInfoImage.Name);
                imageParameters.MainForm.RightInfoImage.DeletedOrMove = true;
            }
        }

        private void WaitUser()
        {
            imageParameters.MainForm.ShowButton();
            //stop Thread and wait next iteration
            imageParameters.MainForm.AutoEvent = new AutoResetEvent(false);
            imageParameters.MainForm.AutoEvent.WaitOne();
        }
    }
}
