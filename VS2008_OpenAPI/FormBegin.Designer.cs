using AxLGUBASEOPENAPILib;
using System;

namespace VS2008_OpenAPI
{
    partial class FormBegin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBegin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NewOrderButton = new System.Windows.Forms.Button();
            this.로그인 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.AutoButton = new System.Windows.Forms.Button();
            this.ProgressAutoBar = new System.Windows.Forms.ProgressBar();
            this.axLGUBaseOpenApi2 = new AxLGUBASEOPENAPILib.AxLGUBaseOpenApi();
            this.axLGUBaseOpenApi1 = new AxLGUBASEOPENAPILib.AxLGUBaseOpenApi();
            this.listBox = new System.Windows.Forms.ListBox();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_no_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.input_date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1_tel1_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1_dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1_name_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1_dong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1_memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLGUBaseOpenApi2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLGUBaseOpenApi1)).BeginInit();
            this.SuspendLayout();
            // 
            // NewOrderButton
            // 
            this.NewOrderButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NewOrderButton.BackColor = System.Drawing.Color.PapayaWhip;
            this.NewOrderButton.Location = new System.Drawing.Point(1808, 963);
            this.NewOrderButton.Name = "NewOrderButton";
            this.NewOrderButton.Size = new System.Drawing.Size(113, 30);
            this.NewOrderButton.TabIndex = 8;
            this.NewOrderButton.Text = "신규접수";
            this.NewOrderButton.UseVisualStyleBackColor = false;
            this.NewOrderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // 로그인
            // 
            this.로그인.Location = new System.Drawing.Point(559, 980);
            this.로그인.Name = "로그인";
            this.로그인.Size = new System.Drawing.Size(75, 23);
            this.로그인.TabIndex = 11;
            this.로그인.Text = "로그인";
            this.로그인.UseVisualStyleBackColor = true;
            this.로그인.Click += new System.EventHandler(this.로그인_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(745, 986);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "전화받기1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(827, 985);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "전화받기2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(745, 982);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "전화끊기1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(827, 982);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "전화끊기2";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.order_no_2,
            this.input_date2,
            this.c1_tel1_2,
            this.ch,
            this.end,
            this.c1_dept,
            this.c1_name_2,
            this.c1_dong,
            this.c1_memo});
            this.dataGridView2.Location = new System.Drawing.Point(1, 902);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1562, 115);
            this.dataGridView2.TabIndex = 23;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dc_under);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 1063);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1153, 1063);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "label2";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RefreshButton.Location = new System.Drawing.Point(1808, 901);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(113, 30);
            this.RefreshButton.TabIndex = 9;
            this.RefreshButton.Text = "갱신";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.reF);
            // 
            // AutoButton
            // 
            this.AutoButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AutoButton.Location = new System.Drawing.Point(1808, 932);
            this.AutoButton.Name = "AutoButton";
            this.AutoButton.Size = new System.Drawing.Size(113, 30);
            this.AutoButton.TabIndex = 9;
            this.AutoButton.Text = "자동";
            this.AutoButton.UseVisualStyleBackColor = true;
            this.AutoButton.Click += new System.EventHandler(this.reFresh);
            // 
            // ProgressAutoBar
            // 
            this.ProgressAutoBar.Location = new System.Drawing.Point(1808, 993);
            this.ProgressAutoBar.Name = "ProgressAutoBar";
            this.ProgressAutoBar.Size = new System.Drawing.Size(113, 22);
            this.ProgressAutoBar.TabIndex = 30;
            // 
            // axLGUBaseOpenApi2
            // 
            this.axLGUBaseOpenApi2.Enabled = true;
            this.axLGUBaseOpenApi2.Location = new System.Drawing.Point(1587, 1051);
            this.axLGUBaseOpenApi2.Name = "axLGUBaseOpenApi2";
            this.axLGUBaseOpenApi2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLGUBaseOpenApi2.OcxState")));
            this.axLGUBaseOpenApi2.Size = new System.Drawing.Size(100, 50);
            this.axLGUBaseOpenApi2.TabIndex = 37;
            this.axLGUBaseOpenApi2.SendRingEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendRingEventEventHandler(this.axLGUBaseOpenApi2_SendRingEvent);
            this.axLGUBaseOpenApi2.SendChannelListEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendChannelListEventEventHandler(this.axLGUBaseOpenApi2_SendChannelListEvent);
            this.axLGUBaseOpenApi2.SendChannelOutEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendChannelOutEventEventHandler(this.axLGUBaseOpenApi2_SendChannelOutEvent);
            this.axLGUBaseOpenApi2.SendNetworkErrorEvent += new System.EventHandler(this.axLGUBaseOpenApi2_SendNetworkErrorEvent);
            this.axLGUBaseOpenApi2.SendLoginResultEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendLoginResultEventEventHandler(this.axLGUBaseOpenApi2_SendLoginResultEvent);
            this.axLGUBaseOpenApi2.SendCommandResultEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendCommandResultEventEventHandler(this.axLGUBaseOpenApi2_SendCommandResultEvent);
            this.axLGUBaseOpenApi2.SendEtcEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendEtcEventEventHandler(this.axLGUBaseOpenApi2_SendEtcEvent);
            this.axLGUBaseOpenApi2.SendCmdErrorEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendCmdErrorEventEventHandler(this.axLGUBaseOpenApi2_SendCmdErrorEvent);
            // 
            // axLGUBaseOpenApi1
            // 
            this.axLGUBaseOpenApi1.Enabled = true;
            this.axLGUBaseOpenApi1.Location = new System.Drawing.Point(1693, 1051);
            this.axLGUBaseOpenApi1.Name = "axLGUBaseOpenApi1";
            this.axLGUBaseOpenApi1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLGUBaseOpenApi1.OcxState")));
            this.axLGUBaseOpenApi1.Size = new System.Drawing.Size(100, 50);
            this.axLGUBaseOpenApi1.TabIndex = 38;
            this.axLGUBaseOpenApi1.SendRingEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendRingEventEventHandler(this.axLGUBaseOpenApi1_SendRingEvent);
            this.axLGUBaseOpenApi1.SendChannelListEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendChannelListEventEventHandler(this.axLGUBaseOpenApi1_SendChannelListEvent);
            this.axLGUBaseOpenApi1.SendChannelOutEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendChannelOutEventEventHandler(this.axLGUBaseOpenApi1_SendChannelOutEvent);
            this.axLGUBaseOpenApi1.SendNetworkErrorEvent += new System.EventHandler(this.axLGUBaseOpenApi1_SendNetworkErrorEvent);
            this.axLGUBaseOpenApi1.SendLoginResultEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendLoginResultEventEventHandler(this.axLGUBaseOpenApi1_SendLoginResultEvent);
            this.axLGUBaseOpenApi1.SendCommandResultEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendCommandResultEventEventHandler(this.axLGUBaseOpenApi1_SendCommandResultEvent);
            this.axLGUBaseOpenApi1.SendEtcEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendEtcEventEventHandler(this.axLGUBaseOpenApi1_SendEtcEvent);
            this.axLGUBaseOpenApi1.SendCmdErrorEvent += new AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendCmdErrorEventEventHandler(this.axLGUBaseOpenApi1_SendCmdErrorEvent);
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("굴림", 12F);
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(1568, 902);
            this.listBox.Name = "listBox";
            this.listBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox.Size = new System.Drawing.Size(237, 116);
            this.listBox.TabIndex = 39;
            // 
            // NO
            // 
            this.NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.NO.HeaderText = "NO";
            this.NO.Name = "NO";
            this.NO.Width = 48;
            // 
            // order_no_2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.order_no_2.DefaultCellStyle = dataGridViewCellStyle3;
            this.order_no_2.HeaderText = "오더번호";
            this.order_no_2.Name = "order_no_2";
            this.order_no_2.Visible = false;
            // 
            // input_date2
            // 
            this.input_date2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.input_date2.DefaultCellStyle = dataGridViewCellStyle4;
            this.input_date2.HeaderText = "수신시간";
            this.input_date2.Name = "input_date2";
            this.input_date2.Width = 170;
            // 
            // c1_tel1_2
            // 
            this.c1_tel1_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.c1_tel1_2.DefaultCellStyle = dataGridViewCellStyle5;
            this.c1_tel1_2.HeaderText = "고객번호";
            this.c1_tel1_2.Name = "c1_tel1_2";
            this.c1_tel1_2.Width = 150;
            // 
            // ch
            // 
            this.ch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ch.DefaultCellStyle = dataGridViewCellStyle6;
            this.ch.HeaderText = "1차수신";
            this.ch.Name = "ch";
            this.ch.Width = 150;
            // 
            // end
            // 
            this.end.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.end.DefaultCellStyle = dataGridViewCellStyle7;
            this.end.HeaderText = "2차수신";
            this.end.Name = "end";
            this.end.Width = 150;
            // 
            // c1_dept
            // 
            this.c1_dept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.c1_dept.DefaultCellStyle = dataGridViewCellStyle8;
            this.c1_dept.HeaderText = "콜타입";
            this.c1_dept.Name = "c1_dept";
            // 
            // c1_name_2
            // 
            this.c1_name_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.c1_name_2.DefaultCellStyle = dataGridViewCellStyle9;
            this.c1_name_2.HeaderText = "고객명";
            this.c1_name_2.Name = "c1_name_2";
            this.c1_name_2.Width = 200;
            // 
            // c1_dong
            // 
            this.c1_dong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.c1_dong.DefaultCellStyle = dataGridViewCellStyle10;
            this.c1_dong.HeaderText = "기준동";
            this.c1_dong.Name = "c1_dong";
            this.c1_dong.Width = 200;
            // 
            // c1_memo
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.c1_memo.DefaultCellStyle = dataGridViewCellStyle11;
            this.c1_memo.HeaderText = "적요";
            this.c1_memo.Name = "c1_memo";
            this.c1_memo.ReadOnly = true;
            // 
            // FormBegin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1041);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.axLGUBaseOpenApi1);
            this.Controls.Add(this.axLGUBaseOpenApi2);
            this.Controls.Add(this.ProgressAutoBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.로그인);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.AutoButton);
            this.Controls.Add(this.NewOrderButton);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBegin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormBegin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLGUBaseOpenApi2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLGUBaseOpenApi1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button NewOrderButton;
        private System.Windows.Forms.Button 로그인;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button AutoButton;
        private System.Windows.Forms.ProgressBar ProgressAutoBar;
        private AxLGUBASEOPENAPILib.AxLGUBaseOpenApi axLGUBaseOpenApi2;
        private AxLGUBASEOPENAPILib.AxLGUBaseOpenApi axLGUBaseOpenApi1;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_no_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn input_date2;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1_tel1_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch;
        private System.Windows.Forms.DataGridViewTextBoxColumn end;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1_dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1_name_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1_dong;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1_memo;
    }
}