using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using excel = Microsoft.Office.Interop.Excel;

namespace irsaliye_mutabakat
{
    public partial class Xtra_gonderilen : DevExpress.XtraEditors.XtraForm
    {
        public Xtra_gonderilen()
        {
            InitializeComponent();
        }
       
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=irsaliye.accdb");

        DataTable tablo = new DataTable();
        int i = 0;
        int a, b;

        private void Xtra_gonderilen_Load(object sender, EventArgs e)
        {

           date_tarih.Text = DateTime.Now.ToShortDateString();
          
            
            
            grid_doldur();
            grid_isim();
            grid_boyut();
            
            magazalar();

            txt_ay.Text = lbl_ay.Text;
        }

        public void grid_doldur()
        {

            bag.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from gonderilen", bag);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            
            

            i = ds.Tables[0].Rows.Count - 1; // tablodaki en son veri
            lbl_baslangic_no.Text = ds.Tables[0].Rows[i]["irsaliye_no"].ToString();

            a = Convert.ToInt32(lbl_baslangic_no.Text);
            b = a + 1;
            txt_irs_no.Text = Convert.ToString(b);

            bag.Close();

            
            

            
           
        
        } 
        public void grid_isim()
        {
            dataGridView1.Columns[0].HeaderText = "İRSALİYE NUMARASI";
            dataGridView1.Columns[1].HeaderText = "TARİH";
            dataGridView1.Columns[2].HeaderText = "GÖNDERİLEN DEPO & MAĞAZA";
            dataGridView1.Columns[3].HeaderText = "AÇIKLAMA";
            dataGridView1.Columns[4].HeaderText = "GÖNDERİLEN ADET";



        } // data tablo isim
        public void grid_boyut()
        {
            dataGridView1.Columns[0].Width = 135;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 135;

        } // data tablo sutun boyutları


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
        } 



        public void kaydet()
        {
            if (txt_irs_no.Text=="")
            {
                XtraMessageBox.Show("LÜTFEN İRSALİYE NUMARASINI GİRİNİZ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else if (cmb_magaza.Text=="")
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
                OleDbCommand kmt = new OleDbCommand("insert into gonderilen(irsaliye_no,tarih,magaza,aciklama,gonderilen_adet) values ('" + txt_irs_no.Text + "','" + date_tarih.Text + "','" + cmb_magaza.Text + "','" + txt_irs_aciklama.Text + "','" + txt_irs_gon_adet.Text + "')", bag);


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
                    cmb_magaza.Text = "";
                    txt_irs_gon_adet.Text = "";


                }

                grid_doldur();


            }                  
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            kaydet();
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

        private void textEdit1_TextChanged(object sender, EventArgs e)
        { 
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xtra_magazalar magaza = new Xtra_magazalar();
            magaza.Show();
        }


       

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textEdit4_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void btn_ara_Click_1(object sender, EventArgs e)
        {
            panelControl3.Visible = true;
        }

        private void lbl_magaza_kodu_Click(object sender, EventArgs e)
        {

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            string a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult cevap;
            cevap = MessageBox.Show("Kayıdı Silmek İstediğinizden Emin Misiniz ? ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {

                bag.Open();
                OleDbCommand cmd = new OleDbCommand("delete from gonderilen where irsaliye_no=" + a + " ", bag);
                cmd.ExecuteNonQuery();
                bag.Close();
                grid_doldur();
                

            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            
            }

        private void txt_irs_ara_TextChanged(object sender, EventArgs e)
        {
            if (txt_irs_ara.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gonderilen", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;



            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gonderilen where irsaliye_no like '%" + txt_irs_ara.Text + "%' ", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                



            }
        }

        private void date_ara_TextChanged(object sender, EventArgs e)
        {
            if (date_ara.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gonderilen", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;



            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gonderilen where tarih like '%" + date_ara.Text + "%' ", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;




            }
        }

        private void txt_gon_ara_TextChanged(object sender, EventArgs e)
        {
            if (txt_gon_ara.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gonderilen", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;



            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from gonderilen where magaza like '%" + txt_gon_ara.Text + "%' ", bag);
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

        private void btn_cikis_Click(object sender, EventArgs e)
        {
           
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xtra_gelen gelen = new Xtra_gelen();
            gelen.Owner = this;
            gelen.Show();
            this.Hide();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xtra_aylik ay = new Xtra_aylik();
            ay.Owner = this;
            ay.Show();
            this.Hide();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void txt_ay_TextChanged(object sender, EventArgs e)
        {
            
        }
        }


   
}