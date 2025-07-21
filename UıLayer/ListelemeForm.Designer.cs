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
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            button1 = new Button();
            checkBox1 = new CheckBox();
            button2 = new Button();
            button3 = new Button();
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
            label1.Location = new Point(603, 15);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 1;
            label1.Text = "Başlangıç Tarihi:";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(603, 68);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 2;
            label2.Text = "Bitiş Tarihi:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(750, 10);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(750, 63);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(385, 10);
            button1.Name = "button1";
            button1.Size = new Size(145, 44);
            button1.TabIndex = 5;
            button1.Text = "Personel Seçimi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(397, 67);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(119, 24);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Tüm Personel";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button2
            // 
            button2.Location = new Point(1018, 5);
            button2.Name = "button2";
            button2.Size = new Size(270, 49);
            button2.TabIndex = 8;
            button2.Text = "Rapor Çıkar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(1018, 67);
            button3.Name = "button3";
            button3.Size = new Size(270, 50);
            button3.TabIndex = 10;
            button3.Text = "Excel'e aktar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ListelemeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 824);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "ListelemeForm";
            Text = "ListelemeForm";
            Load += ListelemeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Button button1;
        private CheckBox checkBox1;
        private Button button2;
        private Button button3;
    }
}