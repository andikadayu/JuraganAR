using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
namespace JuraganAR
{
    class LoginData
    {
        static string name;
        static string email;
        static string ids;
        static bool isLogin = false;

        public void setLogin(string idss,string names, string emails)
        {
            name = names;
            email = emails;
            isLogin = true;
            ids = idss;
        }

        public void Logout()
        {
            name = null;
            email = null;
            isLogin = false;
        }

        public string getName()
        {
            return name;
        }

        public string getEmail()
        {
            return email;
        }

        public bool has_Login()
        {
            return isLogin;
        }

        public bool is_active()
        {
            bool condition = false;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {

                var url = "https://juraganar.com/api/cek_aktif.php?id="+ids;

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
