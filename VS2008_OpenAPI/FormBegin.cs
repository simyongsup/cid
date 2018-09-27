using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using VS2008_OpenAPI;

namespace VS2008_OpenAPI
{
    public partial class FormBegin : Form
    {
        string ip;
        string host;
        string param1;
        string param2;
        string pwd;
        string pwd1;
        string pwd2;
        string id;
        string ptype;
        string callcenter_idx;
        string callcenter_name;
        static FormReceipt form;
        static FormBegin formBegin;
        int line_count = 0;
        string dial1 = "";
        string dial2 = "";
        bool missed1 = false;
        bool missed2 = false;

        string miss1 = "";
        string miss_cha1 = "";
        string miss2 = "";
        string miss_cha2 = "";

        CefSettings settings = new CefSettings();
        public ChromiumWebBrowser chromeBrowser;
        Boolean auto = false;
        int count = 0;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        tcpClient client = new tcpClient();


        bool calling1 = false;
        bool calling2 = false;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(int uAction, int uParam, out RECT lpvParam, int fuWinIni);


        private void FormBegin_Load(object sender, EventArgs e)
        {

        }

        public FormBegin()
        {
            InitializeComponent();
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {

        }
        
        public FormBegin(string param1, string id, string pwd, string callcenter_idx, string pwd1, string pwd2, string ip, string host, string ptype, string callcenter_name)
        {
            //MessageBox.Show("param1=" + param1 + " param2=" + param2 + "  callcenter_idx=" + callcenter_idx);
            this.param1 = param1;
            this.pwd1 = pwd1;
            this.pwd2 = pwd2;
            this.id = id;
            this.pwd = pwd;
            this.ip = ip;
            this.ptype = ptype;
            this.host = host;
            this.callcenter_idx = callcenter_idx;
            this.callcenter_name = callcenter_name;

            //MessageBox.Show("1  " + callcenter_idx);
            client.cidClient(callcenter_idx, this);
            //socks(callcenter_idx);

            InitializeComponent();
            this.Text = callcenter_name;
            init1();
            screenView();
            load2(0, callcenter_idx);
        }

        public FormBegin(string param1, string param2, string id, string pwd, string callcenter_idx, string pwd1, string pwd2, string ip, string host, string ptype, string callcenter_name)
        {
            //MessageBox.Show("param1="+param1+" param2="+param2 +"  callcenter_idx="+callcenter_idx);
            this.param1 = param1;
            this.param2 = param2;
            this.pwd1 = pwd1;
            this.pwd2 = pwd2;
            this.id = id;
            this.pwd = pwd;
            this.ip = ip;
            this.ptype = ptype;
            this.host = host;
            this.callcenter_idx = callcenter_idx;
            this.callcenter_name = callcenter_name;

            InitializeComponent();
            this.Text = callcenter_name;
            //MessageBox.Show("2  "+callcenter_idx);
            client.cidClient(callcenter_idx, this);

            init2();
            load2(0, callcenter_idx);
            screenView();
        }

        internal void setString(string msg)
        {
            this.Invoke(new Action(delegate () // this == Form 이다. Form이 아닌 컨트롤의 Invoke를 직접호출해도 무방하다.
            {
                //listBox.Items.Clear();
                msg = DateTime.Now.ToString("HH:mm:ss")+ "  /  "+PhoneNumberFormatter(msg.Trim());
                //MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //listBox.Items.Insert(0, DateTime.Now.ToString("HH:mm:ss"));
                listBox.Items.Insert(0, msg);
                listBox.SetSelected(0, true);

                //listBox.SelectedItem = 0;
                //listBox.Items.Add(msg.Trim());
                //listBox.Items.Add(c1_name);
                //listBox.Items.Add(c1_address);
            }));
        }

        public void screenView()
        {
            formBegin = this;

            /*Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = screen.Width;
            this.Size = new Size(w, 200);
            //작업영역을 알아오는 Flag
            int SPI_GETWORKAREA = 0x0030;
            RECT r = new RECT();
            SystemParametersInfo(SPI_GETWORKAREA, 0, out r, 0);
            Size s = this.Size;
            Point p = new Point(r.right - s.Width, r.bottom - s.Height);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = p;
            */


            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            timer.Tick += new EventHandler(timer_Tick);

            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = screen.Width;
            int h = screen.Height;
            this.Size = new Size(w, h);
            //작업영역을 알아오는 Flag
            int SPI_GETWORKAREA = 0x0030;
            RECT r = new RECT();
            SystemParametersInfo(SPI_GETWORKAREA, 0, out r, 0);
            Size s = this.Size;
            Point p = new Point(r.right - s.Width, r.bottom - s.Height);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = p;

            string url = "https://daemuri.net/main/getMemberCheck.do?id=" + id + "&pwd=" + pwd + "&ip=" + ip + "&host=" + host;
            //string url = "http://127.0.0.1:8080/main/getMemberCheck.do?id=" + id + "&pwd=" + pwd + "&ip=" + ip + "&host=" + host;
            chromeBrowser = new ChromiumWebBrowser(url);

            chromeBrowser.LoadingStateChanged += OnLoadingStateChanged;
            Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;

        }

        //전화로그인1
        public void init1()
        {
            line_count = 1;

            if (ptype.Equals("DCS"))
            {
                axLGUBaseOpenApi1.LoginServer(param1, pwd1, "1.217.15.142");
            }
            else
            {
                //MessageBox.Show("1 type = " + ptype + "  param1=" + param1);
                axLGUBaseOpenApi1.LoginServer(param1, pwd1, "");
            }
        }

        //전화로그인2
        public void init2()
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = screen.Width;
            this.Size = new Size(w, 245);
            line_count = 2;

            if (ptype.Equals("DCS"))
            {
                axLGUBaseOpenApi1.LoginServer(param1, pwd1, "1.217.15.142");
                axLGUBaseOpenApi2.LoginServer(param2, pwd2, "1.217.15.142");
            }
            else
            {
                //MessageBox.Show("2 type = " + ptype + "  param1=" + param1);
                axLGUBaseOpenApi1.LoginServer(param1, pwd1, "");
                axLGUBaseOpenApi2.LoginServer(param2, pwd2, "");
            }
        }

