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
            string message = "Voulez-vous supprimer cette image ?";
            string caption = "Confirmation de supression";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                try
                {
                    FileSystem.DeleteFile(imagePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Erreur : Accès non autorisé");
                }
                catch (PathTooLongException)
                {
                    MessageBox.Show("Erreur : Chemin trop long");
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show("Erreur : Fichier introuvable");
                }
                catch (IOException)
                {
                    MessageBox.Show("Erreur de suppresion de l'image");
                }
            }
        }
    }
}
