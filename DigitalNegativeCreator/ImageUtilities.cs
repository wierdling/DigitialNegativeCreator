using DigitalNegativeCreator.Entities;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DigitalNegativeCreator
{
    public static class ImageUtilities
    {
        private const int ALPHA = 3;
        private const int RED = 2;
        private const int GREEN = 1;
        private const int BLUE = 0;

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

        public static Bitmap ResizeBitmap(Bitmap originalBitmap, int width, int height, int verticalResolution, int horizontalResolution)
        {
            // Create a new bitmap with the desired size
            Bitmap resizedBitmap = new Bitmap(width, height);
            resizedBitmap.SetResolution(verticalResolution, horizontalResolution);

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

        public static Bitmap CreateTestImage()
        {
            var cellInchSize = .234;
            var border = .05;
            var dpi = 100; // using 100 vs 96 so everything works out mathmatically easier.
            //  We want each block plus one spacer line to be .5 inches.
            var rowHeight = cellInchSize * dpi;
            var paperWidth = 11.0;
            var paperHeight = 8.5;
            var spacer = (int)(border * dpi);
            var blockSize = (int)((cellInchSize - border) * dpi);
            var width = (int)(paperWidth * dpi);
            var height = (int)(paperHeight * dpi);
            var rows = (int)(height / rowHeight);
            //rows -= 1; // one blank row on top
            var columns = (int)(width / rowHeight); // row height is actually cell heght/width.
            columns -= 2; // one blank at the beginning, one blank at the end.
            Bitmap bmp = new Bitmap(width, height);
            bmp.SetResolution(dpi, dpi);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            var t = bmp.PixelFormat;

            int startY = (int)(rowHeight / 2);
            int startX = (int)(rowHeight * 1.5);
            int cellSize = (int)(rowHeight);
            int red = 0;
            int blue = 0;
            int green = 0;

            var smallStep = 7;
            var largeStep = (255 - (smallStep * 17)) / 17;
            var centerRow = 18; // 0 index, actual row 19
            var babyStep = 2;

            var redColumn = 0;
            var greenColumn = 15;
            var blueColumn = 30;
            var columnOffset = 8;
            int c = 0;

            unsafe
            {
                byte* pixel;
                int currentColumn;

                for(int c1 = 0; c1 < bmp.Width; c1++)
                {
                    for(int r1 = 0; r1 < bmp.Height; r1++)
                    {
                        pixel = (byte*)ptr + (r1 * stride) + (c1 * bytesPerPixel);
                        pixel[GREEN] = (byte)0;
                        pixel[BLUE] = (byte)0;
                        pixel[RED] = (byte)0;
                        pixel[ALPHA] = (byte)255;
                    }
                }

                //  First row, 0 for everything.
                for(int columnCount = 0; columnCount < columns; columnCount++)
                {
                    currentColumn = startX + (columnCount * cellSize);
                    var iy = startY; // 1 == rowcount
                    for (int y2 = 0; y2 < blockSize; y2++)
                    {
                        for (int x2 = 0; x2 < blockSize; x2++)
                        {
                            pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                            pixel[GREEN] = (byte)0;
                            pixel[BLUE] = (byte)0;
                            pixel[RED] = (byte)0;
                        }
                    }
                }

                //  first set of columns, increments of red to center row, then max red.
                red = 0;
                currentColumn = startX;

                for (int columnCount = 0; columnCount < columnOffset; columnCount++)
                {
                    red = 0;
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = 0; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[RED] = (byte)red;
                            }
                        }
                        red += 15;
                        if (red > 255) red = 255;
                    }
                }

                for (int columnCount = columns - columnOffset + 1; columnCount < columns; columnCount++)
                {
                    red = 0;
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = 0; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[RED] = (byte)red;
                            }
                        }
                        red += 15;
                        if (red > 255) red = 255;
                    }
                }

                //  Green columns
                for (int columnCount = greenColumn - columnOffset + 1; columnCount < greenColumn + columnOffset; columnCount++)
                {
                    green = 0;
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = 0; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[GREEN] = (byte)green;
                            }
                        }
                        green += 15;
                        if (green > 255) green = 255;
                    }
                }

                //  Blue columns
                for (int columnCount = blueColumn - columnOffset + 1; columnCount < blueColumn + columnOffset; columnCount++)
                {
                    blue = 0;
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = 0; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[BLUE] = (byte)blue;
                            }
                        }
                        blue += 15;
                        if (blue > 255) blue = 255;
                    }
                }
                
                //  Green from column red add baby step for each row.
                green = (int)babyStep;
                for (int columnCount = redColumn; columnCount < redColumn + columnOffset; columnCount++)
                {
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        if (rowCount <= centerRow)
                        {
                            if (currentColumn == redColumn)
                            {
                                green = 0;
                            }
                            else if (columnCount == redColumn + 1)
                            {
                                green = (rowCount * babyStep) + ((columnCount - 1) * babyStep);
                            }
                            else
                            {
                                pixel = (byte*)ptr + (iy * stride) + ((startX + ((redColumn + 1) * cellSize)) * bytesPerPixel);
                                var tGreen = (byte)pixel[GREEN];
                                green = tGreen * columnCount;

                            }
                            if (green > 255) green = 255;
                            if (green < 0) green = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + ((startY + (centerRow * cellSize)) * stride) + ((startX + ((columnCount) * cellSize)) * bytesPerPixel);
                            var tempGreen = (byte)pixel[GREEN];
                            var mult = (255 - tempGreen) / 17;
                            green = (mult * (rowCount - centerRow)) + tempGreen;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[GREEN] = (byte)green;
                            }
                        }
                    }
                }
                
                //  Green from blue column back to blue column - offset.
                c = 0;
                for (int columnCount = blueColumn; columnCount > blueColumn - columnOffset; columnCount--)
                {
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        if (rowCount <= centerRow)
                        {
                            if (currentColumn == blueColumn)
                            {
                                green = 0;
                            }
                            else if (columnCount == blueColumn - 1)
                            {
                                green = (rowCount * babyStep) + ((c - 1) * babyStep);
                            }
                            else
                            {
                                pixel = (byte*)ptr + (iy * stride) + ((startX + ((blueColumn - 1) * cellSize)) * bytesPerPixel);
                                var tGreen = (byte)pixel[GREEN];
                                green = tGreen * c;

                            }
                            if (green > 255) green = 255;
                            if (green < 0) green = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + ((startY + (centerRow * cellSize)) * stride) + ((startX + ((columnCount) * cellSize)) * bytesPerPixel);
                            var tempGreen = (byte)pixel[GREEN];
                            var mult = (255 - tempGreen) / 17;
                            green = (mult * (rowCount - centerRow)) + tempGreen;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[GREEN] = (byte)green;
                            }
                        }
                    }
                    c++;
                }
                
                //  blue from last column back to last column - offset.
                c = 0;
                for (int columnCount = columns - 1; columnCount > columns - columnOffset - 1; columnCount--)
                {
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        if (rowCount <= centerRow)
                        {
                            if (columnCount == columns - 1)
                            {
                                blue = (rowCount * babyStep) + (c * babyStep);
                            }
                            else
                            {
                                pixel = (byte*)ptr + (iy * stride) + ((startX + ((columns - 1) * cellSize)) * bytesPerPixel);
                                var tBlue = (byte)pixel[BLUE];
                                blue = tBlue * (c + 1);

                            }
                            if (blue > 255) blue = 255;
                            if (blue < 0) blue = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + ((startY + (centerRow * cellSize)) * stride) + ((startX + ((columnCount) * cellSize)) * bytesPerPixel);
                            var tempBlue = (byte)pixel[BLUE];
                            var mult = (255 - tempBlue) / 17;
                            blue = (mult * (rowCount - centerRow)) + tempBlue;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[BLUE] = (byte)blue;
                            }
                        }
                    }
                    c++;
                }

                //  blue for first column to < greenColumn.
                for (int columnCount = 0; columnCount < greenColumn; columnCount++)
                {
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = centerRow; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        pixel = (byte*)ptr + ((startY + (centerRow * cellSize)) * stride) + (startX * bytesPerPixel);
                        var tempBlue = (byte)pixel[BLUE];
                        var mult = (255 - tempBlue) / 17;
                        blue = (mult * (rowCount - centerRow)) + tempBlue;
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[BLUE] = (byte)blue;
                            }
                        }
                    }
                }
                
                // blue from green over to green + offset
                for (int columnCount = greenColumn; columnCount < greenColumn + columnOffset; columnCount++)
                {
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        if (rowCount <= centerRow)
                        {
                            if (columnCount == greenColumn)
                            {
                                blue = 0;
                            }
                            else if (columnCount == greenColumn + 1)
                            {
                                blue = (rowCount * babyStep) + ((columnCount - greenColumn - 1) * babyStep);
                            }
                            else
                            {
                                pixel = (byte*)ptr + (iy * stride) + ((startX + ((greenColumn + 1) * cellSize)) * bytesPerPixel);
                                var tBlue = (byte)pixel[BLUE];
                                blue = tBlue * ((columnCount - greenColumn) + 1);

                            }
                            if (blue > 255) blue = 255;
                            if (blue < 0) blue = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + ((startY + (centerRow * cellSize)) * stride) + ((startX + ((columnCount) * cellSize)) * bytesPerPixel);
                            var tempBlue = (byte)pixel[BLUE];
                            var mult = (255 - tempBlue) / 17;
                            blue = (mult * (rowCount - centerRow)) + tempBlue;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[BLUE] = (byte)blue;
                            }
                        }
                    }
                }

                // red from blue column to blue column + offset
                red = (int)babyStep;
                c = 0;
                for (int columnCount = blueColumn; columnCount < blueColumn + columnOffset; columnCount++)
                {
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        if (rowCount <= centerRow)
                        {
                            if (columnCount == blueColumn)
                            {
                                red = 0;
                            }
                            else if (columnCount == blueColumn + 1)
                            {
                                red = (rowCount * babyStep) + ((c - 1) * babyStep);
                            }
                            else
                            {
                                pixel = (byte*)ptr + (iy * stride) + ((startX + ((blueColumn + 1) * cellSize)) * bytesPerPixel);
                                var tRed = (byte)pixel[RED];
                                red = tRed * (c - 1);

                            }
                            if (red > 255) red = 255;
                            if (red < 0) red = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + ((startY + (centerRow * cellSize)) * stride) + ((startX + (columnCount * cellSize)) * bytesPerPixel);
                            var tempRed = (byte)pixel[RED];
                            var mult = (255 - tempRed) / 17;
                            red = (mult * (rowCount - centerRow)) + tempRed;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[RED] = (byte)red;
                            }
                        }
                    }
                    c++;
                }

                //  red from green down to green - offset
                c = 0;
                for (int columnCount = greenColumn; columnCount > greenColumn - columnOffset; columnCount--)
                {
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        if (rowCount <= centerRow)
                        {
                            if (currentColumn == greenColumn)
                            {
                                red = 0;
                            }
                            else if (columnCount == greenColumn - 1)
                            {
                                red = (rowCount * babyStep) + ((c - 1) * babyStep);
                            }
                            else
                            {
                                pixel = (byte*)ptr + (iy * stride) + ((startX + ((greenColumn - 1) * cellSize)) * bytesPerPixel);
                                var tRed = (byte)pixel[RED];
                                red = tRed * c;

                            }
                            if (red > 255) red = 255;
                            if (red < 0) red = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + ((startY + (centerRow * cellSize)) * stride) + ((startX + ((columnCount) * cellSize)) * bytesPerPixel);
                            var tRed = (byte)pixel[RED];
                            var mult = (255 - tRed) / 17;
                            red = (mult * (rowCount - centerRow)) + tRed;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[RED] = (byte)red;
                                pixel[ALPHA] = (byte)255;
                            }
                        }
                    }
                    c++;
                }

                //  red for first green column + 1 to < blueColumn.
                for (int columnCount = greenColumn + 1; columnCount < blueColumn; columnCount++)
                {
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = centerRow; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        pixel = (byte*)ptr + ((startY + (centerRow * cellSize)) * stride) + ((startX + (greenColumn * cellSize)) * bytesPerPixel);
                        var tempRed = (byte)pixel[RED];
                        var mult = (255 - tempRed) / 17;
                        red = (mult * (rowCount - centerRow)) + tempRed;
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[RED] = (byte)red;
                            }
                        }
                    }
                }

                //  green for first blue column + 1 to < columns - 1.
                for (int columnCount = blueColumn + 1; columnCount < columns; columnCount++)
                {
                    currentColumn = startX + (columnCount * cellSize);
                    for (int rowCount = centerRow; rowCount < rows; rowCount++)
                    {
                        var iy = startY + (rowCount * cellSize);
                        pixel = (byte*)ptr + ((startY + (centerRow * cellSize)) * stride) + ((startX + (blueColumn * cellSize)) * bytesPerPixel);
                        var tGreen = (byte)pixel[GREEN];
                        var mult = (255 - tGreen) / 17;
                        green = (mult * (rowCount - centerRow)) + tGreen;
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + ((y2 + iy) * stride) + ((currentColumn + x2) * bytesPerPixel);
                                pixel[GREEN] = (byte)green;
                            }
                        }
                    }
                }
            }
            return bmp;
        }

        private static byte GammaCorrect(ushort value)
        {
            double normalized = value / 65535.0; // Scale to [0,1]
            double corrected = Math.Pow(normalized, 1.0 / 2.2); // Gamma Correction
            return (byte)(corrected * 255); // Scale to [0,255]
        }
    }
}
