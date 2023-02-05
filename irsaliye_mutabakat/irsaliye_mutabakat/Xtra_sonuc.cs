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
    public partial class Xtra_sonuc : DevExpress.XtraEditors.XtraForm
    {
        public Xtra_sonuc(DataGridView dataax)
        {
            InitializeComponent();
            dt = dataax;
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=irsaliye.accdb");
        DataGridView dt = new DataGridView();
        private void Xtra_sonuc_Load(object sender, EventArgs e)
        {
            textEdit2.Text = dt.CurrentRow.Cells[0].Value.ToString();
        }

        private void chc_satildi_CheckedChanged(object sender, EventArgs e)
        {
            if (chc_satildi.Checked)
            {
                chc_iptal.Enabled = false;
               
            }
            else
            {
                chc_iptal.Enabled = true;
            }
        }

        private void chc_iptal_CheckedChanged(object sender, EventArgs e)
        {
            if (chc_iptal.Checked)
            {
                chc_satildi.Enabled = false;

            }
            else
            {
                chc_satildi.Enabled = true;
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

        private void btn_sonuc_kaydet_Click(object sender, EventArgs e)
        {
            if (chc_iptal.Checked)
            {
                    bag.Open();
                    OleDbCommand kmt = new OleDbCommand("Update musteri Set sonuc = @sonuc Where id=@id", bag);
                    kmt.Parameters.Add("@sonuc", OleDbType.VarChar).Value = chc_iptal.Text;
                    kmt.Parameters.Add("@id", OleDbType.VarChar).Value = textEdit2.Text;
                    kmt.Connection = bag;

                    OleDbTransaction trans;
                    trans = bag.BeginTransaction();
                    kmt.Transaction = trans;


                    try
                    {
                        kmt.ExecuteNonQuery();
                        trans.Commit();
                        XtraMessageBox.Show("SATIŞ BİLGİSİ EKLENMİŞTİR  ", "SATIŞ BİLGİSİ EKLENDİ", MessageBoxButtons.OK);
                    }
                    catch
                    {
                        trans.Rollback();
                        XtraMessageBox.Show("SATIŞ BİLGİSİ EKLENMEMİŞTİR ", "BİLGİ EKLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        bag.Close();
                        grid_doldur();
                        this.Close();

                    }
                }
            else if (chc_satildi.Checked)
            {
                
                    bag.Open();
                    OleDbCommand kmt = new OleDbCommand("Update musteri Set sonuc = @sonuc Where id=@id", bag);
                    kmt.Parameters.Add("@sonuc", OleDbType.VarChar).Value = chc_satildi.Text;
                    kmt.Parameters.Add("@id", OleDbType.VarChar).Value = textEdit2.Text;
                    kmt.Connection = bag;

                    OleDbTransaction trans;
                    trans = bag.BeginTransaction();
                    kmt.Transaction = trans;


                    try
                    {
                        kmt.ExecuteNonQuery();
                        trans.Commit();
                        XtraMessageBox.Show("SATIŞ BİLGİSİ EKLENMİŞTİR  ", "SATIŞ BİLGİSİ EKLENDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        trans.Rollback();
                        XtraMessageBox.Show("SATIŞ BİLGİSİ EKLENMEMİŞTİR ", "BİLGİ EKLEME BAŞARISIZ", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        }
    }
