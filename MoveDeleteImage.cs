using Microsoft.VisualBasic.FileIO;
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
                MessageBox.Show("Error: Unauthorized access");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Error: Path too long");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Error: File not found");
            }
            catch (IOException)
            {
                MessageBox.Show("Image moving error");
            }
        }

        public void DeleteImage(string imagePath)
        {
            try
            {
                FileSystem.DeleteFile(imagePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Error: Unauthorized access");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Error: Path too long");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Error: File not found");
            }
            catch (IOException)
            {
                MessageBox.Show("Image deletion error");
            }
        }
    }
}
