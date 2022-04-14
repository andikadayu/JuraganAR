using JuraganAR.models;
using System;
using System.Windows.Forms;

namespace JuraganAR
{
    public partial class SettingPage : Form
    {
        public SettingPage()
        {
            InitializeComponent();
            txtAwalProduk.Text = allsettings.Default.add_first_name;
            txtAkhirProduk.Text = allsettings.Default.add_last_name;
            txtAwalDeskripsi.Text = allsettings.Default.add_first_description;
            txtAkhirDeskripsi.Text = allsettings.Default.add_last_description;
            txtHapusKata.Text = allsettings.Default.remove_text;
            txtPreorder.Text = allsettings.Default.preorder;
            txtEtalase.Text = allsettings.Default.etalase;
            txtKategori.Text = allsettings.Default.kategori;
            txtMarkup.Text = allsettings.Default.markup_value;
            txtBerat.Text = allsettings.Default.weight;
            txtMinPesan.Text = allsettings.Default.min_pesan;
            txtMinStok.Text = allsettings.Default.min_stok;
            txtMinHarga.Text = allsettings.Default.min_harga;

            cbMarkup.Checked = allsettings.Default.with_markup;
            cbRumus.Checked = allsettings.Default.with_rumus;
            if(allsettings.Default.rumus_value.ToString() != "")
            {
                comboRumus.SelectedItem = allsettings.Default.rumus_value;
            }
            else
            {
                comboRumus.SelectedItem = "Murah";
            }
            
            txtDelayScrap.Text = allsettings.Default.delay_scrap;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var questions = MessageBox.Show("Are you sure to save this setting?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (questions.ToString() == "Yes")
            {
                SaveSetting();
            }
        }

        private void SaveSetting()
        {
            allsettings.Default.add_first_name = txtAwalProduk.Text;
            allsettings.Default.add_last_name = txtAkhirProduk.Text;
            allsettings.Default.add_first_description = txtAwalDeskripsi.Text;
            allsettings.Default.add_last_description = txtAkhirDeskripsi.Text;
            allsettings.Default.remove_text = txtHapusKata.Text;
            allsettings.Default.preorder = txtPreorder.Text;
            allsettings.Default.etalase = txtEtalase.Text;
            allsettings.Default.kategori = txtKategori.Text;
            allsettings.Default.markup_value = txtMarkup.Text;
            allsettings.Default.weight = txtBerat.Text;
            allsettings.Default.min_pesan = txtMinPesan.Text;
            allsettings.Default.min_stok = txtMinStok.Text;
            allsettings.Default.min_harga = txtMinHarga.Text;

            allsettings.Default.with_markup = cbMarkup.Checked;
            allsettings.Default.with_rumus = cbRumus.Checked;
           
            allsettings.Default.rumus_value = comboRumus.SelectedItem.ToString();
            allsettings.Default.delay_scrap = txtDelayScrap.Text;
            

            allsettings.Default.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
