using Dual_Image_Finder.Models;
using System;
using System.Collections.Generic;
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
        private delegate void SafeCallDelegateRightImage();


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

            TComparator tComparator = new TComparator(this, folderBrowserDialog_1.SelectedPath, percentSimilatiry, checkBox_Auto.Checked, radioButton_Delete.Checked);
            threadComparator = new Thread(tComparator.ThreadSupervisor);
            threadComparator.Start();

            label_NbImgScanned.Visible = true;
            label_percentage.Visible = true;
            label_text_ScannedImg.Visible = true;
        }

        private void button_ImgNext_Click(object sender, EventArgs e)
        {
            Continue();
        }

        private void button_ImgLeftFolder_Click(object sender, EventArgs e)
        {
            openFolder(LeftInfoImage.Path);
        }

        private void button_ImgLeftDelete_Click(object sender, EventArgs e)
        {
            //Set deleted to true in list
            //pictureBox_left.BackgroundImage.Dispose();
            deleteFile(LeftInfoImage.Path);
            LeftInfoImage.DeletedOrMove = true;
            Continue();
        }

        private void button_ImgRightFolder_Click(object sender, EventArgs e)
        {
            openFolder(RightInfoImage.Path);
        }

        private void button_ImgRightDelete_Click(object sender, EventArgs e)
        {
            //Set deleted to true in list
            pictureBox_right.BackgroundImage.Dispose();
            deleteFile(RightInfoImage.Path);
            RightInfoImage.DeletedOrMove = true;
            Continue();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_percentsimilarity.Text = trackBar1.Value.ToString() + "%";
            percentSimilatiry = trackBar1.Value;
        }

        private void checkBox_Auto_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_Move.Enabled = checkBox_Auto.Checked;
            radioButton_Delete.Enabled = checkBox_Auto.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadComparator.IsAlive)
            {
                threadComparator.Abort();
            }
        }

        private void Continue()
        {
            autoEvent.Set();
            resetFront();
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
            PopUpDelete popUpDelete = new PopUpDelete();
            popUpDelete.deleteImage(filePath);
        }

        private void resetFront()
        {
            button_ImgLeftFolder.Enabled = false;
            button_ImgLeftDelete.Enabled = false;
            button_ImgLeftFolder.Visible = false;
            button_ImgLeftDelete.Visible = false;

            button_ImgNext.Enabled = false;
            button_ImgNext.Visible = false;

            button_ImgRightFolder.Enabled = false;
            button_ImgRightDelete.Enabled = false;
            button_ImgRightFolder.Visible = false;
            button_ImgRightDelete.Visible = false;
        }

        private void showFrontButton()
        {
            button_ImgLeftFolder.Enabled = true;
            button_ImgLeftDelete.Enabled = true;
            button_ImgLeftFolder.Visible = true;
            button_ImgLeftDelete.Visible = true;

            button_ImgNext.Enabled = true;
            button_ImgNext.Visible = true;

            button_ImgRightFolder.Enabled = true;
            button_ImgRightDelete.Enabled = true;
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
                pictureBox_left.BackgroundImage = GetImageFromFile(LeftInfoImage.Path);
                pictureBox_right.BackgroundImage = GetImageFromFile(RightInfoImage.Path);
                label_text_DescImgLeft.Text = LeftInfoImage.Name;
                label_text_DescImgRight.Text = RightInfoImage.Name;
            }
        }

        private Bitmap GetImageFromFile(string imagePath)
        {
            Bitmap newImage;

            using (var bmpTemp = new Bitmap(imagePath))
            {
                newImage = new Bitmap(bmpTemp);
            }

            return newImage;
        }

        public void RemoveRightImage()
        {
            if (pictureBox_right.InvokeRequired)
            {
                SafeCallDelegateRightImage d = new SafeCallDelegateRightImage(ShowButton);
                pictureBox_right.Invoke(d, new object[] { });
            }
            else
            {
                pictureBox_right.BackgroundImage.Dispose();
                this.Refresh();
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
