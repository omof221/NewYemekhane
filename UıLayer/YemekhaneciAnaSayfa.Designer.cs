namespace UıLayer
{
    partial class YemekhaneciAnaSayfa
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16.2F);
            button1.Location = new Point(518, 470);
            button1.Name = "button1";
            button1.Size = new Size(276, 96);
            button1.TabIndex = 0;
            button1.Text = "Kart İşlemleri";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 16.2F);
            button2.Location = new Point(835, 470);
            button2.Name = "button2";
            button2.Size = new Size(276, 96);
            button2.TabIndex = 1;
            button2.Text = "Raporlama İşlemleri";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 16.2F);
            button3.Location = new Point(1148, 470);
            button3.Name = "button3";
            button3.Size = new Size(276, 96);
            button3.TabIndex = 2;
            button3.Text = "Yemekhane Okutma İşlemleri";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button4.Location = new Point(21, 22);
            button4.Name = "button4";
            button4.Size = new Size(195, 64);
            button4.TabIndex = 3;
            button4.Text = "Yemekhaneden Çıkış Yap";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(774, 358);
            label1.Name = "label1";
            label1.Size = new Size(448, 41);
            label1.TabIndex = 4;
            label1.Text = "Yapmak İstediğiniz İşlemi Seçiniz";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(725, 36);
            label2.Name = "label2";
            label2.Size = new Size(550, 50);
            label2.TabIndex = 5;
            label2.Text = "Yemekhane İşlemleri Ana Sayfası";
            label2.Click += label2_Click;
            // 
            // YemekhaneciAnaSayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "YemekhaneciAnaSayfa";
            Text = "YemekhaneciAnaSayfa";
            Load += YemekhaneciAnaSayfa_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
    }
}