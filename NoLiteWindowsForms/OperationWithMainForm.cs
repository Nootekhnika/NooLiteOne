using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    class OperationWithMainForm
    {
        public int ScrollOn(TabPage tabPage)
        {
            List<PictureBox> pictureCount = new List<PictureBox>();
            foreach (PictureBox p in tabPage.Controls)
            {
                pictureCount.Add(p);
            };
            return pictureCount.Count();
        }

        public void CheckScroll(TabControl tabControl, TabPage tabPage)
        {
            if (ScrollOn(tabPage) > 21)
            {
                tabControl.Width = 855;
            }
            else
            {
                tabControl.Width = 845;
            }
        }
    }
}
