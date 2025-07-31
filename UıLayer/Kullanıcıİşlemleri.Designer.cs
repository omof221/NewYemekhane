namespace UıLayer
{
    partial class Kullanıcıİşlemleri
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
            txtTc = new TextBox();
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtKullaniciAdi = new TextBox();
            txtSifre = new TextBox();
            cmbDurum = new ComboBox();
            dataGridView1 = new DataGridView();
            btnEkle = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            button1 = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtTc
            // 
            txtTc.Location = new Point(351, 524);
            txtTc.Name = "txtTc";
            txtTc.Size = new Size(188, 27);
            txtTc.TabIndex = 0;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(351, 246);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(188, 27);
            txtAd.TabIndex = 2;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(351, 341);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(188, 27);
            txtSoyad.TabIndex = 4;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(351, 433);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(188, 27);
            txtKullaniciAdi.TabIndex = 6;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(351, 626);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(188, 27);
            txtSifre.TabIndex = 8;
            // 
            // cmbDurum
            // 
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Location = new Point(351, 711);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(188, 28);
            cmbDurum.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(647, 102);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1243, 1032);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnEkle
            // 
            btnEkle.Font = new Font("Segoe UI", 12F);
            btnEkle.Location = new Point(21, 833);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(172, 49);
            btnEkle.TabIndex = 13;
            btnEkle.Text = "EKLE";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Font = new Font("Segoe UI", 12F);
            btnGuncelle.Location = new Point(236, 833);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(172, 49);
            btnGuncelle.TabIndex = 14;
            btnGuncelle.Text = "GÜNCELLE";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.Font = new Font("Segoe UI", 12F);
            btnSil.Location = new Point(464, 833);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(172, 49);
            btnSil.TabIndex = 15;
            btnSil.Text = "SİL";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(203, 65);
            button1.TabIndex = 16;
            button1.Text = "Admin Anasayfasına Geri Dön";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label7.Location = new Point(62, 615);
            label7.Name = "label7";
            label7.Size = new Size(93, 38);
            label7.TabIndex = 29;
            label7.Text = "Parola";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label6.Location = new Point(62, 524);
            label6.Name = "label6";
            label6.Size = new Size(206, 38);
            label6.TabIndex = 28;
            label6.Text = "Çalışan Sicil No";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.Location = new Point(62, 701);
            label5.Name = "label5";
            label5.Size = new Size(212, 38);
            label5.TabIndex = 27;
            label5.Text = "Aktiflik Durumu";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label9.Location = new Point(62, 422);
            label9.Name = "label9";
            label9.Size = new Size(264, 38);
            label9.TabIndex = 25;
            label9.Text = "Çalışan Kullanıcı Adı";
            label9.Click += label9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label10.Location = new Point(62, 330);
            label10.Name = "label10";
            label10.Size = new Size(187, 38);
            label10.TabIndex = 24;
            label10.Text = "Çalışan Soyad";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label11.Location = new Point(62, 235);
            label11.Name = "label11";
            label11.Size = new Size(162, 38);
            label11.TabIndex = 23;
            label11.Text = "Çalışan İsim";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(647, 9);
            label1.Name = "label1";
            label1.Size = new Size(608, 46);
            label1.TabIndex = 30;
            label1.Text = "Yeni Yemekhane Çalışanı Ekleme Sayfası";
            // 
            // Kullanıcıİşlemleri
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(button1);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(btnEkle);
            Controls.Add(dataGridView1);
            Controls.Add(cmbDurum);
            Controls.Add(txtSifre);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Controls.Add(txtTc);
            Name = "Kullanıcıİşlemleri";
            Text = "YeniYemekhaneCalisaniEkleme";
            Load += YeniYemekhaneCalisaniEkleme_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTc;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtKullaniciAdi;
        private TextBox txtSifre;
        private ComboBox cmbDurum;
        private DataGridView dataGridView1;
        private Button btnEkle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button button1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label1;
    }
}