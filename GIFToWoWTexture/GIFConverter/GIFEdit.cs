using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace GIFConverter
{
    public class GIFEdit
        : IDisposable
    {
        public Image OriginalGIFImage { get; }
        public List<Image> GIFFrames { get; set; }
        public int FrameCount => GIFFrames.Count;
        public int Width => OriginalGIFImage.Width;
        public int Height => OriginalGIFImage.Height;
        public string Name { get; }
        public GIFEdit(string path)
        {
            OriginalGIFImage = Image.FromFile(path);
            GIFFrames = GetFramesFromAnimatedGIF(OriginalGIFImage);
            Name = Path.GetFileName(path);
        }

        public GIFEdit(Image image, string name)
        {
            OriginalGIFImage = image;
            GIFFrames = GetFramesFromAnimatedGIF(OriginalGIFImage);
            Name = name;
        }

        public GIFEdit ApplyToNewEditor()
        {
            return new GIFEdit(ImagesToGIF(GIFFrames), Name);
        }

        private static List<Image> GetFramesFromAnimatedGIF(Image IMG)
        {
            List<Image> IMGs = new List<Image>();
            int Length = IMG.GetFrameCount(FrameDimension.Time);

            for (int i = 0; i < Length; i++)
            {
                IMG.SelectActiveFrame(FrameDimension.Time, i);
                IMGs.Add(new Bitmap(IMG));
            }

            return IMGs;
        }

        private static Image ImagesToGIF(IEnumerable<Image> images)
        {
            MemoryStream memoryStream = new MemoryStream();
            GifWriter gifWriter = new GifWriter(memoryStream);
            foreach(Image image in images)
            {
                gifWriter.WriteFrame(image);
            }
            return Image.FromStream(memoryStream);
        }

        private void DisposeImages(IEnumerable<Image> images)
        {
            if (images.IsNullOrEmpty()) { return; }
            foreach(Image image in images)
            {
                image.Dispose();
            }
        }

        public void MakeTransparent(Color color1, Color color2)
        {
            List<Image> images = new List<Image>();

            foreach(Image image in GIFFrames)
            {
                images.Add(ImageTransforms.MakeCopyWithColorRangeTransparent(color1, color2, image));
            }

            GIFFrames.ForEach(o => o.Dispose());
            GIFFrames = images;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DisposeImages(GIFFrames);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GIF()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
