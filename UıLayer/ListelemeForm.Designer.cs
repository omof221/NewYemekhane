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
            comboBox1 = new ComboBox();
            label5 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(856, 44);
            label1.Name = "label1";
            label1.Size = new Size(148, 28);
            label1.TabIndex = 1;
            label1.Text = "Başlangıç Tarihi:";
            //label1.Click += this.label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(856, 97);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 2;
            label2.Text = "Bitiş Tarihi:";
            //label2.Click += this.label2_Click;
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Font = new Font("Segoe UI", 10.8F);
            dtpBaslangic.Location = new Point(1021, 46);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(250, 31);
            dtpBaslangic.TabIndex = 3;
            dtpBaslangic.ValueChanged += dtpBaslangic_ValueChanged;
            // 
            // dtpBitis
            // 
            dtpBitis.Font = new Font("Segoe UI", 10.8F);
            dtpBitis.Location = new Point(1021, 99);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(250, 31);
            dtpBitis.TabIndex = 4;
            dtpBitis.ValueChanged += dtpBitis_ValueChanged;
            // 
            // btnPersonelSecimi
            // 
            btnPersonelSecimi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnPersonelSecimi.Location = new Point(477, 44);
            btnPersonelSecimi.Name = "btnPersonelSecimi";
            btnPersonelSecimi.Size = new Size(329, 64);
            btnPersonelSecimi.TabIndex = 5;
            btnPersonelSecimi.Text = "Personel Seçimi";
            btnPersonelSecimi.UseVisualStyleBackColor = true;
            btnPersonelSecimi.Click += button1_Click;
            // 
            // btnExceleAktar
            // 
            btnExceleAktar.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnExceleAktar.Location = new Point(1766, 19);
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
            dataGridView1.Size = new Size(1884, 875);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(1074, 4);
            label3.Name = "label3";
            label3.Size = new Size(127, 28);
            label3.TabIndex = 12;
            label3.Text = "Tarih Seçimi";
            //label3.Click += this.label3_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Control;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(12, 6);
            button2.Name = "button2";
            button2.Size = new Size(195, 64);
            button2.TabIndex = 14;
            button2.Text = "Ana Sayfaya Dön";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1375, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(350, 28);
            comboBox1.TabIndex = 17;
            //comboBox1.SelectedIndexChanged += this.comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.Location = new Point(1375, 35);
            label5.Name = "label5";
            label5.Size = new Size(350, 28);
            label5.TabIndex = 18;
            label5.Text = "Almak İstediğiniz Rapor Türünü Seçiniz";
            label5.Click += label5_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button1.Location = new Point(264, 53);
            button1.Name = "button1";
            button1.Size = new Size(156, 47);
            button1.TabIndex = 19;
            button1.Text = "Seçimleri Sıfırla";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // ListelemeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(comboBox1);
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
        private ComboBox comboBox1;
        private Label label5;
        private MaskedTextBox maskedTextBox1;
        private Button button1;
    }
}