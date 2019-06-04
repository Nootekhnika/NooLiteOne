using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft.Terminal
{
    public class ValidationTerminalInput
    {
        public void ValidatiionKeyPressNum(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }            
        }

        public void ValidateNumericDown( NumericUpDown numericUpDown)
        {
            if (numericUpDown.Value > 255) numericUpDown.Value = 255;
        }

        public void ValidationKeyPressNumId(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || e.KeyChar == 8) return;
            e.Handled = true;
        }
    }
}
