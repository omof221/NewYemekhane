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
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 102);
            label1.Name = "label1";
            label1.Size = new Size(132, 20);
            label1.TabIndex = 0;
            label1.Text = "Admin Giriş Portalı";
            label1.Click += label1_Click;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(191, 157);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(186, 27);
            txtKullaniciAdi.TabIndex = 1;
            txtKullaniciAdi.ValidatingType = typeof(int);
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(191, 215);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(186, 27);
            txtSifre.TabIndex = 2;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // btnGirisYap
            // 
            btnGirisYap.Location = new Point(191, 267);
            btnGirisYap.Name = "btnGirisYap";
            btnGirisYap.Size = new Size(125, 29);
            btnGirisYap.TabIndex = 3;
            btnGirisYap.Text = "Giriş Yap";
            btnGirisYap.UseVisualStyleBackColor = true;
            btnGirisYap.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 157);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 4;
            label2.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 222);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 5;
            label3.Text = "Şifre";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(30, 12);
            button1.Name = "button1";
            button1.Size = new Size(212, 54);
            button1.TabIndex = 6;
            button1.Text = "Önceki Sayfaya Dön";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Adminn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 410);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnGirisYap);
            Controls.Add(txtSifre);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(label1);
            Name = "Adminn";
            Text = "Admin";
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
        private Button button1;
    }
}