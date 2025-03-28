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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            _colorMapPanel = new Panel();
            _testImagePictureBox = new PictureBox();
            _createGreyscaleColorMapping = new Button();
            _normalizeColorMappingButton = new Button();
            _createTestImageButton = new Button();
            toolTip1 = new ToolTip(components);
            label1 = new Label();
            _startX = new NumericUpDown();
            _startY = new NumericUpDown();
            label2 = new Label();
            _xOffset = new NumericUpDown();
            label3 = new Label();
            _yOffset = new NumericUpDown();
            label4 = new Label();
            _rotation = new NumericUpDown();
            label5 = new Label();
            _cellSize = new NumericUpDown();
            label6 = new Label();
            groupBox1 = new GroupBox();
            _testModeCheckBox = new CheckBox();
            _colorMapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_testImagePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_startX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_startY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_xOffset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_yOffset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_rotation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_cellSize).BeginInit();
            groupBox1.SuspendLayout();
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
            // _createGreyscaleColorMapping
            // 
            _createGreyscaleColorMapping.Location = new Point(191, 77);
            _createGreyscaleColorMapping.Name = "_createGreyscaleColorMapping";
            _createGreyscaleColorMapping.Size = new Size(153, 23);
            _createGreyscaleColorMapping.TabIndex = 6;
            _createGreyscaleColorMapping.Text = "Create Grayscale Mapping";
            toolTip1.SetToolTip(_createGreyscaleColorMapping, "Load the printed image (that has gone through the same process you want your regular images to go through) that was scanned.  \r\nThe image needs to be scanned at 300 dpi and be 8.5 x 11 inches in size.");
            _createGreyscaleColorMapping.UseVisualStyleBackColor = true;
            _createGreyscaleColorMapping.Click += CreateGrayScaleMappedImageButton_Click;
            // 
            // _normalizeColorMappingButton
            // 
            _normalizeColorMappingButton.Location = new Point(397, 77);
            _normalizeColorMappingButton.Name = "_normalizeColorMappingButton";
            _normalizeColorMappingButton.Size = new Size(153, 23);
            _normalizeColorMappingButton.TabIndex = 7;
            _normalizeColorMappingButton.Text = "Normalize Grayscale Mapping";
            toolTip1.SetToolTip(_normalizeColorMappingButton, "This command will fill in the gaps in the tones by selecting the lower tone.  Keep running the command until it is finished. ");
            _normalizeColorMappingButton.UseVisualStyleBackColor = true;
            _normalizeColorMappingButton.Click += _normalizeColorMappingButton_Click;
            // 
            // _createTestImageButton
            // 
            _createTestImageButton.Location = new Point(12, 197);
            _createTestImageButton.Name = "_createTestImageButton";
            _createTestImageButton.Size = new Size(153, 23);
            _createTestImageButton.TabIndex = 0;
            _createTestImageButton.Text = "Create Color Image";
            toolTip1.SetToolTip(_createTestImageButton, resources.GetString("_createTestImageButton.ToolTip"));
            _createTestImageButton.UseVisualStyleBackColor = true;
            _createTestImageButton.Click += _createTestImageButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 18);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 4;
            label1.Text = "Start X";
            // 
            // _startX
            // 
            _startX.DecimalPlaces = 2;
            _startX.Location = new Point(113, 14);
            _startX.Name = "_startX";
            _startX.Size = new Size(120, 23);
            _startX.TabIndex = 0;
            _startX.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // _startY
            // 
            _startY.DecimalPlaces = 2;
            _startY.Location = new Point(113, 43);
            _startY.Name = "_startY";
            _startY.Size = new Size(120, 23);
            _startY.TabIndex = 1;
            _startY.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 47);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 6;
            label2.Text = "Start Y";
            // 
            // _xOffset
            // 
            _xOffset.DecimalPlaces = 2;
            _xOffset.Location = new Point(319, 14);
            _xOffset.Name = "_xOffset";
            _xOffset.Size = new Size(120, 23);
            _xOffset.TabIndex = 2;
            _xOffset.Value = new decimal(new int[] { 57, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 18);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 8;
            label3.Text = "X Offset";
            // 
            // _yOffset
            // 
            _yOffset.DecimalPlaces = 2;
            _yOffset.Location = new Point(319, 43);
            _yOffset.Name = "_yOffset";
            _yOffset.Size = new Size(120, 23);
            _yOffset.TabIndex = 3;
            _yOffset.Value = new decimal(new int[] { 57, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(265, 47);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 10;
            label4.Text = "Y Offset";
            // 
            // _rotation
            // 
            _rotation.DecimalPlaces = 4;
            _rotation.Location = new Point(517, 45);
            _rotation.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            _rotation.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            _rotation.Name = "_rotation";
            _rotation.Size = new Size(120, 23);
            _rotation.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(463, 49);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 12;
            label5.Text = "Rotation";
            // 
            // _cellSize
            // 
            _cellSize.Location = new Point(517, 16);
            _cellSize.Name = "_cellSize";
            _cellSize.Size = new Size(120, 23);
            _cellSize.TabIndex = 4;
            _cellSize.Value = new decimal(new int[] { 45, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(463, 20);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 14;
            label6.Text = "Cell Size";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(_testModeCheckBox);
            groupBox1.Controls.Add(_startY);
            groupBox1.Controls.Add(_cellSize);
            groupBox1.Controls.Add(_normalizeColorMappingButton);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(_createGreyscaleColorMapping);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(_startX);
            groupBox1.Controls.Add(_rotation);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(_yOffset);
            groupBox1.Controls.Add(_xOffset);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 110);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Calibration";
            // 
            // _testModeCheckBox
            // 
            _testModeCheckBox.AutoSize = true;
            _testModeCheckBox.Checked = true;
            _testModeCheckBox.CheckState = CheckState.Checked;
            _testModeCheckBox.Location = new Point(70, 77);
            _testModeCheckBox.Name = "_testModeCheckBox";
            _testModeCheckBox.Size = new Size(80, 19);
            _testModeCheckBox.TabIndex = 15;
            _testModeCheckBox.Text = "Test Mode";
            _testModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(_createTestImageButton);
            Controls.Add(_colorMapPanel);
            Name = "Settings";
            Text = "Settings";
            Shown += Settings_Shown;
            _colorMapPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_testImagePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)_startX).EndInit();
            ((System.ComponentModel.ISupportInitialize)_startY).EndInit();
            ((System.ComponentModel.ISupportInitialize)_xOffset).EndInit();
            ((System.ComponentModel.ISupportInitialize)_yOffset).EndInit();
            ((System.ComponentModel.ISupportInitialize)_rotation).EndInit();
            ((System.ComponentModel.ISupportInitialize)_cellSize).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel _colorMapPanel;
        private PictureBox _testImagePictureBox;
        private Button _createGreyscaleColorMapping;
        private Button _normalizeColorMappingButton;
        private Button _createTestImageButton;
        private ToolTip toolTip1;
        private Label label1;
        private NumericUpDown _startX;
        private NumericUpDown _startY;
        private Label label2;
        private NumericUpDown _xOffset;
        private Label label3;
        private NumericUpDown _yOffset;
        private Label label4;
        private NumericUpDown _rotation;
        private Label label5;
        private NumericUpDown _cellSize;
        private Label label6;
        private GroupBox groupBox1;
        private CheckBox _testModeCheckBox;
    }
}