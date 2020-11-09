namespace AmongUsDiscordBot
{
    partial class ChangeKeybindForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeKeybindForm));
            this.PushToMute = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Keybind = new System.Windows.Forms.Label();
            this.background = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.ActionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PushToMute
            // 
            this.PushToMute.AutoSize = true;
            this.PushToMute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.PushToMute.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PushToMute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(218)))), ((int)(((byte)(217)))));
            this.PushToMute.Location = new System.Drawing.Point(12, 30);
            this.PushToMute.Name = "PushToMute";
            this.PushToMute.Size = new System.Drawing.Size(101, 17);
            this.PushToMute.TabIndex = 0;
            this.PushToMute.Text = "Push to Mute";
            this.PushToMute.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(243)))));
            this.textBox1.Location = new System.Drawing.Point(149, 30);
            this.textBox1.MaximumSize = new System.Drawing.Size(183, 25);
            this.textBox1.MinimumSize = new System.Drawing.Size(183, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(183, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TabStop = false;
            this.textBox1.WordWrap = false;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.GotFocus += new System.EventHandler(this.textBox1_GotFocus);
            this.textBox1.LostFocus += new System.EventHandler(this.textBox1_LostFocus);
            // 
            // Keybind
            // 
            this.Keybind.AutoSize = true;
            this.Keybind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.Keybind.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keybind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(146)))), ((int)(((byte)(151)))));
            this.Keybind.Location = new System.Drawing.Point(147, 13);
            this.Keybind.Name = "Keybind";
            this.Keybind.Size = new System.Drawing.Size(52, 12);
            this.Keybind.TabIndex = 2;
            this.Keybind.Text = "KEYBIND";
            this.Keybind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Keybind.Click += new System.EventHandler(this.Keybind_Click);
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.background.Location = new System.Drawing.Point(-5, -20);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(411, 89);
            this.background.TabIndex = 1;
            this.background.Click += new System.EventHandler(this.background_Click);
            // 
            // testButton
            // 
            this.testButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.testButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.testButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.testButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(218)))), ((int)(((byte)(217)))));
            this.testButton.Location = new System.Drawing.Point(340, 29);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(50, 23);
            this.testButton.TabIndex = 4;
            this.testButton.TabStop = false;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = false;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // ActionLabel
            // 
            this.ActionLabel.AutoSize = true;
            this.ActionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ActionLabel.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(146)))), ((int)(((byte)(151)))));
            this.ActionLabel.Location = new System.Drawing.Point(13, 13);
            this.ActionLabel.Name = "ActionLabel";
            this.ActionLabel.Size = new System.Drawing.Size(48, 12);
            this.ActionLabel.TabIndex = 5;
            this.ActionLabel.Text = "ACTION";
            this.ActionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChangeKeybindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(403, 64);
            this.Controls.Add(this.ActionLabel);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.Keybind);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PushToMute);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeKeybindForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keybinds";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PushToMute;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Keybind;
        private System.Windows.Forms.Label background;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label ActionLabel;
    }
}