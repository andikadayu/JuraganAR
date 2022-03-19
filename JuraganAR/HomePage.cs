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

namespace JuraganAR
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            LoginData login = new LoginData();
            if (!login.has_Login() && !login.is_active())
            {
                goLogout();
            }
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
                goLogout();
            }
        }

        private void goLogout()
        {
            var log = new LoginData();
            log.Logout();
            this.Hide();
            var loginPage = new Login();
            loginPage.FormClosed += (s, args) => this.Close();
            loginPage.Show();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string link = txtLink.Text.Trim();
            if(link != "")
            {
                progScrap.Visible = true;

                string[] allLinks = link.Split(',');
                int counts = allLinks.Length;
                int curr = 0;
                int progress = 0;

                foreach (var lins in allLinks)
                {
                    if(lins != "")
                    {
                        string links = lins.Replace(@"""", String.Empty).Replace("?", ".").Replace("-i.", "~");

                        string[] param = links.Split('~');
                        string[] para = param[1].Split('.');
                        string shopid = para[0];
                        string itemid = para[1];

                        var shopee = new ShopeeHelper();

                        shopee.shopeeInit(shopid, itemid);
                    }

                    curr++;
                    progress = curr / counts * 100;

                    progScrap.Value = progress;

                }
                MessageBox.Show("Scrapping Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLink.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Invalid Form", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            progExport.Visible = true;
            var sql = new SQLController();
            int total = int.Parse(sql.get_count("tb_detail", "*"));
            int f = 0;
            int progress = 0;

            var filename = txtFileName.Text.Trim();

            if(filename != "" && total > 0)
            {
                progExport.Visible = true;
                while (f < total)
                {
                    if(f % 299 == 0)
                    {
                        try
                        {
                            var excel = new ExcelController();
                            var result = sql.read_database("tb_detail", "*", "", "", "", "299", f.ToString());
                            excel.create_excel("299", f.ToString(), filename,result);
                            sql.close_connection();

                        }catch(Exception ex)
                        {
                            Console.WriteLine(ex.StackTrace);
                            MessageBox.Show(ex.Message);
                        }

                    }
                        if(f == total - 1)
                        {
                            MessageBox.Show("Export Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        f++;
                    
                    progress = f / total * 100;

                    progExport.Value = progress;
                }
            }
            else
            {
                MessageBox.Show("Invalid Form", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        
    }
}
