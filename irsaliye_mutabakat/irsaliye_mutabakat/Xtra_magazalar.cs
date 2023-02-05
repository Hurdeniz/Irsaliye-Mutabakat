using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;

namespace irsaliye_mutabakat
{
    public partial class Xtra_magazalar : DevExpress.XtraEditors.XtraForm
    {
        public Xtra_magazalar()
        {
            InitializeComponent();
        }
        OleDbConnection bag1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=irsaliye.accdb");

        private void Xtra_magazalar_Load(object sender, EventArgs e)
        {
            grid_doldur();

        }
        public void grid_doldur()
        {

            string sqltext = "select * from magazalar ";
            OleDbDataAdapter da = new OleDbDataAdapter(sqltext, bag1);
            DataSet ds = new DataSet();
            bag1.Open();

            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            bag1.Close();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "MAĞAZA ADI";

            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].Width = 150;
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            kaydet();
        }
        public void kaydet()
        {

            OleDbCommand komut = new OleDbCommand();
            bag1.Open();
            komut.Connection = bag1;
            string sql = "Insert into magazalar(magaza_adi)  values('" +txt_magaza_adi.Text+ "')";
            komut.CommandText = sql;
            komut.ExecuteNonQuery();
            XtraMessageBox.Show("Kayıt İşleminiz Yapılmıştır ", "BAŞARILI", MessageBoxButtons.OK);
            bag1.Close();
            grid_doldur();
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult cevap;
            cevap = MessageBox.Show("Kayıdı Silmek İstediğinizden Emin Misiniz ? ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {

                bag1.Open();
                OleDbCommand cmd = new OleDbCommand("delete from magazalar where id=" + a + " ", bag1);
                cmd.ExecuteNonQuery();
                bag1.Close();
                grid_doldur();


            }
        }

        private void txt_magaza_adi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kaydet();
            } 
        }
    }
}