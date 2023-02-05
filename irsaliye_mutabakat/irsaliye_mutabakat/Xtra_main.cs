using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace irsaliye_mutabakat
{
    public partial class Xtra_main : DevExpress.XtraEditors.XtraForm
    {
        public Xtra_main()
        {
            InitializeComponent();
        }

        private void btn_gonderilen_Click(object sender, EventArgs e)
        {
            Xtra_gonderilen gon = new Xtra_gonderilen();
            gon.Show();
        }

        private void btn_aylik_Click(object sender, EventArgs e)
        {
            Xtra_aylik aylik = new Xtra_aylik();
            aylik.Show();
        }

        private void btn_gelen_Click(object sender, EventArgs e)
        {
            Xtra_gelen gelen = new Xtra_gelen();
            gelen.Show();
        }

        private void barManager1_CloseButtonClick(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show("Programdan Çıkmak İstediğinizden Emin Misiniz ? ", "NİNE WEST - İRSALİYE MUATABAKAT && MÜŞTERİ ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Xtra_musteri musteri = new Xtra_musteri();
            musteri.Show();
        }
    }
}