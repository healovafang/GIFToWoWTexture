using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GIFConverter.GIFPropertiesNodes;
using TGASharpLib;
using System.IO;

namespace GIFConverter
{
    public partial class GIFConverterForm : Form
    {
        private GIFEdit CurrentEdit { get; set; }

        private int CurrentFramePosition => GIFPositionScrollBar.Value;
        private Image CurrentFrame => CurrentEdit?.GIFFrames[CurrentFramePosition];

        public GIFConverterForm()
        {
            InitializeComponent();

            GIFPositionScrollBar = new HScrollBar();
            GIFPositionScrollBar.Location = new Point(PicturePreviewsSplitContainer.Location.X, PicturePreviewsSplitContainer.Location.Y - 20);
            GIFPositionScrollBar.Size = new Size(PicturePreviewsSplitContainer.Panel1.Width, 20);
            GIFPositionScrollBar.ValueChanged += GIFPositionScrollBar_ValueChanged;
            this.Controls.Add(GIFPositionScrollBar);
        }

        private void GIFPositionScrollBar_ValueChanged(object sender, EventArgs e)
        {
            GIFPictureBox.Image = CurrentFrame;
            currentFrameLabel.Text = "Current Frame: " + CurrentFramePosition.ToString();
        }

        private void LoadGIFButton_Click(object sender, EventArgs e)
        {
            ClearEdits();

            var file = new OpenFileDialog();
            file.Filter = "GIF Files (*.gif)|*.gif";

            if(file.ShowDialog() == DialogResult.OK)
            {
                CurrentEdit = new GIFEdit(file.FileName);
                UpdateCurrentEditViews(CurrentEdit);
            }
        }

        private void ClearEdits()
        {
            UpdateCurrentEditViews(null);
        }

        private void UpdateCurrentEditViews(GIFEdit gifEdit)
        {
            CurrentEdit = gifEdit;
            GIFPropertyTreeView.Nodes.Clear();
            GIFPositionScrollBar.Value = 0;
            if (gifEdit != null)
            {
                GIFPositionScrollBar.Maximum = CurrentEdit.GIFFrames.Count + 8;
                GIFPropertyTreeView.Nodes.Add(new GIFEditNode(gifEdit));
                GIFPictureBox.Image = CurrentFrame;
            }
        }

        private void ToWoWTextureButton_Click(object sender, EventArgs e)
        {
            Image wowtexture = ImageTransforms.ArrayImages(CurrentEdit.GIFFrames);
            wowtexture = ImageTransforms.Resize(wowtexture, GetBestImageSize(wowtexture.Width, wowtexture.Height));
            WoWTexturePictureBox.Image = wowtexture;
        }

        private Size GetBestImageSize(int width, int height)
        {
            double aspectRatio = ((double)width) / ((double)height);

            int ceilWidth = CeilPower2(width);
            int floorWidth = FloorPower2(width);

            int ceilHeight = CeilPower2(height);
            int floorHeight = FloorPower2(height);

            Size bestSize = new Size(ceilWidth, ceilHeight);
            bestSize = GetBestSize(aspectRatio, height, bestSize, ceilWidth, floorHeight);
            bestSize = GetBestSize(aspectRatio, height, bestSize, floorWidth, ceilHeight);
            bestSize = GetBestSize(aspectRatio, height, bestSize, floorWidth, floorHeight);

            while(bestSize.Height >= 16384 || bestSize.Width >= 16384)
            {
                bestSize = new Size(bestSize.Width / 2, bestSize.Height / 2);
            }
            return bestSize;
        }

        private Size GetBestSize(double idealAspectRatio, int idealHeight, Size previousSize, int width, int height)
        {
            if(GetDistance(idealAspectRatio, AspectRatio(previousSize)) > GetDistance(idealAspectRatio, (((double)width) / ((double)height))))
            {
                return new Size(width, height);
            }
            else if(GetDistance(idealAspectRatio, AspectRatio(previousSize)) == GetDistance(idealAspectRatio, (((double)width) / ((double)height))))
            {
                if(GetDistance(idealHeight, previousSize.Height) < GetDistance(idealHeight, height))
                {
                    return previousSize;
                }
                else
                {
                    return new Size(width, height);
                }
            }
            else
            {
                return previousSize;
            }
        }

        private double GetDistance(double ideal, double possible)
        {
            return Math.Abs(ideal - possible);
        }

        private static double AspectRatio(Size size)
        {
            return (((double)size.Width) / ((double)size.Height));
        }

        public static int CeilPower2(int x)
        {
            if (x < 2)
            {
                return 1;
            }
            return (int)Math.Pow(2, (int)Math.Log(x - 1, 2) + 1);
        }

        public static int FloorPower2(int x)
        {
            if (x < 1)
            {
                return 1;
            }
            return (int)Math.Pow(2, (int)Math.Log(x, 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CurrentEdit is null) { return; }
            using (CropForm newcrop = new CropForm(CurrentFrame))
            {
                newcrop.ShowDialog();

                var CropArea = newcrop.CropArea;
                List<Image> images = CurrentEdit.GIFFrames
                    .Select(o => ImageTransforms.Crop(o, CropArea)).ToList();

                CurrentEdit.GIFFrames = images;
                //GIFEdit edit = new GIFEdit(ImageTransforms.ImagesToGIF(images), CurrentEdit.Name);
                //GIFEdits.Add(CurrentEdit);
                UpdateCurrentEditViews(CurrentEdit);
            }
        }

        private void removeFramesFromStartButton_Click(object sender, EventArgs e)
        {
            CurrentEdit.GIFFrames.RemoveRange(0, CurrentFramePosition);
            UpdateCurrentEditViews(CurrentEdit);
        }

        private void trimEndButton_Click(object sender, EventArgs e)
        {
            CurrentEdit.GIFFrames.RemoveRange(CurrentFramePosition + 1, CurrentEdit.GIFFrames.Count - (CurrentFramePosition + 1));
            UpdateCurrentEditViews(CurrentEdit);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CurrentEdit.GIFFrames.RemoveAt(CurrentFramePosition);
        }

        private void saveTextureButton_Click(object sender, EventArgs e)
        {
            if(WoWTexturePictureBox.Image is null) { return; }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "png (*.png) | *.png";
            saveFileDialog.ShowDialog();

            using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create)) 
            {
                WoWTexturePictureBox.Image.Save(fileStream, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
