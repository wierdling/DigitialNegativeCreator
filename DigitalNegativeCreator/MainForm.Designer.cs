namespace DigitalNegativeCreator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            _createNegativeToolstripButton = new ToolStripButton();
            _imageTabs = new TabControl();
            tabPage1 = new TabPage();
            _resizeImageToolstripButton = new ToolStripButton();
            toolStrip1.SuspendLayout();
            _imageTabs.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, _createNegativeToolstripButton, _resizeImageToolstripButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1057, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "Settings";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // _createNegativeToolstripButton
            // 
            _createNegativeToolstripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _createNegativeToolstripButton.Image = (Image)resources.GetObject("_createNegativeToolstripButton.Image");
            _createNegativeToolstripButton.ImageTransparentColor = Color.Magenta;
            _createNegativeToolstripButton.Name = "_createNegativeToolstripButton";
            _createNegativeToolstripButton.Size = new Size(23, 22);
            _createNegativeToolstripButton.Text = "Create Negative";
            _createNegativeToolstripButton.Click += _createNegativeToolstripButton_Click;
            // 
            // _imageTabs
            // 
            _imageTabs.Controls.Add(tabPage1);
            _imageTabs.Dock = DockStyle.Fill;
            _imageTabs.Location = new Point(0, 25);
            _imageTabs.Name = "_imageTabs";
            _imageTabs.SelectedIndex = 0;
            _imageTabs.Size = new Size(1057, 651);
            _imageTabs.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1049, 623);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // _resizeImageToolstripButton
            // 
            _resizeImageToolstripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _resizeImageToolstripButton.Image = (Image)resources.GetObject("_resizeImageToolstripButton.Image");
            _resizeImageToolstripButton.ImageTransparentColor = Color.Magenta;
            _resizeImageToolstripButton.Name = "_resizeImageToolstripButton";
            _resizeImageToolstripButton.Size = new Size(23, 22);
            _resizeImageToolstripButton.Text = "toolStripButton2";
            _resizeImageToolstripButton.Click += _resizeImageToolstripButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 676);
            Controls.Add(_imageTabs);
            Controls.Add(toolStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Digital Negative Creator";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            _imageTabs.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton _createNegativeToolstripButton;
        private TabControl _imageTabs;
        private TabPage tabPage1;
        private ToolStripButton _resizeImageToolstripButton;
    }
}