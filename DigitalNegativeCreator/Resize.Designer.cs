namespace DigitalNegativeCreator
{
    partial class Resize
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
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            _originalWidth = new NumericUpDown();
            _originalHeight = new NumericUpDown();
            _originalResolution = new NumericUpDown();
            _newResolution = new NumericUpDown();
            _newHeight = new NumericUpDown();
            _newWidth = new NumericUpDown();
            _lockAspectRationCheckBox = new CheckBox();
            _okButton = new Button();
            _cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)_originalWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_originalHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_originalResolution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_newResolution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_newHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_newWidth).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 51);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Width:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 109);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Resolution";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 80);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 3;
            label4.Text = "Height";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(319, 18);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 4;
            label5.Text = "New";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(135, 18);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 5;
            label6.Text = "Original";
            // 
            // _originalWidth
            // 
            _originalWidth.Enabled = false;
            _originalWidth.Location = new Point(115, 49);
            _originalWidth.Maximum = new decimal(new int[] { 316580113, 18446744, 0, 0 });
            _originalWidth.Name = "_originalWidth";
            _originalWidth.Size = new Size(120, 23);
            _originalWidth.TabIndex = 6;
            // 
            // _originalHeight
            // 
            _originalHeight.Enabled = false;
            _originalHeight.Location = new Point(115, 78);
            _originalHeight.Maximum = new decimal(new int[] { 316580113, 18446744, 0, 0 });
            _originalHeight.Name = "_originalHeight";
            _originalHeight.Size = new Size(120, 23);
            _originalHeight.TabIndex = 7;
            // 
            // _originalResolution
            // 
            _originalResolution.Enabled = false;
            _originalResolution.Location = new Point(115, 107);
            _originalResolution.Maximum = new decimal(new int[] { 316580113, 18446744, 0, 0 });
            _originalResolution.Name = "_originalResolution";
            _originalResolution.Size = new Size(120, 23);
            _originalResolution.TabIndex = 8;
            // 
            // _newResolution
            // 
            _newResolution.Location = new Point(270, 107);
            _newResolution.Maximum = new decimal(new int[] { 316580113, 18446744, 0, 0 });
            _newResolution.Name = "_newResolution";
            _newResolution.Size = new Size(120, 23);
            _newResolution.TabIndex = 9;
            // 
            // _newHeight
            // 
            _newHeight.Location = new Point(270, 78);
            _newHeight.Maximum = new decimal(new int[] { 316580113, 18446744, 0, 0 });
            _newHeight.Name = "_newHeight";
            _newHeight.Size = new Size(120, 23);
            _newHeight.TabIndex = 10;
            _newHeight.ValueChanged += _newHeight_ValueChanged;
            // 
            // _newWidth
            // 
            _newWidth.Location = new Point(270, 49);
            _newWidth.Maximum = new decimal(new int[] { 316580113, 18446744, 0, 0 });
            _newWidth.Name = "_newWidth";
            _newWidth.Size = new Size(120, 23);
            _newWidth.TabIndex = 11;
            _newWidth.ValueChanged += _newWidth_ValueChanged;
            // 
            // _lockAspectRationCheckBox
            // 
            _lockAspectRationCheckBox.AutoSize = true;
            _lockAspectRationCheckBox.Checked = true;
            _lockAspectRationCheckBox.CheckState = CheckState.Checked;
            _lockAspectRationCheckBox.Location = new Point(411, 82);
            _lockAspectRationCheckBox.Name = "_lockAspectRationCheckBox";
            _lockAspectRationCheckBox.Size = new Size(125, 19);
            _lockAspectRationCheckBox.TabIndex = 12;
            _lockAspectRationCheckBox.Text = "Lock Aspect Ratio?";
            _lockAspectRationCheckBox.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            _okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _okButton.Location = new Point(12, 140);
            _okButton.Name = "_okButton";
            _okButton.Size = new Size(75, 23);
            _okButton.TabIndex = 13;
            _okButton.Text = "&Apply";
            _okButton.UseVisualStyleBackColor = true;
            _okButton.Click += _okButton_Click;
            // 
            // _cancelButton
            // 
            _cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _cancelButton.Location = new Point(449, 140);
            _cancelButton.Name = "_cancelButton";
            _cancelButton.Size = new Size(75, 23);
            _cancelButton.TabIndex = 14;
            _cancelButton.Text = "&Cancel";
            _cancelButton.UseVisualStyleBackColor = true;
            _cancelButton.Click += _cancelButton_Click;
            // 
            // Resize
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 175);
            ControlBox = false;
            Controls.Add(_cancelButton);
            Controls.Add(_okButton);
            Controls.Add(_lockAspectRationCheckBox);
            Controls.Add(_newWidth);
            Controls.Add(_newHeight);
            Controls.Add(_newResolution);
            Controls.Add(_originalResolution);
            Controls.Add(_originalHeight);
            Controls.Add(_originalWidth);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "Resize";
            Text = "Resize Image";
            ((System.ComponentModel.ISupportInitialize)_originalWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)_originalHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)_originalResolution).EndInit();
            ((System.ComponentModel.ISupportInitialize)_newResolution).EndInit();
            ((System.ComponentModel.ISupportInitialize)_newHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)_newWidth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown _originalWidth;
        private NumericUpDown _originalHeight;
        private NumericUpDown _originalResolution;
        private NumericUpDown _newResolution;
        private NumericUpDown _newHeight;
        private NumericUpDown _newWidth;
        private CheckBox _lockAspectRationCheckBox;
        private Button _okButton;
        private Button _cancelButton;
    }
}