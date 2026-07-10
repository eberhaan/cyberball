using System;
using Cyberball.Common;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;

namespace cb5webservices.Controllers
{
    public class CBEController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            var path = HttpContext.Current.Server.MapPath("~/CBEs/cbe-" + id + "/config.cbe");

            if (!File.Exists(path))
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Config not found");


            var str = "";
            XmlSerializer serializer = new XmlSerializer(typeof(CBConfig));
            var stringWriter = new StringWriter();
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.Encoding = Encoding.UTF8;
            xws.WriteEndDocumentOnClose = true;
            using (var xmlTextWriter = XmlWriter.Create(stringWriter, xws))
            {
                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                xsn.Add("", "");
                serializer.Serialize(xmlTextWriter, ConfigIO.ReadConfig(path), xsn);
            }
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(stringWriter.ToString(), Encoding.UTF8, "text/plain");
            return resp;
        }

        public HttpResponseMessage Post([FromBody] CBConfig cbe)
        {
            var cbeToSave = cbe;
            try
            {
                //Get ID and update it to cbe
                if (cbeToSave.ID == Guid.Empty)
                    cbeToSave.ID = Guid.NewGuid();

                var dirPath = HttpContext.Current.Server.MapPath("~/CBEs/cbe-" + cbeToSave.ID);
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);

                SaveEmail(cbe.Email);

                ConfigIO.SaveConfig(cbeToSave, dirPath + "/config.cbe");
            }
            catch (Exception)
            {
                var err = new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError,
                    "Could not write config");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, cbeToSave.ID);
        }

        private static string fileMutex = "";

        private long GetCBEID()
        {
            long id = 0;
            var counterfilePath = HttpContext.Current.Server.MapPath("~/CBEs/cbe-counter.txt");

            lock (fileMutex)
            {
                if (!File.Exists(counterfilePath))
                {
                    File.WriteAllText(counterfilePath, "0");
                }
                var counterLines = File.ReadAllLines(counterfilePath);
                long lastID = Convert.ToInt64(counterLines[0]);
                id = lastID + 1;
                File.WriteAllText(counterfilePath, id.ToString());
            }

            return id;
        }

        private static string emailFileMutex = "";

        private void SaveEmail(string email)
        {
            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Emails")))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Emails"));

            var emailsFilePath = HttpContext.Current.Server.MapPath("~/Emails/cb5-emails.txt");

            lock (emailFileMutex)
            {
                File.AppendAllLines(emailsFilePath, new[] { email });
            }
        }
    }
}