namespace DigitalNegativeCreator
{
    public partial class ImageDisplayForm : Form
    {
        public ImageDisplayForm(Bitmap image)
        {
            InitializeComponent();
            _pictureBox.Image = image;
            _pictureBox.Size = image.Size;
        }
    }
}
