namespace irsaliye_mutabakat
{
    partial class Xtra_bilgi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Xtra_bilgi));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.btn_bil_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.chc_ulaş = new DevExpress.XtraEditors.CheckEdit();
            this.chc_cevap = new DevExpress.XtraEditors.CheckEdit();
            this.chc_arandi = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc_ulaş.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc_cevap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc_arandi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(12, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(24, 20);
            this.textEdit1.TabIndex = 11;
            // 
            // btn_bil_kaydet
            // 
            this.btn_bil_kaydet.Location = new System.Drawing.Point(68, 92);
            this.btn_bil_kaydet.Name = "btn_bil_kaydet";
            this.btn_bil_kaydet.Size = new System.Drawing.Size(100, 36);
            this.btn_bil_kaydet.TabIndex = 10;
            this.btn_bil_kaydet.Text = "KAYDET";
            this.btn_bil_kaydet.Click += new System.EventHandler(this.btn_bil_kaydet_Click);
            // 
            // chc_ulaş
            // 
            this.chc_ulaş.Location = new System.Drawing.Point(55, 63);
            this.chc_ulaş.Name = "chc_ulaş";
            this.chc_ulaş.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chc_ulaş.Properties.Appearance.Options.UseFont = true;
            this.chc_ulaş.Properties.Caption = "ULAŞILAMIYOR";
            this.chc_ulaş.Size = new System.Drawing.Size(141, 23);
            this.chc_ulaş.TabIndex = 9;
            this.chc_ulaş.CheckedChanged += new System.EventHandler(this.chc_ulaş_CheckedChanged);
            // 
            // chc_cevap
            // 
            this.chc_cevap.Location = new System.Drawing.Point(55, 38);
            this.chc_cevap.Name = "chc_cevap";
            this.chc_cevap.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chc_cevap.Properties.Appearance.Options.UseFont = true;
            this.chc_cevap.Properties.Caption = "CEVAP VERMEDİ";
            this.chc_cevap.Size = new System.Drawing.Size(156, 23);
            this.chc_cevap.TabIndex = 8;
            this.chc_cevap.CheckedChanged += new System.EventHandler(this.chc_cevap_CheckedChanged);
            // 
            // chc_arandi
            // 
            this.chc_arandi.Location = new System.Drawing.Point(55, 13);
            this.chc_arandi.Name = "chc_arandi";
            this.chc_arandi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chc_arandi.Properties.Appearance.Options.UseFont = true;
            this.chc_arandi.Properties.Caption = "ARANDI";
            this.chc_arandi.Size = new System.Drawing.Size(102, 23);
            this.chc_arandi.TabIndex = 7;
            this.chc_arandi.CheckedChanged += new System.EventHandler(this.chc_arandi_CheckedChanged);
            // 
            // Xtra_bilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 140);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.btn_bil_kaydet);
            this.Controls.Add(this.chc_ulaş);
            this.Controls.Add(this.chc_cevap);
            this.Controls.Add(this.chc_arandi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Xtra_bilgi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BİLGİ EKLE";
            this.Load += new System.EventHandler(this.Xtra_bilgi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc_ulaş.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc_cevap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chc_arandi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btn_bil_kaydet;
        private DevExpress.XtraEditors.CheckEdit chc_ulaş;
        private DevExpress.XtraEditors.CheckEdit chc_cevap;
        private DevExpress.XtraEditors.CheckEdit chc_arandi;
    }
}