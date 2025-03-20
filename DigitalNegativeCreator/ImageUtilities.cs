using DigitalNegativeCreator.Entities;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace DigitalNegativeCreator
{
    public static class ImageUtilities
    {
        public static Bitmap? CreateNegative(Bitmap originalImageBitmap, SettingsEntity settingsEntity, string imageFileName, string negativeFileName)
        {
            Bitmap bmp = (Bitmap)originalImageBitmap.Clone();
            ImageUtilities.DesaturateBitmap(bmp);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            var regularDict = new Dictionary<Color, Point>();
            foreach(var kvp in settingsEntity.SortedGrayscaleColorMapping)
            {
                regularDict.Add(kvp.Key, kvp.Value);
            }
            unsafe
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        byte* pixel = (byte*)ptr + (y * stride) + (x * bytesPerPixel);
                        byte blue = (byte)(255 - pixel[0]); // image is desaturated now, so ok to just use first color component from pixel (inverted).
                        var color = regularDict.Keys.FirstOrDefault(x => x.B == blue);
                        if (!color.IsEmpty)
                        {
                            var point = regularDict[color];
                            var swapColor = settingsEntity.ColorPointMappings[point];
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

        public static Bitmap ResizeBitmap(Bitmap originalBitmap, int width, int height)
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

        public static void DesaturateBitmap(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            int stride = bmpData.Stride;
            IntPtr scan0 = bmpData.Scan0;

            unsafe
            {
                byte* ptr = (byte*)scan0;

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        byte* pixel = ptr + (y * stride) + (x * bytesPerPixel);

                        // Compute grayscale value using luminance formula RGB
                        byte gray = (byte)(0.299 * pixel[2] + 0.587 * pixel[1] + 0.114 * pixel[0]);

                        // Assign grayscale value (preserving alpha)
                        pixel[0] = gray; // Red
                        pixel[1] = gray; // Green
                        pixel[2] = gray; // Blue
                    }
                }
            }

            bmp.UnlockBits(bmpData);
        }

        public static Dictionary<Point, Color> CreateColorMapForFormat48bppRgb(Bitmap bmp)
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
                        byte* pixel = (byte*)ptr + (iy * stride) + (ix * bytesPerPixel);

                        ushort blue = (ushort)(pixel[1] << 8 | pixel[0]);   // R = (high << 8) | low
                        ushort green = (ushort)(pixel[3] << 8 | pixel[2]); // G = (high << 8) | low
                        ushort red = (ushort)(pixel[5] << 8 | pixel[4]);
                        var color = Color.FromArgb(255, GammaCorrect(red), GammaCorrect(green), GammaCorrect(blue));
                        mappedColors.Add(new Point(ix, iy), color);
                        //int gray = (int)(0.299 * red + 0.587 * green + 0.114 * blue);
                        //var grayColor = Color.FromArgb(alpha, gray, gray, gray);

                    }
                }
            }
            return mappedColors;
        }

        public static Dictionary<Point, Color> CreateColorMapForFormat24bppRgb(Bitmap bmp)
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
                        byte* pixel = (byte*)ptr + (iy * stride) + (ix * bytesPerPixel);

                        byte blue = pixel[0];
                        byte green = pixel[1];
                        byte red = pixel[2];
                        var color = Color.FromArgb(255, red, green, blue);
                        //var color = Color.FromArgb(255, red >> 8, green >> 8, blue >> 8));
                        mappedColors.Add(new Point(ix, iy), color);
                        //int gray = (int)(0.299 * red + 0.587 * green + 0.114 * blue);
                        //var grayColor = Color.FromArgb(alpha, gray, gray, gray);

                    }
                }
            }
            return mappedColors;
        }

        public static Dictionary<Point, Color> CreateColorMapping(string imagePath)
        {
            using Bitmap bmp = new Bitmap(imagePath);
            Dictionary<Point, Color> mappedColors;
            switch (bmp.PixelFormat)
            {
                case PixelFormat.Format48bppRgb:
                    mappedColors = ImageUtilities.CreateColorMapForFormat48bppRgb(bmp);
                    break;
                default:
                    mappedColors = ImageUtilities.CreateColorMapForFormat24bppRgb(bmp);
                    break;
            }
            return mappedColors;
        }

        private static byte GammaCorrect(ushort value)
        {
            double normalized = value / 65535.0; // Scale to [0,1]
            double corrected = Math.Pow(normalized, 1.0 / 2.2); // Gamma Correction
            return (byte)(corrected * 255); // Scale to [0,255]
        }
    }
}
