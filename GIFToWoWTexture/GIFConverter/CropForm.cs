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
        public Rectangle CropArea = new Rectangle(0, 0, 200, 200);
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
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(120,220,220,220)), CropArea);
        }

        private void CropPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(MouseIsOver(CropArea, e.Location))
            {
                isMouseDown = true;
                LastMousePosition = e.Location;
            }
        }

        private bool MouseIsOver(Rectangle cropArea, Point mouseLocation)
        {
            return mouseLocation.X >= cropArea.Location.X &&
                    mouseLocation.X <= (cropArea.Location.X + cropArea.Size.Width) &&
                    mouseLocation.Y >= cropArea.Location.Y &&
                    mouseLocation.Y <= (cropArea.Location.Y + cropArea.Size.Height);
        }

        private void CropPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                CropArea.Location = AddDelta(GetVector(LastMousePosition, e.Location), CropArea.Location);
                LastMousePosition = e.Location;

                if (CropArea.Right > CropPictureBox.Image.Width)
                {
                    CropArea.X = CropPictureBox.Image.Width - CropArea.Width;
                }
                if (CropArea.Top < 0)
                {
                    CropArea.Y = 0;
                }
                if (CropArea.Left < 0)
                {
                    CropArea.X = 0;
                }
                if (CropArea.Bottom > CropPictureBox.Image.Height)
                {
                    CropArea.Y = CropPictureBox.Image.Height - CropArea.Height;
                }
                Refresh();
            }
        }

        private Point GetVector(Point lastMousePosition, Point currentMousePosition)
        {
            return new Point(currentMousePosition.X - lastMousePosition.X, currentMousePosition.Y - lastMousePosition.Y);
        }

        private Point AddDelta(Point vector, Point currentlocation)
        {
            return new Point(currentlocation.X + vector.X, currentlocation.Y + vector.Y);
        }

        private void CropPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void cropButton_Click(object sender, EventArgs e)
        {

        }

        private void maxSizeButton_Click(object sender, EventArgs e)
        {
            int smallestImageDimension = CropPictureBox.Image.Width > CropPictureBox.Image.Height ?
                                                    CropPictureBox.Image.Height : CropPictureBox.Image.Width;
            CropArea = new Rectangle(0, 0, smallestImageDimension, smallestImageDimension);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int smallestImageDimension = CropPictureBox.Image.Width > CropPictureBox.Image.Height ?
                                                    CropPictureBox.Image.Height : CropPictureBox.Image.Width;

            if(int.TryParse(textBox1.Text, out int inputValue))
            {
                if(inputValue > smallestImageDimension)
                {
                    textBox1.Text = smallestImageDimension.ToString();
                }
                else
                {
                    CropArea = new Rectangle(0, 0, inputValue, inputValue);
                }
                Refresh();
            }
        }
    }
}
