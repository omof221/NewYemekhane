namespace UıLayer
{
    partial class YemekhaneciEklemeSayfası
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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            listBox1 = new ListBox();
            button1 = new Button();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(88, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(153, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 42);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 1;
            label1.Text = "İsim";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 92);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 3;
            label2.Text = "Soyisim";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(88, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(153, 27);
            textBox2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 138);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 5;
            label3.Text = "Mail";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(88, 131);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(153, 27);
            textBox3.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(-9, 200);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 7;
            label4.Text = "Kullancı Adı";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(88, 193);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(153, 27);
            textBox4.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 257);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 9;
            label5.Text = "Şifre";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(88, 250);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(153, 27);
            textBox5.TabIndex = 8;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(473, 16);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(447, 204);
            listBox1.TabIndex = 10;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(88, 298);
            button1.Name = "button1";
            button1.Size = new Size(153, 68);
            button1.TabIndex = 11;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(475, 269);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(445, 197);
            dataGridView2.TabIndex = 12;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // YemekhaneciEklemeSayfası
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1295, 506);
            Controls.Add(dataGridView2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "YemekhaneciEklemeSayfası";
            Text = "YemekhaneciEklemeSayfası";
            Load += YemekhaneciEklemeSayfası_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
        private ListBox listBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn İsim;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn username;
        private DataGridView dataGridView2;
    }
}