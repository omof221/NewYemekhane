namespace UıLayer
{
    partial class ListelemeForm
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            dtpBaslangic = new DateTimePicker();
            dtpBitis = new DateTimePicker();
            btnPersonelSecimi = new Button();
            cbTumPersonel = new CheckBox();
            btnRaporCikar = new Button();
            btnExceleAktar = new Button();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(27, 65);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(293, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += cmbRaporSeçimi;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(597, 59);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 1;
            label1.Text = "Başlangıç Tarihi:";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(597, 112);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 2;
            label2.Text = "Bitiş Tarihi:";
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Location = new Point(744, 54);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(250, 27);
            dtpBaslangic.TabIndex = 3;
            // 
            // dtpBitis
            // 
            dtpBitis.Location = new Point(744, 107);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(250, 27);
            dtpBitis.TabIndex = 4;
            dtpBitis.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // btnPersonelSecimi
            // 
            btnPersonelSecimi.Location = new Point(411, 54);
            btnPersonelSecimi.Name = "btnPersonelSecimi";
            btnPersonelSecimi.Size = new Size(145, 44);
            btnPersonelSecimi.TabIndex = 5;
            btnPersonelSecimi.Text = "Personel Seçimi";
            btnPersonelSecimi.UseVisualStyleBackColor = true;
            btnPersonelSecimi.Click += button1_Click;
            // 
            // cbTumPersonel
            // 
            cbTumPersonel.AutoSize = true;
            cbTumPersonel.Location = new Point(423, 111);
            cbTumPersonel.Name = "cbTumPersonel";
            cbTumPersonel.Size = new Size(119, 24);
            cbTumPersonel.TabIndex = 6;
            cbTumPersonel.Text = "Tüm Personel";
            cbTumPersonel.UseVisualStyleBackColor = true;
            cbTumPersonel.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // btnRaporCikar
            // 
            btnRaporCikar.Location = new Point(1018, 30);
            btnRaporCikar.Name = "btnRaporCikar";
            btnRaporCikar.Size = new Size(270, 49);
            btnRaporCikar.TabIndex = 8;
            btnRaporCikar.Text = "Rapor Çıkar";
            btnRaporCikar.UseVisualStyleBackColor = true;
            btnRaporCikar.Click += button2_Click;
            // 
            // btnExceleAktar
            // 
            btnExceleAktar.Location = new Point(1018, 92);
            btnExceleAktar.Name = "btnExceleAktar";
            btnExceleAktar.Size = new Size(270, 50);
            btnExceleAktar.TabIndex = 10;
            btnExceleAktar.Text = "Excel'e aktar";
            btnExceleAktar.UseVisualStyleBackColor = true;
            btnExceleAktar.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1281, 413);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(815, 20);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 12;
            label3.Text = "Tarih Seçimi";
            // 
            // ListelemeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 824);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(btnExceleAktar);
            Controls.Add(btnRaporCikar);
            Controls.Add(cbTumPersonel);
            Controls.Add(btnPersonelSecimi);
            Controls.Add(dtpBitis);
            Controls.Add(dtpBaslangic);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "ListelemeForm";
            Text = "ListelemeForm";
            Load += ListelemeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpBitis;
        private Button btnPersonelSecimi;
        private CheckBox cbTumPersonel;
        private Button btnRaporCikar;
        private Button btnExceleAktar;
        private DataGridView dataGridView1;
        private Label label3;
    }
}