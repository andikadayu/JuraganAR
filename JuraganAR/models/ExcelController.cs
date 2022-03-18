using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using System.Data.SQLite;

namespace JuraganAR.models
{
    class ExcelController
    {
        private static string removetext(string s)
        {
            StringBuilder sb = new StringBuilder(s);

            string[] removes = allsettings.Default.remove_text.ToString().Trim().Split(',');
            foreach(var rms in removes)
            {
                sb.Replace(rms, String.Empty);
            }

            return sb.ToString();
        }

        public void create_excel(string limit,string offset,string nama_file,SQLiteDataReader result)
        {
            WorkBook excel = WorkBook.Load("models/templetes.xlsx");
            WorkSheet sheet = excel.WorkSheets.First();

            SQLController sql = new SQLController();

            int currents = 5;

            while (result.Read())
            {
                string[] image = result.GetValue(11).ToString().Replace(@"""",String.Empty).Replace("[",String.Empty).Replace("]",String.Empty).Replace(" ",String.Empty).Replace("\n", String.Empty).Replace("\r",String.Empty).Trim().Split(',');

                sheet[$"A{currents}"].Value = String.Empty;
                sheet[$"B{currents}"].Value = removetext(allsettings.Default.add_first_name + result.GetValue(3).ToString() + allsettings.Default.add_last_name);
                sheet[$"C{currents}"].Value = removetext(allsettings.Default.add_first_description + result.GetValue(4).ToString() + allsettings.Default.add_last_description);
                sheet[$"D{currents}"].Value = allsettings.Default.kategori;
                sheet[$"E{currents}"].Value = allsettings.Default.weight;
                sheet[$"F{currents}"].Value = allsettings.Default.min_pesan;
                sheet[$"G{currents}"].Value = allsettings.Default.etalase;
                sheet[$"H{currents}"].Value = allsettings.Default.preorder;
                sheet[$"I{currents}"].Value = result.GetValue(10).ToString();
                sheet[$"J{currents}"].Value = (image.Length >= 1) ? "https://f.shopee.co.id/file/"+image[0] : String.Empty;
                sheet[$"K{currents}"].Value = (image.Length >= 2) ? "https://f.shopee.co.id/file/" + image[1] : String.Empty;
                sheet[$"L{currents}"].Value = (image.Length >= 3) ? "https://f.shopee.co.id/file/" + image[2] : String.Empty;
                sheet[$"M{currents}"].Value = (image.Length >= 4) ? "https://f.shopee.co.id/file/" + image[3] : String.Empty;
                sheet[$"N{currents}"].Value = (image.Length >= 5) ? "https://f.shopee.co.id/file/" + image[4] : String.Empty;
                sheet[$"O{currents}"].Value = String.Empty;
                sheet[$"P{currents}"].Value = String.Empty;
                sheet[$"Q{currents}"].Value = String.Empty;
                sheet[$"R{currents}"].Value = result.GetValue(13).ToString();
                sheet[$"S{currents}"].Value = result.GetValue(14).ToString();
                sheet[$"T{currents}"].Value = result.GetValue(15).ToString();
                sheet[$"U{currents}"].Value = new RumusHelper().getHarga(result.GetValue(16).ToString()).ToString();
                sheet[$"V{currents}"].Value = result.GetValue(17).ToString();

                currents++;
            }



            excel.SaveAs($"exports/{nama_file}_{offset}.xlsx");

        }
    }
}
