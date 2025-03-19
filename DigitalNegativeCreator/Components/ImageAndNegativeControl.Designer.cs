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
            this._imagesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._saveImageButton = new System.Windows.Forms.Button();
            this._createNegativeButton = new System.Windows.Forms.Button();
            this._currentImageInfoGroupBox = new System.Windows.Forms.GroupBox();
            this._yResolutionTextBox = new System.Windows.Forms.TextBox();
            this._xResolutionTextBox = new System.Windows.Forms.TextBox();
            this._currentHeightTextBox = new System.Windows.Forms.TextBox();
            this._currentWidthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._scaleButton = new System.Windows.Forms.Button();
            this._widthHeightTypeComboBox = new System.Windows.Forms.ComboBox();
            this._scaleResolutionRatioLockedCheckBox = new System.Windows.Forms.CheckBox();
            this._aspectRationLockedCheckBox = new System.Windows.Forms.CheckBox();
            this._scaleYResolutionNumberBox = new System.Windows.Forms.NumericUpDown();
            this._scaleXResolutionNumberBox = new System.Windows.Forms.NumericUpDown();
            this._scaleHeightNumberBox = new System.Windows.Forms.NumericUpDown();
            this._scaleWidthNumberBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._imageNameLabel = new System.Windows.Forms.Label();
            this._imagesPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._imagesSplitContainer)).BeginInit();
            this._imagesSplitContainer.Panel1.SuspendLayout();
            this._imagesSplitContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this._currentImageInfoGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scaleYResolutionNumberBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._scaleXResolutionNumberBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._scaleHeightNumberBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._scaleWidthNumberBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._imagesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _imagesSplitContainer
            // 
            this._imagesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._imagesSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._imagesSplitContainer.Name = "_imagesSplitContainer";
            // 
            // _imagesSplitContainer.Panel1
            // 
            this._imagesSplitContainer.Panel1.Controls.Add(this.panel2);
            this._imagesSplitContainer.Panel1.Controls.Add(this._imageNameLabel);
            this._imagesSplitContainer.Panel1.Controls.Add(this._imagesPictureBox);
            this._imagesSplitContainer.Size = new System.Drawing.Size(1451, 726);
            this._imagesSplitContainer.SplitterDistance = 802;
            this._imagesSplitContainer.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this._currentImageInfoGroupBox);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(5, 515);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 208);
            this.panel2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this._saveImageButton);
            this.panel1.Controls.Add(this._createNegativeButton);
            this.panel1.Location = new System.Drawing.Point(3, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 189);
            this.panel1.TabIndex = 11;
            // 
            // _saveImageButton
            // 
            this._saveImageButton.Location = new System.Drawing.Point(3, 32);
            this._saveImageButton.Name = "_saveImageButton";
            this._saveImageButton.Size = new System.Drawing.Size(75, 23);
            this._saveImageButton.TabIndex = 1;
            this._saveImageButton.Text = "Save Image";
            this._saveImageButton.UseVisualStyleBackColor = true;
            this._saveImageButton.Click += new System.EventHandler(this._saveImageButton_Click);
            // 
            // _createNegativeButton
            // 
            this._createNegativeButton.Location = new System.Drawing.Point(3, 3);
            this._createNegativeButton.Name = "_createNegativeButton";
            this._createNegativeButton.Size = new System.Drawing.Size(101, 23);
            this._createNegativeButton.TabIndex = 0;
            this._createNegativeButton.Text = "Create Negative";
            this._createNegativeButton.UseVisualStyleBackColor = true;
            this._createNegativeButton.Click += new System.EventHandler(this._createNegativeButton_Click);
            // 
            // _currentImageInfoGroupBox
            // 
            this._currentImageInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._currentImageInfoGroupBox.Controls.Add(this._yResolutionTextBox);
            this._currentImageInfoGroupBox.Controls.Add(this._xResolutionTextBox);
            this._currentImageInfoGroupBox.Controls.Add(this._currentHeightTextBox);
            this._currentImageInfoGroupBox.Controls.Add(this._currentWidthTextBox);
            this._currentImageInfoGroupBox.Controls.Add(this.label2);
            this._currentImageInfoGroupBox.Controls.Add(this.label4);
            this._currentImageInfoGroupBox.Controls.Add(this.label1);
            this._currentImageInfoGroupBox.Controls.Add(this.label3);
            this._currentImageInfoGroupBox.Location = new System.Drawing.Point(126, 11);
            this._currentImageInfoGroupBox.Name = "_currentImageInfoGroupBox";
            this._currentImageInfoGroupBox.Size = new System.Drawing.Size(201, 189);
            this._currentImageInfoGroupBox.TabIndex = 6;
            this._currentImageInfoGroupBox.TabStop = false;
            this._currentImageInfoGroupBox.Text = "Image Info";
            // 
            // _yResolutionTextBox
            // 
            this._yResolutionTextBox.Enabled = false;
            this._yResolutionTextBox.Location = new System.Drawing.Point(88, 104);
            this._yResolutionTextBox.Name = "_yResolutionTextBox";
            this._yResolutionTextBox.ReadOnly = true;
            this._yResolutionTextBox.Size = new System.Drawing.Size(100, 23);
            this._yResolutionTextBox.TabIndex = 9;
            // 
            // _xResolutionTextBox
            // 
            this._xResolutionTextBox.Enabled = false;
            this._xResolutionTextBox.Location = new System.Drawing.Point(88, 75);
            this._xResolutionTextBox.Name = "_xResolutionTextBox";
            this._xResolutionTextBox.ReadOnly = true;
            this._xResolutionTextBox.Size = new System.Drawing.Size(100, 23);
            this._xResolutionTextBox.TabIndex = 8;
            // 
            // _currentHeightTextBox
            // 
            this._currentHeightTextBox.Enabled = false;
            this._currentHeightTextBox.Location = new System.Drawing.Point(88, 46);
            this._currentHeightTextBox.Name = "_currentHeightTextBox";
            this._currentHeightTextBox.ReadOnly = true;
            this._currentHeightTextBox.Size = new System.Drawing.Size(100, 23);
            this._currentHeightTextBox.TabIndex = 7;
            // 
            // _currentWidthTextBox
            // 
            this._currentWidthTextBox.Enabled = false;
            this._currentWidthTextBox.Location = new System.Drawing.Point(88, 17);
            this._currentWidthTextBox.Name = "_currentWidthTextBox";
            this._currentWidthTextBox.ReadOnly = true;
            this._currentWidthTextBox.Size = new System.Drawing.Size(100, 23);
            this._currentWidthTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y Resolution";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "X Resolution:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._scaleButton);
            this.groupBox1.Controls.Add(this._widthHeightTypeComboBox);
            this.groupBox1.Controls.Add(this._scaleResolutionRatioLockedCheckBox);
            this.groupBox1.Controls.Add(this._aspectRationLockedCheckBox);
            this.groupBox1.Controls.Add(this._scaleYResolutionNumberBox);
            this.groupBox1.Controls.Add(this._scaleXResolutionNumberBox);
            this.groupBox1.Controls.Add(this._scaleHeightNumberBox);
            this.groupBox1.Controls.Add(this._scaleWidthNumberBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(333, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 190);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scale Image";
            // 
            // _scaleButton
            // 
            this._scaleButton.Location = new System.Drawing.Point(165, 156);
            this._scaleButton.Name = "_scaleButton";
            this._scaleButton.Size = new System.Drawing.Size(75, 23);
            this._scaleButton.TabIndex = 13;
            this._scaleButton.Text = "Scale";
            this._scaleButton.UseVisualStyleBackColor = true;
            this._scaleButton.Click += new System.EventHandler(this._scaleButton_Click);
            // 
            // _widthHeightTypeComboBox
            // 
            this._widthHeightTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._widthHeightTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._widthHeightTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._widthHeightTypeComboBox.FormattingEnabled = true;
            this._widthHeightTypeComboBox.Items.AddRange(new object[] {
            "px",
            "percent",
            "inches",
            "millimeters"});
            this._widthHeightTypeComboBox.Location = new System.Drawing.Point(252, 31);
            this._widthHeightTypeComboBox.Name = "_widthHeightTypeComboBox";
            this._widthHeightTypeComboBox.Size = new System.Drawing.Size(121, 23);
            this._widthHeightTypeComboBox.TabIndex = 12;
            // 
            // _scaleResolutionRatioLockedCheckBox
            // 
            this._scaleResolutionRatioLockedCheckBox.AutoSize = true;
            this._scaleResolutionRatioLockedCheckBox.Checked = true;
            this._scaleResolutionRatioLockedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._scaleResolutionRatioLockedCheckBox.Location = new System.Drawing.Point(177, 91);
            this._scaleResolutionRatioLockedCheckBox.Name = "_scaleResolutionRatioLockedCheckBox";
            this._scaleResolutionRatioLockedCheckBox.Size = new System.Drawing.Size(69, 19);
            this._scaleResolutionRatioLockedCheckBox.TabIndex = 11;
            this._scaleResolutionRatioLockedCheckBox.Text = "Locked?";
            this._scaleResolutionRatioLockedCheckBox.UseVisualStyleBackColor = true;
            // 
            // _aspectRationLockedCheckBox
            // 
            this._aspectRationLockedCheckBox.AutoSize = true;
            this._aspectRationLockedCheckBox.Checked = true;
            this._aspectRationLockedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._aspectRationLockedCheckBox.Location = new System.Drawing.Point(177, 33);
            this._aspectRationLockedCheckBox.Name = "_aspectRationLockedCheckBox";
            this._aspectRationLockedCheckBox.Size = new System.Drawing.Size(69, 19);
            this._aspectRationLockedCheckBox.TabIndex = 10;
            this._aspectRationLockedCheckBox.Text = "Locked?";
            this._aspectRationLockedCheckBox.UseVisualStyleBackColor = true;
            // 
            // _scaleYResolutionNumberBox
            // 
            this._scaleYResolutionNumberBox.Location = new System.Drawing.Point(88, 105);
            this._scaleYResolutionNumberBox.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this._scaleYResolutionNumberBox.Name = "_scaleYResolutionNumberBox";
            this._scaleYResolutionNumberBox.Size = new System.Drawing.Size(83, 23);
            this._scaleYResolutionNumberBox.TabIndex = 9;
            this._scaleYResolutionNumberBox.ValueChanged += new System.EventHandler(this._scaleYResolutionNumberBox_ValueChanged);
            // 
            // _scaleXResolutionNumberBox
            // 
            this._scaleXResolutionNumberBox.Location = new System.Drawing.Point(88, 76);
            this._scaleXResolutionNumberBox.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this._scaleXResolutionNumberBox.Name = "_scaleXResolutionNumberBox";
            this._scaleXResolutionNumberBox.Size = new System.Drawing.Size(83, 23);
            this._scaleXResolutionNumberBox.TabIndex = 8;
            this._scaleXResolutionNumberBox.ValueChanged += new System.EventHandler(this._scaleXResolutionNumberBox_ValueChanged);
            // 
            // _scaleHeightNumberBox
            // 
            this._scaleHeightNumberBox.Location = new System.Drawing.Point(88, 46);
            this._scaleHeightNumberBox.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this._scaleHeightNumberBox.Name = "_scaleHeightNumberBox";
            this._scaleHeightNumberBox.Size = new System.Drawing.Size(83, 23);
            this._scaleHeightNumberBox.TabIndex = 7;
            this._scaleHeightNumberBox.ValueChanged += new System.EventHandler(this._scaleHeightNumberBox_ValueChanged);
            // 
            // _scaleWidthNumberBox
            // 
            this._scaleWidthNumberBox.Location = new System.Drawing.Point(88, 17);
            this._scaleWidthNumberBox.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this._scaleWidthNumberBox.Name = "_scaleWidthNumberBox";
            this._scaleWidthNumberBox.Size = new System.Drawing.Size(83, 23);
            this._scaleWidthNumberBox.TabIndex = 6;
            this._scaleWidthNumberBox.ValueChanged += new System.EventHandler(this._scaleWidthNumberBox_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Height:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Y Resolution";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Width:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "X Resolution:";
            // 
            // _imageNameLabel
            // 
            this._imageNameLabel.AutoSize = true;
            this._imageNameLabel.Location = new System.Drawing.Point(5, 6);
            this._imageNameLabel.Name = "_imageNameLabel";
            this._imageNameLabel.Size = new System.Drawing.Size(38, 15);
            this._imageNameLabel.TabIndex = 1;
            this._imageNameLabel.Text = "label1";
            // 
            // _imagesPictureBox
            // 
            this._imagesPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._imagesPictureBox.Location = new System.Drawing.Point(3, 26);
            this._imagesPictureBox.Name = "_imagesPictureBox";
            this._imagesPictureBox.Size = new System.Drawing.Size(796, 483);
            this._imagesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._imagesPictureBox.TabIndex = 0;
            this._imagesPictureBox.TabStop = false;
            // 
            // ImageAndNegativeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._imagesSplitContainer);
            this.Name = "ImageAndNegativeControl";
            this.Size = new System.Drawing.Size(1451, 726);
            this._imagesSplitContainer.Panel1.ResumeLayout(false);
            this._imagesSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._imagesSplitContainer)).EndInit();
            this._imagesSplitContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this._currentImageInfoGroupBox.ResumeLayout(false);
            this._currentImageInfoGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scaleYResolutionNumberBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._scaleXResolutionNumberBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._scaleHeightNumberBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._scaleWidthNumberBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._imagesPictureBox)).EndInit();
            this.ResumeLayout(false);

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
        private Panel panel1;
        private Button _saveImageButton;
        private Button _createNegativeButton;
        private Button _scaleButton;
    }
}
