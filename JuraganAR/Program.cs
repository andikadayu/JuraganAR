﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuraganAR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginData logindata = new LoginData();
            if (!logindata.has_Login())
            {
                Application.Run(new Login()); // require login first
            }
            else
            {
                Application.Run(new Login()); // if has login
            }
        }
    }
}
