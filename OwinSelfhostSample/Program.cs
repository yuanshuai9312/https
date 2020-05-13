using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Owin.Hosting;

namespace OwinSelfhostSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = string.Format("http://{0}:{1}/",
                System.Configuration.ConfigurationManager.AppSettings.Get("Domain"),
                System.Configuration.ConfigurationManager.AppSettings.Get("Port"));

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("host 已启动：{0}", DateTime.Now);
                Console.WriteLine("访问：{0}/page/index.html", baseAddress);
                Console.ReadLine();
            }
        }

    }
}
