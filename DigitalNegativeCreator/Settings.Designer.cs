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
            _colorMapPanel = new Panel();
            _testImagePictureBox = new PictureBox();
            button1 = new Button();
            _normalizeColorMappingButton = new Button();
            _createTestImageButton = new Button();
            _colorMapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_testImagePictureBox).BeginInit();
            SuspendLayout();
            // 
            // _colorMapPanel
            // 
            _colorMapPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _colorMapPanel.Controls.Add(_testImagePictureBox);
            _colorMapPanel.Location = new Point(12, 241);
            _colorMapPanel.Name = "_colorMapPanel";
            _colorMapPanel.Size = new Size(776, 197);
            _colorMapPanel.TabIndex = 0;
            // 
            // _testImagePictureBox
            // 
            _testImagePictureBox.Dock = DockStyle.Fill;
            _testImagePictureBox.Location = new Point(0, 0);
            _testImagePictureBox.Name = "_testImagePictureBox";
            _testImagePictureBox.Size = new Size(776, 197);
            _testImagePictureBox.TabIndex = 0;
            _testImagePictureBox.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(153, 23);
            button1.TabIndex = 1;
            button1.Text = "Create Color Mapping";
            button1.UseVisualStyleBackColor = true;
            button1.Click += CreateColorMappedImageButton_Click;
            // 
            // _normalizeColorMappingButton
            // 
            _normalizeColorMappingButton.Location = new Point(12, 41);
            _normalizeColorMappingButton.Name = "_normalizeColorMappingButton";
            _normalizeColorMappingButton.Size = new Size(153, 23);
            _normalizeColorMappingButton.TabIndex = 2;
            _normalizeColorMappingButton.Text = "Normalize Color Mapping";
            _normalizeColorMappingButton.UseVisualStyleBackColor = true;
            _normalizeColorMappingButton.Click += _normalizeColorMappingButton_Click;
            // 
            // _createTestImageButton
            // 
            _createTestImageButton.Location = new Point(12, 70);
            _createTestImageButton.Name = "_createTestImageButton";
            _createTestImageButton.Size = new Size(153, 23);
            _createTestImageButton.TabIndex = 3;
            _createTestImageButton.Text = "Create Test Image";
            _createTestImageButton.UseVisualStyleBackColor = true;
            _createTestImageButton.Click += _createTestImageButton_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_createTestImageButton);
            Controls.Add(_normalizeColorMappingButton);
            Controls.Add(button1);
            Controls.Add(_colorMapPanel);
            Name = "Settings";
            Text = "Settings";
            Shown += Settings_Shown;
            _colorMapPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_testImagePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel _colorMapPanel;
        private PictureBox _testImagePictureBox;
        private Button button1;
        private Button _normalizeColorMappingButton;
        private Button _createTestImageButton;
    }
}