using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIFConverter
{
    
    public partial class CropForm : Form
    {
        bool isMouseDown = false;
        Rectangle cropArea = new Rectangle(0, 0, 200, 200);
        Point LastMousePosition;
        public CropForm(Image image)
        {
            InitializeComponent();
            CropPictureBox.Image = image;
            this.DoubleBuffered = true;

            CropPictureBox.Paint += CropPictureBox_Paint;
            CropPictureBox.MouseDown += CropPictureBox_MouseDown;
            CropPictureBox.MouseMove += CropPictureBox_MouseMove;
            CropPictureBox.MouseUp += CropPictureBox_MouseUp;

            Refresh();
        }
        private void CropPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(120,220,220,220)), cropArea);
        }

        private void CropPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(MouseIsOver(CropPictureBox, e.Location))
            {
                isMouseDown = true;
                LastMousePosition = e.Location;
            }
        }

        private void CropPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                cropArea.Location = GetDelta(LastMousePosition, e.Location);

                if (cropArea.Right > CropPictureBox.Width)
                {
                    cropArea.X = CropPictureBox.Width - cropArea.Width;
                }
                if (cropArea.Top < 0)
                {
                    cropArea.Y = 0;
                }
                if (cropArea.Left < 0)
                {
                    cropArea.X = 0;
                }
                if (cropArea.Bottom > CropPictureBox.Height)
                {
                    cropArea.Y = CropPictureBox.Height - cropArea.Height;
                }
                Refresh();
            }
        }

        private void CropPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void cropButton_Click(object sender, EventArgs e)
        {

        }
    }
}
