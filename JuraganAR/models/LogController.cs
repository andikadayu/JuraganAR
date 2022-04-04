using System;
using System.IO;

namespace JuraganAR.models
{
    class LogController
    {

        public void log_message(string message,string stacktrace)
        {
            string dateNOW = DateTime.Now.ToString("dd-MM-yyyy");
            string dateFull = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            string log_location = Path.GetFullPath($"log/log-{dateNOW}.txt");
        
            using (StreamWriter w = File.AppendText(log_location))
            {
                Log(dateFull,message, stacktrace, w);
                w.Close();
            }

        }


        private void Log(string dateFull,string message,string stacktrace,TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine(dateFull);
            w.WriteLine($"Message : {message}");
            w.WriteLine($"StackTrace : {stacktrace}");
            w.WriteLine("---------------------------------------------------------------------------");
        }

    }
}
