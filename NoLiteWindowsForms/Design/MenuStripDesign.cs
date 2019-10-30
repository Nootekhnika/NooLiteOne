using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft.Design
{
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderMenuItemBackground(e);
                e.Item.BackColor = Color.White;
            }
            else
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                e.Graphics.FillRectangle(Brushes.Gray, rc);
                e.Item.BackColor = Color.FromArgb(117, 117, 117);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            if (!e.Item.Selected)
            {
                e.Item.ForeColor = Color.Black;
            }
            else
            {
                e.Item.ForeColor = Color.White;
            }
        }
    }
}

