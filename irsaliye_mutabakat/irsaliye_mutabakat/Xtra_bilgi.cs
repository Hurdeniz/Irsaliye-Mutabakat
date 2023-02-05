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
    public partial class Xtra_bilgi : DevExpress.XtraEditors.XtraForm
    {
        public Xtra_bilgi(DataGridView dataax)
        {
            InitializeComponent();
            dt = dataax;
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=irsaliye.accdb");
        DataGridView dt = new DataGridView();
        private void Xtra_bilgi_Load(object sender, EventArgs e)
        {
            textEdit1.Text = dt.CurrentRow.Cells[0].Value.ToString();

        }

        private void chc_arandi_CheckedChanged(object sender, EventArgs e)
        {
            if (chc_arandi.Checked)
            {
                chc_cevap.Enabled = false;
                chc_ulaş.Enabled = false;
            }
            else
            {
                chc_cevap.Enabled = true;
                chc_ulaş.Enabled = true;
            }
        }

        private void chc_cevap_CheckedChanged(object sender, EventArgs e)
        {
            if (chc_cevap.Checked)
            {
                chc_arandi.Enabled = false;
                chc_ulaş.Enabled = false;
            }
            else
            {
                chc_arandi.Enabled = true;
                chc_ulaş.Enabled = true;

            }
        }

        private void chc_ulaş_CheckedChanged(object sender, EventArgs e)
        {
            if (chc_ulaş.Checked)
            {
                chc_arandi.Enabled = false;
                chc_cevap.Enabled = false;
            }
            else
            {
                chc_arandi.Enabled = true;
                chc_cevap.Enabled = true;

            }
        }

        private void btn_bil_kaydet_Click(object sender, EventArgs e)
        {
            if (chc_arandi.Checked)
            {
                bag.Open();
            OleDbCommand kmt = new OleDbCommand("Update musteri Set bilgi = @bilgi Where id=@id", bag);
            kmt.Parameters.Add("@bilgi", OleDbType.VarChar).Value = chc_arandi.Text;
            kmt.Parameters.Add("@id", OleDbType.VarChar).Value = textEdit1.Text;
            kmt.Connection = bag;

            OleDbTransaction trans;
            trans = bag.BeginTransaction();
            kmt.Transaction = trans;
           

            try
            {
                kmt.ExecuteNonQuery();
                trans.Commit();
                XtraMessageBox.Show("ARAMA BİLGİSİ EKLENMİŞTİR  ", "BİLGİ EKLENDİ", MessageBoxButtons.OK);
            }
            catch
            {
                trans.Rollback();
                XtraMessageBox.Show("ARAMA BİLGİSİ EKLENMEMİŞTİR ", "BİLGİ EKLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                bag.Close();
                grid_doldur();
                this.Close();

            }
            }

            else if (chc_cevap.Checked)
            {

                bag.Open();
                OleDbCommand kmt1 = new OleDbCommand("Update musteri Set bilgi = @bilgi Where id=@id", bag);
                kmt1.Parameters.Add("@bilgi", OleDbType.VarChar).Value = chc_cevap.Text;
                kmt1.Parameters.Add("@id", OleDbType.VarChar).Value = textEdit1.Text;
                kmt1.Connection = bag;

                OleDbTransaction trans;
                trans = bag.BeginTransaction();
                kmt1.Transaction = trans;


                try
                {
                    kmt1.ExecuteNonQuery();
                    trans.Commit();
                    XtraMessageBox.Show("ARAMA BİLGİSİ EKLENMİŞTİR  ", "BİLGİ EKLENDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    trans.Rollback();
                    XtraMessageBox.Show("ARAMA BİLGİSİ EKLENMEMİŞTİR ", "BİLGİ EKLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    bag.Close();
                    grid_doldur();
                    this.Close();
                    
                    

                }

                
            }


            else if (chc_ulaş.Checked)
            {

                bag.Open();
                OleDbCommand kmt = new OleDbCommand("Update musteri Set bilgi = @bilgi Where id=@id", bag);
                kmt.Parameters.Add("@bilgi", OleDbType.VarChar).Value = chc_ulaş.Text;
                kmt.Parameters.Add("@id", OleDbType.VarChar).Value = textEdit1.Text;
                kmt.Connection = bag;

                OleDbTransaction trans;
                trans = bag.BeginTransaction();
                kmt.Transaction = trans;


                try
                {
                    kmt.ExecuteNonQuery();
                    trans.Commit();
                    XtraMessageBox.Show("ARAMA BİLGİSİ EKLENMİŞTİR  ", "BİLGİ EKLENDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    trans.Rollback();
                    XtraMessageBox.Show("ARAMA BİLGİSİ EKLENMEMİŞTİR ", "BİLGİ EKLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    bag.Close();
                    grid_doldur();
                    this.Close();
                    

                }
                
            }
            else
            {
                XtraMessageBox.Show("LÜTFEN BİR İŞLEM SEÇİNİZ ", "SATIŞ BİLGİSİ BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            }
        public void grid_doldur()
        {

            bag.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from musteri", bag);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dt.DataSource = ds.Tables[0];
            bag.Close();


        }
        }
    }

