using System.Drawing.Imaging;
using System.Text.Json;
using DigitalNegativeCreator.HelperClasses;
using DigitalNegativeCreator.Utilities;

namespace DigitalNegativeCreator
{
    public partial class Settings : Form
    {
        private Dictionary<Point, Color> MappedColorPoints { get; set; }

        public Settings()
        {
            InitializeComponent();
        }


        public Dictionary<Point, Color> LoadColorMappingForPrintedImage(string imagePath)
        {
            var bmp = new Bitmap(imagePath);
            ImageUtilities.DesaturateBitmap(bmp);
            var grayscaleBitmap = ImageUtilities.ConvertDesaturatedToGrayscale(bmp);
            return ImageUtilities.CreateAveragedColorMapForFormat24bppRgb(bmp, ImageUtilities.OFFSET, ImageUtilities.OFFSET, ImageUtilities.CELLSIZE);
        }

        private void Settings_Shown(object sender, EventArgs e)
        {

        }

        private void CreateColorMappedImage(Dictionary<Point, Color> mappedColors)
        {
            int startPoint = ImageUtilities.OFFSET + ImageUtilities.HALFCELLSIZE;
            int yOffset = ImageUtilities.CELLSIZE; // cell size
            int mult = 20;
            using Bitmap cm = new Bitmap(ImageUtilities.ROWS * mult, ImageUtilities.COLUMNS * mult, PixelFormat.Format32bppArgb);
            var rect2 = new Rectangle(0, 0, cm.Width, cm.Height);
            var bmpData2 = cm.LockBits(rect2, ImageLockMode.ReadOnly, cm.PixelFormat);
            IntPtr ptr2 = bmpData2.Scan0;
            int stride2 = bmpData2.Stride;
            int bytesPerPixel2 = Image.GetPixelFormatSize(bmpData2.PixelFormat) / 8;
            unsafe
            {
                for (int y = 0; y < ImageUtilities.COLUMNS; y++)
                {
                    var iy = startPoint + (y * yOffset);
                    for (int x = 0; x < ImageUtilities.ROWS; x++)
                    {
                        var ix = startPoint + (x * yOffset);
                        var p = new Point(ix, iy);
                        var color = mappedColors[p];
                        for (int yy = 0; yy < mult; yy++)
                        {
                            int subY = ((y * mult) * stride2) + (stride2 * yy);
                            for (int xx = 0; xx < mult; xx++)
                            {
                                int subX = (x * mult) + xx;
                                byte* pixel = (byte*)ptr2 + subY + (subX * bytesPerPixel2);
                                pixel[0] = color.B;
                                pixel[1] = color.G;
                                pixel[2] = color.R;
                                pixel[3] = color.A;
                            }
                        }
                    }
                }
            }
            cm.UnlockBits(bmpData2);
            //cm.Save("test.png", ImageFormat.Png);
            var jpg = Bitmap.FromFile("test.png");
            _testImagePictureBox.Image = jpg;
        }

        private void CreateGrayScaleMappedImageButton_Click(object sender, EventArgs e)
        {
            //  Load a scanned image that was printed using the test imge to print.
            //  The printed image needs to be fully processed (toned, fixed, etc).
            var ofd = new OpenFileDialog();
            if (DialogResult.OK != ofd.ShowDialog())
            {
                return;
            }
            Dictionary<Point, Color> greyscaleMappedColors = LoadColorMappingForPrintedImage(ofd.FileName);
            //CreateColorMappedImage(greyscaleMappedColors);
            //MappedColorPoints = ImageUtilities.CreateColorMapping("TestImageToPrint.png");
            SortedDictionary<Color, Point> sortedColors = new SortedDictionary<Color, Point>(new GrayscaleColorComparer());
            foreach (var kvp in greyscaleMappedColors)
            {
                Color foundColor = sortedColors.Keys.FirstOrDefault(x => x.R == kvp.Value.R && x.G == kvp.Value.G && x.B == kvp.Value.B);
                if (foundColor.R == 0 && foundColor.G == 0 && foundColor.B == 0 && foundColor.A == 0)
                {
                    sortedColors.Add(kvp.Value, kvp.Key);
                }
            }

            var normalizedGreyscaleMappedColors = new SortedDictionary<Color, Point>(new GrayscaleColorComparer());
            byte max = sortedColors.First().Key.R; // they are greyscale so ok to use red.
            byte min = sortedColors.Last().Key.R;
            foreach (var kvp in sortedColors)
            {
                byte r = kvp.Key.R;
                byte newR = (byte)((r - min) * (byte)255 / (max - min));
                Color scaledColor = Color.FromArgb(newR, newR, newR);
                normalizedGreyscaleMappedColors.Add(scaledColor, kvp.Value);
            }

            //  Serialize the dict to disk.
            var now = DateTime.UtcNow;
            var fileName = $"MappedGrayscaleColors_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.json";
            var serializebleList = new List<KeyValuePair<string, Point>>();
            foreach (var kvp in normalizedGreyscaleMappedColors)
            {
                serializebleList.Add(new KeyValuePair<string, Point>(ColorToHex(kvp.Key), kvp.Value));
            }
            string json = JsonSerializer.Serialize(serializebleList, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }

        public static string ColorToHex(Color color) => $"#{color.R:X2}{color.G:X2}{color.B:X2}";

        public static Color ColorFromHex(string hex)
        {
            var rString = hex.Substring(1, 2);
            var gString = hex.Substring(3, 2);
            var bString = hex.Substring(5, 2);
            var r = Convert.ToByte(rString, 16);
            var g = Convert.ToByte(gString, 16);
            var b = Convert.ToByte(bString, 16);
            return Color.FromArgb(r, g, b);
        }

        private void _normalizeColorMappingButton_Click(object sender, EventArgs e)
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
            List<KeyValuePair<Color, Point>> itemsToAdd = new List<KeyValuePair<Color, Point>>();
            for (int i = 0; i < sortedColors.Count - 1; i++)
            {
                var testColor = sortedColors.Keys.ElementAt(i);
                var testByte = testColor.R;
                if (sortedColors.Keys.ElementAt(i + 1).R != testByte + 1)
                {
                    itemsToAdd.Add(new KeyValuePair<Color, Point>(Color.FromArgb(testByte + 1, testByte + 1, testByte + 1), sortedColors[testColor]));
                }
            }
            if (itemsToAdd.Any())
            {
                foreach (var kvp in itemsToAdd)
                {
                    sortedColors.Add(kvp.Key, kvp.Value);
                }
                var serializebleList = new List<KeyValuePair<string, Point>>();
                foreach (var kvp in sortedColors)
                {
                    serializebleList.Add(new KeyValuePair<string, Point>(ColorToHex(kvp.Key), kvp.Value));
                }
                string json = JsonSerializer.Serialize(serializebleList, new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(ofd.FileName, json);
                MessageBox.Show($"Added {itemsToAdd.Count} new mapped colors.");
            }
            else
            {
                MessageBox.Show("Finished.");
            }
        }

        private void _createTestImageButton_Click(object sender, EventArgs e)
        {
            var testImage = ImageUtilities.CreateTestImage();
            testImage.Save("TestImageToPrint.png", ImageFormat.Png);
        }
    }
}
