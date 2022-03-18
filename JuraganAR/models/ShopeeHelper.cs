using System;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace JuraganAR.models
{
    class ShopeeHelper
    {
        public void shopeeInit(string shopid,string itemid)
        {
            int version = new Random().Next(7, 999999999);
            try
            {

                var url = "https://shopee.co.id/api/v4/item/get?itemid=" + itemid + "&shopid=" + shopid + "&version=" + version;

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    var res = JObject.Parse(result);

                    shopeeDetail(res);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
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
            string sku = "SKU-" + new Random().Next(11111111, 99999999) + "ID";

            var sql = new SQLController();
            sql.insert_database("tb_detail", $"(NULL,'{satu}','{links}','{nama}','{deskripsi}','{catid}','{kosong}','{satu}','{kosong}','{satu}','{kondisi}','{imageArray}',NULL,'{sku}','{status}','{stok}','{harga}','{asuransi}')");

        }

    }
}
