using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalNegativeCreator.Components
{
    public partial class ImageAndNegativeControl : UserControl
    {
        //  possible widthHeight types:
        /*
         px
        percent
        inches
        millimeters
        */
        public ImageAndNegativeControl()
        {
            InitializeComponent();
            _widthHeightTypeComboBox.SelectedIndex = 1;
        }

        public void LoadImage()
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Open Main Image To Convert";
            if (DialogResult.OK != ofd.ShowDialog())
            {
                return;
            }
            var imageFileName = ofd.FileName;

            var originalImageBitmap = (Bitmap)Bitmap.FromFile(imageFileName, true);
            SetImageInfo(originalImageBitmap, imageFileName);
        }

        private void _createNegativeButton_Click(object sender, EventArgs e)
        {

        }

        private void _saveImageButton_Click(object sender, EventArgs e)
        {

        }

        private void _scaleButton_Click(object sender, EventArgs e)
        {

        }

        private void SetImageInfo(Bitmap bitmap, string fileName)
        {
            _imagesPictureBox.Image = bitmap;
            _imageNameLabel.Text = Path.GetFileNameWithoutExtension(fileName);
            _currentWidthTextBox.Text = $"{bitmap.Width}";
            _currentHeightTextBox.Text = $"{bitmap.Height}";
            _xResolutionTextBox.Text = $"{bitmap.VerticalResolution}";
            _yResolutionTextBox.Text = $"{bitmap.HorizontalResolution}";
            _scaleWidthNumberBox.Value = bitmap.Width;
            _scaleHeightNumberBox.Value = bitmap.Height;
            _scaleXResolutionNumberBox.Value = (decimal)bitmap.HorizontalResolution;
            _scaleYResolutionNumberBox.Value = (decimal)bitmap.VerticalResolution;
        }

        private void _scaleWidthNumberBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void _scaleHeightNumberBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void _scaleXResolutionNumberBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void _scaleYResolutionNumberBox_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
