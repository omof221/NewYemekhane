namespace UıLayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic", 10.8F, FontStyle.Bold);
            button1.Location = new Point(80, 140);
            button1.Name = "button1";
            button1.Size = new Size(197, 57);
            button1.TabIndex = 0;
            button1.Text = "Admin Girişi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Yu Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(508, 140);
            button2.Name = "button2";
            button2.Size = new Size(197, 57);
            button2.TabIndex = 1;
            button2.Text = "Yemekhane Calisan Girisi";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 10.8F, FontStyle.Bold);
            label1.Location = new Point(508, 91);
            label1.Name = "label1";
            label1.Size = new Size(179, 46);
            label1.TabIndex = 2;
            label1.Text = "İsmail Abi buna bas\r\n\r\n";
            label1.Click += label1_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Yu Gothic", 10.8F, FontStyle.Bold);
            button3.Location = new Point(305, 91);
            button3.Name = "button3";
            button3.Size = new Size(197, 57);
            button3.TabIndex = 3;
            button3.Text = "kartekle";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Yu Gothic", 10.8F, FontStyle.Bold);
            button4.Location = new Point(305, 204);
            button4.Name = "button4";
            button4.Size = new Size(197, 57);
            button4.TabIndex = 4;
            button4.Text = "Yeni Okutma Ekleme";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(798, 293);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Button button3;
        private Button button4;
    }
}
