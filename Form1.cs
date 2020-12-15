using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button_ImgLeftNext_Click(object sender, EventArgs e)
        {

        }

        private void button_ImgLeftFolder_Click(object sender, EventArgs e)
        {

        }

        private void button_ImgLeftDelete_Click(object sender, EventArgs e)
        {

        }

        private void button_ImgRightNext_Click(object sender, EventArgs e)
        {

        }

        private void button_ImgRightFolder_Click(object sender, EventArgs e)
        {

        }

        private void button_ImgRightDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
