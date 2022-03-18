using System;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace JuraganAR
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
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

                    var url = "https://juraganar.com/api/login_desktop.php?email="+email+"&password="+password;

                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();

                        var res = JObject.Parse(result);

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

                }
                catch (Exception ef)
                {
                    Console.WriteLine(ef.StackTrace);
                    var status = ef.Message;
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
