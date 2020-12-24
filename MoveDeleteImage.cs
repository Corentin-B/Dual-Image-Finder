using System;
using System.IO;
using System.Windows.Forms;

namespace Dual_Image_Finder
{
    class MoveDeleteImage
    {
        private readonly string folderToMove = "Duplicate";


        public void MoveImage(string imagePath, string folderPath, string imageName)
        {
            Directory.CreateDirectory(folderPath + "\\" + folderToMove);

            try
            {
                File.Move(imagePath, folderPath + "\\" + folderToMove + "\\" + imageName);
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
            catch (IOException e)
            {
                MessageBox.Show("Erreur pour déplacer l'image" + "\n" + e);
            }
        }

        public void DeleteImage(string imagePath)
        {
            try
            {
                File.Delete(imagePath);
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
