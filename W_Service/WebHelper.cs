using System.IO;
using System.Net;
using System.Text;
using DataModel;
using Newtonsoft.Json;

namespace W_Service
{
    internal static class WebHelper
    {
        public static void Put(SysInfoDM objEmployee, string url)
        {
            var result = "";
            var json = JsonConvert.SerializeObject(objEmployee);
            var cookies = new CookieContainer();
            ServicePointManager.Expect100Continue = false;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            request.CookieContainer = cookies;
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            using (var responseStream = request.GetResponse().GetResponseStream())
            using (var reader = new System.IO.StreamReader(responseStream, Encoding.GetEncoding("UTF-8")))
            {
                result = reader.ReadToEnd();
            }
        }
    }
}
