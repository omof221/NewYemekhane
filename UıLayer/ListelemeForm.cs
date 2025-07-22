using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using YemekhaneDataAccesLayer.Context; 
using YemekhaneEntityLayer.Entities;   


namespace UıLayer
{
    public partial class ListelemeForm : Form
    {
        private DataGridView dataGridViewOkutmalar; // Formun üstüne ekle

        public ListelemeForm()
        {
            InitializeComponent();

            dataGridViewOkutmalar = new DataGridView();
            dataGridViewOkutmalar.Name = "dataGridViewOkutmalar";
            dataGridViewOkutmalar.Size = new Size(800, 300);
            dataGridViewOkutmalar.Location = new Point(20, 20);
            this.Controls.Add(dataGridViewOkutmalar);
        }

        private void cmbRaporSeçimi(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ListelemeForm_Load(object sender, EventArgs e)
        {
            using (var context = new YemekhaneContext())
            {
                var okutmaListesi = context.Okutmalar.ToList();
                dataGridViewOkutmalar.DataSource = okutmaListesi;

                dataGridViewOkutmalar.Columns[0].HeaderText = "Kart No";
                dataGridViewOkutmalar.Columns[1].HeaderText = "Kart No";
                dataGridViewOkutmalar.Columns[2].HeaderText = "Okutma Tarihi";
                dataGridViewOkutmalar.Columns[3].HeaderText = "Çalışan Adı";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
