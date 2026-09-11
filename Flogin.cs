using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using System.Windows.Forms;

namespace apk_bel
{
    public partial class Flogin : Form
    {
        public Flogin()
        {
            InitializeComponent();
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            if (textpass.Text != textpass.Text)
            {
                MessageBox.Show("Password dan Confirm Password tidak sama!");
                return;
            }

            DB.crud($"SELECT * FROM admin WHERE username='{textuser.Text}' AND password='{textpass.Text}'");

            int cekjumlahbaris = DB.ds.Tables[0].Rows.Count;
            Console.WriteLine(cekjumlahbaris);

            if (cekjumlahbaris == 1)
            {
                DataRow baris = DB.ds.Tables[0].Rows[0];

                string idami = "" + baris["ida"];

                Fdasboard syaharani = new Fdasboard();
                syaharani.idsyaharani = idami;
                syaharani.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password salah!");
            }
        }
    }
}
