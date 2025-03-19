using DigitalNegativeCreator.Components;
using DigitalNegativeCreator.Entities;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.Json;

namespace DigitalNegativeCreator
{
    public partial class MainForm : Form
    {
        private SettingsEntity SettingsEntity = new SettingsEntity();
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

            //if (SettingsEntity.SortedGrayscaleColorMapping == null || SettingsEntity.SortedGrayscaleColorMapping.Count == 0)
            //{
            //    LoadGrayscaleMappingFile();
            //}

            //if (null == SettingsEntity?.SortedGrayscaleColorMapping) return; // todo: show message?

            //Cursor = Cursors.WaitCursor;
            //try
            //{
            //    DateTime now = DateTime.Now;
            //    var negativeFileName = $"{Path.GetFileNameWithoutExtension(imageFileName)}_negative_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.tiff";
            //    var bmp = CreateNegative(originalImageBitmap, imageFileName, negativeFileName);
            //    if (null == bmp) return;
            //    var negativePictureBox = AddImageToTabControl(bmp, negativeFileName, negativeFileName);
            //    ImageNegativePairs.Add(imageFileName, negativeFileName);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
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

        private void _resizeImageToolstripButton_Click(object sender, EventArgs e)
        {
            var tabPage = _imageTabs.SelectedTab;
            var pb = GetPictureBoxFromTabPageControls(tabPage);
            if (pb == null) return;
            var image = pb.Image as Bitmap;
            float dpiX = image.HorizontalResolution;
            float dpiY = image.VerticalResolution;
            int bitDepth = Image.GetPixelFormatSize(image.PixelFormat);
            var sizeEntity = new ImageSizeEntity { Height = image.Height, Width = image.Width, Resolution = (int)dpiX * bitDepth };
            var resizeDialog = new Resize(sizeEntity);
            resizeDialog.OnImageSize += (sender, e) =>
            {
                var newImage = ResizeBitmap(image, e.Width, e.Height);
                pb.Image = newImage;
                if (ImageNegativePairs.ContainsKey(tabPage.Tag as string))
                {
                    foreach(TabPage tp in _imageTabs.TabPages)
                    {
                        if (((string)tp.Tag).Equals(ImageNegativePairs[tabPage.Tag as string]))
                        {
                            var negPictureBox = GetPictureBoxFromTabPageControls(tp);
                            var bmp = CreateNegative(newImage, tabPage.Tag as string, tp.Tag as string);
                            negPictureBox.Image = bmp;
                        }
                    }
                }
            };
            resizeDialog.ShowDialog(this);
        }

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

        static Bitmap ResizeBitmap(Bitmap originalBitmap, int width, int height)
        {
            // Create a new bitmap with the desired size
            Bitmap resizedBitmap = new Bitmap(width, height);

            // Use Graphics for high-quality resizing
            using (Graphics graphics = Graphics.FromImage(resizedBitmap))
            {
                // Set high-quality interpolation mode
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                // Draw the original image onto the resized bitmap
                graphics.DrawImage(originalBitmap, 0, 0, width, height);
            }

            return resizedBitmap;
        }

        private Bitmap? CreateNegative(Bitmap originalImageBitmap, string imageFileName, string negativeFileName)
        {
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
            
                bmp.Save(Path.Combine(Path.GetDirectoryName(imageFileName), negativeFileName), ImageFormat.Tiff);
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}