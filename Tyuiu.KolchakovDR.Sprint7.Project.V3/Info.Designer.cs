
namespace Tyuiu.KolchakovDR.Sprint7.Project.V3
{
    partial class Info
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.buttonDone_KDR = new System.Windows.Forms.Button();
            this.labelInfo_KDR = new System.Windows.Forms.Label();
            this.pictureBox_KDR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_KDR)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDone_KDR
            // 
            this.buttonDone_KDR.Location = new System.Drawing.Point(287, 176);
            this.buttonDone_KDR.Name = "buttonDone_KDR";
            this.buttonDone_KDR.Size = new System.Drawing.Size(118, 23);
            this.buttonDone_KDR.TabIndex = 11;
            this.buttonDone_KDR.TabStop = false;
            this.buttonDone_KDR.Text = "OK";
            this.buttonDone_KDR.UseVisualStyleBackColor = true;
            this.buttonDone_KDR.Click += new System.EventHandler(this.buttonDone_KDR_Click);
            // 
            // labelInfo_KDR
            // 
            this.labelInfo_KDR.AutoSize = true;
            this.labelInfo_KDR.Location = new System.Drawing.Point(138, 9);
            this.labelInfo_KDR.Name = "labelInfo_KDR";
            this.labelInfo_KDR.Size = new System.Drawing.Size(284, 117);
            this.labelInfo_KDR.TabIndex = 10;
            this.labelInfo_KDR.Text = resources.GetString("labelInfo_KDR.Text");
            // 
            // pictureBox_KDR
            // 
            this.pictureBox_KDR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox_KDR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_KDR.BackgroundImage")));
            this.pictureBox_KDR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_KDR.Location = new System.Drawing.Point(0, 9);
            this.pictureBox_KDR.Name = "pictureBox_KDR";
            this.pictureBox_KDR.Size = new System.Drawing.Size(132, 154);
            this.pictureBox_KDR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_KDR.TabIndex = 9;
            this.pictureBox_KDR.TabStop = false;
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.buttonDone_KDR);
            this.Controls.Add(this.labelInfo_KDR);
            this.Controls.Add(this.pictureBox_KDR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(450, 250);
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_KDR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDone_KDR;
        private System.Windows.Forms.Label labelInfo_KDR;
        private System.Windows.Forms.PictureBox pictureBox_KDR;
    }
}