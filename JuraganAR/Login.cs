using System;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using RestSharp;

namespace JuraganAR
{
    public partial class Login : Form
    {
        models.LogController log = new models.LogController();
        public Login()
        {
            InitializeComponent();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if(new LoginData().has_Login())
            {
                var homePage = new HomePage();
                homePage.FormClosed += (s, args) => this.Close();
                homePage.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (email != "" && password != "")
            {
                
                try
                {
                    var client = new RestClient("https://juraganar.com/api/");
                    var request = new RestRequest("login_desktop.php", Method.GET);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddQueryParameter("email", email);
                    request.AddQueryParameter("password", password);
                    var result = client.Execute(request);
                    
                        var res = JObject.Parse(result.Content);

                        var status = res.GetValue("status").ToString();
                        var ids = res.GetValue("ids").ToString();
                        var emails = res.GetValue("email").ToString();
                        var names = res.GetValue("name").ToString();

                        if(status == "OK")
                        {
                            MessageBox.Show("Login Success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoginData loginData = new LoginData();
                            loginData.setLogin(ids,names, emails);
                            this.Hide();
                            var homePage = new HomePage();
                            homePage.FormClosed += (s, args) => this.Close();
                            homePage.Show();

                        }
                        else
                        {
                            MessageBox.Show("Invalid Email or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    

                }
                catch (Exception ef)
                {
                    Console.WriteLine(ef.StackTrace);
                    var status = ef.Message;
                    log.log_message(ef.Message, ef.StackTrace);
                    MessageBox.Show(status, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Email and Password are required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }   
    }
}
