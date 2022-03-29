using System;
using System.Text;
using System.Data.SQLite;
using System.IO;
using SpreadsheetLight;

namespace JuraganAR.models
{
    class ExcelController
    {
        static string lokasi_wb = Path.GetFullPath("models/templetes.xlsx");
        static string lokasi_exp = Path.GetFullPath("exports");

        private static string removetext(string s)
        {
            StringBuilder sb = new StringBuilder(s);

            string[] removes = allsettings.Default.remove_text.ToString().Trim().Split(',');
            foreach(var rms in removes)
            {
                if(rms != "" || rms != String.Empty)
                {
                    sb.Replace(rms, String.Empty);
                }
            }

            return sb.ToString();
        }

        public void create_excel(string limit,string offset,string nama_file,SQLiteDataReader result)
        {

            SQLController sql = new SQLController();

            int currents = 5;

            using (SLDocument sheet = new SLDocument(lokasi_wb))
            {
                while (result.Read())
                {
                    string[] image = result.GetValue(11).ToString().Replace(@"""", String.Empty).Replace("[", String.Empty).Replace("]", String.Empty).Replace(" ", String.Empty).Replace("\n", String.Empty).Replace("\r", String.Empty).Trim().Split(',');

                    sheet.SetCellValue($"A{currents}",String.Empty);
                    sheet.SetCellValue($"B{currents}", removetext(allsettings.Default.add_first_name + result.GetValue(3).ToString() + allsettings.Default.add_last_name));
                    sheet.SetCellValue($"C{currents}", removetext(allsettings.Default.add_first_description + result.GetValue(4).ToString() + allsettings.Default.add_last_description));
                    sheet.SetCellValue($"D{currents}", allsettings.Default.kategori);
                    sheet.SetCellValue($"E{currents}", allsettings.Default.weight);
                    sheet.SetCellValue($"F{currents}", allsettings.Default.min_pesan);
                    sheet.SetCellValue($"G{currents}", allsettings.Default.etalase);
                    sheet.SetCellValue($"H{currents}", allsettings.Default.preorder);
                    sheet.SetCellValue($"I{currents}", result.GetValue(10).ToString());
                    sheet.SetCellValue($"J{currents}", (image.Length >= 1) ? "https://f.shopee.co.id/file/" + image[0] : String.Empty);
                    sheet.SetCellValue($"K{currents}", (image.Length >= 2) ? "https://f.shopee.co.id/file/" + image[1] : String.Empty);
                    sheet.SetCellValue($"L{currents}", (image.Length >= 3) ? "https://f.shopee.co.id/file/" + image[2] : String.Empty);
                    sheet.SetCellValue($"M{currents}", (image.Length >= 4) ? "https://f.shopee.co.id/file/" + image[3] : String.Empty);
                    sheet.SetCellValue($"N{currents}", (image.Length >= 5) ? "https://f.shopee.co.id/file/" + image[4] : String.Empty);
                    sheet.SetCellValue($"O{currents}", String.Empty);
                    sheet.SetCellValue($"P{currents}", String.Empty);
                    sheet.SetCellValue($"Q{currents}", String.Empty);
                    sheet.SetCellValue($"R{currents}", result.GetValue(13).ToString());
                    sheet.SetCellValue($"S{currents}", result.GetValue(14).ToString());
                    sheet.SetCellValue($"T{currents}", result.GetValue(15).ToString());
                    sheet.SetCellValue($"U{currents}", new RumusHelper().getHarga(result.GetValue(16).ToString()).ToString());
                    sheet.SetCellValue($"V{currents}", result.GetValue(17).ToString());
                    
                    currents++;
                }

                sheet.SaveAs($"{lokasi_exp}/{nama_file}_{offset}.xlsx");
            }

        }
    }
}
