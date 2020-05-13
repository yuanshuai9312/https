using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Windows.Forms;

namespace WinformApiApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HttpSelfHostConfiguration config = null;
        HttpSelfHostServer server = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            config = new HttpSelfHostConfiguration("http://localhost:8084");

            config.Routes.MapHttpRoute("API Default", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            server = new HttpSelfHostServer(config);

            server.OpenAsync().Wait();

        }
        delegate void SetTextCallback(string text);
        public void Log(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                while (!this.textBox1.IsHandleCreated)
                {
                    if (this.textBox1.Disposing || this.textBox1.IsDisposed)
                        return;
                }
                SetTextCallback d = new SetTextCallback(Log);
                this.textBox1.Invoke(d, new object[] { text });
            }
            else
            {
                textBox1.AppendText(text);
                textBox1.AppendText(Environment.NewLine);
                textBox1.ScrollToCaret();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
