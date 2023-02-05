namespace irsaliye_mutabakat
{
    partial class Xtra_sonuc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Xtra_sonuc));
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.btn_sonuc_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.chc_iptal = new DevExpress.XtraEditors.CheckEdit();
            this.chc_satildi = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc_iptal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc_satildi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit2
            // 
            this.textEdit2.Enabled = false;
            this.textEdit2.Location = new System.Drawing.Point(12, 12);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(24, 20);
            this.textEdit2.TabIndex = 11;
            // 
            // btn_sonuc_kaydet
            // 
            this.btn_sonuc_kaydet.Location = new System.Drawing.Point(56, 77);
            this.btn_sonuc_kaydet.Name = "btn_sonuc_kaydet";
            this.btn_sonuc_kaydet.Size = new System.Drawing.Size(96, 37);
            this.btn_sonuc_kaydet.TabIndex = 10;
            this.btn_sonuc_kaydet.Text = "KAYDET";
            this.btn_sonuc_kaydet.Click += new System.EventHandler(this.btn_sonuc_kaydet_Click);
            // 
            // chc_iptal
            // 
            this.chc_iptal.Location = new System.Drawing.Point(63, 37);
            this.chc_iptal.Name = "chc_iptal";
            this.chc_iptal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chc_iptal.Properties.Appearance.Options.UseFont = true;
            this.chc_iptal.Properties.Caption = "SATILMADI";
            this.chc_iptal.Size = new System.Drawing.Size(98, 23);
            this.chc_iptal.TabIndex = 9;
            this.chc_iptal.CheckedChanged += new System.EventHandler(this.chc_iptal_CheckedChanged);
            // 
            // chc_satildi
            // 
            this.chc_satildi.Location = new System.Drawing.Point(63, 8);
            this.chc_satildi.Name = "chc_satildi";
            this.chc_satildi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chc_satildi.Properties.Appearance.Options.UseFont = true;
            this.chc_satildi.Properties.Caption = "SATILDI";
            this.chc_satildi.Size = new System.Drawing.Size(98, 23);
            this.chc_satildi.TabIndex = 8;
            this.chc_satildi.CheckedChanged += new System.EventHandler(this.chc_satildi_CheckedChanged);
            // 
            // Xtra_sonuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 127);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.btn_sonuc_kaydet);
            this.Controls.Add(this.chc_iptal);
            this.Controls.Add(this.chc_satildi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Xtra_sonuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÜRÜN SONUÇ";
            this.Load += new System.EventHandler(this.Xtra_sonuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc_iptal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc_satildi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.SimpleButton btn_sonuc_kaydet;
        private DevExpress.XtraEditors.CheckEdit chc_iptal;
        private DevExpress.XtraEditors.CheckEdit chc_satildi;
    }
}