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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(12, 12);
            maskedTextBox1.Mask = "0000000000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(125, 27);
            maskedTextBox1.TabIndex = 0;
            maskedTextBox1.TextChanged += maskedTextBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(857, 258);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 320);
            button1.Name = "button1";
            button1.Size = new Size(237, 45);
            button1.TabIndex = 2;
            button1.Text = "Okutmayı Sil";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnCalisanAra
            // 
            btnCalisanAra.Location = new Point(632, 320);
            btnCalisanAra.Name = "btnCalisanAra";
            btnCalisanAra.Size = new Size(237, 45);
            btnCalisanAra.TabIndex = 3;
            btnCalisanAra.Text = "Çalışan Ara";
            btnCalisanAra.UseVisualStyleBackColor = true;
            btnCalisanAra.Click += btnCalisanAra_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 410);
            button2.Name = "button2";
            button2.Size = new Size(237, 45);
            button2.TabIndex = 4;
            button2.Text = "Ana Sayfaya Dön";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // YeniOkutmaEkleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 604);
            Controls.Add(button2);
            Controls.Add(btnCalisanAra);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(maskedTextBox1);
            Name = "YeniOkutmaEkleForm";
            Text = "YeniOkutmaEkleForm";
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
    }
}