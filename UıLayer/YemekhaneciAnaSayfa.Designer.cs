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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(40, 164);
            button1.Name = "button1";
            button1.Size = new Size(276, 96);
            button1.TabIndex = 0;
            button1.Text = "Yeni Kart Ekleme";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(342, 282);
            button2.Name = "button2";
            button2.Size = new Size(276, 96);
            button2.TabIndex = 1;
            button2.Text = "Raporlama İşelmleri";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(622, 164);
            button3.Name = "button3";
            button3.Size = new Size(276, 96);
            button3.TabIndex = 2;
            button3.Text = "Yemekhane Okutma İşlemleri";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(95, 429);
            button4.Name = "button4";
            button4.Size = new Size(108, 23);
            button4.TabIndex = 3;
            button4.Text = "Çıkış Yap";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // YemekhaneciAnaSayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 495);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "YemekhaneciAnaSayfa";
            Text = "YemekhaneciAnaSayfa";
            Load += YemekhaneciAnaSayfa_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}