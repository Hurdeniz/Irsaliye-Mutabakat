namespace irsaliye_mutabakat
{
    partial class Xtra_aylik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Xtra_aylik));
            this.btn_excel = new DevExpress.XtraEditors.SimpleButton();
            this.ımageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tab = new DevExpress.XtraTab.XtraTabControl();
            this.tab_gon = new DevExpress.XtraTab.XtraTabPage();
            this.tab_gelen = new DevExpress.XtraTab.XtraTabPage();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ımageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tab)).BeginInit();
            this.tab.SuspendLayout();
            this.tab_gon.SuspendLayout();
            this.tab_gelen.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_excel
            // 
            this.btn_excel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_excel.Appearance.Options.UseFont = true;
            this.btn_excel.ImageIndex = 0;
            this.btn_excel.ImageList = this.ımageCollection1;
            this.btn_excel.Location = new System.Drawing.Point(277, 393);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(148, 61);
            this.btn_excel.TabIndex = 0;
            this.btn_excel.Text = "EXCEL AKTAR";
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // ımageCollection1
            // 
            this.ımageCollection1.ImageSize = new System.Drawing.Size(55, 55);
            this.ımageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ımageCollection1.ImageStream")));
            this.ımageCollection1.Images.SetKeyName(0, "1446500594_application-vnd.ms-excel.png");
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(697, 352);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(697, 352);
            this.dataGridView2.TabIndex = 2;
            // 
            // tab
            // 
            this.tab.Location = new System.Drawing.Point(5, 6);
            this.tab.Name = "tab";
            this.tab.SelectedTabPage = this.tab_gon;
            this.tab.Size = new System.Drawing.Size(704, 381);
            this.tab.TabIndex = 3;
            this.tab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tab_gelen,
            this.tab_gon});
            // 
            // tab_gon
            // 
            this.tab_gon.Controls.Add(this.dataGridView2);
            this.tab_gon.Name = "tab_gon";
            this.tab_gon.Size = new System.Drawing.Size(697, 352);
            this.tab_gon.Text = "GÖNDERİLEN İRALİYELER";
            // 
            // tab_gelen
            // 
            this.tab_gelen.Controls.Add(this.dataGridView1);
            this.tab_gelen.Name = "tab_gelen";
            this.tab_gelen.Size = new System.Drawing.Size(697, 352);
            this.tab_gelen.Text = "GELEN İRSALİYELER";
            // 
            // Xtra_aylik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 466);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.btn_excel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Xtra_aylik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AYLIK RAPOR";
            this.Load += new System.EventHandler(this.Xtra_aylik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ımageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tab)).EndInit();
            this.tab.ResumeLayout(false);
            this.tab_gon.ResumeLayout(false);
            this.tab_gelen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_excel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private DevExpress.XtraTab.XtraTabControl tab;
        private DevExpress.XtraTab.XtraTabPage tab_gon;
        private DevExpress.XtraTab.XtraTabPage tab_gelen;
        private DevExpress.Utils.ImageCollection ımageCollection1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}