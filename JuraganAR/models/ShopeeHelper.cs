using System;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using RestSharp;
using System.Net.Http;

namespace JuraganAR.models
{
    class ShopeeHelper
    {
        LogController log = new LogController();
        static readonly HttpClient client = new HttpClient();

        public string generateUserAgents(int len = 10)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)];
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return UppercaseFirst(Name);
        }

        public string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public string generateVersion()
        {
            Random random = new Random();
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int first = numbers[random.Next(numbers.Length)];
            int second = numbers[random.Next(numbers.Length)];
            int third = numbers[random.Next(numbers.Length)];
            string version = $"{first}.{second}.{third}";
            return version;
        }

        public void shopeeInits(string shopid,string itemid)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            int version = new Random().Next(7, 999999999);
            string userAgent = null;
            string userAgents = generateUserAgents(15) + "/" + generateVersion();
            try
            {
                var client = new RestClient("https://shopee.co.id/api/v4/item/");
                client.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                client.UserAgent = userAgents;
                var request = new RestRequest("get", Method.GET);
                request.AddHeader("User-Agent", userAgents);
                request.AddHeader("Accept-Encoding", "gzip, deflate, br");
                request.AddHeader("Cache-Control", "public,max-age=0");
                request.AddQueryParameter("itemid", itemid);
                request.AddQueryParameter("shopid", shopid);
                request.AddQueryParameter("version", version.ToString());
                var result = client.Execute(request);
                userAgent = client.UserAgent;
                if (result.IsSuccessful)
                {
                    var res = JObject.Parse(result.Content);
                    shopeeDetail(res);
                }
                else
                {
                    log.log_message($"{result.ErrorMessage} at {shopid} , {itemid} with User Agent {userAgent}", result.ErrorException.StackTrace);
                }

            }
            catch(Exception ex)
            {
                log.log_message($"{ex.Message} at {shopid} , {itemid}  with User Agent {userAgent}", ex.StackTrace);
                Console.WriteLine(ex.Message + " at " + shopid + " " + itemid + "\n" + ex.StackTrace);
            }
        }

        public async void shopeeInitsss(string shopid, string itemid, string proxy = null, string fullLink = null)
        {
            int version = new Random().Next(7, 999999999);
            string userAgents = generateUserAgents(15) + "/" + generateVersion();
            try
            {
                var url = "https://shopee.co.id/api/v4/item/get?itemid=" + itemid + "&shopid=" + shopid + "&version=" + version;

                // set Default Header
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("user-agent", userAgents);
                client.DefaultRequestHeaders.Add("authority", "shopee.co.id");
                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("accept-language", "en-GB,en;q=0.9");
                client.DefaultRequestHeaders.Add("sec-fetch-dest", "document");
                client.DefaultRequestHeaders.Add("sec-fetch-mode", "navigate");
                client.DefaultRequestHeaders.Add("sec-fetch-site", "none");
                client.DefaultRequestHeaders.Add("sec-fetch-user", "?1");
                client.DefaultRequestHeaders.Add("sec-gpc", "1");
                client.DefaultRequestHeaders.Add("upgrade-insecure-requests", "1");

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var res = JObject.Parse(responseBody);

                shopeeDetail(res);

                response.Dispose();
                
            }
            catch (Exception ex)
            {
                log.log_message($"{ex.Message} at {shopid} , {itemid}  with User Agent {userAgents}", ex.StackTrace);
                log.log_advance(fullLink);
                Console.WriteLine(ex.Message + " at " + shopid + " " + itemid + "\n" + ex.StackTrace);
            }

        }

        public void shopeeInit(string shopid,string itemid,string proxy = null,string fullLink = null)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            int version = new Random().Next(7, 999999999);
            string userAgent = null;
            string userAgents = generateUserAgents(15) + "/" + generateVersion();
            try
            {

                var url = "https://shopee.co.id/api/v4/item/get?itemid=" + itemid + "&shopid=" + shopid + "&version=" + version;

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "GET";
                httpRequest.Credentials = null;
                httpRequest.UseDefaultCredentials = true;
                httpRequest.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                httpRequest.UserAgent = userAgents;
                httpRequest.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                httpRequest.Referer = "shopee.co.id";
                httpRequest.Accept = "*/*";
                httpRequest.AllowWriteStreamBuffering = false;
                
                userAgent = httpRequest.UserAgent;
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    var res = JObject.Parse(result);

                    shopeeDetail(res);
                }
                httpResponse.Close();
            }
            catch (Exception ex)
            {
                log.log_message($"{ex.Message} at {shopid} , {itemid}  with User Agent {userAgent}", ex.StackTrace);
                log.log_advance(fullLink);
                Console.WriteLine(ex.Message + " at " + shopid + " " + itemid + "\n"+ex.StackTrace);
            }
        }

        public void shopeeDetail(JObject result)
        {
            string shopid = result["data"]["shopid"].ToString();
            string itemid = result["data"]["itemid"].ToString();
            string price = result["data"]["price_max"].ToString();
            string harga = price.Substring(0, price.Length - 5);
            string stok = result["data"]["stock"].ToString();
            string nama = result["data"]["name"].ToString().Replace("'", String.Empty);
            string catid = result["data"]["catid"].ToString();
            string deskripsi = result["data"]["description"].ToString().Replace("'", String.Empty);
            string imageArray = result["data"]["images"].ToString();
            string video = result["data"]["video_info_list"].ToString();
            string links = "https://shopee.co.id/" + nama.Replace(" ","-") + "-i." + shopid + "." + itemid;

            string kosong = "0";
            string satu = "1";
            string kondisi = (result["data"]["condition"].ToString().Equals("1") ? "Baru" : "Bekas");
            string status = (result["data"]["status"].ToString().Equals("1") ? "Aktif" : "Nonaktif");
            string asuransi = "optional";
            string sku = "SKU-" + new Random().Next(10000000, 99999999) + "ID";

            var sql = new SQLController();
            sql.insert_database("tb_detail", $"(NULL,'{satu}','{links}','{nama}','{deskripsi}','{catid}','{kosong}','{satu}','{kosong}','{satu}','{kondisi}','{imageArray}',NULL,'{sku}','{status}','{stok}','{harga}','{asuransi}')");

        }

    }
}
