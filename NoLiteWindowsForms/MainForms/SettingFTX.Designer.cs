namespace NooLiteServiceSoft
{
    partial class SettingFTX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingFTX));
            this.labelDeviceSetting = new System.Windows.Forms.Label();
            this.stateMemorization = new System.Windows.Forms.GroupBox();
            this.off_State = new System.Windows.Forms.RadioButton();
            this.on_State = new System.Windows.Forms.RadioButton();
            this.stateAfterOn = new System.Windows.Forms.GroupBox();
            this.off_StateAfterOn = new System.Windows.Forms.RadioButton();
            this.on_StateAfterOn = new System.Windows.Forms.RadioButton();
            this.TakeNooLiteCommand = new System.Windows.Forms.GroupBox();
            this.banReceivingCommandFromNL = new System.Windows.Forms.RadioButton();
            this.allowReceivingCommandFromNL = new System.Windows.Forms.RadioButton();
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.stateMemorization.SuspendLayout();
            this.stateAfterOn.SuspendLayout();
            this.TakeNooLiteCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDeviceSetting
            // 
            this.labelDeviceSetting.AutoSize = true;
            this.labelDeviceSetting.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelDeviceSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDeviceSetting.Location = new System.Drawing.Point(25, 12);
            this.labelDeviceSetting.Name = "labelDeviceSetting";
            this.labelDeviceSetting.Size = new System.Drawing.Size(0, 25);
            this.labelDeviceSetting.TabIndex = 0;
            // 
            // stateMemorization
            // 
            this.stateMemorization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.stateMemorization.Controls.Add(this.off_State);
            this.stateMemorization.Controls.Add(this.on_State);
            this.stateMemorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stateMemorization.Location = new System.Drawing.Point(10, 49);
            this.stateMemorization.Name = "stateMemorization";
            this.stateMemorization.Size = new System.Drawing.Size(260, 118);
            this.stateMemorization.TabIndex = 1;
            this.stateMemorization.TabStop = false;
            this.stateMemorization.Text = "Запоминание состояния";
            // 
            // off_State
            // 
            this.off_State.AutoSize = true;
            this.off_State.Location = new System.Drawing.Point(6, 74);
            this.off_State.Name = "off_State";
            this.off_State.Size = new System.Drawing.Size(111, 22);
            this.off_State.TabIndex = 1;
            this.off_State.TabStop = true;
            this.off_State.Text = "Выключено";
            this.off_State.UseVisualStyleBackColor = true;
            // 
            // on_State
            // 
            this.on_State.AutoSize = true;
            this.on_State.Location = new System.Drawing.Point(6, 46);
            this.on_State.Name = "on_State";
            this.on_State.Size = new System.Drawing.Size(100, 22);
            this.on_State.TabIndex = 0;
            this.on_State.TabStop = true;
            this.on_State.Text = "Включено";
            this.on_State.UseVisualStyleBackColor = true;
            // 
            // stateAfterOn
            // 
            this.stateAfterOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.stateAfterOn.Controls.Add(this.off_StateAfterOn);
            this.stateAfterOn.Controls.Add(this.on_StateAfterOn);
            this.stateAfterOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stateAfterOn.Location = new System.Drawing.Point(276, 49);
            this.stateAfterOn.Name = "stateAfterOn";
            this.stateAfterOn.Size = new System.Drawing.Size(260, 118);
            this.stateAfterOn.TabIndex = 2;
            this.stateAfterOn.TabStop = false;
            this.stateAfterOn.Text = "Состояние после включения";
            // 
            // off_StateAfterOn
            // 
            this.off_StateAfterOn.AutoSize = true;
            this.off_StateAfterOn.ForeColor = System.Drawing.Color.Black;
            this.off_StateAfterOn.Location = new System.Drawing.Point(6, 74);
            this.off_StateAfterOn.Name = "off_StateAfterOn";
            this.off_StateAfterOn.Size = new System.Drawing.Size(102, 22);
            this.off_StateAfterOn.TabIndex = 1;
            this.off_StateAfterOn.TabStop = true;
            this.off_StateAfterOn.Text = "Выключен";
            this.off_StateAfterOn.UseVisualStyleBackColor = true;
            // 
            // on_StateAfterOn
            // 
            this.on_StateAfterOn.AutoSize = true;
            this.on_StateAfterOn.Location = new System.Drawing.Point(6, 46);
            this.on_StateAfterOn.Name = "on_StateAfterOn";
            this.on_StateAfterOn.Size = new System.Drawing.Size(91, 22);
            this.on_StateAfterOn.TabIndex = 0;
            this.on_StateAfterOn.TabStop = true;
            this.on_StateAfterOn.Text = "Включён";
            this.on_StateAfterOn.UseVisualStyleBackColor = true;
            // 
            // TakeNooLiteCommand
            // 
            this.TakeNooLiteCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.TakeNooLiteCommand.Controls.Add(this.banReceivingCommandFromNL);
            this.TakeNooLiteCommand.Controls.Add(this.allowReceivingCommandFromNL);
            this.TakeNooLiteCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TakeNooLiteCommand.Location = new System.Drawing.Point(542, 49);
            this.TakeNooLiteCommand.Name = "TakeNooLiteCommand";
            this.TakeNooLiteCommand.Size = new System.Drawing.Size(260, 118);
            this.TakeNooLiteCommand.TabIndex = 3;
            this.TakeNooLiteCommand.TabStop = false;
            this.TakeNooLiteCommand.Text = "Приём nooLite";
            // 
            // banReceivingCommandFromNL
            // 
            this.banReceivingCommandFromNL.AutoSize = true;
            this.banReceivingCommandFromNL.ForeColor = System.Drawing.Color.Black;
            this.banReceivingCommandFromNL.Location = new System.Drawing.Point(6, 74);
            this.banReceivingCommandFromNL.Name = "banReceivingCommandFromNL";
            this.banReceivingCommandFromNL.Size = new System.Drawing.Size(98, 22);
            this.banReceivingCommandFromNL.TabIndex = 1;
            this.banReceivingCommandFromNL.TabStop = true;
            this.banReceivingCommandFromNL.Text = "Запрещён";
            this.banReceivingCommandFromNL.UseVisualStyleBackColor = true;
            // 
            // allowReceivingCommandFromNL
            // 
            this.allowReceivingCommandFromNL.AutoSize = true;
            this.allowReceivingCommandFromNL.Location = new System.Drawing.Point(6, 46);
            this.allowReceivingCommandFromNL.Name = "allowReceivingCommandFromNL";
            this.allowReceivingCommandFromNL.Size = new System.Drawing.Size(98, 22);
            this.allowReceivingCommandFromNL.TabIndex = 0;
            this.allowReceivingCommandFromNL.TabStop = true;
            this.allowReceivingCommandFromNL.Text = "Разрешён";
            this.allowReceivingCommandFromNL.UseVisualStyleBackColor = true;
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.White;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_btn.Location = new System.Drawing.Point(276, 173);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(107, 39);
            this.save_btn.TabIndex = 34;
            this.save_btn.Text = "Сохранить";
            this.save_btn.UseVisualStyleBackColor = false;
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.White;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_btn.Location = new System.Drawing.Point(430, 175);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(106, 39);
            this.cancel_btn.TabIndex = 35;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.Remove_btn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, -12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 450);
            this.panel3.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(809, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 450);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 2);
            this.panel2.TabIndex = 38;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(-19, 224);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(850, 2);
            this.panel4.TabIndex = 39;
            // 
            // SettingFTX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 226);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.TakeNooLiteCommand);
            this.Controls.Add(this.stateAfterOn);
            this.Controls.Add(this.stateMemorization);
            this.Controls.Add(this.labelDeviceSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingFTX";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "nooLiteDesktopControl";
            this.stateMemorization.ResumeLayout(false);
            this.stateMemorization.PerformLayout();
            this.stateAfterOn.ResumeLayout(false);
            this.stateAfterOn.PerformLayout();
            this.TakeNooLiteCommand.ResumeLayout(false);
            this.TakeNooLiteCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDeviceSetting;
        private System.Windows.Forms.GroupBox stateMemorization;
        private System.Windows.Forms.RadioButton off_State;
        private System.Windows.Forms.RadioButton on_State;
        private System.Windows.Forms.GroupBox stateAfterOn;
        private System.Windows.Forms.RadioButton off_StateAfterOn;
        private System.Windows.Forms.RadioButton on_StateAfterOn;
        private System.Windows.Forms.GroupBox TakeNooLiteCommand;
        private System.Windows.Forms.RadioButton banReceivingCommandFromNL;
        private System.Windows.Forms.RadioButton allowReceivingCommandFromNL;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
    }
}