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
    public partial class Fdasboard : Form
    {
        public Fdasboard()
        {
            InitializeComponent();
        }

        public string idsyaharani;
        private void guna2Button4_Click(object sender, EventArgs e)
        {

            DialogResult ami = MessageBox.Show("Kamu mau keluar?", "Pemberitahuan", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (ami == DialogResult.Yes)
            {
                Flogin a = new Flogin();
                a.Visible = true;
                this.Hide();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Fpetugas Hal1 = new Fpetugas() { TopLevel = false, TopMost = true };
            DB.untukform(Hal1, panel2);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Fmenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Fjdwlhri ami = new Fjdwlhri() { TopLevel = false, TopMost = true };
            DB.untukform(ami, panel2);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(idsyaharani);
        }

        private void Fmenu_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Fhari ami = new Fhari() { TopLevel = false, TopMost = true };
            DB.untukform(ami, panel2);
        }
    }
}
