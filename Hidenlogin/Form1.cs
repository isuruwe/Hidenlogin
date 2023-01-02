using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        String url = "http://www.gstatic.com/generate_204";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WebBrowser WebForm = new WebBrowser();
            webBrowser1.Navigate(new Uri(url));
          

        }
      

        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //foreach (HtmlElement HtmlElement1 in webBrowser1.Document.Body.All)
            //{
            //    if (HtmlElement1.GetAttribute("value") == "Continue")
            //    {
            //        HtmlElement1.InvokeMember("click");
            //        break;
            //    }
            //}
        }
        public bool chkint()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 5000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task MyMethodAsync()
        {
            Task<int> longRunningTask = LongRunningOperationAsync();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here

            //and now we call await on the task 
            int result = await longRunningTask;
            //use the result 
            
        }

        public async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
        {
            try
            {

                //while (webBrowser1.ReadyState == WebBrowserReadyState.Loading || webBrowser1.ReadyState == WebBrowserReadyState.Uninitialized)
                //{





                //}

                webBrowser1.Document.GetElementById("ft_un").InnerText = "3913";
                webBrowser1.Document.GetElementById("ft_pd").InnerText = "Rma@3913";

                HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement el in elc)
                {
                    if (el.GetAttribute("type").Equals("submit"))
                    {
                        el.InvokeMember("Click");
                    }
                }
            }
            catch (Exception ex)
            {

            }
           
            try
            {
                if (chkint() == false)
                {
                    webBrowser1.Navigate(new Uri(url));
                    //while (webBrowser1.ReadyState == WebBrowserReadyState.Loading || webBrowser1.ReadyState == WebBrowserReadyState.Uninitialized)
                    //{





                    //}
                }
                else
                {
                    webBrowser1.Refresh();
                }


            }
            catch (Exception ex)
            {

            }
            await Task.Delay(3000); // 1 second delay
            return 1;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            MyMethodAsync();
        }
    }
}
