using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GIFConverter.GIFPropertiesNodes
{
    public class ImageNode
        : TreeNode
    {
        public Image Image { get; }
        public ImageNode(Image image, int frameNumber)
            : base(frameNumber.ToString())
        {
            Image = image;

            FillImageNodes();
        }

        private void FillImageNodes()
        {
            Nodes.Add(new TreeNode("Width: " + Image.Width));
            Nodes.Add(new TreeNode("Height: " + Image.Height));
        }
    }
}
