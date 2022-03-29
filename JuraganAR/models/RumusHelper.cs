using System;

namespace JuraganAR.models
{
    class RumusHelper
    {
        public int nilaiRumus(string metode,int harga)
        {
            var sql = new SQLController();

            var ambil = sql.read_database("tb_" + metode.ToLower(), "nilai", "start_range < " + harga + " AND end_range >= " + harga);
            string result = null;
            while (ambil.Read())
            {
                result = ambil.GetValue(0).ToString();
            }

            int profit = 0;

            if (result.EndsWith("%"))
            {
                int persen = int.Parse(result.Replace("%", String.Empty));
                profit = harga * persen / 100;
            }
            else
            {
                profit = int.Parse(result);
            }
            sql.close_connection();

            return profit;

        }

        public int nilaiMarkup(string nilai,int harga)
        {
            int profit = 0;
            if (nilai.EndsWith("%"))
            {
                int persen = int.Parse(nilai.Replace("%", String.Empty));
                profit = harga * persen / 100;
            }
            else
            {
                profit = int.Parse(nilai);
            }

            return profit;
        }

        public int getHarga(string harga)
        {
            int ori_price = int.Parse(harga);
            int n_markup = 0;
            int n_rumus = 0;
            if (allsettings.Default.with_markup)
            {
                n_markup = nilaiMarkup(allsettings.Default.markup_value, ori_price);
            }
            if (allsettings.Default.with_rumus)
            {
                n_rumus = nilaiRumus(allsettings.Default.rumus_value, ori_price);
            }

            return ori_price + n_markup + n_rumus;

        }
    }
}
