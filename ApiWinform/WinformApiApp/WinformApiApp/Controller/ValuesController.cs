using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Windows.Forms;

namespace WinformApiApp.Controller
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("st")]
        public string GetServerTime()
        {
            StringBuilder sb = new StringBuilder();
            string s = "China: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.zzz");
            sb.Append(s).AppendLine();
            sb.Append("IP: " + GetClientIp()).AppendLine();
            sb.Append("UserAgent: " + Request.Headers.UserAgent.ToString()).AppendLine();
            if (Request.Headers.CacheControl != null)
            {
                sb.Append("CacheControl: " + Request.Headers.CacheControl.ToString()).AppendLine();
            }
            sb.Append("Accept: " + Request.Headers.Accept.ToString()).AppendLine();
            sb.Append("AcceptCharset: " + Request.Headers.AcceptCharset.ToString()).AppendLine();
            sb.Append("AcceptEncoding: " + Request.Headers.AcceptEncoding.ToString()).AppendLine();
            sb.Append("AcceptLanguage: " + Request.Headers.AcceptLanguage.ToString()).AppendLine();
            sb.Append("Host: " + Request.Headers.Host.ToString()).AppendLine();
            Program.f.Log(sb.ToString());
            return sb.ToString();
        }
        protected HttpRequestBase GetRequest()
        {
            HttpContextBase context = (HttpContextBase)Request.Properties["MS_RequestContext"];//获取传统context
            HttpRequestBase request = context.Request;//定义传统request对象
            return request;
        }
        private string GetClientIp(HttpRequestMessage request = null)
        {
            request = request ?? Request;

            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return string.Format("Address:{0}, Port: {1}", prop.Address, prop.Port.ToString());
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return null;
            }
        }
    }
}
