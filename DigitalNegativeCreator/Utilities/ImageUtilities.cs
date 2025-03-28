using DigitalNegativeCreator.Entities;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using DigitalNegativeCreator.HelperClasses;

namespace DigitalNegativeCreator.Utilities
{
    public static class ImageUtilities
    {
        private const int ALPHA = 3;
        private const int RED = 2;
        private const int GREEN = 1;
        private const int BLUE = 0;
        public const int ROWS = 48;
        public const int COLUMNS = 62;
        public const int CELLSIZE = 45;
        public const int HALFCELLSIZE = 22;
        public const int OFFSET = 30;

        public static Bitmap? CreateNegative(Bitmap originalImageBitmap, SettingsEntity settingsEntity, string imageFileName, string negativeFileName)
        {
            Bitmap bmp = (Bitmap)originalImageBitmap.Clone();
            DesaturateBitmap(bmp);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            nint ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            var regularDict =  settingsEntity.SortedGrayscaleColorMapping.ToDictionary<Color, Point>();

            unsafe
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        byte* pixel = (byte*)ptr + y * stride + x * bytesPerPixel;
                        byte blue = (byte)(255 - pixel[0]); // image is desaturated now, so ok to just use first color component from pixel (inverted).
                        var color = regularDict.Keys.FirstOrDefault(x => x.B == blue);
                        if (!color.IsEmpty)
                        {
                            var point = regularDict[color];
                            if (settingsEntity.ColorPointMappings.ContainsKey(point))
                            {
                                var swapColor = settingsEntity.ColorPointMappings[point];
                                pixel[0] = swapColor.R;
                                pixel[1] = swapColor.G;
                                pixel[2] = swapColor.B;
                            }
                        }
                    }
                }
            }

            bmp.UnlockBits(bmpData);
            var now = DateTime.Now;

            bmp.Save(Path.Combine(Path.GetDirectoryName(imageFileName), negativeFileName), ImageFormat.Tiff);
            return bmp;

        }

        public static SortedDictionary<Color, Point> TestImgageScan(Bitmap scannedImage)
        {
            //  First desatureate and save bitmap.
            DesaturateBitmap(scannedImage);
            var grayscaleBitmap = ConvertDesaturatedToGrayscale(scannedImage);
            //  Now we need to invert it as the border should be white with black shapes.
            //  the library needs to have white shapes.
            //var newImage = InvertGrayscale(grayscaleBitmap);
            //Mat grayImage = grayscaleBitmap.ToImage<Gray, byte>().Mat;

            //var testOutBmp = new Bitmap(grayscaleBitmap.Width, grayscaleBitmap.Height, PixelFormat.Format24bppRgb);
            //Mat testImage = testOutBmp.ToImage<Gray, byte>().Mat;

            ////  Get test images.
            //if (!File.Exists("OnePlus.png")
            //    || !File.Exists("TwoPlus.png")
            //    || !File.Exists("ThreePlus.png")
            //    || !File.Exists("FourPlus.png"))
            //{
            //    CreateTestShapeImages();
            //}

            //var chainApproxMethod = ChainApproxMethod.ChainApproxNone;

            ////  Diamond, spade, club, heart.
            //var (onePlusContours, allSpaceContours) = GetContour("OnePlus.png", chainApproxMethod);
            //var (twoPlusContours, allDiamonContours) = GetContour("TwoPlus.png", chainApproxMethod);
            //var (threePlusContours, allHeartContours) = GetContour("ThreePlus.png", chainApproxMethod);
            //var (fourPlusContours, allClubContours) = GetContour("FourPlus.png", chainApproxMethod);

            ////CvInvoke.DrawContours(testImage, allSpaceContours, -1, new MCvScalar(128, 128, 128), 1);
            //// Convert to binary using Otsu thresholding (invert: suits are black)
            //Mat binaryImage = new Mat();
            //CvInvoke.Threshold(grayImage, binaryImage, 0, 255, ThresholdType.BinaryInv | ThresholdType.Otsu);
            //CvInvoke.Imwrite("grayImage2.png", binaryImage);

            ////  Single plus == upper left hand.
            ////  double plus == upper right
            ////  tripple plus == lower left
            ////  four plus == lower right
            //int ulX = 0, ulY = 0;
            //int urX = 0, urY = 0;
            //int llX = 0, llY = 0;
            //int lrX = 0, lrY = 0;

            //// Detect contours
            //using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            //{
            //    CvInvoke.FindContours(binaryImage, contours, null, RetrType.External, chainApproxMethod);
            //    for (int i = 0; i < contours.Size; i++)
            //    {
            //        VectorOfPoint contour = contours[i];
            //        Rectangle boundingBox = CvInvoke.BoundingRectangle(contour);
            //        double scale = 100.0 / Math.Max(boundingBox.Width, boundingBox.Height);
            //        Matrix<double> scaleMat = new Matrix<double>(2, 3);
            //        scaleMat.SetIdentity();
            //        scaleMat[0, 0] = scale;
            //        scaleMat[1, 1] = scale;

            //        VectorOfPoint scaledContour = new VectorOfPoint();
            //        CvInvoke.Transform(contour, scaledContour, scaleMat);

            //        double onePlusMatchSCore = CvInvoke.MatchShapes(onePlusContours, scaledContour, ContoursMatchType.I1, 0);
            //        // Lower score means better match (0.0 is perfect)
            //        if (onePlusMatchSCore < .2)
            //        {
            //            // This is likely a spade
            //            var moments = CvInvoke.Moments(contour);
            //            ulX = (int)(moments.M10 / moments.M00);
            //            ulY = (int)(moments.M01 / moments.M00);
            //            // Optional: Draw match
            //            CvInvoke.DrawContours(testImage, contours, i, new MCvScalar(128, 128, 128), 1);
            //        }

            //        double threePlusMatchScore = CvInvoke.MatchShapes(threePlusContours, scaledContour, ContoursMatchType.I1, 0);
            //        if (threePlusMatchScore < 1)
            //        {
            //            var moments = CvInvoke.Moments(contour);
            //            llX = (int)(moments.M10 / moments.M00);
            //            llY = (int)(moments.M01 / moments.M00);
            //            CvInvoke.DrawContours(testImage, contours, i, new MCvScalar(128, 128, 128), 1);
            //        }

            //        double twoPlusMatchScore = CvInvoke.MatchShapes(twoPlusContours, scaledContour, ContoursMatchType.I1, 0);
            //        if (twoPlusMatchScore < .3)
            //        {
            //            var moments = CvInvoke.Moments(contour);
            //            urX = (int)(moments.M10 / moments.M00);
            //            urY = (int)(moments.M01 / moments.M00);
            //            CvInvoke.DrawContours(testImage, contours, i, new MCvScalar(128, 128, 128), 1);
            //        }

            //        double fourPlusMatchScore = CvInvoke.MatchShapes(fourPlusContours, scaledContour, ContoursMatchType.I1, 0);
            //        if (fourPlusMatchScore < .2)
            //        {
            //            var moments = CvInvoke.Moments(contour);
            //            lrX = (int)(moments.M10 / moments.M00);
            //            lrY = (int)(moments.M01 / moments.M00);
            //            CvInvoke.DrawContours(testImage, contours, i, new MCvScalar(128, 128, 128), 1);
            //        }
            //        //System.Diagnostics.Debug.WriteLine($"onePlusMatchScore: {onePlusMatchSCore}. threePlusMatchScore: {threePlusMatchScore}. twoPlusMatchScore: {twoPlusMatchScore}. fourPlusMatchScore: {fourPlusMatchScore}");
            //    }

            //    // Save the result for visual testing.
            //    CvInvoke.Imwrite("testDetectedImage.png", testImage);

            //if (ulX <= 0 || urX <= 0 || llX <= 0 || lrX <= 0) throw new ArgumentException("Could not find starting point for calculations."); // todo: show an error or something.
            var greyscaleMappedColors = CreateAveragedColorMapForFormat24bppRgb(scannedImage, OFFSET, OFFSET, CELLSIZE);
            SortedDictionary<Color, Point> sortedColors = new SortedDictionary<Color, Point>(new GrayscaleColorComparer());
            foreach (var kvp in greyscaleMappedColors)
            {
                Color foundColor = sortedColors.Keys.FirstOrDefault(x => x.R == kvp.Value.R && x.G == kvp.Value.G && x.B == kvp.Value.B);
                if (foundColor.R == 0 && foundColor.G == 0 && foundColor.B == 0 && foundColor.A == 0)
                {
                    sortedColors.Add(kvp.Value, kvp.Key);
                }
            }
            return sortedColors;
            //}
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
            nint scan0 = bmpData.Scan0;

            unsafe
            {
                byte* ptr = (byte*)scan0;

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        byte* pixel = ptr + y * stride + x * bytesPerPixel;

                        // Compute grayscale value using luminance formula RGB
                        byte gray = (byte)(0.299 * pixel[2] + 0.587 * pixel[1] + 0.114 * pixel[0]);

                        // Assign grayscale value (preserving alpha)
                        pixel[RED] = gray; // Red
                        pixel[GREEN] = gray; // Green
                        pixel[BLUE] = gray; // Blue
                    }
                }
            }

            bmp.UnlockBits(bmpData);
        }

        public static Dictionary<Point, Color> CreateColorMapForFormat48bppRgb(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            nint ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            Dictionary<Point, Color> mappedColors = new Dictionary<Point, Color>();
            int startPoint = OFFSET + HALFCELLSIZE;
            int offset = CELLSIZE;
            unsafe
            {
                for (int y = 0; y < ROWS; y++)
                {
                    var iy = startPoint + y * offset;
                    for (int x = 0; x < COLUMNS; x++)
                    {
                        var ix = startPoint + x * offset;
                        byte* pixel = (byte*)ptr + iy * stride + ix * bytesPerPixel;

                        ushort blue = (ushort)(pixel[1] << 8 | pixel[0]);   // R = (high << 8) | low
                        ushort green = (ushort)(pixel[3] << 8 | pixel[2]); // G = (high << 8) | low
                        ushort red = (ushort)(pixel[5] << 8 | pixel[4]);
                        var color = Color.FromArgb(255, GammaCorrect(red), GammaCorrect(green), GammaCorrect(blue));
                        mappedColors.Add(new Point(ix, iy), color);
                    }
                }
            }
            return mappedColors;
        }

        public static Dictionary<Point, Color> CreateColorMapForFormat24bppRgb(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            nint ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            Dictionary<Point, Color> mappedColors = new Dictionary<Point, Color>();
            int startPoint = OFFSET + HALFCELLSIZE;
            int offset = CELLSIZE;
            unsafe
            {
                for (int y = 0; y < ROWS; y++)
                {
                    var iy = startPoint + y * offset;
                    for (int x = 0; x < COLUMNS; x++)
                    {
                        var ix = startPoint + x * offset;
                        byte* pixel = (byte*)ptr + iy * stride + ix * bytesPerPixel;

                        byte blue = pixel[0];
                        byte green = pixel[1];
                        byte red = pixel[2];
                        var color = Color.FromArgb(255, red, green, blue);
                        mappedColors.Add(new Point(ix, iy), color);

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
                    mappedColors = CreateColorMapForFormat48bppRgb(bmp);
                    break;
                default:
                    mappedColors = CreateColorMapForFormat24bppRgb(bmp);
                    break;
            }
            return mappedColors;
        }

        //  This will create an image with 48 rows and 62 columns.
        //  Each block of color is 45 px in size.
        //  The first one starts at 30, 30
        public static Bitmap CreateTestImage()
        {
            var cellInchSize = .175;
            var border = .025;
            var dpi = 300;
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
            //columns -= 5; // one blank at the beginning, one blank at the end.
            Bitmap bmp = new Bitmap(width, height);
            bmp.SetResolution(dpi, dpi);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            nint ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            var t = bmp.PixelFormat;

            int startY = 30;
            int startX = 30;
            int cellSize = (int)rowHeight;
            int red = 0;
            int blue = 0;
            int green = 0;

            var centerRow = 23; // 0 index, actual row 19
            var babyStep = 1;

            var redColumn = 0;
            var greenColumn = 21;
            var blueColumn = 42;
            var columnOffset = 11;
            int c = 0;

            int cmult = 11;

            unsafe
            {
                byte* pixel;
                int currentColumn;

                for (int c1 = 0; c1 < bmp.Width; c1++)
                {
                    for (int r1 = 0; r1 < bmp.Height; r1++)
                    {
                        pixel = (byte*)ptr + r1 * stride + c1 * bytesPerPixel;
                        pixel[GREEN] = 0;
                        pixel[BLUE] = 0;
                        pixel[RED] = 0;
                        pixel[ALPHA] = 255;
                    }
                }

                //  First row, 0 for everything.
                for (int columnCount = 0; columnCount < columns; columnCount++)
                {
                    currentColumn = startX + columnCount * cellSize;
                    var iy = startY; // 1 == rowcount
                    for (int y2 = 0; y2 < blockSize; y2++)
                    {
                        for (int x2 = 0; x2 < blockSize; x2++)
                        {
                            pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                            pixel[GREEN] = 0;
                            pixel[BLUE] = 0;
                            pixel[RED] = 0;
                        }
                    }
                }

                //  first set of columns, increments of red to center row, then max red.
                red = 0;
                currentColumn = startX;
                for (int columnCount = 0; columnCount < columnOffset; columnCount++)
                {
                    red = 0;
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = 0; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[RED] = (byte)red;
                            }
                        }
                        red += cmult;
                        if (red > 255) red = 255;
                    }
                }

                for (int columnCount = columns - columnOffset + 1; columnCount < columns; columnCount++)
                {
                    red = 0;
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = 0; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[RED] = (byte)red;
                            }
                        }
                        red += cmult;
                        if (red > 255) red = 255;
                    }
                }

                //  Green columns
                for (int columnCount = greenColumn - columnOffset + 1; columnCount < greenColumn + columnOffset; columnCount++)
                {
                    green = 0;
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = 0; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[GREEN] = (byte)green;
                            }
                        }
                        green += cmult;
                        if (green > 255) green = 255;
                    }
                }

                //  Blue columns
                for (int columnCount = blueColumn - columnOffset + 1; columnCount < blueColumn + columnOffset; columnCount++)
                {
                    blue = 0;
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = 0; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[BLUE] = (byte)blue;
                            }
                        }
                        blue += cmult;
                        if (blue > 255) blue = 255;
                    }
                }

                //  Green from column red add baby step for each row.
                green = babyStep;
                for (int columnCount = redColumn; columnCount < redColumn + columnOffset; columnCount++)
                {
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        if (rowCount <= centerRow)
                        {
                            if (currentColumn == redColumn)
                            {
                                green = 0;
                            }
                            else if (columnCount == redColumn + 1)
                            {
                                green = rowCount * babyStep + (columnCount - 1) * babyStep;
                            }
                            else
                            {
                                pixel = (byte*)ptr + iy * stride + (startX + (redColumn + 1) * cellSize) * bytesPerPixel;
                                var tGreen = pixel[GREEN];
                                green = tGreen * columnCount;

                            }
                            if (green > 255) green = 255;
                            if (green < 0) green = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + (startY + centerRow * cellSize) * stride + (startX + columnCount * cellSize) * bytesPerPixel;
                            var tempGreen = pixel[GREEN];
                            var mult = (255 - tempGreen) / (rows - centerRow - 2);
                            green = mult * (rowCount - centerRow) + tempGreen;
                            if (green > 255) green = 255;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[GREEN] = (byte)green;
                            }
                        }
                    }
                }

                //  Green from blue column back to blue column - offset.
                c = 0;
                for (int columnCount = blueColumn; columnCount > blueColumn - columnOffset; columnCount--)
                {
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        if (rowCount <= centerRow)
                        {
                            if (currentColumn == blueColumn)
                            {
                                green = 0;
                            }
                            else if (columnCount == blueColumn - 1)
                            {
                                green = rowCount * babyStep + (c - 1) * babyStep;
                            }
                            else
                            {
                                pixel = (byte*)ptr + iy * stride + (startX + (blueColumn - 1) * cellSize) * bytesPerPixel;
                                var tGreen = pixel[GREEN];
                                green = tGreen * c;

                            }
                            if (green > 255) green = 255;
                            if (green < 0) green = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + (startY + centerRow * cellSize) * stride + (startX + columnCount * cellSize) * bytesPerPixel;
                            var tempGreen = pixel[GREEN];
                            var mult = (255 - tempGreen) / (rows - centerRow - 2);
                            green = mult * (rowCount - centerRow) + tempGreen;
                            if (green > 255) green = 255;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
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
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        if (rowCount <= centerRow)
                        {
                            if (columnCount == columns - 1)
                            {
                                blue = rowCount * babyStep + c * babyStep;
                            }
                            else
                            {
                                pixel = (byte*)ptr + iy * stride + (startX + (columns - 1) * cellSize) * bytesPerPixel;
                                var tBlue = pixel[BLUE];
                                blue = tBlue * (c + 1);

                            }
                            if (blue > 255) blue = 255;
                            if (blue < 0) blue = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + (startY + centerRow * cellSize) * stride + (startX + columnCount * cellSize) * bytesPerPixel;
                            var tempBlue = pixel[BLUE];
                            var mult = (255 - tempBlue) / (rows - centerRow - 2);
                            blue = mult * (rowCount - centerRow) + tempBlue;
                            if (blue > 255) blue = 255;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[BLUE] = (byte)blue;
                            }
                        }
                    }
                    c++;
                }

                //  blue for first column to < greenColumn.
                for (int columnCount = 0; columnCount < greenColumn; columnCount++)
                {
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = centerRow; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        pixel = (byte*)ptr + (startY + centerRow * cellSize) * stride + startX * bytesPerPixel;
                        var tempBlue = pixel[BLUE];
                        var mult = (255 - tempBlue) / (rows - centerRow - 2);
                        blue = mult * (rowCount - centerRow) + tempBlue;
                        if (blue > 255) blue = 255;
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[BLUE] = (byte)blue;
                            }
                        }
                    }
                }

                // blue from green over to green + offset
                for (int columnCount = greenColumn; columnCount < greenColumn + columnOffset; columnCount++)
                {
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        if (rowCount <= centerRow)
                        {
                            if (columnCount == greenColumn)
                            {
                                blue = 0;
                            }
                            else if (columnCount == greenColumn + 1)
                            {
                                blue = rowCount * babyStep + (columnCount - greenColumn - 1) * babyStep;
                            }
                            else
                            {
                                pixel = (byte*)ptr + iy * stride + (startX + (greenColumn + 1) * cellSize) * bytesPerPixel;
                                var tBlue = pixel[BLUE];
                                blue = tBlue * (columnCount - greenColumn + 1);

                            }
                            if (blue > 255) blue = 255;
                            if (blue < 0) blue = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + (startY + centerRow * cellSize) * stride + (startX + columnCount * cellSize) * bytesPerPixel;
                            var tempBlue = pixel[BLUE];
                            var mult = (255 - tempBlue) / (rows - centerRow - 2);
                            blue = mult * (rowCount - centerRow) + tempBlue;
                            if (blue > 255) blue = 255;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[BLUE] = (byte)blue;
                            }
                        }
                    }
                }

                // red from blue column to blue column + offset
                red = babyStep;
                c = 0;
                for (int columnCount = blueColumn; columnCount < blueColumn + columnOffset; columnCount++)
                {
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        if (rowCount <= centerRow)
                        {
                            if (columnCount == blueColumn)
                            {
                                red = 0;
                            }
                            else if (columnCount == blueColumn + 1)
                            {
                                red = rowCount * babyStep + (c - 1) * babyStep;
                            }
                            else
                            {
                                pixel = (byte*)ptr + iy * stride + (startX + (blueColumn + 1) * cellSize) * bytesPerPixel;
                                var tRed = pixel[RED];
                                red = tRed * (c - 1);

                            }
                            if (red > 255) red = 255;
                            if (red < 0) red = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + (startY + centerRow * cellSize) * stride + (startX + columnCount * cellSize) * bytesPerPixel;
                            var tempRed = pixel[RED];
                            var mult = (255 - tempRed) / (rows - centerRow - 2);
                            red = mult * (rowCount - centerRow) + tempRed;
                            if (red > 255) red = 255;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
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
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = 1; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        if (rowCount <= centerRow)
                        {
                            if (currentColumn == greenColumn)
                            {
                                red = 0;
                            }
                            else if (columnCount == greenColumn - 1)
                            {
                                red = rowCount * babyStep + (c - 1) * babyStep;
                            }
                            else
                            {
                                pixel = (byte*)ptr + iy * stride + (startX + (greenColumn - 1) * cellSize) * bytesPerPixel;
                                var tRed = pixel[RED];
                                red = tRed * c;

                            }
                            if (red > 255) red = 255;
                            if (red < 0) red = 0;
                        }
                        else
                        {
                            pixel = (byte*)ptr + (startY + centerRow * cellSize) * stride + (startX + columnCount * cellSize) * bytesPerPixel;
                            var tRed = pixel[RED];
                            var mult = (255 - tRed) / (rows - centerRow - 2);
                            red = mult * (rowCount - centerRow) + tRed;
                            if (red > 255) red = 255;
                        }

                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[RED] = (byte)red;
                                pixel[ALPHA] = 255;
                            }
                        }
                    }
                    c++;
                }

                //  red for first green column + 1 to < blueColumn.
                for (int columnCount = greenColumn + 1; columnCount < blueColumn; columnCount++)
                {
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = centerRow; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        pixel = (byte*)ptr + (startY + centerRow * cellSize) * stride + (startX + greenColumn * cellSize) * bytesPerPixel;
                        var tempRed = pixel[RED];
                        var mult = (255 - tempRed) / (rows - centerRow - 2);
                        red = mult * (rowCount - centerRow) + tempRed;
                        if (red > 255) red = 255;
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[RED] = (byte)red;
                            }
                        }
                    }
                }

                //  green for first blue column + 1 to < columns - 1.
                for (int columnCount = blueColumn + 1; columnCount < columns; columnCount++)
                {
                    currentColumn = startX + columnCount * cellSize;
                    for (int rowCount = centerRow; rowCount < rows; rowCount++)
                    {
                        var iy = startY + rowCount * cellSize;
                        pixel = (byte*)ptr + (startY + centerRow * cellSize) * stride + (startX + blueColumn * cellSize) * bytesPerPixel;
                        var tGreen = pixel[GREEN];
                        var mult = (255 - tGreen) / (rows - centerRow - 2);
                        green = mult * (rowCount - centerRow) + tGreen;
                        if (green > 255) green = 255;
                        for (int y2 = 0; y2 < blockSize; y2++)
                        {
                            for (int x2 = 0; x2 < blockSize; x2++)
                            {
                                pixel = (byte*)ptr + (y2 + iy) * stride + (currentColumn + x2) * bytesPerPixel;
                                pixel[GREEN] = (byte)green;
                            }
                        }
                    }
                }

            }

            bmp.UnlockBits(bmpData);
            var text = $"Right Margin.  {rows} Rows, {columns} columns.";
            Font font = new Font("Arial", 6, FontStyle.Regular);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Brush brush = new SolidBrush(Color.White))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                // Measure the text (before rotation)
                SizeF textSize = g.MeasureString(text, font);
                float yOffset = (bmp.Height - textSize.Width) / 2f + textSize.Width;
                // Set rotation and position
                g.TranslateTransform(bmp.Width - 40, yOffset);
                g.RotateTransform(-90); // rotate counter-clockwise 90 degrees

                // Draw the text
                g.DrawString(text, font, brush, 0, 0);

                // Reset transform
                g.ResetTransform();

            }
            return bmp;
        }

        public static void CreateTestShapeImages()
        {
            var strings = new List<KeyValuePair<string, int>>();
            strings.Add(new KeyValuePair<string, int>("OnePlus", 1));
            strings.Add(new KeyValuePair<string, int>("TwoPlus", 2));
            strings.Add(new KeyValuePair<string, int>("ThreePlus", 3));
            strings.Add(new KeyValuePair<string, int>("FourPlus", 4));
            foreach (var s in strings)
            {
                var bmp = new Bitmap(100, 100, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Black);
                }
                switch (s.Value)
                {
                    case 1:
                        DrawPlus(bmp, new Point(50, 40), 20, 2, Color.White);
                        break;
                    case 2:
                        DrawPlus(bmp, new Point(50, 40), 20, 2, Color.White);
                        DrawPlus(bmp, new Point(50, 50), 20, 2, Color.White);
                        break;
                    case 3:
                        DrawPlus(bmp, new Point(50, 40), 20, 2, Color.White);
                        DrawPlus(bmp, new Point(50, 50), 20, 2, Color.White);
                        DrawPlus(bmp, new Point(50, 60), 20, 2, Color.White);
                        break;
                    case 4:
                        DrawPlus(bmp, new Point(50, 40), 20, 2, Color.White);
                        DrawPlus(bmp, new Point(50, 50), 20, 2, Color.White);
                        DrawPlus(bmp, new Point(50, 60), 20, 2, Color.White);
                        DrawPlus(bmp, new Point(50, 70), 20, 2, Color.White);
                        break;
                }

                bmp.Save($"{s.Key}.png", ImageFormat.Png);
                bmp.Dispose();
            }
        }

        public static Bitmap ConvertDesaturatedToGrayscale(Bitmap input)
        {
            if (input.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new ArgumentException("Bitmap must be 32bpp ARGB.");
            }

            Bitmap grayBmp = new Bitmap(input.Width, input.Height, PixelFormat.Format8bppIndexed);

            // Create grayscale palette
            ColorPalette palette = grayBmp.Palette;
            for (int i = 0; i < 256; i++)
                palette.Entries[i] = Color.FromArgb(i, i, i);
            grayBmp.Palette = palette;

            BitmapData srcData = input.LockBits(
            new Rectangle(0, 0, input.Width, input.Height),
            ImageLockMode.ReadOnly,
            PixelFormat.Format32bppArgb);

            BitmapData dstData = grayBmp.LockBits(
            new Rectangle(0, 0, grayBmp.Width, grayBmp.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format8bppIndexed);

            unsafe
            {
                for (int y = 0; y < input.Height; y++)
                {
                    byte* srcRow = (byte*)srcData.Scan0 + y * srcData.Stride;
                    byte* dstRow = (byte*)dstData.Scan0 + y * dstData.Stride;

                    for (int x = 0; x < input.Width; x++)
                    {
                        byte gray = srcRow[x * 4]; // Could be R, G, or B – they’re all the same
                        dstRow[x] = gray;
                    }
                }
            }

            input.UnlockBits(srcData);
            grayBmp.UnlockBits(dstData);

            return grayBmp;
        }

        public static Bitmap InvertGrayscale(Bitmap input)
        {
            if (input.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new ArgumentException("Bitmap must be 8bpp grayscale.");

            Bitmap inverted = new Bitmap(input.Width, input.Height, PixelFormat.Format8bppIndexed);

            // Copy grayscale palette
            ColorPalette palette = inverted.Palette;
            for (int i = 0; i < 256; i++)
                palette.Entries[i] = Color.FromArgb(i, i, i);
            inverted.Palette = palette;

            BitmapData srcData = input.LockBits(
            new Rectangle(0, 0, input.Width, input.Height),
            ImageLockMode.ReadOnly,
            PixelFormat.Format8bppIndexed);

            BitmapData dstData = inverted.LockBits(
            new Rectangle(0, 0, inverted.Width, inverted.Height),
            ImageLockMode.WriteOnly,
            PixelFormat.Format8bppIndexed);

            unsafe
            {
                for (int y = 0; y < input.Height; y++)
                {
                    byte* srcRow = (byte*)srcData.Scan0 + y * srcData.Stride;
                    byte* dstRow = (byte*)dstData.Scan0 + y * dstData.Stride;

                    for (int x = 0; x < input.Width; x++)
                    {
                        dstRow[x] = (byte)(255 - srcRow[x]);
                    }
                }
            }

            input.UnlockBits(srcData);
            inverted.UnlockBits(dstData);

            return inverted;
        }

        public static Dictionary<Point, Color> CreateAveragedColorMapForFormat24bppRgb(Bitmap bmp, int startX, int startY, int cellSize)
        {
            /*
            squares start at 30, 30
            Each square is 45 x 45
            at 300 px per inch


            48 rows
            62 columns
            */
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            nint ptr = bmpData.Scan0;
            int stride = bmpData.Stride;
            int bytesPerPixel = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;
            Dictionary<Point, Color> mappedColors = new Dictionary<Point, Color>();
            int startPoint = startX + HALFCELLSIZE;
            int offset = cellSize;
            unsafe
            {
                for (int columnCount = 0; columnCount < COLUMNS; columnCount++)
                {
                    var iy = startPoint + columnCount * offset;
                    for (int rowCount = 0; rowCount < ROWS; rowCount++)
                    {
                        var ix = startPoint + rowCount * offset;
                        var color = GetPixelNeighborsAverage(ix, iy, ptr, stride, bytesPerPixel);
                        int gray = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                        var grayColor = Color.FromArgb(255, gray, gray, gray);
                        mappedColors.Add(new Point(ix, iy), grayColor);
                    }
                }
            }
            return mappedColors;
        }

        unsafe private static Color GetPixelNeighborsAverage(int x, int y, nint ptr, int stride, int bytesPerPixel)
        {
            //  image format should be 32bppArgb
            int sumR = 0, sumG = 0, sumB = 0, count = 0;
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int nx = x + dx;
                    int ny = y + dy;
                    byte* pixel = (byte*)ptr + ny * stride + nx * bytesPerPixel;
                    byte blue = pixel[BLUE];
                    byte green = pixel[GREEN];
                    byte red = pixel[RED];

                    sumR += red;
                    sumG += green;
                    sumB += blue;
                    count++;
                }
            }
            return Color.FromArgb(sumR / count, sumG / count, sumB / count);
        }

        private static byte GammaCorrect(ushort value)
        {
            double normalized = value / 65535.0; // Scale to [0,1]
            double corrected = Math.Pow(normalized, 1.0 / 2.2); // Gamma Correction
            return (byte)(corrected * 255); // Scale to [0,255]
        }

        private static VectorOfPoint Center(VectorOfPoint contour)
        {
            var moments = CvInvoke.Moments(contour);
            double cx = moments.M10 / moments.M00;
            double cy = moments.M01 / moments.M00;

            VectorOfPoint centeredContour = new VectorOfPoint();

            for (int i = 0; i < contour.Size; i++)
            {
                Point p = contour[i];
                Point centeredPoint = new Point((int)(p.X - cx), (int)(p.Y - cy));
                centeredContour.Push(new[] { centeredPoint });
            }
            return centeredContour;
        }

        private static (VectorOfPoint, VectorOfVectorOfPoint) GetContour(string templatePath, ChainApproxMethod method)
        {
            Mat matImage = CvInvoke.Imread(templatePath, ImreadModes.Grayscale);
            Mat bin = new Mat();
            CvInvoke.Threshold(matImage, bin, 0, 255, ThresholdType.Otsu);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(bin, contours, null, RetrType.External, method);

            // Assume largest contour is the given image
            double maxArea = 0;
            int maxIndex = 0;
            for (int i = 0; i < contours.Size; i++)
            {
                double area = CvInvoke.ContourArea(contours[i]);
                if (area > maxArea)
                {
                    maxArea = area;
                    maxIndex = i;
                }
            }

            var contour = contours[maxIndex];
            Rectangle boundingBox = CvInvoke.BoundingRectangle(contour);
            double scale = 100.0 / Math.Max(boundingBox.Width, boundingBox.Height);
            Matrix<double> scaleMat = new Matrix<double>(2, 3);
            scaleMat.SetIdentity();
            scaleMat[0, 0] = scale;
            scaleMat[1, 1] = scale;

            VectorOfPoint scaledContour = new VectorOfPoint();
            CvInvoke.Transform(contour, scaledContour, scaleMat);
            return (scaledContour, contours);
        }

        public static Bitmap DrawPlus(Bitmap bmp, Point center, int size, int thickness, Color color)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen pen = new Pen(color, thickness))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Calculate endpoints for vertical line
                Point v1 = new Point(center.X, center.Y - size / 2);
                Point v2 = new Point(center.X, center.Y + size / 2);

                // Calculate endpoints for horizontal line
                Point h1 = new Point(center.X - size / 2, center.Y);
                Point h2 = new Point(center.X + size / 2, center.Y);

                // Draw lines
                g.DrawLine(pen, v1, v2); // vertical
                g.DrawLine(pen, h1, h2); // horizontal
            }

            return bmp;
        }
    }
}
