using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuraganAR.models;
using Newtonsoft.Json.Linq;
using System.IO;

namespace JuraganAR
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            var dataPage = new DataPage();
            dataPage.Show();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            var settingPage = new SettingPage();
            settingPage.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            var aboutPage = new AboutPage();
            aboutPage.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var questions = MessageBox.Show("Are you sure to Logout?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(questions.ToString() == "Yes")
            {
                var log = new LoginData();
                log.Logout();
                this.Hide();
                var loginPage = new Login();
                loginPage.FormClosed += (s, args) => this.Close();
                loginPage.Show();
                
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var link = txtLink.Text.Trim();
            progScrap.Visible = true;

            for(int i = 1; i <= 100; i++)
            {
                progScrap.Value = i;
            }

            var shopee = new ShopeeHelper();
            try
            {
                string shop = shopee.shopeeDetail(JObject.Parse(File.ReadAllText("models/shopee_response.json")));

                txtLink.Text = shop;

            }catch(Exception ef)
            {
                Console.WriteLine(ef.StackTrace);
            }
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            progExport.Visible = true;
            for (int i = 1; i <= 100; i++)
            {
                progExport.Value = i;
            }

            var filename = txtFileName.Text.Trim();

        }

        
    }
}
