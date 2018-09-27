using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxLGUBASEOPENAPILib;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;

namespace VS2008_OpenAPI
{
    public partial class FormLogin : Form
    {
        private string param1;
        private string param2;
        String callcenter_idx;
        String id;
        string pwd;
        string cid;
        string auth;
        string ptype;

        FormBegin form;

        public FormLogin()
        {
            InitializeComponent();
            //IDBox.Text = Properties.Settings.Default.loginId;
            //PwdBox.Text = Properties.Settings.Default.LoginPwd;
            IDBox.Focus();
            init();

        }

        public FormLogin(string param1, string param2, AxLGUBaseOpenApi axLGUBaseOpenApi1, AxLGUBaseOpenApi axLGUBaseOpenApi2)
        {
            InitializeComponent();
            init();
            IDBox.Focus();
            //this.param1 = param1;
            //this.param2 = param2;
        }
        
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
        
        public void init()
        {

            /*int SPI_GETWORKAREA = 0x0030; //작업영역을 알아오는 Flag
            RECT r = new RECT();
            SystemParametersInfo(SPI_GETWORKAREA, 0, out r, 0);
            Size s = this.Size;
            Point p = new Point(r.right - s.Width, r.bottom - s.Height);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = p;*/
            this.Height = 218;
            label1.Text = GetLocalIP();
            //PBox.Select();
            //PBox.SelectedText = "센트릭스";
            //PBox.SelectedItem = "센트릭스";
            //MessageBox.Show("");
        }
      

        public string GetLocalIP()
        {
            string localIP = "인터넷 연결 불가!";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public static implicit operator FormLogin(FormReceipt v)
        {
            throw new NotImplementedException();
        }
        
        //아이디 입력 후 엔터
        private void enterKey(object sender, KeyEventArgs e)
        {
            id = IDBox.Text.ToString();
            if (e.KeyCode == Keys.Enter)
            {
                if (IDBox.Text.ToString().Equals(""))
                {
                    IDBox.Focus();
                    MessageBox.Show("아이디를 입력해 주세요");
                }
                else
                {                    
                    PwdBox.Focus();
                }
            }
        }

        //비번 입력 후 엔터
        private void enterKey2(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter)
            {
                loginOk1();
            }
        }

