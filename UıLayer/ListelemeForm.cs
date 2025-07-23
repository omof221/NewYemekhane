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
using YemekhaneDataAccesLayer.Repositories;
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
            var aramaForm = new PersonelAramaForm();
            aramaForm.SecilenCalisanlarGonder += CalisanFiltrele;
            aramaForm.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ListelemeForm_Load(object sender, EventArgs e)
        {
            using (var context = new YemekhaneContext())
            {
                var okutmaListesi = context.Okutmalar
                .Include(o => o.calisan)
                .Where(o => o.calisan.aktiflik == true)
                .Select(o => new
                {
                   OkutmaID = o.OkutmalarID,
                   CalisanID = o.calisanID,
                   CalisanAdi = o.calisan.calisanIsmi + " " + o.calisan.calisanSoyad, // Ad + Soyad
                   Tarih = o.OkutmaTarihi,
                   JokerGecis = o.jokerGecis,
                   GecisSayisi = o.gecisCount
                })
               .ToList();
                dataGridView1.DataSource = okutmaListesi;

                dataGridView1.Columns["OkutmaID"].HeaderText = "Okutma ID";
                dataGridView1.Columns["CalisanID"].HeaderText = "Çalışan ID";
                dataGridView1.Columns["CalisanAdi"].HeaderText = "Çalışan Adı";
                dataGridView1.Columns["Tarih"].HeaderText = "Tarih";
                //dataGridView1.Columns["JokerGecis"].HeaderText = "Joker Geçiş";
                dataGridView1.Columns["GecisSayisi"].HeaderText = "Geçiş Sayısı";
            }
            comboBox1.Items.Add("Alınan Toplam Yemek Raporu");
            comboBox1.Items.Add("Detaylı Yemek Raporu");
            comboBox1.SelectedIndex = 0;
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
        private void CalisanFiltrele(List<int> calisanIdListesi)
        {
            using (var context = new YemekhaneContext())
            {
                var okutmaListesi = context.Okutmalar
                    .Include(o => o.calisan)
                    .Where(o => calisanIdListesi.Contains(o.calisanID))
                    .Select(o => new
                    {
                        OkutmaID = o.OkutmalarID,
                        CalisanID = o.calisanID,
                        CalisanAdi = o.calisan.calisanIsmi + " " + o.calisan.calisanSoyad,
                        Tarih = o.OkutmaTarihi,
                        JokerGecis = o.jokerGecis,
                        GecisSayisi = o.gecisCount
                    })
                    .ToList();

                dataGridView1.DataSource = okutmaListesi;
            }
        }

    }
}