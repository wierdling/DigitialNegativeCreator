namespace DigitalNegativeCreator
{
    partial class ImageDisplayForm
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
            _pictureBox = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)_pictureBox).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // _pictureBox
            // 
            _pictureBox.Location = new Point(3, 3);
            _pictureBox.Name = "_pictureBox";
            _pictureBox.Size = new Size(390, 352);
            _pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            _pictureBox.TabIndex = 0;
            _pictureBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(_pictureBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1105, 687);
            panel1.TabIndex = 1;
            // 
            // ImageDisplayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 687);
            Controls.Add(panel1);
            Name = "ImageDisplayForm";
            Text = "ImageDisplayForm";
            ((System.ComponentModel.ISupportInitialize)_pictureBox).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox _pictureBox;
        private Panel panel1;
    }
}