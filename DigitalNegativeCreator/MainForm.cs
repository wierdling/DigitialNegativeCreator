using DigitalNegativeCreator.Entities;
using System.Drawing.Imaging;
using System.Text.Json;

namespace DigitalNegativeCreator
{
    public partial class MainForm : Form
    {
        private SettingsEntity SettingsEntity = new SettingsEntity();
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
            var ofd = new OpenFileDialog();
            ofd.Title = "Open Main Image To Convert";
            if (DialogResult.OK != ofd.ShowDialog())
            {
                return;
            }
            var imageFileName = ofd.FileName;

            var originalImageBitmap = (Bitmap)Bitmap.FromFile(imageFileName, true);
            AddImageToTabControl(originalImageBitmap, imageFileName);

            if (SettingsEntity.SortedGrayscaleColorMapping == null || SettingsEntity.SortedGrayscaleColorMapping.Count == 0)
            {
                LoadGrayscaleMappingFile();
            }

            if (null == SettingsEntity?.SortedGrayscaleColorMapping) return; // todo: show message?

            Cursor = Cursors.WaitCursor;
            try
            {
                Bitmap bmp = (Bitmap)originalImageBitmap.Clone();
                ImageUtilities.DesaturateBitmap(bmp);
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);


                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int stride = bmpData.Stride;
                int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
                unsafe
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            byte* pixel = (byte*)ptr + (y * stride) + (x * bytesPerPixel);
                            byte blue = (byte)(255 - pixel[0]); // image is desaturated now, so ok to just use first color component from pixel (inverted).
                            var color = SettingsEntity.SortedGrayscaleColorMapping.Keys.FirstOrDefault(x => x.B == blue);
                            if (!color.IsEmpty)

                            {
                                var point = SettingsEntity.SortedGrayscaleColorMapping[color];
                                var swapColor = SettingsEntity.ColorPointMappings[point];
                                pixel[0] = swapColor.R;
                                pixel[1] = swapColor.G;
                                pixel[2] = swapColor.B;
                            }
                        }
                    }
                }

                bmp.UnlockBits(bmpData);
                var now = DateTime.Now;
                var negativeFileName = $"{Path.GetFileNameWithoutExtension(imageFileName)}_negative_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.tiff";
                var negativePictureBox = AddImageToTabControl(bmp, negativeFileName);
                bmp.Save(Path.Combine(Path.GetDirectoryName(imageFileName), negativeFileName), ImageFormat.Tiff);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private PictureBox AddImageToTabControl(Bitmap bmp, string fileName)
        {
            var tabPage = new TabPage($"Original Image: {Path.GetFileNameWithoutExtension(fileName)}");
            var pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = bmp;
            tabPage.Controls.Add(pictureBox);
            _imageTabs.TabPages.Add(tabPage);
            return pictureBox;
        }

        private void LoadGrayscaleMappingFile()
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