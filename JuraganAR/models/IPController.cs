using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace JuraganAR.models
{
    class IPController
    {
        static readonly HttpClient client = new HttpClient();
        string GlobalIP = null;

        public async Task<String> getCurrentIP()
        {
            try
            {
                var url = "http://ip.jsontest.com/";

                // set Default Header
                client.DefaultRequestHeaders.Clear();
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

                GlobalIP = res["ip"].ToString();

                response.Dispose();

            }
            catch (Exception ex)
            {
                GlobalIP = null;
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }

            return GlobalIP;
        }
    }
}
