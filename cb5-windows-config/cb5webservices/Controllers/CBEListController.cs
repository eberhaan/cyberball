using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Cyberball.Common;

namespace cb5webservices.Controllers
{
    public class CBEListController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var dirs = Directory.EnumerateDirectories(HttpContext.Current.Server.MapPath("~/CBEs/"), "cbe-*");
            StringBuilder sb = new StringBuilder();
            foreach (string dir in dirs)
            {
                sb.Append(Path.GetFileName(dir))
                    .Append("#")
                    .Append(ConfigIO.ReadConfig(dir + "/config.cbe").Conditions.Count)
                    .Append("##");
            }
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(sb.ToString(), Encoding.UTF8, "text/plain")
            };
            return resp;
        }
    }
}