using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuraganAR
{
    public partial class DataPage : Form
    {
        models.SQLController sql = new models.SQLController();
        public DataPage()
        {
            InitializeComponent();
            string hala = sql.get_count("tb_detail","*");
            string msg = "Terdapat {0} Data yang Tersimpan";
            txtDetail.Text = String.Format(msg,hala);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var questions = MessageBox.Show("Are you sure to Clear All Data?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (questions.ToString() == "Yes")
            {
                sql.truncate_database();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
