using System;
using System.ComponentModel;
using System.Windows.Forms;
using JuraganAR.models;
using System.Threading;

namespace JuraganAR
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            LoginData login = new LoginData();
            InitializeComponent();
            if (!login.has_Login() || !login.is_active())
            {
                goLogout();
            }
        }

        struct DataParameter
        {
            public string link;
        }
        struct ExportParameter
        {
            public string filename;
            public int total;
        }

        private DataParameter _inputparameter;
        private ExportParameter _exportparameter;
        ShopeeHelper shopee = new ShopeeHelper();
        private int delay = 100;

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
                _inputparameter.link = link;
                progScrap.Visible = true;
                WorkerScrap.RunWorkerAsync(_inputparameter);
            }
            else
            {
                MessageBox.Show("Invalid Form", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var sql = new SQLController();
            int total = int.Parse(sql.get_count("tb_detail", "*"));

            var filename = txtFileName.Text.Trim();

            if(filename != "" && total > 0)
            {
                progExport.Visible = true;
                _exportparameter.filename = filename;
                _exportparameter.total = total;
                WorkerExport.RunWorkerAsync(_exportparameter);

                
            }
            else
            {
                MessageBox.Show("Invalid Form", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void WorkerScrap_DoWork(object sender, DoWorkEventArgs e)
        {
           
                string link = ((DataParameter)e.Argument).link;
                string[] allLinks = link.Split(',');
                int counts = allLinks.Length;
                int curr = 1;

            foreach (string lins in allLinks) {
                    curr++;
                    WorkerScrap.ReportProgress(curr * 100 / counts, string.Format("Proccess Data {0}", curr));
                    Thread.Sleep(delay);
                    if (lins != "")
                    {
                        try
                        {
                            string links = lins.Replace(@"""", String.Empty).Replace(" ",String.Empty).Replace("?", ".").Replace("~","-").Replace("-i.", "~");

                            string[] param = links.Split('~');
                            string[] para = param[1].Split('.');
                            string shopid = para[0];
                            string itemid = para[1];
                            
                            shopee.shopeeInit(shopid, itemid);

                        }
                        catch (Exception exs)
                        {
                            Console.Write(exs.Message + "\n" + exs.StackTrace);
                        }
                    }
                    

                }       
        }

        private void WorkerScrap_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progScrap.Value = e.ProgressPercentage;
            progScrap.Update();
        }

        private void WorkerScrap_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Scrapping Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtLink.Text = String.Empty;
            progScrap.Value = 0;
            progScrap.Update();
            progScrap.Visible = false;
        }

        private void WorkerExport_DoWork(object sender, DoWorkEventArgs e)
        {
            int f = 0;
            int total = ((ExportParameter)e.Argument).total;
            string filename = ((ExportParameter)e.Argument).filename;
            int progress = 0;
            int index = 1;
            
            try
            {
                while (f < total)
                {
                    progress = index++ * 100 / total;
                    WorkerExport.ReportProgress(progress);
                    Thread.Sleep(delay);
                   
                    if (f % 300 == 0) // limiter loop
                    {
                        try
                        {
                            var sql = new SQLController();
                            var excel = new ExcelController();
                            var result = sql.read_database("tb_detail", "*", "", "", "", "300", f.ToString()); // limiter for read database
                            excel.create_excel("300", f.ToString(), filename, result); // limiter for create excel
                            sql.close_connection();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.StackTrace);
                            MessageBox.Show(ex.Message);
                        }

                    }
                    

                    f++;
                   
                    
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

        private void WorkerExport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progExport.Value = e.ProgressPercentage;
            progExport.Update();
        }

        private void WorkerExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Export Done", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progExport.Value = 0;
            progExport.Update();
            progExport.Visible = false;
        }
    }
}
