using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace GIFConverter
{
    public static class ImageTransforms
    {

        public static Image MakeCopyWithColorRangeTransparent(Color color1, Color color2, Image image)
        {
            Bitmap copy = new Bitmap(image);

            for (int x = 0; x < copy.Width; x++)
            {
                for (int y = 0; y < copy.Height; y++)
                {
                    Color clr = copy.GetPixel(x, y);
                    if(ColorIsWithinRange(clr, color1, color2))
                    {
                        copy.SetPixel(x, y, Color.Transparent);
                    }
                }
            }

            return copy;
        }

        private static bool ColorIsWithinRange(Color color, Color colorRange1, Color colorRange2)
        {
            if(color.A >= colorRange1.A && color.A <= colorRange2.A)
            {
                if(color.R >= colorRange1.R && color.R <= colorRange2.R)
                {
                    if(color.G >= colorRange1.G && color.G <= colorRange2.G)
                    {
                        if(color.B >= colorRange1.B && color.B <= colorRange2.B)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static Image ImagesToGIF(IEnumerable<Image> images)
        {
            MemoryStream memoryStream = new MemoryStream();
            GifWriter gifWriter = new GifWriter(memoryStream);
            foreach (Image image in images)
            {
                gifWriter.WriteFrame(image);
            }
            return Image.FromStream(memoryStream);
        }

        public static Image Crop(Image image, Rectangle cropArea)
        {
            var currentTile = new Bitmap(cropArea.Width, cropArea.Height, PixelFormat.Format32bppArgb);
            currentTile.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            

            using (var currentTileGraphics = Graphics.FromImage(currentTile))
            {
                currentTileGraphics.Clear(Color.Transparent);
                currentTileGraphics.DrawImage(image, 0, 0, cropArea, GraphicsUnit.Pixel);
            }

            return currentTile;
        }
        /// <summary>
        /// Tries to create a square of arrayed images
        /// </summary>
        public static Image ArrayImages(List<Image> images)
        {
            (int rows, int columns) RowsAndColumns = CalculateRowsAndColumns(images);

            int wid = RowsAndColumns.columns * images.First().Width;
            int hgt = RowsAndColumns.rows * images.First().Height;
            Bitmap bm = new Bitmap(wid, hgt, PixelFormat.Format32bppArgb);
            bm.MakeTransparent();
            // Place the images on it.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.Transparent);

                int x = 0;
                int y = 0;
                for (int i = 0; i < images.Count; i++)
                {
                    gr.DrawImage(images[i], x, y);

                    x += images.First().Width;
                    if (x >= wid)
                    {
                        y += images.First().Height;
                        x = 0;
                    }
                }
            }
            return bm;
        }

        private static (int Rows, int Columns) CalculateRowsAndColumns(List<Image> images)
        {
            int rows = 1;
            int columns = 1;
            int imageWidth = images.First().Width;
            int imageHeight = images.First().Height;

            while (images.Count > rows * columns) //while we need more cells
            {
                if (imageWidth * columns >= imageHeight * rows) //if width is greater than height
                {
                    rows++; //increase rows
                }
                else //if height is greater than width
                {
                    columns++; //increase columns
                }
            }

            return (rows, columns);
        }

        internal static Image Resize(Image image, Size size)
        {
            int width = size.Width;
            int height = size.Height;

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        internal static Color ModifyColor(Color color, int mod)
        {
            int alpha, red, blue, green;

            alpha = color.A + mod;
            red = color.R + mod;
            blue = color.B + mod;
            green = color.G + mod;

            alpha = ColorClamp(alpha);
            red = ColorClamp(red);
            blue = ColorClamp(blue);
            green = ColorClamp(green);

            return Color.FromArgb(alpha, red, green, blue);
        }

        private static int ColorClamp(int colorComponent)
        {
            if(colorComponent > 255)
            {
                return 255;
            }
            else if(colorComponent < 0)
            {
                return 0;
            }
            else
            {
                return colorComponent;
            }
        }
    }
}
