namespace DigitalNegativeCreator.Components
{
    partial class ImageAndNegativeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageAndNegativeControl));
            _imagesSplitContainer = new SplitContainer();
            toolStrip1 = new ToolStrip();
            _saveImageToolstripButton = new ToolStripButton();
            _saveImageAsToolstripButton = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            panel2 = new Panel();
            _currentImageInfoGroupBox = new GroupBox();
            _yResolutionTextBox = new TextBox();
            _xResolutionTextBox = new TextBox();
            _currentHeightTextBox = new TextBox();
            _currentWidthTextBox = new TextBox();
            label2 = new Label();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            _scaleButton = new Button();
            _widthHeightTypeComboBox = new ComboBox();
            _scaleResolutionRatioLockedCheckBox = new CheckBox();
            _aspectRationLockedCheckBox = new CheckBox();
            _scaleYResolutionNumberBox = new NumericUpDown();
            _scaleXResolutionNumberBox = new NumericUpDown();
            _scaleHeightNumberBox = new NumericUpDown();
            _scaleWidthNumberBox = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            _imageNameLabel = new Label();
            _imagesPictureBox = new PictureBox();
            toolStrip2 = new ToolStrip();
            _saveNegativeToolstripButton = new ToolStripButton();
            _createNegativesToolstripButton = new ToolStripButton();
            label9 = new Label();
            _negativePictureBox = new PictureBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)_imagesSplitContainer).BeginInit();
            _imagesSplitContainer.Panel1.SuspendLayout();
            _imagesSplitContainer.Panel2.SuspendLayout();
            _imagesSplitContainer.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            _currentImageInfoGroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_scaleYResolutionNumberBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_scaleXResolutionNumberBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_scaleHeightNumberBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_scaleWidthNumberBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_imagesPictureBox).BeginInit();
            toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_negativePictureBox).BeginInit();
            SuspendLayout();
            // 
            // _imagesSplitContainer
            // 
            _imagesSplitContainer.Dock = DockStyle.Fill;
            _imagesSplitContainer.Location = new Point(0, 0);
            _imagesSplitContainer.Name = "_imagesSplitContainer";
            // 
            // _imagesSplitContainer.Panel1
            // 
            _imagesSplitContainer.Panel1.Controls.Add(toolStrip1);
            _imagesSplitContainer.Panel1.Controls.Add(panel2);
            _imagesSplitContainer.Panel1.Controls.Add(_imageNameLabel);
            _imagesSplitContainer.Panel1.Controls.Add(_imagesPictureBox);
            // 
            // _imagesSplitContainer.Panel2
            // 
            _imagesSplitContainer.Panel2.Controls.Add(toolStrip2);
            _imagesSplitContainer.Panel2.Controls.Add(label9);
            _imagesSplitContainer.Panel2.Controls.Add(_negativePictureBox);
            _imagesSplitContainer.Size = new Size(1451, 726);
            _imagesSplitContainer.SplitterDistance = 665;
            _imagesSplitContainer.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { _saveImageToolstripButton, _saveImageAsToolstripButton, toolStripButton3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(665, 25);
            toolStrip1.TabIndex = 12;
            toolStrip1.Text = "toolStrip1";
            // 
            // _saveImageToolstripButton
            // 
            _saveImageToolstripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _saveImageToolstripButton.Image = (Image)resources.GetObject("_saveImageToolstripButton.Image");
            _saveImageToolstripButton.ImageTransparentColor = Color.Black;
            _saveImageToolstripButton.Name = "_saveImageToolstripButton";
            _saveImageToolstripButton.Size = new Size(23, 22);
            _saveImageToolstripButton.Text = "Save Image";
            _saveImageToolstripButton.Click += _saveImageButton_Click;
            // 
            // _saveImageAsToolstripButton
            // 
            _saveImageAsToolstripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _saveImageAsToolstripButton.Image = (Image)resources.GetObject("_saveImageAsToolstripButton.Image");
            _saveImageAsToolstripButton.ImageTransparentColor = Color.Black;
            _saveImageAsToolstripButton.Name = "_saveImageAsToolstripButton";
            _saveImageAsToolstripButton.Size = new Size(23, 22);
            _saveImageAsToolstripButton.Text = "Save Image As";
            _saveImageAsToolstripButton.Click += _saveImageAsToolstripButton_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(23, 22);
            toolStripButton3.Text = "toolStripButton3";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoScroll = true;
            panel2.Controls.Add(_currentImageInfoGroupBox);
            panel2.Controls.Add(groupBox1);
            panel2.Location = new Point(5, 515);
            panel2.Name = "panel2";
            panel2.Size = new Size(657, 208);
            panel2.TabIndex = 11;
            // 
            // _currentImageInfoGroupBox
            // 
            _currentImageInfoGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _currentImageInfoGroupBox.Controls.Add(_yResolutionTextBox);
            _currentImageInfoGroupBox.Controls.Add(_xResolutionTextBox);
            _currentImageInfoGroupBox.Controls.Add(_currentHeightTextBox);
            _currentImageInfoGroupBox.Controls.Add(_currentWidthTextBox);
            _currentImageInfoGroupBox.Controls.Add(label2);
            _currentImageInfoGroupBox.Controls.Add(label4);
            _currentImageInfoGroupBox.Controls.Add(label1);
            _currentImageInfoGroupBox.Controls.Add(label3);
            _currentImageInfoGroupBox.Location = new Point(3, 11);
            _currentImageInfoGroupBox.Name = "_currentImageInfoGroupBox";
            _currentImageInfoGroupBox.Size = new Size(201, 189);
            _currentImageInfoGroupBox.TabIndex = 6;
            _currentImageInfoGroupBox.TabStop = false;
            _currentImageInfoGroupBox.Text = "Image Info";
            // 
            // _yResolutionTextBox
            // 
            _yResolutionTextBox.Enabled = false;
            _yResolutionTextBox.Location = new Point(88, 104);
            _yResolutionTextBox.Name = "_yResolutionTextBox";
            _yResolutionTextBox.ReadOnly = true;
            _yResolutionTextBox.Size = new Size(100, 23);
            _yResolutionTextBox.TabIndex = 9;
            // 
            // _xResolutionTextBox
            // 
            _xResolutionTextBox.Enabled = false;
            _xResolutionTextBox.Location = new Point(88, 75);
            _xResolutionTextBox.Name = "_xResolutionTextBox";
            _xResolutionTextBox.ReadOnly = true;
            _xResolutionTextBox.Size = new Size(100, 23);
            _xResolutionTextBox.TabIndex = 8;
            // 
            // _currentHeightTextBox
            // 
            _currentHeightTextBox.Enabled = false;
            _currentHeightTextBox.Location = new Point(88, 46);
            _currentHeightTextBox.Name = "_currentHeightTextBox";
            _currentHeightTextBox.ReadOnly = true;
            _currentHeightTextBox.Size = new Size(100, 23);
            _currentHeightTextBox.TabIndex = 7;
            // 
            // _currentWidthTextBox
            // 
            _currentWidthTextBox.Enabled = false;
            _currentWidthTextBox.Location = new Point(88, 17);
            _currentWidthTextBox.Name = "_currentWidthTextBox";
            _currentWidthTextBox.ReadOnly = true;
            _currentWidthTextBox.Size = new Size(100, 23);
            _currentWidthTextBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 49);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 3;
            label2.Text = "Height:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 107);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 5;
            label4.Text = "Y Resolution";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 20);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 2;
            label1.Text = "Width:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 78);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 4;
            label3.Text = "X Resolution:";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(_scaleButton);
            groupBox1.Controls.Add(_widthHeightTypeComboBox);
            groupBox1.Controls.Add(_scaleResolutionRatioLockedCheckBox);
            groupBox1.Controls.Add(_aspectRationLockedCheckBox);
            groupBox1.Controls.Add(_scaleYResolutionNumberBox);
            groupBox1.Controls.Add(_scaleXResolutionNumberBox);
            groupBox1.Controls.Add(_scaleHeightNumberBox);
            groupBox1.Controls.Add(_scaleWidthNumberBox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Location = new Point(210, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(444, 190);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Scale Image";
            // 
            // _scaleButton
            // 
            _scaleButton.Location = new Point(165, 156);
            _scaleButton.Name = "_scaleButton";
            _scaleButton.Size = new Size(75, 23);
            _scaleButton.TabIndex = 13;
            _scaleButton.Text = "Scale";
            _scaleButton.UseVisualStyleBackColor = true;
            _scaleButton.Click += _scaleButton_Click;
            // 
            // _widthHeightTypeComboBox
            // 
            _widthHeightTypeComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _widthHeightTypeComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            _widthHeightTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _widthHeightTypeComboBox.FormattingEnabled = true;
            _widthHeightTypeComboBox.Items.AddRange(new object[] { "px", "percent", "inches", "millimeters" });
            _widthHeightTypeComboBox.Location = new Point(252, 31);
            _widthHeightTypeComboBox.Name = "_widthHeightTypeComboBox";
            _widthHeightTypeComboBox.Size = new Size(103, 23);
            _widthHeightTypeComboBox.TabIndex = 12;
            _widthHeightTypeComboBox.SelectedIndexChanged += _widthHeightTypeComboBox_SelectedIndexChanged;
            // 
            // _scaleResolutionRatioLockedCheckBox
            // 
            _scaleResolutionRatioLockedCheckBox.AutoSize = true;
            _scaleResolutionRatioLockedCheckBox.Checked = true;
            _scaleResolutionRatioLockedCheckBox.CheckState = CheckState.Checked;
            _scaleResolutionRatioLockedCheckBox.Location = new Point(177, 91);
            _scaleResolutionRatioLockedCheckBox.Name = "_scaleResolutionRatioLockedCheckBox";
            _scaleResolutionRatioLockedCheckBox.Size = new Size(69, 19);
            _scaleResolutionRatioLockedCheckBox.TabIndex = 11;
            _scaleResolutionRatioLockedCheckBox.Text = "Locked?";
            _scaleResolutionRatioLockedCheckBox.UseVisualStyleBackColor = true;
            // 
            // _aspectRationLockedCheckBox
            // 
            _aspectRationLockedCheckBox.AutoSize = true;
            _aspectRationLockedCheckBox.Checked = true;
            _aspectRationLockedCheckBox.CheckState = CheckState.Checked;
            _aspectRationLockedCheckBox.Location = new Point(177, 33);
            _aspectRationLockedCheckBox.Name = "_aspectRationLockedCheckBox";
            _aspectRationLockedCheckBox.Size = new Size(69, 19);
            _aspectRationLockedCheckBox.TabIndex = 10;
            _aspectRationLockedCheckBox.Text = "Locked?";
            _aspectRationLockedCheckBox.UseVisualStyleBackColor = true;
            // 
            // _scaleYResolutionNumberBox
            // 
            _scaleYResolutionNumberBox.Location = new Point(88, 105);
            _scaleYResolutionNumberBox.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            _scaleYResolutionNumberBox.Name = "_scaleYResolutionNumberBox";
            _scaleYResolutionNumberBox.Size = new Size(83, 23);
            _scaleYResolutionNumberBox.TabIndex = 9;
            _scaleYResolutionNumberBox.ValueChanged += _scaleYResolutionNumberBox_ValueChanged;
            // 
            // _scaleXResolutionNumberBox
            // 
            _scaleXResolutionNumberBox.Location = new Point(88, 76);
            _scaleXResolutionNumberBox.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            _scaleXResolutionNumberBox.Name = "_scaleXResolutionNumberBox";
            _scaleXResolutionNumberBox.Size = new Size(83, 23);
            _scaleXResolutionNumberBox.TabIndex = 8;
            _scaleXResolutionNumberBox.ValueChanged += _scaleXResolutionNumberBox_ValueChanged;
            // 
            // _scaleHeightNumberBox
            // 
            _scaleHeightNumberBox.Location = new Point(88, 46);
            _scaleHeightNumberBox.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            _scaleHeightNumberBox.Name = "_scaleHeightNumberBox";
            _scaleHeightNumberBox.Size = new Size(83, 23);
            _scaleHeightNumberBox.TabIndex = 7;
            _scaleHeightNumberBox.ValueChanged += _scaleHeightNumberBox_ValueChanged;
            // 
            // _scaleWidthNumberBox
            // 
            _scaleWidthNumberBox.Location = new Point(88, 17);
            _scaleWidthNumberBox.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            _scaleWidthNumberBox.Name = "_scaleWidthNumberBox";
            _scaleWidthNumberBox.Size = new Size(83, 23);
            _scaleWidthNumberBox.TabIndex = 6;
            _scaleWidthNumberBox.ValueChanged += _scaleWidthNumberBox_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 49);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 3;
            label5.Text = "Height:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 107);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 5;
            label6.Text = "Y Resolution";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 20);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 2;
            label7.Text = "Width:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 78);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 4;
            label8.Text = "X Resolution:";
            // 
            // _imageNameLabel
            // 
            _imageNameLabel.AutoSize = true;
            _imageNameLabel.Location = new Point(5, 26);
            _imageNameLabel.Name = "_imageNameLabel";
            _imageNameLabel.Size = new Size(38, 15);
            _imageNameLabel.TabIndex = 1;
            _imageNameLabel.Text = "label1";
            // 
            // _imagesPictureBox
            // 
            _imagesPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _imagesPictureBox.Location = new Point(3, 53);
            _imagesPictureBox.Name = "_imagesPictureBox";
            _imagesPictureBox.Size = new Size(659, 456);
            _imagesPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            _imagesPictureBox.TabIndex = 0;
            _imagesPictureBox.TabStop = false;
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { _saveNegativeToolstripButton, _createNegativesToolstripButton });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(782, 25);
            toolStrip2.TabIndex = 4;
            toolStrip2.Text = "toolStrip2";
            // 
            // _saveNegativeToolstripButton
            // 
            _saveNegativeToolstripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _saveNegativeToolstripButton.Image = (Image)resources.GetObject("_saveNegativeToolstripButton.Image");
            _saveNegativeToolstripButton.ImageTransparentColor = Color.Black;
            _saveNegativeToolstripButton.Name = "_saveNegativeToolstripButton";
            _saveNegativeToolstripButton.Size = new Size(23, 22);
            _saveNegativeToolstripButton.Text = "Save Negative";
            _saveNegativeToolstripButton.Click += _saveNegativeToolstripButton_Click;
            // 
            // _createNegativesToolstripButton
            // 
            _createNegativesToolstripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _createNegativesToolstripButton.Image = (Image)resources.GetObject("_createNegativesToolstripButton.Image");
            _createNegativesToolstripButton.ImageTransparentColor = Color.Magenta;
            _createNegativesToolstripButton.Name = "_createNegativesToolstripButton";
            _createNegativesToolstripButton.Size = new Size(23, 22);
            _createNegativesToolstripButton.Text = "Create Negative";
            _createNegativesToolstripButton.Click += _CreateColorMappedImageButton_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 35);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 3;
            label9.Text = "label1";
            // 
            // _negativePictureBox
            // 
            _negativePictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _negativePictureBox.Location = new Point(3, 53);
            _negativePictureBox.Name = "_negativePictureBox";
            _negativePictureBox.Size = new Size(776, 456);
            _negativePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            _negativePictureBox.TabIndex = 2;
            _negativePictureBox.TabStop = false;
            // 
            // ImageAndNegativeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_imagesSplitContainer);
            Name = "ImageAndNegativeControl";
            Size = new Size(1451, 726);
            _imagesSplitContainer.Panel1.ResumeLayout(false);
            _imagesSplitContainer.Panel1.PerformLayout();
            _imagesSplitContainer.Panel2.ResumeLayout(false);
            _imagesSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_imagesSplitContainer).EndInit();
            _imagesSplitContainer.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            _currentImageInfoGroupBox.ResumeLayout(false);
            _currentImageInfoGroupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_scaleYResolutionNumberBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)_scaleXResolutionNumberBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)_scaleHeightNumberBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)_scaleWidthNumberBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)_imagesPictureBox).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_negativePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer _imagesSplitContainer;
        private GroupBox groupBox1;
        private ComboBox _widthHeightTypeComboBox;
        private CheckBox _scaleResolutionRatioLockedCheckBox;
        private CheckBox _aspectRationLockedCheckBox;
        private NumericUpDown _scaleYResolutionNumberBox;
        private NumericUpDown _scaleXResolutionNumberBox;
        private NumericUpDown _scaleHeightNumberBox;
        private NumericUpDown _scaleWidthNumberBox;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private GroupBox _currentImageInfoGroupBox;
        private TextBox _yResolutionTextBox;
        private TextBox _xResolutionTextBox;
        private TextBox _currentHeightTextBox;
        private TextBox _currentWidthTextBox;
        private Label label2;
        private Label label4;
        private Label label1;
        private Label label3;
        private Label _imageNameLabel;
        private PictureBox _imagesPictureBox;
        private Panel panel2;
        private Button _scaleButton;
        private Label label9;
        private PictureBox _negativePictureBox;
        private ToolStrip toolStrip1;
        private ToolStripButton _saveImageToolstripButton;
        private ToolStripButton _saveImageAsToolstripButton;
        private ToolStripButton toolStripButton3;
        private ToolStrip toolStrip2;
        private ToolStripButton _saveNegativeToolstripButton;
        private ToolStripButton _createNegativesToolstripButton;
        private ToolTip toolTip1;
    }
}
