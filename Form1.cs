using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Dual_Image_Finder
{
    public partial class MainForm : Form
    {
        private InfoImage leftInfoImage;
        private InfoImage rightInfoImage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button_targetFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog_1.ShowDialog();
            this.textBox_1.Text = this.folderBrowserDialog_1.SelectedPath;

            if (this.folderBrowserDialog_1.SelectedPath.Length != 0)
            {
                this.button_Start.Enabled = true;
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            //Call search method

            //Create Thread

            ImageFinder imageFinder = new ImageFinder();
            List<InfoImage> maliste = imageFinder.GetImagesInFolder(this.folderBrowserDialog_1.SelectedPath);
            Comparator comparator = new Comparator();
            comparator.ImageComparator(maliste);
        }

        private void button_ImgLeftNext_Click(object sender, EventArgs e)
        {
            //Continue
        }

        private void button_ImgLeftFolder_Click(object sender, EventArgs e)
        {
            //Open folder current image
            openFolder(leftInfoImage.Path);
        }

        private void button_ImgLeftDelete_Click(object sender, EventArgs e)
        {
            //Delete Image
            deleteFile(leftInfoImage.Path);
            //Continue
        }

        private void button_ImgRightNext_Click(object sender, EventArgs e)
        {
            //Continue
        }

        private void button_ImgRightFolder_Click(object sender, EventArgs e)
        {
            //Open folder current image
            openFolder(rightInfoImage.Path);
            //Contine
        }

        private void button_ImgRightDelete_Click(object sender, EventArgs e)
        {
            //Delete Image
            deleteFile(rightInfoImage.Path);
            //Continue
        }


        private void openFolder(string folderPath)
        {
            try
            {
                Process.Start(Path.GetDirectoryName(folderPath));
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Erreur : Impossible d'ouvrir le dossier");
            }
        }

        private void deleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
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
        }
    }
}
