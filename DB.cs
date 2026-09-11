using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace apk_bel
{
    class DB
    {
        public static MySqlConnection koneksi = new MySqlConnection("Server = 127.0.0.1; username = 'root'; password =; database = 'db_bell'");
        public static DataSet ds = new DataSet();
        public static MySqlDataAdapter da;
        public static MySqlCommand perintah;

        public static void crud(String sqlnya)
        {
            Console.WriteLine(sqlnya);
            ds.Tables.Clear();
            perintah = new MySqlCommand(sqlnya, koneksi);
            da = new MySqlDataAdapter(perintah);
            da.Fill(ds);
        }
        public static void amiimup(Form Fpetugas, Panel PNLcontent)
        {
            PNLcontent.Controls.Clear();
            PNLcontent.Controls.Add(Fpetugas);
            Fpetugas.FormBorderStyle = FormBorderStyle.None;
            Fpetugas.Dock = DockStyle.Fill;
            Fpetugas.Show();
        }

        public static void untukform(Form frm, Panel pnl)
        {
            pnl.Controls.Clear();

            frm.TopLevel = false;
            frm.TopMost = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnl.Controls.Add(frm);
            frm.Show();
        }
    }
}