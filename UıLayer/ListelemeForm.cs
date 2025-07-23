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


        private void button1_Click_2(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult sonuc = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (sonuc == DialogResult.Yes)
                {
                    // Veriyi al
                    var selectedRow = dataGridView1.CurrentRow.DataBoundItem as Okutmalar;

                    if (selectedRow != null)
                    {
                        int secilenId = selectedRow.OkutmalarID;

                        // Doğrudan manuel silme işlemi
                        using (var context = new YemekhaneContext())
                        {
                            var entity = context.Okutmalar.FirstOrDefault(x => x.OkutmalarID == secilenId);

                            if (entity != null)
                            {
                                context.Okutmalar.Remove(entity); // Sil
                                context.SaveChanges(); // Kaydet

                                MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ListelemeForm_Load(null, null); // Listeyi yenile
                            }
                            else
                            {
                                MessageBox.Show("Kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }











    }
}