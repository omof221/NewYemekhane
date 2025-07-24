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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            btnKaydet = new Button();
            txtIsim = new TextBox();
            txtGorevv = new TextBox();
            txtSoyad = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            maskedTextBoxKartID = new MaskedTextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(591, 295);
            dataGridView1.TabIndex = 0;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(666, 256);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(255, 29);
            btnKaydet.TabIndex = 1;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += button1_Click;
            // 
            // txtIsim
            // 
            txtIsim.Location = new Point(745, 104);
            txtIsim.Name = "txtIsim";
            txtIsim.Size = new Size(176, 27);
            txtIsim.TabIndex = 3;
            // 
            // txtGorevv
            // 
            txtGorevv.Location = new Point(745, 201);
            txtGorevv.Name = "txtGorevv";
            txtGorevv.Size = new Size(176, 27);
            txtGorevv.TabIndex = 5;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(745, 157);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(176, 27);
            txtSoyad.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(666, 107);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 7;
            label2.Text = "isim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(666, 164);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 8;
            label3.Text = "soyad";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(667, 208);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 9;
            label4.Text = "gorev";
            // 
            // maskedTextBoxKartID
            // 
            maskedTextBoxKartID.Location = new Point(745, 10);
            maskedTextBoxKartID.Mask = "0000000000";
            maskedTextBoxKartID.Name = "maskedTextBoxKartID";
            maskedTextBoxKartID.Size = new Size(125, 27);
            maskedTextBoxKartID.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(633, 12);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 13;
            label1.Text = "Çalışan Kart ID";
            // 
            // kartKullanıcıEkleme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 569);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private MaskedTextBox maskedTextBoxKartID;
        private Label label1;
    }
}