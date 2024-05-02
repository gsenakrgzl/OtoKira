using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static Mysqlx.Expect.Open.Types;

namespace OtoKira
{
    public partial class Form1 : Form
    {

       MySqlConnection conn = new MySqlConnection("server = localhost; uid = root; database = otokira");
        MySqlCommand cmd;
        MySqlDataAdapter da;

      private  void listele()
        {
            da = new MySqlDataAdapter("select * from arabalar", conn);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            tbPlaka.Text = "";
            tbMarka.Text = "";
            tbModel.Text = "";
            cbUretim.Text = "";
            tbKm.Text = "";
            cbRenk.Text = "";
            cbDurum.Text = "";
            cbYakit.Text = "";
            tbKiraUcret.Text = "";
            pictureBox1.Image = null;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("Select * from arabalar", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("insert into arabalar (plaka, marka, model, uretim, km, renk, yakit, kiraucreti, durum, resim) values ('"+ tbPlaka.Text+"', '"+tbMarka.Text+"', '"+tbModel.Text +"', '"+cbUretim.Text +"', '"+tbKm.Text +"', '"+cbRenk.Text+"', '"+cbYakit.Text +"', '"+ tbKiraUcret.Text + "', '"+cbDurum.Text +"', '"+ pictureBox1.ImageLocation+"')", conn );
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            listele();
        }

        private void btnResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog of1 = new OpenFileDialog();
            of1.Filter = "Resim Dosyaları |* .jpeg; * .jpg; * .png | Tüm Dosyalar |*.*";
            of1.ShowDialog();
            pictureBox1.ImageLocation = of1.FileName;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("Update arabalar set plaka='" + tbPlaka.Text + "', marka='" + tbMarka.Text + "', model='" + tbModel.Text + "', uretim='" + cbUretim.Text + "', km='" + tbKm.Text + "', renk='" + cbRenk.Text + "', yakit='" + cbYakit.Text + "', kiraUcreti='" + tbKiraUcret.Text + "', durum='" + cbDurum.Text + "', resim='" + pictureBox1.ImageLocation + "' where plaka = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ", conn);
            conn.Open(); 
            cmd.ExecuteNonQuery();
            conn.Close(); 
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("Delete From arabalar where plaka = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            listele();
        }

        private void tbAra_TextChanged(object sender, EventArgs e)
        {
            da = new MySqlDataAdapter("select * from arabalar where plaka like " + "'%" + tbAra.Text + "%' ", conn);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("Delete From arabalar", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbPlaka.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbMarka.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbModel.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbUretim.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbKm.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbRenk.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbYakit.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cbDurum.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            tbKiraUcret.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }
    }
}
