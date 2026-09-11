using MySql.Data.MySqlClient;
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
    public partial class Fhari : Form
    {

        MySqlConnection conn;
        MySqlDataAdapter adapter;
        DataTable dt;

        int idHari = 0;

        string connectionString =
            "server=localhost;database=db_bell=root;pwd=;";
        private object cmd;

        public Fhari()
        {
            InitializeComponent();

            TampilData();


        }

        //menampilkan data
        private void TampilData()
        {
            try
            {


                string query = "SELECT id, nama_hari FROM hari ORDER BY id ASC";

                adapter = new MySqlDataAdapter(query, conn);

                dt = new DataTable();
                adapter.Fill(dt);

                dgvHari.DataSource = dt;

                dgvHari.Columns["id"].HeaderText = "ID";
                dgvHari.Columns["nama_hari"].HeaderText = "Nama Hari";

                dgvHari.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan data: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (txtNamaHari.Text.Trim() == "")
            {
                MessageBox.Show("Nama hari harus diisi!");
                txtNamaHari.Focus();
                return;
            }

            try
            {
                conn.Open();
                string query = "INSERT INTO hari (nama_hari) VALUES (@nama)";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@nama", txtNamaHari.Text.Trim());

                    command.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Data hari berhasil disimpan!",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Bersihkan();
                TampilData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menyimpan data: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }


        // MEMBERSIHKAN FORM
        private void Bersihkan()
        {
            txtNamaHari.Clear();

            idHari = 0;

            btnSimpan.Enabled = true;
            btnUbah.Enabled = false;
            btnHapus.Enabled = false;

            txtNamaHari.Focus();
        }
        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (idHari == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus!");
                return;
            }

            DialogResult hasil = MessageBox.Show(
                "Apakah yakin ingin menghapus data ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (hasil == DialogResult.Yes)
            {
                try
                {

                    conn.Open();

                    string query = "DELETE FROM hari WHERE id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@id", idHari);

                        command.ExecuteNonQuery();
                    }

                    conn.Close();

                    MessageBox.Show("Data berhasil dihapus!");

                    Bersihkan();
                    TampilData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal menghapus data: " + ex.Message);
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (idHari == 0)
            {
                MessageBox.Show("Pilih data yang ingin diubah!");
                return;
            }

            if (txtNamaHari.Text.Trim() == "")
            {
                MessageBox.Show("Nama hari harus diisi!");
                return;
            }

            try
            {
                conn.Open();

                string query =
                    "UPDATE hari SET nama_hari = @nama WHERE id = @id";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue(
                        "@nama",
                        txtNamaHari.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@id",
                        idHari);

                    command.ExecuteNonQuery();
                }

                conn.Close();


                MessageBox.Show("Data berhasil diubah!");

                Bersihkan();
                TampilData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengubah data: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        private void dgvHari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvHari.Rows[e.RowIndex];

                    idHari = Convert.ToInt32(row.Cells["id"].Value);
                    txtNamaHari.Text = row.Cells["nama_hari"].Value.ToString();

                    btnSimpan.Enabled = false;
                    btnUbah.Enabled = true;
                    btnHapus.Enabled = true;
                }
            }
    }
}


