using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Windows.Forms;

namespace Dual_Image_Finder
{
    class PopUpDelete
    {
        public void deleteImage(string imagePath)
        {
            string message = "Do you want to delete this image?";
            string caption = "Confirmation of deletion";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                MoveDeleteImage moveDeleteImage = new MoveDeleteImage();
                moveDeleteImage.DeleteImage(imagePath);
            }
        }
    }
}
