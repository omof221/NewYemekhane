using System.IO;

namespace UıLayer
{
    partial class kartKullanıcıEkleme
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
            dataGridView1 = new DataGridView();
            btnKaydet = new Button();
            txtIsim = new TextBox();
            txtGorevv = new TextBox();
            txtSoyad = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            maskedTextBoxKartID = new MaskedTextBox();
            label1 = new Label();
            comboBoxAktiflik = new ComboBox();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label6 = new Label();
            txtsicil = new TextBox();
            label7 = new Label();
            txtgecis = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(653, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(802, 765);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(25, 596);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(135, 49);
            btnKaydet.TabIndex = 1;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += button1_Click;
            // 
            // txtIsim
            // 
            txtIsim.Location = new Point(151, 198);
            txtIsim.Name = "txtIsim";
            txtIsim.Size = new Size(188, 27);
            txtIsim.TabIndex = 3;
            txtIsim.KeyDown += txtIsim_KeyDown;
            // 
            // txtGorevv
            // 
            txtGorevv.Location = new Point(151, 329);
            txtGorevv.Name = "txtGorevv";
            txtGorevv.Size = new Size(188, 27);
            txtGorevv.TabIndex = 5;
            txtGorevv.KeyDown += txtGorevv_KeyDown;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(151, 266);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(189, 27);
            txtSoyad.TabIndex = 4;
            txtSoyad.KeyDown += txtSoyad_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 201);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 7;
            label2.Text = "isim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 273);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 8;
            label3.Text = "soyad";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(85, 324);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 9;
            label4.Text = "gorev";
            // 
            // maskedTextBoxKartID
            // 
            maskedTextBoxKartID.Location = new Point(151, 142);
            maskedTextBoxKartID.Mask = "0000000000";
            maskedTextBoxKartID.Name = "maskedTextBoxKartID";
            maskedTextBoxKartID.Size = new Size(188, 27);
            maskedTextBoxKartID.TabIndex = 10;
            maskedTextBoxKartID.TextChanged += maskedTextBoxKartID_TextChanged_2;
            maskedTextBoxKartID.KeyDown += maskedTextBoxKartID_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 142);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 13;
            label1.Text = "Çalışan Kart ID";
            // 
            // comboBoxAktiflik
            // 
            comboBoxAktiflik.FormattingEnabled = true;
            comboBoxAktiflik.Location = new Point(152, 508);
            comboBoxAktiflik.Name = "comboBoxAktiflik";
            comboBoxAktiflik.Size = new Size(187, 28);
            comboBoxAktiflik.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(88, 516);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 15;
            label5.Text = "Durum";
            // 
            // button1
            // 
            button1.Location = new Point(222, 596);
            button1.Name = "button1";
            button1.Size = new Size(135, 49);
            button1.TabIndex = 16;
            button1.Text = "Güncelle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(25, 688);
            button2.Name = "button2";
            button2.Size = new Size(135, 49);
            button2.TabIndex = 17;
            button2.Text = "Hücreleri Temizle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(222, 688);
            button3.Name = "button3";
            button3.Size = new Size(135, 49);
            button3.TabIndex = 18;
            button3.Text = "Sil";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(140, 36);
            button4.TabIndex = 19;
            button4.Text = "Ana Sayfaya Dön";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(89, 411);
            label6.Name = "label6";
            label6.Size = new Size(34, 20);
            label6.TabIndex = 20;
            label6.Text = "sicil";
            // 
            // txtsicil
            // 
            txtsicil.Location = new Point(151, 408);
            txtsicil.Name = "txtsicil";
            txtsicil.Size = new Size(189, 27);
            txtsicil.TabIndex = 21;
            txtsicil.KeyDown += txtsicil_KeyDown;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 478);
            label7.Name = "label7";
            label7.Size = new Size(134, 20);
            label7.TabIndex = 22;
            label7.Text = "Günlük Geçiş Sayısı";
            // 
            // txtgecis
            // 
            txtgecis.Location = new Point(152, 475);
            txtgecis.Name = "txtgecis";
            txtgecis.Size = new Size(188, 27);
            txtgecis.TabIndex = 23;
            // 
            // kartKullanıcıEkleme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1525, 789);
            Controls.Add(txtgecis);
            Controls.Add(label7);
            Controls.Add(txtsicil);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(comboBoxAktiflik);
            Controls.Add(label1);
            Controls.Add(maskedTextBoxKartID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtGorevv);
            Controls.Add(txtSoyad);
            Controls.Add(txtIsim);
            Controls.Add(btnKaydet);
            Controls.Add(dataGridView1);
            Name = "kartKullanıcıEkleme";
            Text = "kartKullanıcıEkleme";
            Load += kartKullanıcıEkleme_Load;
            Shown += kartKullanıcıEkleme_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnKaydet;
        private TextBox txtIsim;
        private TextBox txtGorevv;
        private TextBox txtSoyad;
        private Label label2;
        private Label label3;
        private Label label4;
        private MaskedTextBox maskedTextBoxKartID;
        private Label label1;
        private ComboBox comboBoxAktiflik;
        private Label label5;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label6;
        private TextBox txtsicil;
        private Label label7;
        private TextBox txtgecis;
    }
}