namespace DigitalNegativeCreator
{
    partial class Settings
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
            this._colorMapPanel = new System.Windows.Forms.Panel();
            this._testImagePictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this._normalizeColorMappingButton = new System.Windows.Forms.Button();
            this._colorMapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._testImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _colorMapPanel
            // 
            this._colorMapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._colorMapPanel.Controls.Add(this._testImagePictureBox);
            this._colorMapPanel.Location = new System.Drawing.Point(12, 241);
            this._colorMapPanel.Name = "_colorMapPanel";
            this._colorMapPanel.Size = new System.Drawing.Size(776, 197);
            this._colorMapPanel.TabIndex = 0;
            // 
            // _testImagePictureBox
            // 
            this._testImagePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._testImagePictureBox.Location = new System.Drawing.Point(0, 0);
            this._testImagePictureBox.Name = "_testImagePictureBox";
            this._testImagePictureBox.Size = new System.Drawing.Size(776, 197);
            this._testImagePictureBox.TabIndex = 0;
            this._testImagePictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Create Color Mapping";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _normalizeColorMappingButton
            // 
            this._normalizeColorMappingButton.Location = new System.Drawing.Point(12, 41);
            this._normalizeColorMappingButton.Name = "_normalizeColorMappingButton";
            this._normalizeColorMappingButton.Size = new System.Drawing.Size(153, 23);
            this._normalizeColorMappingButton.TabIndex = 2;
            this._normalizeColorMappingButton.Text = "Normalize Color Mapping";
            this._normalizeColorMappingButton.UseVisualStyleBackColor = true;
            this._normalizeColorMappingButton.Click += new System.EventHandler(this._normalizeColorMappingButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._normalizeColorMappingButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._colorMapPanel);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this._colorMapPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._testImagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel _colorMapPanel;
        private PictureBox _testImagePictureBox;
        private Button button1;
        private Button _normalizeColorMappingButton;
    }
}