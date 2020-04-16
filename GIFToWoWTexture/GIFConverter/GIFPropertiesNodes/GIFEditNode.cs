using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIFConverter.GIFPropertiesNodes
{
    public class GIFEditNode
        : TreeNode
    {
        public GIFEdit GIFEdit { get; }
        public GIFEditNode(GIFEdit gifEdit, int editCount)
            : base(gifEdit.Name + " Edit " + editCount.ToString())
        {
            GIFEdit = gifEdit;
            FillPropertyNodes();
        }

        private void FillPropertyNodes()
        {
            Nodes.Add(new TreeNode("Frame Count: " + GIFEdit.FrameCount.ToString()));
            Nodes.Add(new TreeNode("Height: " + GIFEdit.Height.ToString()));
            Nodes.Add(new TreeNode("Width: " + GIFEdit.Width.ToString()));
        }
    }
}
