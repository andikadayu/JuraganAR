using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace JuraganAR.models
{
    class SQLController
    {
        SQLiteConnection conn;
        static string lokasi = Path.GetFullPath("models/scrapping.db");

        private static SQLiteConnection open_connection()
        {
            SQLiteConnection connect;
            connect = new SQLiteConnection($"Data Source={lokasi};Version=3;");
            try
            {
                connect.Open();
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return connect;
        }

        public void close_connection()
        {
            conn.Close();
        }

        public SQLiteDataReader read_database(string table,string select="*",string where="",string groupby="",string orderby="",string limit="",string offset = "") 
        {
            conn = open_connection();
            SQLiteDataReader data_reader;
            SQLiteCommand cmd;

            string sql = "SELECT " + select + " FROM " + table + " ";

            if (where != "")
            {
                sql += "WHERE "+where + " ";
            }
            if (groupby != "")
            {
                sql += "GROUP BY " + groupby + " ";
            }
            if (orderby != "")
            {
                sql += "ORDER BY " + orderby + " ";
            }
            if (limit != "")
            {
                sql += "LIMIT " + limit + " ";
            }
            if (offset != "")
            {
                sql += "OFFSET " + offset + " ";
            }


            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            data_reader = cmd.ExecuteReader();
            
            return data_reader;

        }

        public void insert_database(string table,string values)
        {
            conn = open_connection();

            SQLiteCommand cmd;

            string sql = "INSERT INTO " + table + " VALUES" + values;

            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            close_connection();

        }

        public string get_count(string table,string wcount,string where = "")
        {
            conn = open_connection();
            SQLiteDataReader data_reader;
            SQLiteCommand cmd;

            string sql = "SELECT COUNT(" + wcount + ") FROM " + table + " ";

            if (where != "")
            {
                sql += "WHERE " + where + " ";
            }

            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            data_reader = cmd.ExecuteReader();
            string result = null;

            while (data_reader.Read())
            {
                result =  data_reader.GetInt64(0).ToString();
            }

            close_connection();
            return result;

        }

        public void truncate_database()
        {
            conn = open_connection();

            SQLiteCommand cmd;
            
            cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM tb_detail";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM sqlite_sequence WHERE name = 'tb_detail'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "VACUUM";
            cmd.ExecuteNonQuery();
            close_connection();
        }

    }
}
