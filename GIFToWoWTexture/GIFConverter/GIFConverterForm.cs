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

namespace GIFConverter
{
    public partial class GIFConverterForm : Form
    {
        private List<GIFEdit> GIFEdits;
        private GIFEdit CurrentEdit { get; set; }

        private int CurrentFramePosition => GIFPositionScrollBar.Value;
        private Image CurrentFrame => CurrentEdit?.GIFFrames[CurrentFramePosition];

        public GIFConverterForm()
        {
            InitializeComponent();
            GIFEdits = new List<GIFEdit>();

            GIFPositionScrollBar = new HScrollBar();
            GIFPositionScrollBar.Location = new Point(PicturePreviewsSplitContainer.Location.X, PicturePreviewsSplitContainer.Location.Y - 20);
            GIFPositionScrollBar.Size = new Size(PicturePreviewsSplitContainer.Panel1.Width, 20);
            GIFPositionScrollBar.ValueChanged += GIFPositionScrollBar_ValueChanged;
            this.Controls.Add(GIFPositionScrollBar);
        }

        private void GIFPositionScrollBar_ValueChanged(object sender, EventArgs e)
        {
            GIFPictureBox.Image = CurrentFrame;
        }

        private void LoadGIFButton_Click(object sender, EventArgs e)
        {
            ClearEdits();

            var file = new OpenFileDialog();
            file.Filter = "GIF Files (*.gif)|*.gif";

            if(file.ShowDialog() == DialogResult.OK)
            {
                AddGIFEdit(new GIFEdit(file.FileName));
            }
        }

        private void ClearEdits()
        {
            UpdateCurrentEditViews(null);
            GIFEdits.ForEach(o => o.Dispose());
            GIFEdits.Clear();
        }

        private void UpdateCurrentEditViews(GIFEdit gifEdit)
        {
            CurrentEdit = gifEdit;
            GIFPropertyTreeView.Nodes.Clear();
            GIFPositionScrollBar.Enabled = false;
            GIFPositionScrollBar.Value = 0;
            if (gifEdit != null)
            {
                GIFPositionScrollBar.Maximum = CurrentEdit.GIFFrames.Count;
                GIFPropertyTreeView.Nodes.Add(new GIFEditNode(gifEdit, GIFEdits.Count));
                GIFPictureBox.Image = CurrentFrame;
                GIFPositionScrollBar.Enabled = true;
            }
        }

        private void AddGIFEdit(GIFEdit gifEdit)
        {
            GIFEdits.Add(gifEdit);
            UpdateCurrentEditViews(gifEdit);
        }

        private void ToWoWTextureButton_Click(object sender, EventArgs e)
        {
            WoWTexturePictureBox.Image = ImageTransforms.ArrayImages(CurrentEdit.GIFFrames);
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

                GIFEdit edit = new GIFEdit(ImageTransforms.ImagesToGIF(images), CurrentEdit.Name);
                GIFEdits.Add(edit);
                UpdateCurrentEditViews(edit);
            }
                
        }
    }
}
