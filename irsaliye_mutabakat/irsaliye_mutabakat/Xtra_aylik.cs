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
    public partial class Xtra_aylik : DevExpress.XtraEditors.XtraForm
    {
        public Xtra_aylik()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=irsaliye.accdb");

        private void Xtra_aylik_Load(object sender, EventArgs e)
        {
            grid_doldur();
            grid_isim();
            grid_boyut();
            

        }
        public void grid_doldur()
    {
        bag.Open();
        OleDbDataAdapter da = new OleDbDataAdapter("select * from gonderilen", bag);
        OleDbDataAdapter gel = new OleDbDataAdapter("select * from gelen", bag);

        DataSet ds = new DataSet();
        DataSet ge = new DataSet();

        da.Fill(ds);
        gel.Fill(ge);

        dataGridView2.DataSource = ds.Tables[0];
        dataGridView1.DataSource = ge.Tables[0];
        bag.Close();
    
    }

        public void grid_isim()

        {

            dataGridView2.Columns[0].HeaderText = "İRSALİYE NUMARASI";
            dataGridView2.Columns[1].HeaderText = "TARİH";
            dataGridView2.Columns[2].HeaderText = "GELEN DEPO & MAĞAZA";
            dataGridView2.Columns[3].HeaderText = "AÇIKLAMA";
            dataGridView2.Columns[4].HeaderText = "GELEN ADET";


            dataGridView1.Columns[0].HeaderText = "İRSALİYE NUMARASI";
            dataGridView1.Columns[1].HeaderText = "TARİH";
            dataGridView1.Columns[2].HeaderText = "GÖNDERİLEN DEPO & MAĞAZA";
            dataGridView1.Columns[3].HeaderText = "AÇIKLAMA";
            dataGridView1.Columns[4].HeaderText = "GÖNDERİLEN ADET";


        }
        public void grid_boyut()
        {
            dataGridView1.Columns[0].Width = 135;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 135;

            dataGridView2.Columns[0].Width = 135;
            dataGridView2.Columns[1].Width = 100;
            dataGridView2.Columns[2].Width = 180;
            dataGridView2.Columns[3].Width = 100;
            dataGridView2.Columns[4].Width = 135;

        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            int sutun = 1;
            int satır = 3;

            excel.Application excelapp = new excel.Application();
            excelapp.Workbooks.Add("irsaliye mutabakat");            
            excelapp.Visible = true;
            excelapp.Worksheets[2].activate();
            
            





            satır++;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    excelapp.Cells[satır + i, sutun + j].value = dataGridView2[j, i].Value;

                }
            

           
            }

            excelapp.Worksheets[1].activate();
           
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    excelapp.Cells[satır + i, sutun + j].value = dataGridView1[j, i].Value;

                }



            }
        }
    }
}