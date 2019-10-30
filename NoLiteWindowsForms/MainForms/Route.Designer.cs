namespace NooLiteServiceSoft
{
    partial class Route
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Route));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_ID3 = new System.Windows.Forms.Label();
            this.textBox_AddressSpace = new System.Windows.Forms.TextBox();
            this.textBox_Route = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.operationModecomboBox = new System.Windows.Forms.ComboBox();
            this.button_closeTerminal = new System.Windows.Forms.Button();
            this.button_SendArr = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 450);
            this.panel3.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(598, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 450);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 347);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 3);
            this.panel2.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(603, 2);
            this.panel4.TabIndex = 8;
            // 
            // label_ID3
            // 
            this.label_ID3.AutoSize = true;
            this.label_ID3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_ID3.Location = new System.Drawing.Point(68, 90);
            this.label_ID3.Name = "label_ID3";
            this.label_ID3.Size = new System.Drawing.Size(92, 20);
            this.label_ID3.TabIndex = 32;
            this.label_ID3.Text = "Адресное";
            // 
            // textBox_AddressSpace
            // 
            this.textBox_AddressSpace.Location = new System.Drawing.Point(74, 141);
            this.textBox_AddressSpace.Name = "textBox_AddressSpace";
            this.textBox_AddressSpace.Size = new System.Drawing.Size(83, 22);
            this.textBox_AddressSpace.TabIndex = 31;
            this.textBox_AddressSpace.TextChanged += new System.EventHandler(this.TextBox_AddressSpace_TextChanged);
            this.textBox_AddressSpace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_AddressSpace_KeyPress);
            // 
            // textBox_Route
            // 
            this.textBox_Route.Location = new System.Drawing.Point(234, 141);
            this.textBox_Route.Name = "textBox_Route";
            this.textBox_Route.Size = new System.Drawing.Size(83, 22);
            this.textBox_Route.TabIndex = 33;
            this.textBox_Route.TextChanged += new System.EventHandler(this.TextBox_Route_TextChanged);
            this.textBox_Route.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Route_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(206, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Маршрутизатор";
            // 
            // operationModecomboBox
            // 
            this.operationModecomboBox.BackColor = System.Drawing.Color.White;
            this.operationModecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationModecomboBox.FormattingEnabled = true;
            this.operationModecomboBox.Location = new System.Drawing.Point(390, 141);
            this.operationModecomboBox.Name = "operationModecomboBox";
            this.operationModecomboBox.Size = new System.Drawing.Size(111, 24);
            this.operationModecomboBox.TabIndex = 35;
            // 
            // button_closeTerminal
            // 
            this.button_closeTerminal.BackColor = System.Drawing.Color.White;
            this.button_closeTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_closeTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_closeTerminal.Location = new System.Drawing.Point(456, 285);
            this.button_closeTerminal.Name = "button_closeTerminal";
            this.button_closeTerminal.Size = new System.Drawing.Size(115, 35);
            this.button_closeTerminal.TabIndex = 37;
            this.button_closeTerminal.Text = "Отмена";
            this.button_closeTerminal.UseVisualStyleBackColor = false;
            this.button_closeTerminal.Click += new System.EventHandler(this.Button_closeTerminal_Click);
            // 
            // button_SendArr
            // 
            this.button_SendArr.BackColor = System.Drawing.Color.White;
            this.button_SendArr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SendArr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_SendArr.Location = new System.Drawing.Point(328, 285);
            this.button_SendArr.Name = "button_SendArr";
            this.button_SendArr.Size = new System.Drawing.Size(115, 35);
            this.button_SendArr.TabIndex = 36;
            this.button_SendArr.Text = "Передать";
            this.button_SendArr.UseVisualStyleBackColor = false;
            this.button_SendArr.Click += new System.EventHandler(this.Button_SendArr_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.White;
            this.button_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_clear.Location = new System.Drawing.Point(45, 285);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(115, 35);
            this.button_clear.TabIndex = 38;
            this.button_clear.Text = "Очистить";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.Button_clear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(23, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 25);
            this.label2.TabIndex = 39;
            this.label2.Text = "Настройки Маршрутизации";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(53, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "пространство";
            // 
            // Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_closeTerminal);
            this.Controls.Add(this.button_SendArr);
            this.Controls.Add(this.operationModecomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Route);
            this.Controls.Add(this.label_ID3);
            this.Controls.Add(this.textBox_AddressSpace);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Route";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "nooLiteDesktopControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_ID3;
        private System.Windows.Forms.TextBox textBox_AddressSpace;
        private System.Windows.Forms.TextBox textBox_Route;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox operationModecomboBox;
        private System.Windows.Forms.Button button_closeTerminal;
        private System.Windows.Forms.Button button_SendArr;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}