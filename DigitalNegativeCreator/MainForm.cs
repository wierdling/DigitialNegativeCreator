using DigitalNegativeCreator.Components;
using DigitalNegativeCreator.Entities;
using System.Text.Json;

namespace DigitalNegativeCreator
{
    public partial class MainForm : Form
    {
        public static SettingsEntity SettingsEntity = new SettingsEntity();
        private Dictionary<string, string> ImageNegativePairs { get; set; } = new Dictionary<string, string>();
        public MainForm()
        {
            InitializeComponent();
            _imageTabs.TabPages.Clear();
        }

        private void ShowSettings()
        {
            Settings s = new Settings();
            s.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void _createNegativeToolstripButton_Click(object sender, EventArgs e)
        {
            var imageAndNegativeControl = new ImageAndNegativeControl();
            imageAndNegativeControl.Dock= DockStyle.Fill;
            var tabPage = new TabPage();
            tabPage.Controls.Add(imageAndNegativeControl);
            _imageTabs.TabPages.Add(tabPage);
            imageAndNegativeControl.LoadImage();
            //var ofd = new OpenFileDialog();
            //ofd.Title = "Open Main Image To Convert";
            //if (DialogResult.OK != ofd.ShowDialog())
            //{
            //    return;
            //}
            //var imageFileName = ofd.FileName;

            //var originalImageBitmap = (Bitmap)Bitmap.FromFile(imageFileName, true);
            //AddImageToTabControl(originalImageBitmap, imageFileName, imageFileName);


        }

        //private PictureBox AddImageToTabControl(Bitmap bmp, string fileName, string tag)
        //{
        //    var tabPage = new TabPage($"Original Image: {Path.GetFileNameWithoutExtension(fileName)}");
        //    tabPage.Tag = tag;
        //    var pictureBox = new PictureBox();
        //    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        //    pictureBox.Dock = DockStyle.Fill;
        //    pictureBox.Image = bmp;
        //    tabPage.Controls.Add(pictureBox);
        //    _imageTabs.TabPages.Add(tabPage);
        //    return pictureBox;
        //}

        public static void LoadGrayscaleMappingFile()
        {
            var ofd = new OpenFileDialog();
            ofd.FileName = string.Empty;
            ofd.Title = "Open Grayscale mapping file";
            if (DialogResult.OK != ofd.ShowDialog())
            {
                return;
            }
            var grayscaleMappingSettingsFileName = ofd.FileName;
            SortedDictionary<Color, Point> sortedColors = new SortedDictionary<Color, Point>(new GrayscaleColorComparer());
            var jsonString = File.ReadAllText(grayscaleMappingSettingsFileName);
            var list = JsonSerializer.Deserialize<List<KeyValuePair<string, Point>>>(jsonString);
            foreach (var kvp in list)
            {
                sortedColors.Add(Settings.ColorFromHex(kvp.Key), kvp.Value);
            }

            SettingsEntity.SortedGrayscaleColorMapping = sortedColors;
            SettingsEntity.ColorPointMappings = ImageUtilities.CreateColorMapping("EDN_HSB2_inverted.jpg");

        }

        //private void _resizeImageToolstripButton_Click(object sender, EventArgs e)
        //{
        //    var tabPage = _imageTabs.SelectedTab;
        //    var pb = GetPictureBoxFromTabPageControls(tabPage);
        //    if (pb == null) return;
        //    var image = pb.Image as Bitmap;
        //    float dpiX = image.HorizontalResolution;
        //    float dpiY = image.VerticalResolution;
        //    int bitDepth = Image.GetPixelFormatSize(image.PixelFormat);
        //    var sizeEntity = new ImageSizeEntity { Height = image.Height, Width = image.Width, Resolution = (int)dpiX * bitDepth };
        //    var resizeDialog = new Resize(sizeEntity);
        //    resizeDialog.OnImageSize += (sender, e) =>
        //    {
        //        var newImage = ResizeBitmap(image, e.Width, e.Height);
        //        pb.Image = newImage;
        //        if (ImageNegativePairs.ContainsKey(tabPage.Tag as string))
        //        {
        //            foreach(TabPage tp in _imageTabs.TabPages)
        //            {
        //                if (((string)tp.Tag).Equals(ImageNegativePairs[tabPage.Tag as string]))
        //                {
        //                    var negPictureBox = GetPictureBoxFromTabPageControls(tp);
        //                    var bmp = CreateNegative(newImage, tabPage.Tag as string, tp.Tag as string);
        //                    negPictureBox.Image = bmp;
        //                }
        //            }
        //        }
        //    };
        //    resizeDialog.ShowDialog(this);
        //}

        private PictureBox? GetPictureBoxFromTabPageControls(TabPage tabPage)
        {
            PictureBox pb = null;
            foreach (var c in tabPage.Controls)
            {
                if (c is PictureBox)
                {
                    pb = (PictureBox)c;
                    break;
                }
            }
            return pb;
        }

    }
}