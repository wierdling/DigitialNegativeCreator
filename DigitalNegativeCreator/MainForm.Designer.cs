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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this._createNegativeToolstripButton = new System.Windows.Forms.ToolStripButton();
            this._imageTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1.SuspendLayout();
            this._imageTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this._createNegativeToolstripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1057, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Settings";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // _createNegativeToolstripButton
            // 
            this._createNegativeToolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._createNegativeToolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("_createNegativeToolstripButton.Image")));
            this._createNegativeToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._createNegativeToolstripButton.Name = "_createNegativeToolstripButton";
            this._createNegativeToolstripButton.Size = new System.Drawing.Size(23, 22);
            this._createNegativeToolstripButton.Text = "Create Negative";
            this._createNegativeToolstripButton.Click += new System.EventHandler(this._createNegativeToolstripButton_Click);
            // 
            // _imageTabs
            // 
            this._imageTabs.Controls.Add(this.tabPage1);
            this._imageTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._imageTabs.Location = new System.Drawing.Point(0, 25);
            this._imageTabs.Name = "_imageTabs";
            this._imageTabs.SelectedIndex = 0;
            this._imageTabs.Size = new System.Drawing.Size(1057, 651);
            this._imageTabs.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1049, 623);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 676);
            this.Controls.Add(this._imageTabs);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Digital Negative Creator";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this._imageTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton _createNegativeToolstripButton;
        private TabControl _imageTabs;
        private TabPage tabPage1;
    }
}