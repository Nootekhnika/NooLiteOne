using System.Drawing;
using System.Windows.Forms;

namespace NooLiteServiceSoft.IconClass
{
    public class LabelRoomName
    {
        public void CreateLabelRoomName(int i, PictureBox pct, string[] roomName, string typeDevice)
        {
            Label labelRoomName;
            if (typeDevice.Equals("6"))
            {
                labelRoomName = new Label
                {
                    Height = 20,
                    Width = 96,
                    Name = "roomName" + i.ToString(),
                    Top = 63,
                    Left = 2,
                    BackColor = Color.White,
                    Text = roomName[i],
                    TextAlign = ContentAlignment.MiddleCenter

                };
            }
            else
            {
                labelRoomName = new Label
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
            }
            if (labelRoomName.Text.Length >= 13)
            {
                labelRoomName.Width = 94;
                labelRoomName.Left = 3;
            }

            ToolTip yourToolTip = new ToolTip
            {
                ToolTipIcon = ToolTipIcon.None,
                IsBalloon = false,
                ShowAlways = true,
                BackColor = Color.White
            };
            if (labelRoomName.Text.Length > 12)
            {
                yourToolTip.SetToolTip(labelRoomName, labelRoomName.Text);
            }

            pct.Controls.Add(labelRoomName);
        }
    }
}
