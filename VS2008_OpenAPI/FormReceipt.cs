using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Text;
using System.Threading.Tasks;
using AxLGUBASEOPENAPILib;
using CefSharp.Internals;
using System.Threading;

namespace VS2008_OpenAPI
{
    public partial class FormReceipt : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        FormBegin bForm;
        bool calling1 = false;
        bool calling2 = false;

        bool ring1 = false;
        bool ring2 = false;
        private string param1;
        private string param2;

        private string caller;
        private string to;
        private string ch;
        private string id;
        private FormBegin formBegin;
        private string callcenter_idx;


        int line_count = 0;
        private string order_no;
        CefSettings settings = new CefSettings();
        private string old_new;

        public FormReceipt()
        {
            InitializeComponent();
            if (!Cef.IsInitialized)
                Cef.Initialize(settings);

            Cef.AddDisposable(this);
        }



        /*public FormReceipt(string param1,  FormBegin formBegin, string caller, string id, string ch, string to)
        {
            InitializeComponent();            
        }        
       */

        public FormReceipt(string param1, string param2, FormBegin formBegin, string caller, string id, string ch, string to, string order_no, string old_new)
        {
            InitializeComponent();
            this.param1 = param1;
            this.param2 = param2;
            this.formBegin = formBegin;
            this.caller = caller;
            this.id = id;
            this.ch = ch;
            this.to = to;
            this.order_no = order_no;
            this.old_new = old_new;
        }


        public FormReceipt(string param1, string param2, FormBegin formBegin, string caller, string id, string ch, string to, string order_no, string old_new, string callcenter_idx)
           : this(param1, param2, formBegin, caller, id, ch, to, order_no, old_new)
        {
            this.callcenter_idx = callcenter_idx;
            if (old_new.Equals("old"))
            {
                ///order/updateOrderPop.do?order_no=
                //chromeBrowser = new ChromiumWebBrowser("http://127.0.0.1:8080/corp/updateOrderPop.do?order_no=" + order_no + "&c1_tel1=" + caller);
                chromeBrowser = new ChromiumWebBrowser("https://daemuri.net/order/updateOrderPop.do?order_no=" + order_no + "&c1_tel1=" + caller);

                chromeBrowser.LoadingStateChanged += OnLoadingStateChanged;
                Controls.Add(chromeBrowser);
                chromeBrowser.Dock = DockStyle.Fill;
            }
            else if (old_new.Equals("new"))
            {
                ///order/insertOrderPop.do
                //chromeBrowser = new ChromiumWebBrowser("http://127.0.0.1:8080/corp/insertOrderPop.do?c1_tel1=" +
                chromeBrowser = new ChromiumWebBrowser("https://daemuri.net/order/insertOrderPop.do?c1_tel1=" +
                caller + "&id=" + id + "&ch=" + ch + "&end=" + to + "&callcenter_idx=" + callcenter_idx + "&page=0");

                chromeBrowser.LoadingStateChanged += OnLoadingStateChanged;
                Controls.Add(chromeBrowser);
                chromeBrowser.Dock = DockStyle.Fill;

            }

            
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            
            /* if (formBegin != null)
             {
                 Thread.Sleep(1000);
                 Thread thread = new Thread(new ThreadStart(delegate () // thread 생성
                 {
                     this.Invoke(new Action(delegate () // this == Form 이다. Form이 아닌 컨트롤의 Invoke를 직접호출해도 무방하다.
                     {
                         this.formBegin.load2(0, callcenter_idx);
                     }));
                 }));
                 thread.Start();
             }*/

        }

        


