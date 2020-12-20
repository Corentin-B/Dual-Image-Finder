namespace Dual_Image_Finder
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBox_1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog_1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button_TargetFolder = new System.Windows.Forms.Button();
            this.pictureBox_left = new System.Windows.Forms.PictureBox();
            this.pictureBox_right = new System.Windows.Forms.PictureBox();
            this.label_text_TitleImgLeft = new System.Windows.Forms.Label();
            this.label_text_TitleImgRight = new System.Windows.Forms.Label();
            this.label_text_DescImgLeft = new System.Windows.Forms.Label();
            this.label_text_DescImgRight = new System.Windows.Forms.Label();
            this.button_ImgRightDelete = new System.Windows.Forms.Button();
            this.button_ImgRightFolder = new System.Windows.Forms.Button();
            this.button_ImgRightNext = new System.Windows.Forms.Button();
            this.button_ImgLeftNext = new System.Windows.Forms.Button();
            this.button_ImgLeftFolder = new System.Windows.Forms.Button();
            this.button_ImgLeftDelete = new System.Windows.Forms.Button();
            this.label_text_ScannedImg = new System.Windows.Forms.Label();
            this.label_NbImgScanned = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.label_percentage = new System.Windows.Forms.Label();
            this.label_percentsimilarity = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_1
            // 
            this.textBox_1.Location = new System.Drawing.Point(203, 12);
            this.textBox_1.Name = "textBox_1";
            this.textBox_1.ReadOnly = true;
            this.textBox_1.Size = new System.Drawing.Size(569, 20);
            this.textBox_1.TabIndex = 0;
            // 
            // button_TargetFolder
            // 
            this.button_TargetFolder.BackColor = System.Drawing.Color.Transparent;
            this.button_TargetFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_TargetFolder.BackgroundImage")));
            this.button_TargetFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_TargetFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_TargetFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_TargetFolder.ForeColor = System.Drawing.Color.White;
            this.button_TargetFolder.Location = new System.Drawing.Point(12, 11);
            this.button_TargetFolder.Name = "button_TargetFolder";
            this.button_TargetFolder.Size = new System.Drawing.Size(185, 23);
            this.button_TargetFolder.TabIndex = 2;
            this.button_TargetFolder.Text = "Emplacement du dossier cible";
            this.button_TargetFolder.UseVisualStyleBackColor = false;
            this.button_TargetFolder.Click += new System.EventHandler(this.button_targetFolder_Click);
            // 
            // pictureBox_left
            // 
            this.pictureBox_left.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_left.Location = new System.Drawing.Point(12, 115);
            this.pictureBox_left.Name = "pictureBox_left";
            this.pictureBox_left.Size = new System.Drawing.Size(340, 300);
            this.pictureBox_left.TabIndex = 3;
            this.pictureBox_left.TabStop = false;
            // 
            // pictureBox_right
            // 
            this.pictureBox_right.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_right.Location = new System.Drawing.Point(432, 115);
            this.pictureBox_right.Name = "pictureBox_right";
            this.pictureBox_right.Size = new System.Drawing.Size(340, 300);
            this.pictureBox_right.TabIndex = 4;
            this.pictureBox_right.TabStop = false;
            // 
            // label_text_TitleImgLeft
            // 
            this.label_text_TitleImgLeft.BackColor = System.Drawing.Color.Transparent;
            this.label_text_TitleImgLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_text_TitleImgLeft.ForeColor = System.Drawing.Color.White;
            this.label_text_TitleImgLeft.Location = new System.Drawing.Point(12, 99);
            this.label_text_TitleImgLeft.Name = "label_text_TitleImgLeft";
            this.label_text_TitleImgLeft.Size = new System.Drawing.Size(340, 13);
            this.label_text_TitleImgLeft.TabIndex = 5;
            this.label_text_TitleImgLeft.Text = "Image référente";
            this.label_text_TitleImgLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_text_TitleImgRight
            // 
            this.label_text_TitleImgRight.BackColor = System.Drawing.Color.Transparent;
            this.label_text_TitleImgRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_text_TitleImgRight.ForeColor = System.Drawing.Color.White;
            this.label_text_TitleImgRight.Location = new System.Drawing.Point(432, 99);
            this.label_text_TitleImgRight.Name = "label_text_TitleImgRight";
            this.label_text_TitleImgRight.Size = new System.Drawing.Size(340, 13);
            this.label_text_TitleImgRight.TabIndex = 6;
            this.label_text_TitleImgRight.Text = "Image cible";
            this.label_text_TitleImgRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_text_DescImgLeft
            // 
            this.label_text_DescImgLeft.BackColor = System.Drawing.Color.Transparent;
            this.label_text_DescImgLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_text_DescImgLeft.ForeColor = System.Drawing.Color.White;
            this.label_text_DescImgLeft.Location = new System.Drawing.Point(9, 418);
            this.label_text_DescImgLeft.Name = "label_text_DescImgLeft";
            this.label_text_DescImgLeft.Size = new System.Drawing.Size(343, 23);
            this.label_text_DescImgLeft.TabIndex = 7;
            this.label_text_DescImgLeft.Text = "label_text_DescImgLeft";
            this.label_text_DescImgLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_text_DescImgRight
            // 
            this.label_text_DescImgRight.BackColor = System.Drawing.Color.Transparent;
            this.label_text_DescImgRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_text_DescImgRight.ForeColor = System.Drawing.Color.White;
            this.label_text_DescImgRight.Location = new System.Drawing.Point(429, 418);
            this.label_text_DescImgRight.Name = "label_text_DescImgRight";
            this.label_text_DescImgRight.Size = new System.Drawing.Size(343, 23);
            this.label_text_DescImgRight.TabIndex = 8;
            this.label_text_DescImgRight.Text = "label_text_DescImgRight";
            this.label_text_DescImgRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_ImgRightDelete
            // 
            this.button_ImgRightDelete.BackColor = System.Drawing.Color.Transparent;
            this.button_ImgRightDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ImgRightDelete.BackgroundImage")));
            this.button_ImgRightDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ImgRightDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ImgRightDelete.FlatAppearance.BorderSize = 0;
            this.button_ImgRightDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_ImgRightDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ImgRightDelete.Location = new System.Drawing.Point(690, 441);
            this.button_ImgRightDelete.Name = "button_ImgRightDelete";
            this.button_ImgRightDelete.Size = new System.Drawing.Size(62, 57);
            this.button_ImgRightDelete.TabIndex = 9;
            this.button_ImgRightDelete.TabStop = false;
            this.button_ImgRightDelete.UseVisualStyleBackColor = false;
            this.button_ImgRightDelete.Click += new System.EventHandler(this.button_ImgRightDelete_Click);
            // 
            // button_ImgRightFolder
            // 
            this.button_ImgRightFolder.BackColor = System.Drawing.Color.Transparent;
            this.button_ImgRightFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ImgRightFolder.BackgroundImage")));
            this.button_ImgRightFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ImgRightFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ImgRightFolder.FlatAppearance.BorderSize = 0;
            this.button_ImgRightFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_ImgRightFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ImgRightFolder.Location = new System.Drawing.Point(572, 441);
            this.button_ImgRightFolder.Name = "button_ImgRightFolder";
            this.button_ImgRightFolder.Size = new System.Drawing.Size(62, 57);
            this.button_ImgRightFolder.TabIndex = 10;
            this.button_ImgRightFolder.TabStop = false;
            this.button_ImgRightFolder.UseVisualStyleBackColor = false;
            this.button_ImgRightFolder.Click += new System.EventHandler(this.button_ImgRightFolder_Click);
            // 
            // button_ImgRightNext
            // 
            this.button_ImgRightNext.BackColor = System.Drawing.Color.Transparent;
            this.button_ImgRightNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ImgRightNext.BackgroundImage")));
            this.button_ImgRightNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ImgRightNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ImgRightNext.FlatAppearance.BorderSize = 0;
            this.button_ImgRightNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_ImgRightNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ImgRightNext.Location = new System.Drawing.Point(452, 441);
            this.button_ImgRightNext.Name = "button_ImgRightNext";
            this.button_ImgRightNext.Size = new System.Drawing.Size(62, 57);
            this.button_ImgRightNext.TabIndex = 11;
            this.button_ImgRightNext.TabStop = false;
            this.button_ImgRightNext.UseVisualStyleBackColor = false;
            this.button_ImgRightNext.Click += new System.EventHandler(this.button_ImgRightNext_Click);
            // 
            // button_ImgLeftNext
            // 
            this.button_ImgLeftNext.BackColor = System.Drawing.Color.Transparent;
            this.button_ImgLeftNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ImgLeftNext.BackgroundImage")));
            this.button_ImgLeftNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ImgLeftNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ImgLeftNext.FlatAppearance.BorderSize = 0;
            this.button_ImgLeftNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_ImgLeftNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ImgLeftNext.Location = new System.Drawing.Point(32, 441);
            this.button_ImgLeftNext.Name = "button_ImgLeftNext";
            this.button_ImgLeftNext.Size = new System.Drawing.Size(62, 57);
            this.button_ImgLeftNext.TabIndex = 14;
            this.button_ImgLeftNext.TabStop = false;
            this.button_ImgLeftNext.UseVisualStyleBackColor = false;
            this.button_ImgLeftNext.Click += new System.EventHandler(this.button_ImgLeftNext_Click);
            // 
            // button_ImgLeftFolder
            // 
            this.button_ImgLeftFolder.BackColor = System.Drawing.Color.Transparent;
            this.button_ImgLeftFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ImgLeftFolder.BackgroundImage")));
            this.button_ImgLeftFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ImgLeftFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ImgLeftFolder.FlatAppearance.BorderSize = 0;
            this.button_ImgLeftFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_ImgLeftFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ImgLeftFolder.Location = new System.Drawing.Point(151, 441);
            this.button_ImgLeftFolder.Name = "button_ImgLeftFolder";
            this.button_ImgLeftFolder.Size = new System.Drawing.Size(62, 57);
            this.button_ImgLeftFolder.TabIndex = 13;
            this.button_ImgLeftFolder.TabStop = false;
            this.button_ImgLeftFolder.UseVisualStyleBackColor = false;
            this.button_ImgLeftFolder.Click += new System.EventHandler(this.button_ImgLeftFolder_Click);
            // 
            // button_ImgLeftDelete
            // 
            this.button_ImgLeftDelete.BackColor = System.Drawing.Color.Transparent;
            this.button_ImgLeftDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ImgLeftDelete.BackgroundImage")));
            this.button_ImgLeftDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ImgLeftDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_ImgLeftDelete.FlatAppearance.BorderSize = 0;
            this.button_ImgLeftDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_ImgLeftDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ImgLeftDelete.Location = new System.Drawing.Point(270, 441);
            this.button_ImgLeftDelete.Name = "button_ImgLeftDelete";
            this.button_ImgLeftDelete.Size = new System.Drawing.Size(62, 57);
            this.button_ImgLeftDelete.TabIndex = 12;
            this.button_ImgLeftDelete.TabStop = false;
            this.button_ImgLeftDelete.UseVisualStyleBackColor = false;
            this.button_ImgLeftDelete.Click += new System.EventHandler(this.button_ImgLeftDelete_Click);
            // 
            // label_text_ScannedImg
            // 
            this.label_text_ScannedImg.BackColor = System.Drawing.Color.Transparent;
            this.label_text_ScannedImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_text_ScannedImg.ForeColor = System.Drawing.Color.White;
            this.label_text_ScannedImg.Location = new System.Drawing.Point(358, 277);
            this.label_text_ScannedImg.Name = "label_text_ScannedImg";
            this.label_text_ScannedImg.Size = new System.Drawing.Size(68, 43);
            this.label_text_ScannedImg.TabIndex = 15;
            this.label_text_ScannedImg.Text = "Image scannées";
            this.label_text_ScannedImg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_NbImgScanned
            // 
            this.label_NbImgScanned.BackColor = System.Drawing.Color.Transparent;
            this.label_NbImgScanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NbImgScanned.ForeColor = System.Drawing.Color.White;
            this.label_NbImgScanned.Location = new System.Drawing.Point(358, 234);
            this.label_NbImgScanned.Name = "label_NbImgScanned";
            this.label_NbImgScanned.Size = new System.Drawing.Size(68, 43);
            this.label_NbImgScanned.TabIndex = 16;
            this.label_NbImgScanned.Text = "label_NbImgScanned";
            this.label_NbImgScanned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Start
            // 
            this.button_Start.BackColor = System.Drawing.Color.Transparent;
            this.button_Start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Start.BackgroundImage")));
            this.button_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Start.Enabled = false;
            this.button_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Start.ForeColor = System.Drawing.Color.White;
            this.button_Start.Location = new System.Drawing.Point(358, 115);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(68, 23);
            this.button_Start.TabIndex = 17;
            this.button_Start.Text = "Démarrer";
            this.button_Start.UseVisualStyleBackColor = false;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // label_percentage
            // 
            this.label_percentage.BackColor = System.Drawing.Color.Transparent;
            this.label_percentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_percentage.ForeColor = System.Drawing.Color.White;
            this.label_percentage.Location = new System.Drawing.Point(358, 372);
            this.label_percentage.Name = "label_percentage";
            this.label_percentage.Size = new System.Drawing.Size(68, 43);
            this.label_percentage.TabIndex = 18;
            this.label_percentage.Text = "label_percentage";
            this.label_percentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_percentsimilarity
            // 
            this.label_percentsimilarity.BackColor = System.Drawing.Color.Transparent;
            this.label_percentsimilarity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_percentsimilarity.ForeColor = System.Drawing.Color.White;
            this.label_percentsimilarity.Location = new System.Drawing.Point(15, 43);
            this.label_percentsimilarity.Name = "label_percentsimilarity";
            this.label_percentsimilarity.Size = new System.Drawing.Size(89, 45);
            this.label_percentsimilarity.TabIndex = 19;
            this.label_percentsimilarity.Text = "label_percentsimilarity";
            this.label_percentsimilarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_percentsimilarity.Visible = false;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar1.LargeChange = 25;
            this.trackBar1.Location = new System.Drawing.Point(110, 43);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(662, 45);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 20;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label_percentsimilarity);
            this.Controls.Add(this.label_percentage);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.label_NbImgScanned);
            this.Controls.Add(this.label_text_ScannedImg);
            this.Controls.Add(this.button_ImgLeftNext);
            this.Controls.Add(this.button_ImgLeftFolder);
            this.Controls.Add(this.button_ImgLeftDelete);
            this.Controls.Add(this.button_ImgRightNext);
            this.Controls.Add(this.button_ImgRightFolder);
            this.Controls.Add(this.button_ImgRightDelete);
            this.Controls.Add(this.label_text_DescImgRight);
            this.Controls.Add(this.label_text_DescImgLeft);
            this.Controls.Add(this.label_text_TitleImgRight);
            this.Controls.Add(this.label_text_TitleImgLeft);
            this.Controls.Add(this.pictureBox_right);
            this.Controls.Add(this.pictureBox_left);
            this.Controls.Add(this.button_TargetFolder);
            this.Controls.Add(this.textBox_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dual Image Finder";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_1;
        private System.Windows.Forms.Button button_TargetFolder;
        private System.Windows.Forms.PictureBox pictureBox_left;
        private System.Windows.Forms.PictureBox pictureBox_right;
        private System.Windows.Forms.Label label_text_TitleImgLeft;
        private System.Windows.Forms.Label label_text_TitleImgRight;
        private System.Windows.Forms.Label label_text_DescImgLeft;
        private System.Windows.Forms.Label label_text_DescImgRight;
        private System.Windows.Forms.Button button_ImgRightDelete;
        private System.Windows.Forms.Button button_ImgRightFolder;
        private System.Windows.Forms.Button button_ImgRightNext;
        private System.Windows.Forms.Button button_ImgLeftNext;
        private System.Windows.Forms.Button button_ImgLeftFolder;
        private System.Windows.Forms.Button button_ImgLeftDelete;
        private System.Windows.Forms.Label label_text_ScannedImg;
        private System.Windows.Forms.Label label_NbImgScanned;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label_percentage;
        private System.Windows.Forms.Label label_percentsimilarity;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

