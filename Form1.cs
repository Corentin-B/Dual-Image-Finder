using Dual_Image_Finder.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Dual_Image_Finder
{
    public partial class MainForm : Form
    {
        private volatile InfoImage leftInfoImage;
        private volatile InfoImage rightInfoImage;
        private volatile Thread threadComparator;

        internal InfoImage LeftInfoImage { get => leftInfoImage; set => leftInfoImage = value; }
        internal InfoImage RightInfoImage { get => rightInfoImage; set => rightInfoImage = value; }

        private delegate void SafeCallDelegateProgress(string value);


        public MainForm()
        {
            InitializeComponent();

            label_NbImgScanned.Text = "";
            label_NbImgScanned.Visible = false;
            label_text_ScannedImg.Visible = false;

            label_percentage.Text = "";
            label_percentage.Visible = false;

            resetFront();
        }

        #region Events

        private void button_targetFolder_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog_1.ShowDialog();
            this.textBox_1.Text = this.folderBrowserDialog_1.SelectedPath;
            label_NbImgScanned.Visible = false;
            label_text_ScannedImg.Visible = false;

            if (this.folderBrowserDialog_1.SelectedPath.Length != 0)
            {
                this.button_Start.Enabled = true;
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            button_Start.Enabled = false;
            button_TargetFolder.Enabled = false;

            TComparator tComparator = new TComparator(this, this.folderBrowserDialog_1.SelectedPath);
            threadComparator = new Thread(tComparator.ThreadSupervisor);
            threadComparator.Start();

            label_NbImgScanned.Visible = true;
            label_percentage.Visible = true;
            label_text_ScannedImg.Visible = true;
            resetFront();
        }

        private void button_ImgLeftNext_Click(object sender, EventArgs e)
        {
            //Continue
            threadComparator.Resume();
            resetFront();
        }

        private void button_ImgLeftFolder_Click(object sender, EventArgs e)
        {
            openFolder(LeftInfoImage.Path);
        }

        private void button_ImgLeftDelete_Click(object sender, EventArgs e)
        {
            deleteFile(LeftInfoImage.Path);
            //Set deleted to true in list
        }

        private void button_ImgRightNext_Click(object sender, EventArgs e)
        {
            //Continue
            threadComparator.Resume();
            resetFront();
        }

        private void button_ImgRightFolder_Click(object sender, EventArgs e)
        {
            openFolder(RightInfoImage.Path);
        }

        private void button_ImgRightDelete_Click(object sender, EventArgs e)
        {
            deleteFile(RightInfoImage.Path);
            //Set deleted to true in list
        }

        #endregion

        #region actionUser

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

        private void resetFront()
        {
            label_text_DescImgLeft.Text = "";
            label_text_DescImgLeft.Visible = false;
            button_ImgLeftNext.Enabled = false;
            button_ImgLeftFolder.Enabled = false;
            button_ImgLeftDelete.Enabled = false;

            label_text_DescImgRight.Text = "";
            label_text_DescImgRight.Visible = false;
            button_ImgRightNext.Enabled = false;
            button_ImgRightFolder.Enabled = false;
            button_ImgRightDelete.Enabled = false;
        }

        private void showFront()
        {
            label_text_DescImgLeft.Visible = true;
            button_ImgLeftNext.Enabled = true;
            button_ImgLeftFolder.Enabled = true;
            button_ImgLeftDelete.Enabled = true;

            label_text_DescImgRight.Visible = true;
            button_ImgRightNext.Enabled = true;
            button_ImgRightFolder.Enabled = true;
            button_ImgRightDelete.Enabled = true;
        }

        #endregion

        #region update

        public void UpdateLabelNbImgScanned(string value)
        {
            if (label_NbImgScanned.InvokeRequired)
            {
                SafeCallDelegateProgress d = new SafeCallDelegateProgress(UpdateLabelNbImgScanned);
                label_NbImgScanned.Invoke(d, new object[] { value });
            }
            else
            {
                label_NbImgScanned.Text = value;
            }
        }

        public void StopThread()
        {
            threadComparator.Suspend();
        }

        #endregion

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
