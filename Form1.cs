using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Dual_Image_Finder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_targetFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog_1.ShowDialog();
            this.textBox_1.Text = this.folderBrowserDialog_1.SelectedPath;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            //Call search method
            ImageFinder imageFinder = new ImageFinder();
            List<InfoImage> maliste = imageFinder.GetImagesInFolder(this.folderBrowserDialog_1.SelectedPath);
            
            foreach(InfoImage unitem in maliste)
            {
                Console.WriteLine(unitem);
            }
        }

        private void button_ImgLeftNext_Click(object sender, EventArgs e)
        {
            //Continue
        }

        private void button_ImgLeftFolder_Click(object sender, EventArgs e)
        {
            //Open folder current image
        }

        private void button_ImgLeftDelete_Click(object sender, EventArgs e)
        {
            //Delete Image
        }

        private void button_ImgRightNext_Click(object sender, EventArgs e)
        {
            //Continue
        }

        private void button_ImgRightFolder_Click(object sender, EventArgs e)
        {
            //Open folder current image
        }

        private void button_ImgRightDelete_Click(object sender, EventArgs e)
        {
            //Delete Image
        }
    }
}
