using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using JuraganAR.models;
namespace JuraganAR
{
    class LoginData
    {
       
        public void setLogin(string idss,string names, string emails)
        {
            sharedsession.Default.name = names;
            sharedsession.Default.email = emails;
            sharedsession.Default.id = idss;
            sharedsession.Default.is_login = true;
            sharedsession.Default.Save();
        }

        public void Logout()
        {
            sharedsession.Default.name = string.Empty;
            sharedsession.Default.email = string.Empty;
            sharedsession.Default.id = string.Empty;
            sharedsession.Default.is_login = false;
            sharedsession.Default.Save();
        }

        public string getName()
        {
            return sharedsession.Default.name;
        }

        public string getEmail()
        {
            return sharedsession.Default.email;
        }

        public bool has_Login()
        {
            return sharedsession.Default.is_login;
        }

        public string getId()
        {
            return sharedsession.Default.id;
        }

        public bool is_active()
        {
            bool condition = false;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {

                var url = "https://juraganar.com/api/cek_aktif.php?id="+getId();

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.UseDefaultCredentials = true;
                httpRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    var res = JObject.Parse(result);

                    var status = res.GetValue("status").ToString();

                    if (status == "OK")
                    {
                        condition = true;
                    }
                    else
                    {
                        condition = false;
                    }
                }
            }
            catch (Exception ex)
            {
                condition = false;
                Console.WriteLine(ex.StackTrace);
            }
            return condition;
        }

    }
}
