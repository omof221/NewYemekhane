namespace UıLayer
{
    partial class Adminn
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
            label1 = new Label();
            txtKullaniciAdi = new MaskedTextBox();
            txtSifre = new TextBox();
            btnGirisYap = new Button();
            label2 = new Label();
            label3 = new Label();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F);
            label1.Location = new Point(207, 103);
            label1.Name = "label1";
            label1.Size = new Size(263, 38);
            label1.TabIndex = 0;
            label1.Text = "Admin  Giriş  Portalı";
            label1.Click += label1_Click;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Font = new Font("Segoe UI", 16.2F);
            txtKullaniciAdi.Location = new Point(207, 204);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(255, 43);
            txtKullaniciAdi.TabIndex = 1;
            txtKullaniciAdi.ValidatingType = typeof(int);
            //txtKullaniciAdi.MaskInputRejected += this.txtKullaniciAdi_MaskInputRejected;
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Segoe UI", 16.2F);
            txtSifre.Location = new Point(207, 271);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(255, 43);
            txtSifre.TabIndex = 2;
            txtSifre.UseSystemPasswordChar = true;
            txtSifre.TextChanged += txtSifre_TextChanged;
            // 
            // btnGirisYap
            // 
            btnGirisYap.Font = new Font("Segoe UI", 16.2F);
            btnGirisYap.Location = new Point(252, 364);
            btnGirisYap.Name = "btnGirisYap";
            btnGirisYap.Size = new Size(163, 59);
            btnGirisYap.TabIndex = 3;
            btnGirisYap.Text = "Giriş Yap";
            btnGirisYap.UseVisualStyleBackColor = true;
            btnGirisYap.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F);
            label2.Location = new Point(23, 209);
            label2.Name = "label2";
            label2.Size = new Size(169, 38);
            label2.TabIndex = 4;
            label2.Text = "Kullanıcı Adı";
            //label2.Click += this.label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F);
            label3.Location = new Point(66, 274);
            label3.Name = "label3";
            label3.Size = new Size(73, 38);
            label3.TabIndex = 5;
            label3.Text = "Şifre";
            label3.Click += label3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(180, 57);
            button4.TabIndex = 20;
            button4.Text = "Önceki Sayfaya Dön";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Adminn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 529);
            Controls.Add(button4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnGirisYap);
            Controls.Add(txtSifre);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(label1);
            Name = "Adminn";
            Text = "Admin";
            Load += Adminn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MaskedTextBox txtKullaniciAdi;
        private TextBox txtSifre;
        private Button btnGirisYap;
        private Label label2;
        private Label label3;
        private Button button4;
    }
}