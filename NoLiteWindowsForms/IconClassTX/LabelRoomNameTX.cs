using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClassTX
{
    public class LabelRoomNameTX
    {
        public void CreateLabelRoomNameTX(int i, PictureBox pct, string[] roomName)
        {
            Label labelRoomName = new Label
            {
                Height = 18,
                Width = 96,
                Name = "roomName" + i.ToString(),
                Top = 58,
                Left =2,
                BackColor = Color.White,
                Text = roomName[i],
                TextAlign = ContentAlignment.MiddleCenter

            };

            if (labelRoomName.Text.Length >= 14)
            {
                labelRoomName.Width = 96;
                labelRoomName.Left = 2;
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
