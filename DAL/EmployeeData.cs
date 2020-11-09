using System;
using System.IO;
using System.Net;

namespace DAL
{
    public class EmployeeData
    {
        private readonly string urlApi = "http://masglobaltestapi.azurewebsites.net";//System.Configuration.ConfigurationSettings.AppSettings["UrlApi"].ToString();

        public string ListEmployee()
        {
            string retorno = string.Empty;

            var url = string.Concat(urlApi, "/api/Employees");
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return null;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        return retorno = objReader.ReadToEnd();
                    }
                }
            }

        }
    }
}
