namespace UıLayer
{
    partial class ListelemeForm
    {// 208. satırı değiştirdim ben
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
            label2 = new Label();
            dtpBaslangic = new DateTimePicker();
            dtpBitis = new DateTimePicker();
            btnPersonelSecimi = new Button();
            btnExceleAktar = new Button();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            button2 = new Button();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(317, 41);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 1;
            label1.Text = "Başlangıç Tarihi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(317, 94);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 2;
            label2.Text = "Bitiş Tarihi:";
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Location = new Point(437, 41);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(250, 27);
            dtpBaslangic.TabIndex = 3;
            dtpBaslangic.ValueChanged += dtpBaslangic_ValueChanged;
            // 
            // dtpBitis
            // 
            dtpBitis.Location = new Point(437, 94);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(250, 27);
            dtpBitis.TabIndex = 4;
            dtpBitis.ValueChanged += dtpBitis_ValueChanged;
            // 
            // btnPersonelSecimi
            // 
            btnPersonelSecimi.Location = new Point(12, 52);
            btnPersonelSecimi.Name = "btnPersonelSecimi";
            btnPersonelSecimi.Size = new Size(284, 44);
            btnPersonelSecimi.TabIndex = 5;
            btnPersonelSecimi.Text = "Personel Ara";
            btnPersonelSecimi.UseVisualStyleBackColor = true;
            btnPersonelSecimi.Click += button1_Click;
            // 
            // btnExceleAktar
            // 
            btnExceleAktar.Location = new Point(995, 11);
            btnExceleAktar.Name = "btnExceleAktar";
            btnExceleAktar.Size = new Size(98, 112);
            btnExceleAktar.TabIndex = 10;
            btnExceleAktar.Text = "Excel'e aktar";
            btnExceleAktar.TextAlign = ContentAlignment.BottomCenter;
            btnExceleAktar.UseVisualStyleBackColor = true;
            btnExceleAktar.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 146);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1246, 473);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(508, 7);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 12;
            label3.Text = "Tarih Seçimi";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.ForeColor = Color.White;
            button2.Location = new Point(1110, 81);
            button2.Name = "button2";
            button2.Size = new Size(139, 40);
            button2.TabIndex = 14;
            button2.Text = "Ana Sayfaya Dön";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1132, 29);
            label4.Name = "label4";
            label4.Size = new Size(92, 20);
            label4.TabIndex = 15;
            label4.Text = "Kullanıcı Adı";
            label4.Click += label4_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(726, 91);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(225, 28);
            comboBox1.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(714, 41);
            label5.Name = "label5";
            label5.Size = new Size(266, 20);
            label5.TabIndex = 18;
            label5.Text = "Almak İstediğiniz Rapor Türünü Seçiniz";
            // 
            // ListelemeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1270, 629);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(btnExceleAktar);
            Controls.Add(btnPersonelSecimi);
            Controls.Add(dtpBitis);
            Controls.Add(dtpBaslangic);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ListelemeForm";
            Text = "ListelemeForm";
            Load += ListelemeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpBitis;
        private Button btnPersonelSecimi;
        private Button btnExceleAktar;
        private DataGridView dataGridView1;
        private Label label3;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button button2;
        private Label label4;
        private ComboBox comboBox1;
        private Label label5;
        private MaskedTextBox maskedTextBox1;
    }
}