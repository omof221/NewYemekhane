namespace UıLayer
{
    partial class YeniOkutmaEkleForm
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
            maskedTextBox1 = new MaskedTextBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            btnCalisanAra = new Button();
            button2 = new Button();
            dtpFiltreTarih = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(266, 358);
            maskedTextBox1.Mask = "0000000000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(237, 27);
            maskedTextBox1.TabIndex = 0;
            maskedTextBox1.MaskInputRejected += maskedTextBox1_MaskInputRejected;
            maskedTextBox1.TextChanged += maskedTextBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(647, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1243, 1032);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F);
            button1.Location = new Point(266, 575);
            button1.Name = "button1";
            button1.Size = new Size(237, 45);
            button1.TabIndex = 2;
            button1.Text = "Okutmayı Sil";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnCalisanAra
            // 
            btnCalisanAra.Font = new Font("Segoe UI", 13.8F);
            btnCalisanAra.Location = new Point(266, 460);
            btnCalisanAra.Name = "btnCalisanAra";
            btnCalisanAra.Size = new Size(237, 45);
            btnCalisanAra.TabIndex = 3;
            btnCalisanAra.Text = "Çalışan Ara";
            btnCalisanAra.UseVisualStyleBackColor = true;
            btnCalisanAra.Click += btnCalisanAra_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button2.Location = new Point(12, 12);
            button2.Name = "button2";
            button2.Size = new Size(199, 47);
            button2.TabIndex = 4;
            button2.Text = "Ana Sayfaya Dön";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dtpFiltreTarih
            // 
            dtpFiltreTarih.Location = new Point(21, 776);
            dtpFiltreTarih.Name = "dtpFiltreTarih";
            dtpFiltreTarih.Size = new Size(237, 27);
            dtpFiltreTarih.TabIndex = 5;
            dtpFiltreTarih.Visible = false;
            dtpFiltreTarih.ValueChanged += dtpFiltreTarih_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(176, 113);
            label1.Name = "label1";
            label1.Size = new Size(436, 46);
            label1.TabIndex = 6;
            label1.Text = "Yeni Okutma Ekleme Sayfası";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(329, 283);
            label2.Name = "label2";
            label2.Size = new Size(110, 31);
            label2.TabIndex = 7;
            label2.Text = "Kart Okut";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(62, 701);
            label3.Name = "label3";
            label3.Size = new Size(135, 31);
            label3.TabIndex = 8;
            label3.Text = "Tarih Seçimi";
            label3.Visible = false;
            // 
            // YeniOkutmaEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFiltreTarih);
            Controls.Add(button2);
            Controls.Add(btnCalisanAra);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(maskedTextBox1);
            Name = "YeniOkutmaEkleForm";
            Text = "                                                                               ";
            Load += YeniOkutmaEkleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox maskedTextBox1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button btnCalisanAra;
        private Button button2;
        private DateTimePicker dtpFiltreTarih;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}