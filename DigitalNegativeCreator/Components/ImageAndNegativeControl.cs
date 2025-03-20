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
        private string Filename { get; set; }
        private Bitmap ImageFile { get; set; }
        private Bitmap NegativeFile { get; set; }

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
            Filename = ofd.FileName;
            ImageFile = (Bitmap)Bitmap.FromFile(Filename, true);
            SetImageInfo(ImageFile, Filename);
        }

        private void _createNegativeButton_Click(object sender, EventArgs e)
        {
            if (MainForm.SettingsEntity.SortedGrayscaleColorMapping == null || MainForm.SettingsEntity.SortedGrayscaleColorMapping.Count == 0)
            {
                MainForm.LoadGrayscaleMappingFile();
            }

            if (null == MainForm.SettingsEntity?.SortedGrayscaleColorMapping) return; // todo: show message?

            Cursor = Cursors.WaitCursor;
            try
            {
                DateTime now = DateTime.Now;
                var negativeFileName = $"{Path.GetFileNameWithoutExtension(Filename)}_negative_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.tiff";
                NegativeFile = ImageUtilities.CreateNegative(ImageFile, MainForm.SettingsEntity, Filename, negativeFileName);
                if (null != NegativeFile)
                {
                    _negativePictureBox.Image = NegativeFile;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
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
