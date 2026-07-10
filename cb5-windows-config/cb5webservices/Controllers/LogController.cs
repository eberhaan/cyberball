using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace cb5webservices.Controllers
{
    public class LogController : ApiController
    {
        private static string logMutex = "";

        public HttpResponseMessage Post(string id)
        {
            lock (logMutex)
            {
                var httpContext = (HttpContextWrapper) Request.Properties["MS_HttpContext"];
                var logData = httpContext.Request.Form["log"];
                if (!string.IsNullOrEmpty(logData))
                {
                    File.AppendAllLines(HttpContext.Current.Server.MapPath("~/CBEs/log-cbe-" + id + ".csv"),
                        logData.Split(new string[] {"#nextline#"}, StringSplitOptions.None));
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                return new HttpResponseMessage();
            }
        }

        public HttpResponseMessage Get(string id)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath("~/CBEs/log-cbe-" + id + ".csv")))
            {
                var fileContents = File.ReadAllText(HttpContext.Current.Server.MapPath("~/CBEs/log-cbe-" + id + ".csv"));
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                resp.Content = new StringContent(fileContents, Encoding.UTF8, "text/plain");
                return resp;
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            }
        }
    }
}