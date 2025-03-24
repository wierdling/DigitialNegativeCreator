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
            _widthHeightTypeComboBox.SelectedIndex = 0;
        }

        public void LoadImage()
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Open Main Image To Convert";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.tiff;";
            if (DialogResult.OK != ofd.ShowDialog())
            {
                return;
            }
            Filename = ofd.FileName;
            ImageFile = (Bitmap)Bitmap.FromFile(Filename, true);
            SetImageInfo(ImageFile, Filename);
        }

        private void _CreateNegativeButton_Click(object sender, EventArgs e)
        {
            //  Get the grayscale mapping file (json).
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
            decimal width = _scaleWidthNumberBox.Value;
            decimal height = _scaleHeightNumberBox.Value;
            if (_widthHeightTypeComboBox.Text.Equals("inches"))
            {
                width *= _scaleXResolutionNumberBox.Value;
                height *= _scaleYResolutionNumberBox.Value;
            }
            var newBitmap = ImageUtilities.ResizeBitmap(ImageFile, (int)width, (int)height, (int)_scaleXResolutionNumberBox.Value, (int)_scaleYResolutionNumberBox.Value);
            SetImageInfo(newBitmap, Filename);
        }

        private void SetImageInfo(Bitmap bitmap, string fileName)
        {
            ImageFile = bitmap;
            _imagesPictureBox.Image = bitmap;
            _imageNameLabel.Text = Path.GetFileNameWithoutExtension(fileName);
            _xResolutionTextBox.Text = $"{bitmap.VerticalResolution}";
            _yResolutionTextBox.Text = $"{bitmap.HorizontalResolution}";
            _scaleXResolutionNumberBox.Value = (decimal)bitmap.HorizontalResolution;
            _scaleYResolutionNumberBox.Value = (decimal)bitmap.VerticalResolution;
            SetImageInfoForPX();
        }

        private void _scaleWidthNumberBox_ValueChanged(object? sender, EventArgs e)
        {
            if (!_aspectRationLockedCheckBox.Checked) return;
            RemoveHanlders();
            decimal newHeight = (decimal)((double)_scaleWidthNumberBox.Value / ImageFile.Height * ImageFile.Width);
            _scaleHeightNumberBox.Value = newHeight;
            AddHandlers();
        }

        private void _scaleHeightNumberBox_ValueChanged(object? sender, EventArgs e)
        {
            if (!_aspectRationLockedCheckBox.Checked) return;
            RemoveHanlders();
            decimal newWidth = (decimal)((double)_scaleHeightNumberBox.Value / ImageFile.Height * ImageFile.Width);
            _scaleWidthNumberBox.Value = newWidth;
            AddHandlers();
        }

        private void _scaleXResolutionNumberBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void _scaleYResolutionNumberBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void _saveImageAsToolstripButton_Click(object sender, EventArgs e)
        {

        }

        private void _saveNegativeToolstripButton_Click(object sender, EventArgs e)
        {

        }

        private void _widthHeightTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveHanlders();
            switch (_widthHeightTypeComboBox.Text)
            {
                case "px":
                    SetImageInfoForPX();
                    break;
                case "inches":
                    SetImageInfoForInches();
                    break;
            }
            AddHandlers();
        }

        private void SetImageInfoForPX()
        {
            if (null == ImageFile) return;

            _currentWidthTextBox.Text = $"{ImageFile.Width}";
            _currentHeightTextBox.Text = $"{ImageFile.Height}";
            _scaleWidthNumberBox.DecimalPlaces = 0;
            _scaleWidthNumberBox.Value = ImageFile.Width;
            _scaleHeightNumberBox.DecimalPlaces= 0;
            _scaleHeightNumberBox.Value = ImageFile.Height;
        }

        private void SetImageInfoForInches()
        {
            if (null == ImageFile) return;

            _currentWidthTextBox.Text = $"{(ImageFile.Width / ImageFile.HorizontalResolution):F3}";
            _currentHeightTextBox.Text = $"{(ImageFile.Height / ImageFile.VerticalResolution):F3}";
            _scaleWidthNumberBox.DecimalPlaces = 3;
            _scaleWidthNumberBox.Value = (decimal)((float)ImageFile.Width / ImageFile.HorizontalResolution);
            _scaleHeightNumberBox.DecimalPlaces = 3;
            _scaleHeightNumberBox.Value = (decimal)((float)ImageFile.Height / ImageFile.VerticalResolution);
        }

        private void RemoveHanlders()
        {
            _scaleWidthNumberBox.ValueChanged -= _scaleWidthNumberBox_ValueChanged;
            _scaleHeightNumberBox.ValueChanged -= _scaleHeightNumberBox_ValueChanged;
        }

        private void AddHandlers()
        {
            _scaleWidthNumberBox.ValueChanged += _scaleWidthNumberBox_ValueChanged;
            _scaleHeightNumberBox.ValueChanged += _scaleHeightNumberBox_ValueChanged;
        }
    }
}
