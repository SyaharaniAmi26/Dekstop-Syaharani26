using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apk_bel
{
    public partial class Fpetugas : Form
    {
        public Fpetugas()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void bersih()
        {
            textnama.Text = "";
            textemail.Text = "";
            textalamat.Text = "";
            textuser.Text = "";
            textpass.Text = "";
         
        }

        public void tampildata()
        {
            guna2DataGridView1.Rows.Clear();
            DB.crud($"select * from user");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string idp = "" + baris["idu"];
                string nma = "" + baris["nama"];
                string alt = "" + baris["alamat"];
                string usr = "" + baris["username"];
                string ps = "" + baris["password"];
                string cps = "" + baris["confrmpassword"];
                guna2DataGridView1.Rows.Add(idp, nma, cps, alt, usr, ps);
            }
        }


        private void textcari_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            DB.crud($"SELECT * FROM user where nama like '%{textcari.Text}%'");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string idp = "" + baris["idu"];
                string nma = "" + baris["nama"];
                string alt = "" + baris["alamat"];
                string usr = "" + baris["username"];
                string ps = "" + baris["password"];
                string cps = "" + baris["confrmpassword"];
                guna2DataGridView1.Rows.Add(idp, nma, cps, alt, usr, ps);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string nm = textnama.Text;
            string el = textemail.Text;
            string al = textalamat.Text;
            string user = textuser.Text;
            string pass = textpass.Text;
            DB.crud($"INSERT into login VALUES(null, '{nm}', '{el}','{al}', '{user}', '{pass}')");
            bersih();
            tampildata();
        }


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampildata();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
         
            DB.crud($"UPDATE login SET nama = '{textnama.Text}', email = '{textemail.Text}', alamat = '{textalamat.Text}', username = '{textuser.Text}', password = '{textpass.Text}' where id = '{label4.Text}' ");
            bersih();
            tampildata();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tampildata();
            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;
            string idnya = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();
            if (kolom == 7)
            {
                DB.crud($"SELECT * FROM user where idu = '{idnya}'");
                foreach (DataRow bariss in DB.ds.Tables[0].Rows)
                {
                    string idp = "" + bariss["idu"];
                    string nma = "" + bariss["nama"];
                    string alt = "" + bariss["alamat"];
                    string usr = "" + bariss["username"];
                    string ps = "" + bariss["password"];
                    string cps = "" + bariss["confrmpassword"];
                    label4.Text = idp;
                    textnama.Text = nma;
                    textalamat.Text = alt;
                    textemail.Text = cps;
                    textuser.Text = usr;
                    textpass.Text = ps;
                    
                }
            }
            if (kolom == 8)
            {
                DialogResult setuju = MessageBox.Show("Apa Anda yakin?", "Pemeberitahuan", MessageBoxButtons.YesNo);
                if (setuju == DialogResult.Yes)
                {
                    DB.crud($"delete from user where idu = '{idnya}'");
                    tampildata();
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbagama_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textalamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void textpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Fpetugas_Load(object sender, EventArgs e)
        {

        }
    }
}
