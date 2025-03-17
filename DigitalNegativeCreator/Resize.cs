using DigitalNegativeCreator.Entities;

namespace DigitalNegativeCreator
{
    public partial class Resize : Form
    {
        private ImageSizeEntity OriginalImageSize { get; set; }
        public event EventHandler<ImageSizeEntity> OnImageSize;

        public Resize(ImageSizeEntity imageSize)
        {
            InitializeComponent();
            _originalHeight.Value = imageSize.Height;
            _originalWidth.Value = imageSize.Width;
            _originalResolution.Value = imageSize.Resolution;
            OriginalImageSize = imageSize;
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _newWidth_ValueChanged(object sender, EventArgs e)
        {
            if (!_lockAspectRationCheckBox.Checked)
            {
                return;
            }

            var newHeight = ((int)_newWidth.Value / OriginalImageSize.Width) * OriginalImageSize.Height;
            if (newHeight != _newHeight.Value)
            {
                _newHeight.Value = newHeight;
            }
        }

        private void _newHeight_ValueChanged(object sender, EventArgs e)
        {
            if (!_lockAspectRationCheckBox.Checked)
            {
                return;
            }

            var newWidth = ((int)_newHeight.Value / OriginalImageSize.Height) * OriginalImageSize.Width;
            if (newWidth != _newWidth.Value)
            {
                _newWidth.Value = newWidth;
            }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            var newImageSize = new ImageSizeEntity { Height = (int)_newHeight.Value, Width = (int)_newWidth.Value, Resolution = (int)_newResolution.Value };
            OnImageSize?.Invoke(this, newImageSize);
            Close();
        }
    }
}
