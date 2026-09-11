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
    public partial class Ftrans : Form
    {
        public Ftrans()
        {
            InitializeComponent();
        }
        public string idloginakas;
        private void cmbpb_DropDown(object sender, EventArgs e)
        {
            cmbpb.Items.Clear();
            DB.crud($"select * from tbarang");
            foreach (DataRow baris in DB.ds.Tables[0].Rows)
            {
                string idb = "" + baris["idb"];
                cmbpb.Items.Add(idb);
            }
        }

        private void cmbpb_DropDownClosed(object sender, EventArgs e)
        {
            string idnya = cmbpb.SelectedItem.ToString();

            DB.crud($"SELECT * FROM tbarang where idb = '{idnya}'");
            foreach (DataRow bariss in DB.ds.Tables[0].Rows)
            {
                string nm = "" + bariss["nama"];
                string haj = "" + bariss["harga_jual"];
                txtnb.Text = nm;
                txthg.Text = haj;

            }
        }

        private void txtnb_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtjmlh_TextChanged(object sender, EventArgs e)
        {
            if (txtjmlh.Text != "")
            {
                int harga = Convert.ToInt32(txthg.Text);
                int jumlah = Convert.ToInt32(txtjmlh.Text);
                int hasil = harga * jumlah;
                txtsub.Text = "" + hasil;
            }
            else
            {
                txtsub.Text = "";
            }

        }

        private void btnoke_Click(object sender, EventArgs e)
        {
            string idb = "" + cmbpb.Text;
            string nama = "" + txtnb.Text;
            string haj = "" + txthg.Text;
            string jmlh = "" + txtjmlh.Text;
            string qty = "" + txtsub.Text;
            guna2DataGridView1.Rows.Add(idb, nama, haj, jmlh, qty);
            cmbpb.Text = "";
            txtnb.Text = "";
            txthg.Text = "";
            txtjmlh.Text = "";
            txtsub.Text = "";

            int totalnya = 0;

            for (int i = 0; i < guna2DataGridView1.RowCount; i++)
            {
                int angka = Convert.ToInt32(guna2DataGridView1.Rows[i].Cells[4].Value.ToString());
                totalnya = totalnya + angka ;
                textBox1.Text = "" + angka;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int bayar = Convert.ToInt32(textBox2.Text);
                int total = Convert.ToInt32(textBox1.Text);
                int kembalian = bayar - total;
                textBox3.Text = "" + kembalian;
            }
            else
            {
                textBox3.Text = "";
            }
        }
        public void bersih()
        {
            
        }

        private void textsimpan_Click(object sender, EventArgs e)
        {
            DB.crud($"INSERT INTO ttransaksi VALUES(null,CURDATE(),'{idloginakas}','{textBox1.Text}')");

            for (int i = 0; i < guna2DataGridView1.RowCount; i++)
            {
                string idb = "" + guna2DataGridView1.Rows[i].Cells[0].Value;
                string hr = "" + guna2DataGridView1.Rows[i].Cells[2].Value;
                string qty = "" + guna2DataGridView1.Rows[i].Cells[3].Value;
                string subt = "" + guna2DataGridView1.Rows[i].Cells[4].Value;
                DB.crud($"INSERT INTO tdetaailtrans VALUES (null,(SELECT idt FROM ttransaksi ORDER BY idt DESC LIMIT 1), '{idb}','{hr}','{qty}','{subt}')");
                DB.crud($"UPDATE tbarang SET stok = stok - '{qty}' WHERE idb = '{idb}';");
            }
            guna2DataGridView1.Rows.Clear();
            textBox1.Text ="";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

