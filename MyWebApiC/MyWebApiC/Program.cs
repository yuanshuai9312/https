using System;
using System.Web.Http.SelfHost;
using System.Web.Http;
using System.Reflection;
using System.Collections.Generic;
using WebApi;

namespace MyWebApiC
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ApiController> list = new List<ApiController>();
            list.Add(new HomeController());//这个list集合看似没有用，但是能加载控制台项目以外的项目，去掉之后将不能访问到控制台项目外的其他Api接口。
            Assembly.Load("WebApi,Version=1.0.0.0, PublicKeyToken=null");//加载WebApi到控制台中
            var config = new HttpSelfHostConfiguration("http://localhost:5000"); //配置主机
            config.Routes.MapHttpRoute(    //配置路由
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            using (HttpSelfHostServer server = new HttpSelfHostServer(config)) //监听HTTP
            {
                server.OpenAsync().Wait(); //开启来自客户端的请求
                Console.WriteLine("WebAPi已启动，按按任意键退出！");
                Console.ReadLine();
                server.CloseAsync();
            }
        }

    }
    }

