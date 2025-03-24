using DigitalNegativeCreator.Components;
using DigitalNegativeCreator.Entities;
using System.Drawing.Imaging;
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
            //var testImage = ImageUtilities.CreateTestImage();
            //testImage.Save("TestImageToPrint.png", ImageFormat.Png);
            //if (File.Exists("./TestImageToPrinInvertedForTesting.png"))
            //{
            //    using Bitmap bmp = (Bitmap)Bitmap.FromFile("TestImageToPrinInvertedForTesting.png");
            //    ImageUtilities.TestImgageScan(bmp);
            //}
        }

        private void ShowSettings()
        {
            Settings s = new Settings();
            s.ShowDialog();
        }

        private void toolStripCreateColorMappedImageButton_Click(object sender, EventArgs e)
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
        }

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

    }
}