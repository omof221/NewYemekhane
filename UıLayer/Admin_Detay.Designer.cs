namespace UıLayer
{
    partial class Admin_Detay
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
            label2 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button1.Location = new Point(863, 475);
            button1.Name = "button1";
            button1.Size = new Size(209, 76);
            button1.TabIndex = 0;
            button1.Text = "Yeni Yemekhane Personeli Ekleme";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button2.Location = new Point(22, 26);
            button2.Name = "button2";
            button2.Size = new Size(200, 68);
            button2.TabIndex = 1;
            button2.Text = "Admin Hesabından Çıkış Yap";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(736, 281);
            label2.Name = "label2";
            label2.Size = new Size(473, 50);
            label2.TabIndex = 6;
            label2.Text = "Admin İşlemleri Ana Sayfası";
            label2.Click += label2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button3.Location = new Point(863, 575);
            button3.Name = "button3";
            button3.Size = new Size(209, 76);
            button3.TabIndex = 7;
            button3.Text = "Loglar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Admin_Detay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Admin_Detay";
            Text = "Admin_Detay";
            Load += Admin_Detay_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label2;
        private Button button3;
    }
}