        //1
        private void axLGUBaseOpenApi1_SendLoginResultEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendLoginResultEventEvent e)
        {
            //MessageBox.Show("로그인1" + e.bstrLoginResult.ToString());
        }

        //2
        private void axLGUBaseOpenApi2_SendLoginResultEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendLoginResultEventEvent e)
        {
            //MessageBox.Show("로그인2" + e.bstrLoginResult.ToString());
        }
        //1 벨링
        private void axLGUBaseOpenApi1_SendRingEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendRingEventEvent e)
        {
            this.missed1 = true;
            string[] strArrays = e.bstrRingEvent.ToString().Split(new char[] { '|' });
            if (this.ptype.Equals("DCS"))
            {
            
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].StartsWith("CALLER"))
                    {
                        this.miss1 = strArrays[i].Replace("CALLERID:", "");
                    }
                    else if (strArrays[i].StartsWith("INEXTEN"))
                    {
                        this.miss_cha1 = strArrays[i].Replace("INEXTEN:", "");
                    }
                    else if (strArrays[i].StartsWith("ISDIAL"))
                    {
                        this.dial1 = strArrays[i].Replace("ISDIAL:", "");
                    }
                }
            }
            if (this.ptype.Equals("CENTRIX"))
            {
                for (int j = 0; j < (int)strArrays.Length; j++)
                {
                    if (strArrays[j].StartsWith("CALLER"))
                    {
                        this.miss1 = strArrays[j].Replace("CALLERID:", "");
                    }
                    else if (strArrays[j].StartsWith("INEXTEN"))
                    {
                        this.miss_cha1 = strArrays[j].Replace("INEXTEN:", "");
                    }
                    else if (strArrays[j].StartsWith("ISDIAL"))
                    {
                        this.dial1 = strArrays[j].Replace("ISDIAL:", "");
                    }
                }
            }

            //MessageBox.Show("1번 miss1 : "+this.miss1 + "  dial1="+ this.dial1);
            client.send(this.miss1);  //send(callcenter_idx, this.miss1, this);
        }
        //2 벨링
        private void axLGUBaseOpenApi2_SendRingEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendRingEventEvent e)
        {
            this.missed2 = true;
            string[] strArrays = e.bstrRingEvent.ToString().Split(new char[] { '|' });
            if (this.ptype.Equals("DCS"))
            {
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].StartsWith("CALLER"))
                    {
                        this.miss2 = strArrays[i].Replace("CALLERID:", "");
                    }
                    else if (strArrays[i].StartsWith("INEXTEN"))
                    {
                        this.miss_cha2 = strArrays[i].Replace("INEXTEN:", "");
                    }
                    else if (strArrays[i].StartsWith("ISDIAL"))
                    {
                        this.dial2 = strArrays[i].Replace("ISDIAL:", "");
                    }
                }
            }
            if (this.ptype.Equals("CENTRIX"))
            {
                for (int j = 0; j < (int)strArrays.Length; j++)
                {
                    if (strArrays[j].StartsWith("CALLER"))
                    {
                        this.miss2 = strArrays[j].Replace("CALLERID:", "");
                    }
                    else if (strArrays[j].StartsWith("INEXTEN"))
                    {
                        this.miss_cha2 = strArrays[j].Replace("INEXTEN:", "");
                    }
                    else if (strArrays[j].StartsWith("ISDIAL"))
                    {
                        this.dial2 = strArrays[j].Replace("ISDIAL:", "");
                    }
                }
            }
            //send(callcenter_idx, this.miss2, this);
            client.send(this.miss2);
            //MessageBox.Show("2번 miss2 : " + this.miss2 + "  dial2=" + this.dial2);
        }
        

        //연결성립1
        private void axLGUBaseOpenApi1_SendChannelListEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendChannelListEventEvent e)
        {
            this.calling1 = true;
            this.missed1 = false;

            if (this.ptype.Equals("DCS"))
            {
                string[] strArrays = e.bstrChannelList.ToString().Split(new char[] { '|' });
                string str = "";
                string str1 = "";
                string str2 = "";

                //MessageBox.Show(e.bstrChannelList.ToString());
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].StartsWith("CALLER1"))
                    {
                        //전화를 건 사람
                        str = strArrays[i].Replace("CALLER1ID:", "");
                    }
                    else if (strArrays[i].StartsWith("CALLER2"))
                    {
                        //당겨받는 사람 - 2차 수신자
                        str1 = strArrays[i].Replace("CALLER2ID:", "");
                    }
                    else if (strArrays[i].StartsWith("INEXTEN"))
                    {
                        //1차수신자
                        str2 = strArrays[i].Replace("INEXTEN:", "");
                    }
                }
                //MessageBox.Show("다음1 this.dial1 ="+ this.dial1);

                if (!str2.Equals("") && str2.Length > 4)
                {
                    str2 = str2.Substring(str2.Length - 4, 4);
                }

                if (!str1.Equals("") && str1.Length > 4)
                {
                    str1 = str1.Substring(str1.Length - 4, 4);
                }
                
                //insert
                if (!this.dial1.Equals("0") && !this.dial1.Equals(""))
                {
                    str2 = str;
                    str = this.param1;
                    this.insertCallLog(str, str2, str1, this.callcenter_idx, "전화걸기", this.dial1);
                    //MessageBox.Show("전화걸기 = ");
                } else if (str2.Equals(str1))
                {
                    this.insertCallLog(str, str2, "", this.callcenter_idx, "바로받기", this.dial1);
                    //MessageBox.Show("바로받기 = ");
                }
                else if (!str1.Equals("") && !str1.Equals(str2))
                {
                    this.insertCallLog(str, str2, str1, this.callcenter_idx, "당겨받기", this.dial1);
                    //MessageBox.Show("당겨받기 /  전화건사람=" + str +"  2차 수신자 ="+str1 + "  1차 수신자 =" + str2);
                }

                //MessageBox.Show("전화건사람 = " + str + " 1차수신자 = " + str2 + " 2차수신자 = " + str1);
                if (!str.StartsWith("16445821") && !str.StartsWith("07050"))
                {
                    if (this.line_count != 1)
                    {
                        FormBegin.form = new FormReceipt(this.param1, this.param2, this, str, this.id, str1, str2, "", "new", this.callcenter_idx);
                    }
                    else
                    {
                        FormBegin.form = new FormReceipt(this.param1, "", this, str, this.id, str1, str2, "", "new", this.callcenter_idx);
                    }
                    FormBegin.form.Show();
                    
                }
            }
            else if (this.ptype.Equals("CENTRIX"))
            {
                string[] strArrays1 = e.bstrChannelList.ToString().Split(new char[] { '|' });
                string str3 = "";
                string str4 = "";
                string str5 = "";
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    if (strArrays1[j].StartsWith("CALLER1"))
                    {
                        str3 = strArrays1[j].Replace("CALLER1ID:", "");
                    }
                    else if (strArrays1[j].StartsWith("CALLER2"))
                    {
                        str4 = strArrays1[j].Replace("CALLER2ID:", "");
                    }
                    else if (strArrays1[j].StartsWith("INEXTEN"))
                    {
                        str5 = strArrays1[j].Replace("INEXTEN:", "");
                    }
                }

                if (this.dial1.Equals("0") || this.dial1.Equals(""))
                {                                
                    if (str5.Equals(str4))
                    {
                        this.insertCallLog(str3, str5, "", this.callcenter_idx, "바로받기", this.dial1);
                    }
                    else if (!str4.Equals("") && !str4.Equals(str5))
                    {
                        this.insertCallLog(str3, str5, str4, this.callcenter_idx, "당겨받기", this.dial1);
                    }

                    if (!str3.StartsWith("16445821") && !str3.StartsWith("07050"))
                    {
                        if (this.line_count != 1)
                        {
                            FormBegin.form = new FormReceipt(this.param1, this.param2, this, str3, this.id, str4, str5, "", "new", this.callcenter_idx);
                        }
                        else
                        {
                            FormBegin.form = new FormReceipt(this.param1, "", this, str3, this.id, str4, str5, "", "new", this.callcenter_idx);
                        }
                        FormBegin.form.Show();
                        
                    }
                }
                else
                {
                    str5 = str3;
                    str3 = this.param1;
                    this.insertCallLog(str3, str5, str4, this.callcenter_idx, "전화걸기", this.dial1);
                }
            }
        }


        //연결성립2
        private void axLGUBaseOpenApi2_SendChannelListEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendChannelListEventEvent e)
        {
            this.calling2 = true;
            this.missed2 = false;

            string str = e.bstrChannelList.ToString();
            string str1 = "";
            string str2 = "";
            string str3 = "";
            if (this.ptype.Equals("DCS"))
            {
                string[] strArrays = str.Split(new char[] { '|' });
                //MessageBox.Show(e.bstrChannelList.ToString());
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    if (strArrays[i].StartsWith("CALLER1"))
                    {
                        //전화를 건 사람
                        str1 = strArrays[i].Replace("CALLER1ID:", "");
                    }
                    else if (strArrays[i].StartsWith("CALLER2"))
                    {
                        //2차수신자
                        str2 = strArrays[i].Replace("CALLER2ID:", "");
                    }
                    else if (strArrays[i].StartsWith("INEXTEN"))
                    {
                        //1차수신자 - chnnel
                        str3 = strArrays[i].Replace("INEXTEN:", "");
                    }
                }

                if (!str2.Equals("") && str2.Length > 4)
                {
                    str2 = str2.Substring(str2.Length - 4, 4);
                }

                if (!str3.Equals("") && str3.Length > 4)
                {
                    str3 = str3.Substring(str3.Length - 4, 4);
                }

                if (!this.dial2.Equals("0") && !this.dial2.Equals(""))
                {                    
                    str3 = str1;
                    str1 = this.param1;
                    //c1_tel1, string ch, string to,
                    this.insertCallLog(str1, str3, str2, this.callcenter_idx, "전화걸기", this.dial2);                    
                }                           
                //str3 = str3.Substring(str3.Length - 4, str3.Length);
                else if (str3.Equals(str2))
                {
                    this.insertCallLog(str1, str3, "", this.callcenter_idx, "바로받기", this.dial2);
                }
                else if (!str2.Equals("") && !str2.Equals(str3))
                {
                    this.insertCallLog(str1, str3, str2, this.callcenter_idx, "당겨받기", this.dial2);
                }


                if (!str1.StartsWith("16445821") && !str1.StartsWith("07050"))
                {
                    if (this.line_count != 1)
                    {
                        FormBegin.form = new FormReceipt(this.param1, this.param2, this, str1, this.id, str2, str3, "", "new", this.callcenter_idx);
                    }
                    else
                    {
                        FormBegin.form = new FormReceipt(this.param1, "", this, str1, this.id, str2, str3, "", "new", this.callcenter_idx);
                    }
                    FormBegin.form.Show();
                   
                }
            }
            else if (this.ptype.Equals("CENTRIX"))
            {
                string[] strArrays1 = str.Split(new char[] { '|' });
                for (int j = 0; j < (int)strArrays1.Length; j++)
                {
                    if (strArrays1[j].StartsWith("CALLER1"))
                    {
                        str1 = strArrays1[j].Replace("CALLER1ID:", "");
                    }
                    else if (strArrays1[j].StartsWith("CALLER2"))
                    {
                        str2 = strArrays1[j].Replace("CALLER2ID:", "");
                    }
                    else if (strArrays1[j].StartsWith("INEXTEN"))
                    {
                        str3 = strArrays1[j].Replace("INEXTEN:", "");
                    }
                }
                if (this.dial2.Equals("0") || this.dial2.Equals(""))
                {                   
                    if (str3.Equals(str2))
                    {
                        this.insertCallLog(str1, str3, "", this.callcenter_idx, "바로받기", this.dial2);
                    }
                    else if (!str2.Equals("") && !str2.Equals(str3))
                    {
                        this.insertCallLog(str1, str3, str2, this.callcenter_idx, "당겨받기", this.dial2);
                    }
                    if (!str1.StartsWith("16445821") && !str1.StartsWith("07050"))
                    {
                        if (this.line_count != 1)
                        {
                            FormBegin.form = new FormReceipt(this.param1, this.param2, this, str1, this.id, str2, str3, "", "new", this.callcenter_idx);
                        }
                        else
                        {
                            FormBegin.form = new FormReceipt(this.param1, "", this, str1, this.id, str2, str3, "", "new", this.callcenter_idx);
                        }
                        FormBegin.form.Show();
                        
                    }
                }
                else
                {                   
                    str3 = str1;
                    str1 = this.param1;
                    this.insertCallLog(str1, str3, str2, this.callcenter_idx, "전화걸기", this.dial2);
                }
            }
        }

        //1끊김이벤트
        private void axLGUBaseOpenApi1_SendChannelOutEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendChannelOutEventEvent e)
        {
            this.calling1 = false;
            if (this.missed1 && !this.miss_cha1.Equals(""))
            {
                if (!this.miss_cha1.Equals("") && this.miss_cha1.Length > 4 && this.ptype.Equals("DCS"))
                {
                    this.miss_cha1 = this.miss_cha1.Substring(this.miss_cha1.Length - 4, 4);
                }
                this.insertCallLog(this.miss1, this.miss_cha1, "", this.callcenter_idx, "끊김", this.dial1);
            }
        }
        //2끊김이벤트
        private void axLGUBaseOpenApi2_SendChannelOutEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendChannelOutEventEvent e)
        {
            this.calling2 = false;
            if (this.missed2 && !this.miss_cha2.Equals(""))
            {
                if (!this.miss_cha2.Equals("") && this.miss_cha2.Length > 4 && this.ptype.Equals("DCS"))
                {
                    this.miss_cha2 = this.miss_cha2.Substring(this.miss_cha2.Length - 4, 4);
                }
                this.insertCallLog(this.miss2, this.miss_cha2, "", this.callcenter_idx, "끊김", this.dial2);
            }
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //클릭
        private void button1_Click(object sender, EventArgs e)
        {
            form = new FormReceipt(param1, param2, this, "", id, "7005", "7005", "", "new", callcenter_idx);
            form.Show();
        }

        public void dial(string number)
        {
            //MessageBox.Show("전화번호 = " + number + " line_count="+ line_count + " calling1=" + calling1 + " calling2=" + calling2);
            if (line_count == 1)//단독회선
            {
                if (!calling1)
                {
                    ////MessageBox.Show("단독회선 전화번호1 = "+number);
                    axLGUBaseOpenApi1.Click2Call(number, "", "");
                }
            }
            else//2회선
            {
                if (!calling1)
                {
                    //MessageBox.Show("2중회선 전화번호1 = " + number);
                    axLGUBaseOpenApi1.Click2Call(number, "", "");
                }
                else if (!calling2)
                {
                    //MessageBox.Show("2중회선 전화번호2 = " + number);
                    axLGUBaseOpenApi2.Click2Call(number, "", "");
                }
            }
        }


        private void insertCallLog(string c1_tel1, string ch, string to, string callcenter_idx, string type, string dial)
        {
            // MessageBox.Show("당겨받기 /  전화건사람=" + str +"  2차 수신자 ="+str1 + "  1차 수신자 =" + str2);
            //this.insertCallLog(str, str2, str1, this.callcenter_idx, "당겨받기", this.dial1);
            //string url = "http://127.0.0.1:8080/corp/insertCallLog.do?c1_tel1=" +
            string url = "https://daemuri.net/corp/insertCallLog.do?c1_tel1=" +
            c1_tel1 + "&id=" + id + "&ch=" + ch + "&end=" + to +  "&callcenter_idx=" + callcenter_idx + "&c1_dept=" + type + "&dial=" + dial;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "Application/json;charset=utf-8";

                string sendData = "";

                byte[] buffer;
                buffer = Encoding.Default.GetBytes(sendData);
                request.ContentLength = buffer.Length;
                Stream sendStream = request.GetRequestStream();
                sendStream.Write(buffer, 0, buffer.Length);
                sendStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream respPostStream = response.GetResponseStream();
                StreamReader readerPost = new StreamReader(respPostStream, Encoding.UTF8);
                string resultJson = readerPost.ReadToEnd();


                JObject obj = new JObject();
                obj = JObject.Parse(resultJson);
                string rs = obj["rs"].ToString();
                load2(0, callcenter_idx);
            }
            catch (System.Net.WebException er)
            {
                //MessageBox.Show(er.Message);
            }
        }

        public void load2(int page, string callcenter_idx)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            //string url = "http://127.0.0.1:8080/corp/getListCallHistAjaxCSHARP.do?page="+page+"&callcenter_idx="+callcenter_idx;
            string url = "https://daemuri.net/corp/getListCallHistAjaxCSHARP.do?page=" + page + "&callcenter_idx=" + callcenter_idx;

            ///main/getMemberCheck.do?ip="+ip+"&host="+host

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "Application/json;charset=utf-8";

                string sendData = "";

                byte[] buffer;
                buffer = Encoding.Default.GetBytes(sendData);
                request.ContentLength = buffer.Length;
                Stream sendStream = request.GetRequestStream();
                sendStream.Write(buffer, 0, buffer.Length);
                sendStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream respPostStream = response.GetResponseStream();
                StreamReader readerPost = new StreamReader(respPostStream, Encoding.UTF8);
                string resultJson = readerPost.ReadToEnd();

                JObject obj = new JObject();
                obj = JObject.Parse(resultJson);

                JArray array = JArray.Parse(obj["getListCallHistAjax"].ToString());

                int page_count = Convert.ToInt32(obj["page_count"].ToString());
                int total_count = Convert.ToInt32(obj["total_count"].ToString());
                ////MessageBox.Show(""+order_count);

                //total.Text = "전체건수=>"+total_count;
                //setButtonPage(page_count);

                //Regex regexTel = new Regex(@"\d{3}-\d{3,4}-\d{4}");
                //Regex regexMobile = new Regex(@"01\d-\d{3,4}-\d{4}");

                int i = array.Count;
                foreach (JObject itemObj in array)
                {
                    string order_no = "";
                    string input_date = "";
                    string ch = "";
                    string end = "";
                    string c1_tel1 = "";
                    string c1_dept = "";
                    string c1_name = "";
                    string c1_dong = "";

                    string c1_memo = "";

                    if (itemObj["order_no"] != null)
                    {
                        order_no = itemObj["order_no"].ToString();
                    }
                    if (itemObj["input_date"] != null)
                    {
                        input_date = itemObj["input_date"].ToString();
                    }
                    if (itemObj["c1_tel1"] != null)
                    {
                        c1_tel1 = itemObj["c1_tel1"].ToString();
                        c1_tel1 = PhoneNumberFormatter(c1_tel1);
                    }
                    if (itemObj["ch"] != null)
                    {
                        ch = itemObj["ch"].ToString();
                        ch = PhoneNumberFormatter(ch);
                    }
                    if (itemObj["end"] != null)
                    {
                        end = itemObj["end"].ToString();
                        end = PhoneNumberFormatter(end);
                    }
                   
                    if (itemObj["c1_dept"] != null)
                    {
                        c1_dept = itemObj["c1_dept"].ToString();
                    }
                    if (itemObj["c1_name"] != null)
                    {
                        c1_name = itemObj["c1_name"].ToString();
                    }
                    if (itemObj["c1_dong"] != null)
                    {
                        c1_dong = itemObj["c1_dong"].ToString();
                    }
                    if (itemObj["c1_memo"] != null)
                    {
                        c1_memo = itemObj["c1_memo"].ToString();
                    }


                    string[] row = {
                         ""+(i--),
                         order_no,
                         input_date ,
                         c1_tel1 ,                         
                         ch ,
                         end ,
                         c1_dept,
                         c1_name ,
                         c1_dong ,
                         c1_memo
                    };

                    dataGridView2.Rows.Add(row);

                }
            }
            catch (System.Net.WebException er)
            {
                //MessageBox.Show(er.Message);
            }
        }

        private string PhoneNumberFormatter(string value)
        {
            // value = new Regex(@"\D").Replace(value, string.Empty);
            // value = value.TrimStart('1');
            // value = "01011113333";
            //if (value.Length > 0 & value.Length < 4)
            //{
              //  value = string.Format("{0}", value.Substring(0, value.Length));
                //return value;
            //}
            //else 
            if (value.Length == 8)
            {
                value = string.Format("{0}-{1}", value.Substring(0, 4), value.Substring(4, value.Length-4));
                return value;
            }
            else if (value.Length >= 9 & value.Length <= 10)
            {
                if (value.StartsWith("02") && value.Length == 9)
                {
                    value = string.Format("{0}-{1}-{2}", value.Substring(0, 2), value.Substring(2, 3), value.Substring(5));
                }
                else if (value.StartsWith("02") && value.Length == 10)
                {
                    value = string.Format("{0}-{1}-{2}", value.Substring(0, 2), value.Substring(2, 4), value.Substring(6));
                }
                else
                {
                    value = string.Format("{0}-{1}-{2}", value.Substring(0, 3), value.Substring(3, 3), value.Substring(6));
                }

                return value;
            }
            else if (value.Length == 11)
            {
                //value = value.Remove(value.Length - 1, 1);
                value = string.Format("{0}-{1}-{2}", value.Substring(0, 3), value.Substring(3, 4), value.Substring(value.Length - 4, 4));
                return value;
            }
            return value;
        }

        //갱신
        private void button6_Click(object sender, EventArgs e)
        {
            load2(0, callcenter_idx);
        }

        private void reF(object sender, EventArgs e)
        {
            load2(0, callcenter_idx);
        }



        //1
        private void axLGUBaseOpenApi1_SendNetworkErrorEvent(object sender, EventArgs e)
        {
            axLGUBaseOpenApi1.DisconnectServer();
        }
        //2
        private void axLGUBaseOpenApi2_SendNetworkErrorEvent(object sender, EventArgs e)
        {
            axLGUBaseOpenApi1.DisconnectServer();
        }

        //1
        private void axLGUBaseOpenApi1_SendCmdErrorEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendCmdErrorEventEvent e)
        {
            //logbox.AppendText("1번 명령어 에러 => " + e.bstrMsgValue.ToString() + "\n");
        }
        //2
        private void axLGUBaseOpenApi2_SendCmdErrorEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendCmdErrorEventEvent e)
        {
            //logbox.AppendText("2번 명령어 에러 => " + e.bstrMsgValue.ToString() + "\n");
        }

        //1
        private void axLGUBaseOpenApi1_SendCommandResultEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendCommandResultEventEvent e)
        {

            //logbox.AppendText("1번 명령어 결과 => " + e.bstrCommandResult.ToString() + "\n");
        }
        //2
        private void axLGUBaseOpenApi2_SendCommandResultEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendCommandResultEventEvent e)
        {

            //logbox.AppendText("2번 명령어 결과 => " + e.bstrCommandResult.ToString() + "\n");
        }

        //1
        private void axLGUBaseOpenApi1_SendEtcEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendEtcEventEvent e)
        {
            //logbox.AppendText("1번 Send Rtc Event => " + e.bstrEventValue.ToString() + "\n");
        }
        //2
        private void axLGUBaseOpenApi2_SendEtcEvent(object sender, AxLGUBASEOPENAPILib._DLGUBaseOpenApiEvents_SendEtcEventEvent e)
        {
            //logbox.AppendText("2번 Send Rtc Event => " + e.bstrEventValue.ToString() + "\n");
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            axLGUBaseOpenApi1.DisconnectServer();
            axLGUBaseOpenApi2.DisconnectServer();
            this.Close();
        }

        private void 로그인_Click(object sender, EventArgs e)
        {
            axLGUBaseOpenApi1.LoginServer(param1, "!abcd1234", "1.217.15.142");
            axLGUBaseOpenApi2.LoginServer(param2, "!abcd1234", "1.217.15.142");
        }


        //전화받기1
        private void button2_Click(object sender, EventArgs e)
        {
            axLGUBaseOpenApi1.Answer();
        }
        //전화받기2
        private void button3_Click(object sender, EventArgs e)
        {
            axLGUBaseOpenApi2.Answer();
        }

        //전화끊기1
        private void button4_Click(object sender, EventArgs e)
        {
            axLGUBaseOpenApi1.HangUp();
        }

        //전화끊기2
        private void button5_Click(object sender, EventArgs e)
        {
            axLGUBaseOpenApi2.HangUp();
        }


        private void reFresh(object sender, EventArgs e)
        {

            if (!auto)
            {
                AutoButton.Text = "조회중";
                timer.Interval = 1000; // 1초               
                timer.Start();
                ProgressAutoBar.Value = 0;
                count = 0;
                auto = true;
                ProgressAutoBar.Maximum = 11;
            }
            else
            {
                AutoButton.Text = "자동";
                ProgressAutoBar.Value = 0;
                count = 0;
                auto = false;
                timer.Stop();
            }
        }

        // 매 1초마다 Tick 이벤트 핸들러 실행
        void timer_Tick(object sender, EventArgs e)
        {
            /**/
            ProgressAutoBar.Value = count;
            if (ProgressAutoBar.Maximum == count)
            {
                ProgressAutoBar.Value = 0;
                load2(0, callcenter_idx);
                count = 0;
            }
            ++count;
        }

        private void onStop(object sender, EventArgs e)
        {

        }

        private void dc_under(object sender, DataGridViewCellEventArgs e)
        {
            string order_no = dataGridView2.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            string c1_tel1 = dataGridView2.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();

            if (id == null) id = "admin";

            /*Int32 sel = dataGridView2.Rows.Count;//. DisplayedRowCount;
            
            for (int i=0; i<sel;++i)
            {
                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
            dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(169, 208, 245); */

            string type = "";
            if (order_no != null && !order_no.Equals("") && !order_no.Equals("0"))
            {
                type = "old";
            }
            else
            {
                type = "new";
            }


            c1_tel1 = c1_tel1.Replace("-", "");
            //MessageBox.Show(c1_tel1+"  order="+order_no);
            form = new FormReceipt(param1, param2, this, c1_tel1, id, "", "", order_no, type, callcenter_idx);
            form.Show();
        }

        //인증전화번호 입력 후 엔터
        private void getCidInfo(string cids)
        {
            string url = "https://daemuri.net/corp/getCidInfo.do?cid=" + cids + "&callcenter_idx=" + callcenter_idx;
            //string url = "http://127.0.0.1:8080/corp/getCidInfo.do?cid=" + cids + "&callcenter_idx="+callcenter_idx;
            //MessageBox.Show("cids = " + cids+"/");
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "Application/json;charset=utf-8";

                string sendData = "";

                byte[] buffer;
                buffer = Encoding.Default.GetBytes(sendData);
                request.ContentLength = buffer.Length;
                Stream sendStream = request.GetRequestStream();
                sendStream.Write(buffer, 0, buffer.Length);
                sendStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream respPostStream = response.GetResponseStream();
                StreamReader readerPost = new StreamReader(respPostStream, Encoding.UTF8);
                string resultJson = readerPost.ReadToEnd();

                JObject obj = new JObject();
                obj = JObject.Parse(resultJson);

                string cnt = obj["cnt"].ToString();
                string c1_name = obj["c1_name"].ToString();
                string c1_address = obj["c1_address"].ToString();

                //MessageBox.Show("c1_name = " + c1_name + "   c1_address = " + c1_address);

                if (cnt.Equals("1"))
                {
                    listBox.Items.Clear();
                    listBox.Items.Add(cids.Trim());
                    listBox.Items.Add(c1_name);
                    listBox.Items.Add(c1_address);
                }
                else
                {

                }
            }
            catch (System.Net.WebException er)
            {
                MessageBox.Show(er.Message);
            }
        }

    }


}






