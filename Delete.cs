using System.IO;
using System.Windows.Forms;

namespace Dual_Image_Finder
{
    class Delete
    {
        public static void deleteImage(string ImagePath)
        {
            string message = "Voulez-vous supprimer cette image ?";
            string caption = "Error Detected in Input";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                try
                {
                    File.Delete(ImagePath);
                } catch (IOException)
                {
                    MessageBox.Show("Erreur de suppresion de l'image");
                }
            }
        }
    }
}