        private void loginOk1()
        {
            id = IDBox.Text.ToString();
            pwd = PwdBox.Text.ToString();
            if (PwdBox.Text.ToString().Equals(""))
            {
                IDBox.Focus();
                MessageBox.Show("아이디를 입력해 주세요");                
            }
            else if (IDBox.Text.ToString().Equals(""))
            {
                PwdBox.Focus();
                MessageBox.Show("비밀번호를 입력해 주세요");
            }
            else
            {
                string url = "https://daemuri.net/main/getSendAuth.do?id=" + id + "&pwd=" + pwd;
                //string url = "http://127.0.0.1:8080/main/getSendAuth.do?id=" + id + "&pwd=" + pwd;
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
                    if (!resultJson.Contains("<!DOCTYPE html")) { 
                  
                        JObject obj = new JObject();
                        obj = JObject.Parse(resultJson);
                        string rs = obj["rs"].ToString();

                        if (rs.Equals("fail"))
                        {
                            MessageBox.Show("등록된 사용자가 아닙니다.");
                            this.Height = 218;
                        }
                        else
                        {
                            JObject obj2 = new JObject();
                            obj2 = JObject.Parse(rs);
                            callcenter_idx = obj2["callcenter_idx"].ToString();
                            //MessageBox.Show("callcenter_idx = " + callcenter_idx);
                            CidBox.Visible = true;
                            button3.Visible = true;
                            CidBox.Focus();
                            this.Height = 335;
                        }
                    }else
                    {
                        MessageBox.Show("등록된 사용자가 아닙니다.");
                        this.Height = 217;
                    }
                }
                catch (System.Net.WebException er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        //인증전화번호 입력 후 엔터
        private void enterKyAuth(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getAuth();
            }
        }

        private void getAuth()
        {
            id = IDBox.Text.ToString();
            pwd = PwdBox.Text.ToString();
            cid = CidBox.Text.ToString();
            
            if (CidBox.Text.ToString().Equals(""))
            {
                CidBox.Focus();
                MessageBox.Show("전화번호를 입력해 주세요");
            }
            else
            {
                string url = "https://daemuri.net/util/sendPushAuthAjax.do?id=" + id +
                //string url = "http://127.0.0.1:8080/util/sendPushAuthAjax.do?id=" + id +
                "&pwd=" + pwd +
                "&cid=" + cid;
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
                    if (!resultJson.Contains("<!DOCTYPE html"))
                    {
                        if (resultJson.Equals("전송완료"))
                        {
                            AuthBox.Visible = true;
                            //button3.Visible = true;
                            AuthBox.Focus();
                        }
                        else
                        {
                            MessageBox.Show("등록된 사용자가 아닙니다.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("등록된 사용자가 아닙니다.");
                    }
                }
                catch (System.Net.WebException er)
                {
                    MessageBox.Show(er.Message);
                }
            }
          
        }

        //인증번호 넣고 최종 접속 엔터
        private void enterKeyIn(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter)
            {
                loginFinal();
            }
        }

        private void loginFinal()
        {
            auth = AuthBox.Text.ToString();
            if (AuthBox.Text.ToString().Equals(""))
            {
                AuthBox.Focus();
                MessageBox.Show("인증번호를 입력해 주세요");
            }
            else
            {
                string url = "https://daemuri.net/main/getCheckAuthForLogin.do?id=" + id +
                //string url = "http://127.0.0.1:8080/main/getCheckAuthForLogin.do?id=" + id +
                "&pwd=" + pwd +
                "&cid=" + cid +
                 "&auth=" + auth;
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

                    if (!resultJson.Contains("<!DOCTYPE html"))
                    {
                        if (resultJson.Equals("1"))
                        {
                            if (R1.Checked) ptype = "DCS";
                            else if (R2.Checked) ptype = "CENTRIX";

                            //MessageBox.Show("type ="+ ptype  + "  callcenter_idx="+ callcenter_idx);
                            url = "https://daemuri.net/corp/getDn.do?ip=" + GetLocalIP() + "&callcenter_idx=" + callcenter_idx + "&ptype=" + ptype;
                            //url = "http://127.0.0.1:8080/corp/getDn.do?ip=" + GetLocalIP() + "&callcenter_idx=" + callcenter_idx+"&ptype="+ptype;

                            try
                            {
                                request = (HttpWebRequest)WebRequest.Create(url);
                                request.Method = "POST";
                                request.ContentType = "Application/json;charset=utf-8";

                                sendData = "";

                                buffer = Encoding.Default.GetBytes(sendData);
                                request.ContentLength = buffer.Length;
                                sendStream = request.GetRequestStream();
                                sendStream.Write(buffer, 0, buffer.Length);
                                sendStream.Close();
                                response = (HttpWebResponse)request.GetResponse();
                                respPostStream = response.GetResponseStream();
                                readerPost = new StreamReader(respPostStream, Encoding.UTF8);
                                resultJson = readerPost.ReadToEnd();

                                JObject obj = new JObject();
                                obj = JObject.Parse(resultJson);

                                //string id = obj["id"].ToString();
                                string dn1 = obj["dn1"].ToString();
                                string dn2 = obj["dn2"].ToString();
                                string pwd1 = obj["pwd1"].ToString();
                                string pwd2 = obj["pwd2"].ToString();
                                string callcenter_name = obj["callcenter_name"].ToString();

                                string ip = GetLocalIP();
                                string host = "";
                                id = IDBox.Text.ToString();
                                string pwd = PwdBox.Text.ToString();

                                //MessageBox.Show("dn1 = " + dn1+ "  dn2 = " + dn2+"  ptype="+ptype + " callcenter_idx="+ callcenter_idx);
                                if (id.Equals("0") && dn1.Equals("0"))
                                {
                                    MessageBox.Show("등록된 내선이 없습니다.");
                                }
                                else if (dn2 == null || dn2.Equals("0"))//내선번호 1만 있는경우
                                {
                                    param1 = dn1;

                                    form = new FormBegin(param1, id, pwd, callcenter_idx, pwd1, pwd2, ip, host, ptype, callcenter_name);
                                    this.Hide();
                                    form.Show();
                                }
                                else//내선번호 2도 있는경우
                                {
                                    param1 = dn1;
                                    param2 = dn2;

                                    form = new FormBegin(param1, param2, id, pwd, callcenter_idx, pwd1, pwd2, ip, host, ptype, callcenter_name);
                                    form.Show();
                                    this.Hide();
                                }
                            }
                            catch (System.Net.WebException er)
                            {
                                MessageBox.Show(er.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("등록된 사용자가 아닙니다.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("등록된 사용자가 아닙니다.");
                    }
                }
                catch (System.Net.WebException er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }


        //입장
        private void button1_Click_1(object sender, EventArgs e)
        {
            getAuth();           
        }

        private void clearTextBox1(object sender, MouseEventArgs e)
        {
            IDBox.Text = "";
        }

        private void clearAuthTextBox(object sender, EventArgs e)
        {
            AuthBox.Text = "";
        }

        private void clearMobileNoTextBox(object sender, EventArgs e)
        {
            CidBox.Text = "";
        }

        private void clearPwdTextBox(object sender, EventArgs e)
        {
            PwdBox.Text = "";
        }

        private void CLOSE_BTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login1(object sender, EventArgs e)
        {
            loginOk1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginFinal();
        }
    }
}