        //DOM 전화걸기
        private void dial(string number)
        {
            number = number.Replace("-", "").Replace("-", "");
            formBegin.dial(number);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction1() {");
            sb.AppendLine("    return document.form.c1_tel1.value; ");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction1();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());

            await task.ContinueWith(t =>
             {
                 if (!t.IsFaulted)
                 {
                    // Step 04: Recieve value from JS
                     var response = t.Result;
                     if (response.Success == true)
                     {
                         string tel_no = response.Result.ToString();
                         if (tel_no==null || tel_no.Equals(""))
                         {
                             MessageBox.Show("전화번호를 넣어주세요");
                         }else
                         {
                             dial(tel_no);
                         }                        
                     }
                 }
             }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction4() {");
            sb.AppendLine("    return document.form.c1_tel2.value; ");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction4();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());
            await task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;

                    if (response.Success == true)
                    {
                        string tel_no = response.Result.ToString();
                        if (tel_no == null || tel_no.Equals(""))
                        {
                            MessageBox.Show("전화번호를 넣어주세요");
                        }
                        else
                        {
                            dial(tel_no);
                        }
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction2() {");
            sb.AppendLine("    return document.form.c2_tel1.value; ");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction2();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());

            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;

                    if (response.Success == true)
                    {
                        string tel_no = response.Result.ToString();
                        if (tel_no == null || tel_no.Equals(""))
                        {
                            MessageBox.Show("전화번호를 넣어주세요");
                        }
                        else
                        {
                            dial(tel_no);
                        }
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction5() {");
            sb.AppendLine("    return document.form.c2_tel2.value; ");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction5();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());

            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;
                    if (response.Success == true)
                    {
                        string tel_no = response.Result.ToString();
                        if (tel_no == null || tel_no.Equals(""))
                        {
                            MessageBox.Show("전화번호를 넣어주세요");
                        }
                        else
                        {
                            dial(tel_no);
                        }
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction3() {");
            sb.AppendLine("    return document.form.c3_tel1.value; ");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction3();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());

            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;

                    if (response.Success == true)
                    {
                        string tel_no = response.Result.ToString();
                        if (tel_no == null || tel_no.Equals(""))
                        {
                            MessageBox.Show("전화번호를 넣어주세요");
                        }
                        else
                        {
                            dial(tel_no);
                        }
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction6() {");
            sb.AppendLine("    return document.form.c3_tel2.value; ");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction6();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());
            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;
                    if (response.Success == true)
                    {
                        string tel_no = response.Result.ToString();
                        if (tel_no == null || tel_no.Equals(""))
                        {
                            MessageBox.Show("전화번호를 넣어주세요");
                        }
                        else
                        {
                            dial(tel_no);
                        }
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction7() {");
            sb.AppendLine("    return document.form.cid.value; ");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction7();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());
            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;
                    if (response.Success == true)
                    {
                        string tel_no = response.Result.ToString();
                        if (tel_no == null || tel_no.Equals(""))
                        {
                            MessageBox.Show("전화번호를 넣어주세요");
                        }
                        else
                        {
                            dial(tel_no);
                        }
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }



        //접수저장
        private void button8_Click_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction8() {");
            sb.AppendLine("  checkEmp('receipt'); ");
            sb.AppendLine(" return 'sss'+rs; }");
            sb.AppendLine("tempFunction8();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());
            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;
                    if (response.Success == true)
                    {
                        //MessageBox.Show(response.Result.ToString());
                        //Close();
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        //대기저장
        private void button9_Click_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction9() {");
            sb.AppendLine("  checkEmp('standBy'); ");
            sb.AppendLine(" return 'sss'+rs; }");
            sb.AppendLine("tempFunction9();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());
            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;
                    if (response.Success == true)
                    {
                        //MessageBox.Show(response.Result.ToString());
                        //Close();
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }




        //배차저장
        private void button10_Click_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction10() {");
            sb.AppendLine("  checkEmp('toEmp');  ");
            sb.AppendLine(" }");
            sb.AppendLine("tempFunction10();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());
            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;
                    if (response.Success == true)
                    {
                        //chromeBrowser.ExecuteScriptAsync("alert(document.form.save_complete.value);");
                        //MessageBox.Show(response.Result.ToString());
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void check_complete()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function ck() { ");
            sb.AppendLine("    return document.form.save_complete.value; ");
            sb.AppendLine("}");
            sb.AppendLine("ck();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());
            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;
                    //MessageBox.Show(response.Result.ToString());
                    if (response.Success == true)
                    {
                        if (response.Result.ToString() != null && response.Result.ToString().Equals("Y"))
                        {
                            Close();
                        }
                       
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }


        //문의저장
        private void button12_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction() {");
            sb.AppendLine("   checkEmp('request'); ");
            sb.AppendLine("  }");
            sb.AppendLine("tempFunction();");

            var task = chromeBrowser.EvaluateScriptAsync(sb.ToString());
            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;
                    if (response.Success == true)
                    {
                        //MessageBox.Show(response.Result.ToString());
                        //Close();
                    }
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void close(object sender, FormClosingEventArgs e)
        {
            //Controls.Clear();
            //Cef.ClearCrossOriginWhitelist();
            //Cef.ClearSchemeHandlerFactories();

            //Cef.ClearSchemeHandlerFactories();
            //bForm.Close();
            //bForm = new FormBegin(param1, param2);
            //bForm.Show();

            //Dispose(true);
            //GC.SuppressFinalize(this);            
        }
    }









    /////////////////////////////

}







