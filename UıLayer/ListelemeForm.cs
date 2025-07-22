using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                var okutmaListesi = context.Okutmalar
                    .Include(o => o.calisan) // çalışanın bilgilerini al
                    .ToList();

                dataGridView1.DataSource = okutmaListesi;

                // Kolon başlıklarını güncelle
                dataGridView1.Columns["OkutmalarID"].HeaderText = "Okutma ID";
                dataGridView1.Columns["calisanID"].HeaderText = "Çalışan ID";
                dataGridView1.Columns["OkutmaTarihi"].HeaderText = "Tarih";
                dataGridView1.Columns["jokerGecis"].HeaderText = "Joker Geçiş";
                dataGridView1.Columns["gecisCount"].HeaderText = "Geçiş Sayısı";
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

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
