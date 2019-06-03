using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooLiteServiceSoft
{
    public class ValidatorForm2
    {
        public void Form2Validation(TextBox textBox_name, ComboBox comboBoxCh, Button button, ComboBox comboBoxMode)
        {
            if (textBox_name.Text.Length > 0 && comboBoxCh.SelectedIndex > -1 && comboBoxMode.SelectedIndex > -1)
            {
                button.Visible = true;
            }
            else
            {
                button.Visible = false;
            }
        }

        public void Form2ValidationSecond(TextBox textBox_name, ComboBox comboBoxCh, Button button, ComboBox comboBoxMode, ComboBox comboBoxTypeBlock)
        {
            if (textBox_name.Text.Length > 0 && comboBoxCh.SelectedIndex > -1 && comboBoxMode.SelectedIndex > -1 && comboBoxTypeBlock.SelectedIndex > -1)
            {
                button.Visible = true;
            }
            else
            {
                button.Visible = false;
            }
        }

        public string ComboBoxValidation(string text)
        {
            if (text.Equals("Все устройства"))
            {
                string validatonText = "";
                return validatonText;
            }
            else
            {
                return text;
            }
        }
    }
}
