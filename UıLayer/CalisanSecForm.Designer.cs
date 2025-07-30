namespace UıLayer
{
    partial class CalisanSecForm
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
            txtArama = new TextBox();
            dataGridView1 = new DataGridView();
            btnAra = new Button();
            dtpSecilenTarih = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 51);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 0;
            label1.Text = "Ad veya Soyad Ara:";
            // 
            // txtArama
            // 
            txtArama.Location = new Point(209, 44);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(200, 27);
            txtArama.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(36, 106);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(943, 294);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // btnAra
            // 
            btnAra.Location = new Point(432, 35);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(210, 36);
            btnAra.TabIndex = 3;
            btnAra.Text = "Arama Yap";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // dtpSecilenTarih
            // 
            dtpSecilenTarih.Location = new Point(661, 46);
            dtpSecilenTarih.Name = "dtpSecilenTarih";
            dtpSecilenTarih.Size = new Size(318, 27);
            dtpSecilenTarih.TabIndex = 4;
            // 
            // CalisanSecForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 658);
            Controls.Add(dtpSecilenTarih);
            Controls.Add(btnAra);
            Controls.Add(dataGridView1);
            Controls.Add(txtArama);
            Controls.Add(label1);
            Name = "CalisanSecForm";
            Text = "CalisanSecForm";
            Load += CalisanSecForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtArama;
        private DataGridView dataGridView1;
        private Button btnAra;
        private DateTimePicker dtpSecilenTarih;
    }
}