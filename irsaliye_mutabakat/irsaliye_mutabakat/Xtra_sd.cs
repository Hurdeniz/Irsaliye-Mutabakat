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
    public partial class Xtra_sd : DevExpress.XtraEditors.XtraForm
    {
        public Xtra_sd()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=irsaliye.accdb");

        private void Xtra_sd_Load(object sender, EventArgs e)
        {
            grid_doldur();
            grid_isim();
            grid_boyut();
        }
        public void grid_doldur()
        {

            bag.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from sd", bag);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            bag.Close();


        }
        public void grid_isim()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "ADI - SOYADI";
        }
        public void grid_boyut()
        {
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].Width = 155;
        }
        public void kaydet()
        {
            if (textEdit1.Text=="")
            {
                XtraMessageBox.Show("LÜTFEN SATIŞ DANIŞMANI ADI - SOYADI GİRİNİZ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
            else
            {

                bag.Open();

                string a, b;
                a = Convert.ToString("-");
                b = Convert.ToString("-");
                OleDbCommand kmt = new OleDbCommand("insert into sd(adi_soyadi) values ('" + textEdit1.Text + "')", bag);


                OleDbTransaction trans;
                trans = bag.BeginTransaction();
                kmt.Transaction = trans;


                try
                {
                    kmt.ExecuteNonQuery();
                    trans.Commit();
                    XtraMessageBox.Show("Kayıt İşleminiz Yapılmıştır ", "BAŞARILI", MessageBoxButtons.OK);

                }
                catch
                {

                    trans.Rollback();
                    XtraMessageBox.Show("Kayıt İşleminiz Yapılmamıştır Lütfen Alanları Kontrol Ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    bag.Close();
                    textEdit1.Text = "";

                }

                grid_doldur();
            }



        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            kaydet();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult cevap;
            cevap = MessageBox.Show("Kayıdı Silmek İstediğinizden Emin Misiniz ? ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {

                bag.Open();
                OleDbCommand cmd = new OleDbCommand("delete from sd where id=" + a + " ", bag);
                cmd.ExecuteNonQuery();
                bag.Close();
                grid_doldur();


            }
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kaydet();
            } 
        }
    }
}