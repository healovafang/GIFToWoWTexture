using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace GIFConverter
{
    public static class ImageTransforms
    {
        public static Image ImagesToGIF(IEnumerable<Image> images)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (GifWriter gifWriter = new GifWriter(memoryStream))
            {
                foreach (Image image in images)
                {
                    gifWriter.WriteFrame(image);
                }
                return Image.FromStream(memoryStream);
            }
        }

        public static Image Crop(Image image, Rectangle cropArea)
        {
            var currentTile = new Bitmap(cropArea.Width, cropArea.Height);

            currentTile.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var currentTileGraphics = Graphics.FromImage(currentTile))
            {
                currentTileGraphics.Clear(Color.Black);
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
            Bitmap bm = new Bitmap(wid, hgt);

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
    }
}
