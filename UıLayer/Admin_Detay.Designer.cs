﻿namespace UıLayer
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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(43, 101);
            button1.Name = "button1";
            button1.Size = new Size(192, 77);
            button1.TabIndex = 0;
            button1.Text = "Yemekhaneci Ekleme";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(43, 12);
            button2.Name = "button2";
            button2.Size = new Size(133, 58);
            button2.TabIndex = 1;
            button2.Text = "Çıkış Yap";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Admin_Detay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 554);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Admin_Detay";
            Text = "Admin_Detay";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
    }
}