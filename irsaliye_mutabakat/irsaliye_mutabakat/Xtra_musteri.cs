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
    public partial class Xtra_musteri : DevExpress.XtraEditors.XtraForm
    {
        public Xtra_musteri()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=irsaliye.accdb");
        DataTable tablo = new DataTable();


        private void Xtra_musteri_Load(object sender, EventArgs e)
        {
            cmb_nott.Properties.Items.Add("ÖDEMESİ ALINDI");
            cmb_nott.Properties.Items.Add("DEĞİŞİM OLACAK");
            grid_doldur();
            grid_isim();
            grid_boyut();
            sd();
            
        }

        public void grid_doldur()
        {

            bag.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from musteri", bag);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            bag.Close();


        }
        public void grid_isim()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "ADI - SOYADI";
            dataGridView1.Columns[2].HeaderText = "TELEFON NUMARASI";
            dataGridView1.Columns[3].HeaderText = "ÜRÜN - BARKOD";
            dataGridView1.Columns[4].HeaderText = "SATIŞ DANIŞMANI";
            dataGridView1.Columns[5].HeaderText = "ARAMA BİLGİSİ";
            dataGridView1.Columns[6].HeaderText = "İSTEK SONUÇ";
            dataGridView1.Columns[7].HeaderText = "NOT";



        } // data tablo isim
        public void grid_boyut()
        {
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[3].Width = 140;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 120;
            dataGridView1.Columns[7].Width = 140;

        } // data tablo sutun boyutları
        public void sd()
        {
            bag.Open();
            OleDbCommand kmt = new OleDbCommand("select * from sd", bag);
            OleDbDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                cmb_sd.Properties.Items.Add(oku[1]);
            }
            bag.Close();




        }

        private void btn_bilgi_Click(object sender, EventArgs e)
        {
            Xtra_bilgi bilgi = new Xtra_bilgi(dataGridView1);
            bilgi.Show();
        }

        private void btn_sonuc_Click(object sender, EventArgs e)
        {
            Xtra_sonuc sonuc = new Xtra_sonuc(dataGridView1);
            sonuc.Show();
        }


        public void kaydet()
        {
            if (txt_adi.Text=="")
            {
                 XtraMessageBox.Show("LÜTFEN MÜŞTERİ ADINI GİRİNİZ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_tel.Text=="")
            {
                XtraMessageBox.Show("LÜTFEN MÜŞTERİ TELEFON NUMARASINI GİRİNİZ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_barkod.Text=="")
            {
                XtraMessageBox.Show("LÜTFEN İSTENİLEN ÜRÜN-BARKOD GİRİNİZ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_sd.Text == "")
            {
                XtraMessageBox.Show("LÜTFEN SATIŞ DANIŞMANI GİRİNİZ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                bag.Open();

                string a, b;
                a = Convert.ToString("-");
                b = Convert.ToString("-");
                OleDbCommand kmt = new OleDbCommand("insert into musteri(adi_soyadi,telefon,barkod,satis_dan,bilgi,sonuc,nott) values ('" + txt_adi.Text + "','" + txt_tel.Text + "','" + txt_barkod.Text + "','" + cmb_sd.Text + "','" + a + "','" + b + "','"+cmb_nott.Text+"')", bag);


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
                    txt_adi.Text = "";
                    txt_tel.Text = "";
                    txt_barkod.Text = "";
                    cmb_sd.Text = "";


                }

                grid_doldur();
            }



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
                OleDbCommand cmd = new OleDbCommand("delete from musteri where id=" + a + " ", bag);
                cmd.ExecuteNonQuery();
                bag.Close();
                grid_doldur();


            }
        }

        private void txt_barkod_TextChanged(object sender, EventArgs e)
        {
            if (txt_barkod.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from musteri", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;



            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from musteri where barkod like '%" + txt_barkod.Text + "%' ", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;




            }
        }

        private void btn_bil_kaydet_Click(object sender, EventArgs e)
        {
        }


        private void btn_sonuc_kaydet_Click(object sender, EventArgs e)
        {
        }
           

        private void txt_tel_TextChanged(object sender, EventArgs e)
        {
            if (txt_tel.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from musteri", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;



            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from musteri where telefon like '%" + txt_tel.Text + "%' ", bag);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;




            }
        }

        private void cmb_sd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kaydet();
            } 
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Xtra_sd sd = new Xtra_sd();
            sd.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
           

      
                
            }

        }

           
      
    
