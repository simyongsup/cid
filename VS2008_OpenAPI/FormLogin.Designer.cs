namespace VS2008_OpenAPI
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panel2 = new System.Windows.Forms.Panel();
            this.CLOSE_BTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.CidBox = new System.Windows.Forms.TextBox();
            this.AuthBox = new System.Windows.Forms.TextBox();
            this.PwdBox = new System.Windows.Forms.TextBox();
            this.R1 = new System.Windows.Forms.RadioButton();
            this.R2 = new System.Windows.Forms.RadioButton();
            this.GROUP = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GROUP.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(112)))), ((int)(((byte)(188)))));
            this.panel2.Controls.Add(this.CLOSE_BTN);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 50);
            this.panel2.TabIndex = 20;
            // 
            // CLOSE_BTN
            // 
            this.CLOSE_BTN.BackColor = System.Drawing.Color.LimeGreen;
            this.CLOSE_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLOSE_BTN.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CLOSE_BTN.Location = new System.Drawing.Point(241, 12);
            this.CLOSE_BTN.Name = "CLOSE_BTN";
            this.CLOSE_BTN.Size = new System.Drawing.Size(75, 30);
            this.CLOSE_BTN.TabIndex = 1;
            this.CLOSE_BTN.Text = "닫기";
            this.CLOSE_BTN.UseVisualStyleBackColor = false;
            this.CLOSE_BTN.Click += new System.EventHandler(this.CLOSE_BTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VS2008_OpenAPI.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "label1";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("굴림", 11.5F);
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(264, 218);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 69);
            this.button3.TabIndex = 17;
            this.button3.Text = "인증번호전송";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // IDBox
            // 
            this.IDBox.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IDBox.Location = new System.Drawing.Point(96, 148);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(162, 33);
            this.IDBox.TabIndex = 25;
            this.IDBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enterKey);
            // 
            // CidBox
            // 
            this.CidBox.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CidBox.Location = new System.Drawing.Point(96, 218);
            this.CidBox.Name = "CidBox";
            this.CidBox.Size = new System.Drawing.Size(162, 33);
            this.CidBox.TabIndex = 26;
            this.CidBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enterKyAuth);
            // 
            // AuthBox
            // 
            this.AuthBox.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AuthBox.Location = new System.Drawing.Point(96, 254);
            this.AuthBox.Name = "AuthBox";
            this.AuthBox.Size = new System.Drawing.Size(162, 33);
            this.AuthBox.TabIndex = 26;
            this.AuthBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enterKeyIn);
            // 
            // PwdBox
            // 
            this.PwdBox.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwdBox.Location = new System.Drawing.Point(96, 183);
            this.PwdBox.Name = "PwdBox";
            this.PwdBox.Size = new System.Drawing.Size(162, 33);
            this.PwdBox.TabIndex = 26;
            this.PwdBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enterKey2);
            // 
            // R1
            // 
            this.R1.AutoSize = true;
            this.R1.Checked = true;
            this.R1.Location = new System.Drawing.Point(7, 19);
            this.R1.Name = "R1";
            this.R1.Size = new System.Drawing.Size(48, 16);
            this.R1.TabIndex = 27;
            this.R1.TabStop = true;
            this.R1.Text = "DCS";
            this.R1.UseVisualStyleBackColor = true;
            // 
            // R2
            // 
            this.R2.AutoSize = true;
            this.R2.Location = new System.Drawing.Point(162, 19);
            this.R2.Name = "R2";
            this.R2.Size = new System.Drawing.Size(76, 16);
            this.R2.TabIndex = 27;
            this.R2.Text = "CENTRIX";
            this.R2.UseVisualStyleBackColor = true;
            // 
            // GROUP
            // 
            this.GROUP.Controls.Add(this.R2);
            this.GROUP.Controls.Add(this.R1);
            this.GROUP.Location = new System.Drawing.Point(6, 97);
            this.GROUP.Name = "GROUP";
            this.GROUP.Size = new System.Drawing.Size(252, 45);
            this.GROUP.TabIndex = 28;
            this.GROUP.TabStop = false;
            this.GROUP.Text = "전화기종류";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(3, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "아   이   디";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(5, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "비 밀 번 호";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(1, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "휴대폰 번호";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(5, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "인 증 번 호";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(264, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 68);
            this.button1.TabIndex = 1;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.login1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 12F);
            this.button2.Location = new System.Drawing.Point(96, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 30);
            this.button2.TabIndex = 29;
            this.button2.Text = "로그인";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 333);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GROUP);
            this.Controls.Add(this.AuthBox);
            this.Controls.Add(this.PwdBox);
            this.Controls.Add(this.CidBox);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStandBy";
            this.TopMost = true;
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GROUP.ResumeLayout(false);
            this.GROUP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.TextBox CidBox;
        private System.Windows.Forms.TextBox AuthBox;
        private System.Windows.Forms.TextBox PwdBox;
        private System.Windows.Forms.RadioButton R1;
        private System.Windows.Forms.RadioButton R2;
        private System.Windows.Forms.GroupBox GROUP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CLOSE_BTN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}