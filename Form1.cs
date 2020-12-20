using Dual_Image_Finder.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Dual_Image_Finder
{
    public partial class MainForm : Form
    {
        private volatile Thread threadComparator;
        private int percentSimilatiry;

        private volatile InfoImage leftInfoImage;
        private volatile InfoImage rightInfoImage;
        private volatile AutoResetEvent autoEvent = new AutoResetEvent(false);

        internal InfoImage LeftInfoImage { get => leftInfoImage; set => leftInfoImage = value; }
        internal InfoImage RightInfoImage { get => rightInfoImage; set => rightInfoImage = value; }
        public AutoResetEvent AutoEvent { get => autoEvent; set => autoEvent = value; }

        private delegate void SafeCallDelegateProgress(string value);
        private delegate void SafeCallDelegatePercentage(string value);
        private delegate void SafeCallDelegateButton();


        //TODO Déplacer les images dans un autre dossier "Duplicate"

        public MainForm()
        {
            InitializeComponent();

            int initialTrackBarValue = 10;

            label_NbImgScanned.Text = "";
            label_NbImgScanned.Visible = false;
            label_text_ScannedImg.Visible = false;

            label_percentage.Text = "";
            label_percentage.Visible = false;

            trackBar1.Value = initialTrackBarValue;
            percentSimilatiry = trackBar1.Value;
            label_percentsimilarity.Text = trackBar1.Value.ToString() + "%";

            label_text_DescImgLeft.Text = "";
            label_text_DescImgRight.Text = "";

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

            TComparator tComparator = new TComparator(this, this.folderBrowserDialog_1.SelectedPath, percentSimilatiry);
            threadComparator = new Thread(tComparator.ThreadSupervisor);
            threadComparator.Start();

            label_NbImgScanned.Visible = true;
            label_percentage.Visible = true;
            label_text_ScannedImg.Visible = true;
        }

        private void button_ImgLeftNext_Click(object sender, EventArgs e)
        {
            //Continue
            //threadComparator.Resume();
            autoEvent.Set();
            resetFront();
        }

        private void button_ImgLeftFolder_Click(object sender, EventArgs e)
        {
            openFolder(LeftInfoImage.Path);
        }

        private void button_ImgLeftDelete_Click(object sender, EventArgs e)
        {
            //Set deleted to true in list
            deleteFile(LeftInfoImage.Path);
            LeftInfoImage.Deleted = true;
        }

        private void button_ImgRightNext_Click(object sender, EventArgs e)
        {
            //Continue
            //threadComparator.Resume();
            autoEvent.Set();
            resetFront();
        }

        private void button_ImgRightFolder_Click(object sender, EventArgs e)
        {
            openFolder(RightInfoImage.Path);
        }

        private void button_ImgRightDelete_Click(object sender, EventArgs e)
        {
            //Set deleted to true in list
            deleteFile(RightInfoImage.Path);
            RightInfoImage.Deleted = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_percentsimilarity.Text = trackBar1.Value.ToString() + "%";
            percentSimilatiry = trackBar1.Value;
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
            button_ImgLeftNext.Enabled = false;
            button_ImgLeftFolder.Enabled = false;
            button_ImgLeftDelete.Enabled = false;
            button_ImgLeftNext.Visible = false;
            button_ImgLeftFolder.Visible = false;
            button_ImgLeftDelete.Visible = false;

            button_ImgRightNext.Enabled = false;
            button_ImgRightFolder.Enabled = false;
            button_ImgRightDelete.Enabled = false;
            button_ImgRightNext.Visible = false;
            button_ImgRightFolder.Visible = false;
            button_ImgRightDelete.Visible = false;
        }

        private void showFrontButton()
        {
            button_ImgLeftNext.Enabled = true;
            button_ImgLeftFolder.Enabled = true;
            button_ImgLeftDelete.Enabled = true;
            button_ImgLeftNext.Visible = true;
            button_ImgLeftFolder.Visible = true;
            button_ImgLeftDelete.Visible = true;

            button_ImgRightNext.Enabled = true;
            button_ImgRightFolder.Enabled = true;
            button_ImgRightDelete.Enabled = true;
            button_ImgRightNext.Visible = true;
            button_ImgRightFolder.Visible = true;
            button_ImgRightDelete.Visible = true;
        }

        #endregion

        #region threadSyncronisation

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

        public void UpdateLabelPercentage(string value)
        {
            if (label_percentage.InvokeRequired)
            {
                SafeCallDelegatePercentage d = new SafeCallDelegatePercentage(UpdateLabelPercentage);
                label_percentage.Invoke(d, new object[] { value });
            }
            else
            {
                label_percentage.Text = value;
                pictureBox_left.BackgroundImage = Image.FromFile(LeftInfoImage.Path);
                pictureBox_right.BackgroundImage = Image.FromFile(RightInfoImage.Path);
                label_text_DescImgLeft.Text = LeftInfoImage.Name;
                label_text_DescImgRight.Text = RightInfoImage.Name;
            }
        }

        public void ShowButton()
        {
            if (button_ImgLeftDelete.InvokeRequired)
            {
                SafeCallDelegateButton d = new SafeCallDelegateButton(ShowButton);
                button_ImgLeftDelete.Invoke(d, new object[] { });
            }
            else
            {
                showFrontButton();
            }
        }

        #endregion
    }
}
