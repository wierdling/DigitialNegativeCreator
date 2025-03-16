using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalNegativeCreator
{
    public partial class Settings : Form
    {
        private Dictionary<Point, Color> MappedColorPoints { get; set; }
        public Settings()
        {
            InitializeComponent();
        }


        //  this doesn't work.  will have to figure out a better way.
        [Obsolete]
        public Bitmap CreateTestImage()
        {
            var width = 255 * 5 + 10;
            var height = width;
            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            unsafe
            {
                for (int x = 0; x < 255; x++)
                {
                    var ix = 5 + (x * 5);
                    for (int y = 0; y < 255; y++)
                    {
                        var iy = 5 + (y * 5);
                        for (int xx = 0; xx < 5; xx++)
                        {
                            var fX = ix + xx;
                            for (int yy = 0; yy < 5; yy++)
                            {
                                var fY = iy + yy;
                                byte* pixel = (byte*)ptr + (fX * stride) + (fY * bytesPerPixel);
                            }
                        }
                    }
                }
            }
            return bmp;
        }

       

        public Dictionary<Point, Color> LoadColorMappingForPrintedImage(string imagePath)
        {
            var bmp = new Bitmap(imagePath);
            return CreateAveragedColorMapForFormat24bppRgb(bmp);
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            
        }

        private void CreateColorMappedImage(Dictionary<Point, Color> mappedColors)
        {
            int startPoint = 78 + 35;
            int offset = 74;
            int mult = 20;
            using Bitmap cm = new Bitmap(36 * mult, 21 * mult, PixelFormat.Format32bppArgb);
            var rect2 = new Rectangle(0, 0, cm.Width, cm.Height);
            var bmpData2 = cm.LockBits(rect2, ImageLockMode.ReadOnly, cm.PixelFormat);
            IntPtr ptr2 = bmpData2.Scan0;
            int stride2 = bmpData2.Stride;
            int bytesPerPixel2 = Image.GetPixelFormatSize(bmpData2.PixelFormat) / 8;
            unsafe
            {
                for (int y = 0; y < 21; y++)
                {
                    var iy = startPoint + (y * offset);
                    for (int x = 0; x < 36; x++)
                    {
                        var ix = startPoint + (x * offset);
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
            cm.Save("test.png", ImageFormat.Png);
            var jpg = Bitmap.FromFile("test.png");
            _testImagePictureBox.Image = jpg;
        }

        private Dictionary<Point, Color> CreateAveragedColorMapForFormat24bppRgb(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            Dictionary<Point, Color> mappedColors = new Dictionary<Point, Color>();
            int startPoint = 78 + 35;
            int offset = 74;
            unsafe
            {
                for (int y = 0; y < 21; y++)
                {
                    var iy = startPoint + (y * offset);
                    for (int x = 0; x < 36; x++)
                    {
                        var ix = startPoint + (x * offset);
                        var color = GetPixelNeighborsAverage(ix, iy, ptr, stride, bytesPerPixel);
                        int gray = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                        var grayColor = Color.FromArgb(255, gray, gray, gray);
                        mappedColors.Add(new Point(ix, iy), grayColor);

                    }
                }
            }
            return mappedColors;
        }

        unsafe private Color GetPixelNeighborsAverage(int x, int y, IntPtr ptr, int stride, int bytesPerPixel)
        {
            int sumR = 0, sumG = 0, sumB = 0, count = 0;
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int nx = x + dx;
                    int ny = y + dy;
                    byte* pixel = (byte*)ptr + (ny * stride) + (nx * bytesPerPixel);
                    byte blue = pixel[0];
                    byte green = pixel[1];
                    byte red = pixel[2];

                    sumR += red;
                    sumG += green;
                    sumB += blue;
                    count++;
                }
            }
            return Color.FromArgb(sumR / count, sumG / count, sumB / count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (DialogResult.OK != ofd.ShowDialog())
            {
                return;
            }
            Dictionary<Point, Color> greyscaleMappedColors = LoadColorMappingForPrintedImage(ofd.FileName);
            CreateColorMappedImage(greyscaleMappedColors);
            MappedColorPoints = ImageUtilities.CreateColorMapping("EDN_HSB2_inverted.jpg");
            SortedDictionary<Color, Point> sortedColors = new SortedDictionary<Color, Point>(new GrayscaleColorComparer());
            foreach(var kvp in greyscaleMappedColors)
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
            foreach(var kvp in sortedColors)
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
            foreach(var kvp in normalizedGreyscaleMappedColors)
            {
                serializebleList.Add(new KeyValuePair<string, Point>(ColorToHex(kvp.Key), kvp.Value));
            }
            string json = JsonSerializer.Serialize(serializebleList, new JsonSerializerOptions() { WriteIndented= true });
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
    }
}
