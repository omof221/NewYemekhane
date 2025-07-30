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
            label1 = new Label();
            txtAd = new TextBox();
            Ad = new Label();
            txtSoyad = new TextBox();
            label2 = new Label();
            txtKullaniciAdi = new TextBox();
            nick = new Label();
            txtSifre = new TextBox();
            label3 = new Label();
            cmbDurum = new ComboBox();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            btnEkle = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtTc
            // 
            txtTc.Location = new Point(123, 41);
            txtTc.Name = "txtTc";
            txtTc.Size = new Size(125, 27);
            txtTc.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 41);
            label1.Name = "label1";
            label1.Size = new Size(25, 20);
            label1.TabIndex = 1;
            label1.Text = "TC";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(123, 86);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(125, 27);
            txtAd.TabIndex = 2;
            // 
            // Ad
            // 
            Ad.AutoSize = true;
            Ad.Location = new Point(44, 89);
            Ad.Name = "Ad";
            Ad.Size = new Size(28, 20);
            Ad.TabIndex = 3;
            Ad.Text = "Ad";
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(123, 133);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(125, 27);
            txtSoyad.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 140);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 5;
            label2.Text = "Soyad";
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(123, 188);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(125, 27);
            txtKullaniciAdi.TabIndex = 6;
            // 
            // nick
            // 
            nick.AutoSize = true;
            nick.Location = new Point(6, 195);
            nick.Name = "nick";
            nick.Size = new Size(88, 20);
            nick.TabIndex = 7;
            nick.Text = "kullanıcı adı";
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(123, 246);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(125, 27);
            txtSifre.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 253);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 9;
            label3.Text = "Şifre";
            // 
            // cmbDurum
            // 
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Location = new Point(123, 293);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(151, 28);
            cmbDurum.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 301);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 11;
            label4.Text = "Durum";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(295, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(656, 282);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(49, 343);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(225, 33);
            btnEkle.TabIndex = 13;
            btnEkle.Text = "EKLE";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(55, 382);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(225, 33);
            btnGuncelle.TabIndex = 14;
            btnGuncelle.Text = "GÜNCELLE";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(55, 421);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(225, 33);
            btnSil.TabIndex = 15;
            btnSil.Text = "SİL";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // button1
            // 
            button1.Location = new Point(55, 460);
            button1.Name = "button1";
            button1.Size = new Size(225, 33);
            button1.TabIndex = 16;
            button1.Text = "Geri Dön";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Kullanıcıİşlemleri
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(button1);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(btnEkle);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(cmbDurum);
            Controls.Add(label3);
            Controls.Add(txtSifre);
            Controls.Add(nick);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(label2);
            Controls.Add(txtSoyad);
            Controls.Add(Ad);
            Controls.Add(txtAd);
            Controls.Add(label1);
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
        private Label label1;
        private TextBox txtAd;
        private Label Ad;
        private TextBox txtSoyad;
        private Label label2;
        private TextBox txtKullaniciAdi;
        private Label nick;
        private TextBox txtSifre;
        private Label label3;
        private ComboBox cmbDurum;
        private Label label4;
        private DataGridView dataGridView1;
        private Button btnEkle;
        private Button btnGuncelle;
        private Button btnSil;
        private Button button1;
    }
}