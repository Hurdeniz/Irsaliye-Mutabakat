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
    public partial class Xtra_gelen : DevExpress.XtraEditors.XtraForm
    {
        public Xtra_gelen()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=irsaliye.accdb");
        DataTable tablo = new DataTable();

        private void txt_irs_gon_adet_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Xtra_gelen_Load(object sender, EventArgs e)
        {
            date_tarih.Text = DateTime.Now.ToShortDateString();
           
            grid_doldur();
            grid_isim();
            grid_boyut();
            magazalar();
            
        }
        public void grid_doldur()
        {

            bag.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from gelen", bag);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];  
            bag.Close();

        }
        public void grid_isim()
        {
            dataGridView1.Columns[0].HeaderText = "İRSALİYE NUMARASI";
            dataGridView1.Columns[1].HeaderText = "TARİH";
            dataGridView1.Columns[2].HeaderText = "GELEN DEPO & MAĞAZA";
            dataGridView1.Columns[3].HeaderText = "AÇIKLAMA";
            dataGridView1.Columns[4].HeaderText = "GELEN ADET";



        } 
        public void grid_boyut()
        {
            dataGridView1.Columns[0].Width = 135;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 135;

        }
        public void magazalar()
        {
            bag.Open();
            OleDbCommand kmt = new OleDbCommand("select * from magazalar", bag);
            OleDbDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                cmb_magaza.Properties.Items.Add(oku[1]);
            }
            bag.Close();




        }
        public void kaydet()
        {

            if (txt_irs_no.Text == "")
            {
                XtraMessageBox.Show("LÜTFEN İRSALİYE NUMARASINI GİRİNİZ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (cmb_magaza.Text == "")
            {
                XtraMessageBox.Show("LÜTFEN GÖNDERECEĞİNİZ MAĞAZAYI SEÇİNİZ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_irs_gon_adet.Text == "")
            {
                XtraMessageBox.Show("LÜTFEN GÖNDERECEĞİNİZ ADET SAYISINI GİRİNİZ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bag.Open();
                OleDbCommand kmt = new OleDbCommand("insert into gelen(irsaliye_no,tarih,magaza,aciklama,gelen_adet) values ('" + txt_irs_no.Text + "','" + date_tarih.Text + "','" + cmb_magaza.Text + "','" + txt_irs_aciklama.Text + "','" + txt_irs_gon_adet.Text + "')", bag);


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
                    txt_irs_no.Text = "";
                    cmb_magaza.Text = "";
                    txt_irs_gon_adet.Text = "";


                }

                grid_doldur();
            }
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
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
                OleDbCommand cmd = new OleDbCommand("delete from gelen where irsaliye_no=" + a + " ", bag);
                cmd.ExecuteNonQuery();
                bag.Close();
                grid_doldur();
            }
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            panelControl4.Visible = true;
        }

        private void txt_irs_ara_TextChanged(object sender, EventArgs e)
        {
            if (txt_irs_ara.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gelen", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;



            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gelen where irsaliye_no like '%" + txt_irs_ara.Text + "%' ", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;




            }
        }

        private void date_ara_TextChanged(object sender, EventArgs e)
        {
            if (date_ara.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gelen", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;



            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gelen where tarih like '%" + date_ara.Text + "%' ", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;




            }
        }

        private void txt_gon_ara_TextChanged(object sender, EventArgs e)
        {
            if (txt_gon_ara.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gelen", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;



            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gelen where magaza like '%" + txt_gon_ara.Text + "%' ", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;




            }
        }

        private void txt_irs_gon_adet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kaydet();
            } 
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xtra_gonderilen gon = new Xtra_gonderilen();
            gon.Owner = this;
            gon.Show();
            this.Hide();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xtra_aylik aylik = new Xtra_aylik();
            aylik.Owner = this;
            aylik.Show();
            this.Hide();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xtra_magazalar magaza = new Xtra_magazalar();
            magaza.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void txt_ay_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}