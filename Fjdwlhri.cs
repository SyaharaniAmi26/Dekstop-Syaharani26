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
    public partial class Fjdwlhri : Form
    {
        public Fjdwlhri()
        {
            InitializeComponent();
        }

        private void fbarang_Load(object sender, EventArgs e)
        {

        }
        

        public void bersih()
        {
            textnama.Text = "";
            texthaw.Text = "";
            texthaj.Text = "";
            textstk.Text = "";
        }

        public void tampildata()
        {
            guna2DataGridView1.Rows.Clear();
            DB.crud($"select * from jadwal_bell");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string id = "" + baris["idj"];
                string hri = "" + baris["hari"];
                string wb = "" + baris["waktu_bell"];
                guna2DataGridView1.Rows.Add(id, hri, wb);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampildata();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string nm = textnama.Text;
            string haw = texthaw.Text;
            string haj = texthaj.Text;
            string stk = textstk.Text;
            DB.crud($"INSERT into tbarang VALUES(null, '{nm}', '{haw}', '{haj}', '{stk}')");
            bersih();
            tampildata();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            DB.crud($"UPDATE tbarang SET nama = '{textnama.Text}', harga_awal = '{texthaw.Text}', harga_jual = '{texthaj.Text}', stok = '{textstk.Text}' where idb = '{label5.Text}' ");
            bersih();
            tampildata();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;
            string idnya = guna2DataGridView1.Rows[baris].Cells[0].Value.ToString();
            if (kolom == 5)
            {
                DB.crud($"SELECT * FROM tbarang where idb = '{idnya}'");
                foreach (DataRow bariss in DB.ds.Tables[0].Rows)
                {
                    string id = "" + bariss["idb"];
                    string nm = "" + bariss["nama"];
                    string haw = "" + bariss["harga_awal"];
                    string haj = "" + bariss["harga_jual"];
                    string stk = "" + bariss["stok"];
                    label5.Text = id;
                    textnama.Text = nm;
                    texthaw.Text = haw;
                    texthaj.Text = haj;
                    textstk.Text = stk;
                }
            }
            if (kolom == 6)
            {
                DialogResult setuju = MessageBox.Show("Apa Anda yakin?", "Pemeberitahuan", MessageBoxButtons.YesNo);
                if (setuju == DialogResult.Yes)
                {
                    DB.crud($"delete from tbarang where idb = '{idnya}'");
                    tampildata();
                }
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            DB.crud($"SELECT * FROM tbarang where nama like '%{guna2TextBox4.Text}%'");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string id = "" + baris["idb"];
                string nm = "" + baris["Nama"];
                string haw = "" + baris["harga_awal"];
                string haj = "" + baris["harga_jual"];
                string stk = "" + baris["stok"];
                guna2DataGridView1.Rows.Add(id, nm, haw, haj,stk);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
