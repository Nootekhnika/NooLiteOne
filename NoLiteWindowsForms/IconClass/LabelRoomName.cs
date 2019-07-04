using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class LabelRoomName
    {
        public void CreateLabelRoomName(int i, PictureBox pct, string[] roomName)
        {
            Label labelRoomName = new Label
            {
                Height = 20,
                Width = 96,
                Name = "roomName" + i.ToString(),
                Top = 55,
                Left = 2,
                BackColor = Color.White,
                Text = roomName[i],
                TextAlign = ContentAlignment.MiddleCenter

            };
            if (labelRoomName.Text.Length >= 14)
            {
                labelRoomName.Width = 100;
                labelRoomName.Left = 0;
            }

            ToolTip yourToolTip = new ToolTip
            {
                ToolTipIcon = ToolTipIcon.None,
                IsBalloon = false,
                ShowAlways = true,
                BackColor = Color.White
            };
            if (labelRoomName.Text.Length > 13)
            {
                yourToolTip.SetToolTip(labelRoomName, labelRoomName.Text);
            }

            pct.Controls.Add(labelRoomName);
        }
    }
}
