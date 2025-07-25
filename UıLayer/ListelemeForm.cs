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
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;


namespace UıLayer
{
    public partial class ListelemeForm : Form
    {
        private DataGridView dataGridViewOkutmalar; // Formun üstüne ekle

        public ListelemeForm()
        {
            InitializeComponent();

        }
        private async void ListelemeForm_Load(object sender, EventArgs e)
        {
            await Task.Delay(100); // ufak gecikme UI çizilsin diye

            maskedTextBox1.Text = "";
            maskedTextBox1.SelectionStart = 0;
            maskedTextBox1.Focus();

            using (var context = new YemekhaneContext())
            {
                var okutmaListesi = context.Okutmalar
                .Include(o => o.calisan)
                .Where(o => o.calisan.aktiflik == true && o.aktif == true)
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

                dataGridView1.Columns["OkutmaID"].HeaderText = "Okutma ID";
                dataGridView1.Columns["CalisanID"].HeaderText = "Çalışan ID";
                dataGridView1.Columns["CalisanAdi"].HeaderText = "Çalışan Adı";
                dataGridView1.Columns["Tarih"].HeaderText = "Tarih";
                dataGridView1.Columns["GecisSayisi"].HeaderText = "Geçiş Sayısı";
            }

            comboBox1.Items.Add("Alınan Toplam Yemek Raporu");
            comboBox1.Items.Add("Detaylı Yemek Raporu");
            comboBox1.SelectedIndex = 0;
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




        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            string klasorYolu = @"C:\Users\omery\OneDrive\Masaüstü\raporlar";

            // Daha okunabilir bir format: "23-07-2025_15-10-47"
            string zamanDamgasi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");

            string dosyaAdi = $"Okutmalar_{zamanDamgasi}.xlsx";
            string dosyaYolu = Path.Combine(klasorYolu, dosyaAdi);

            try
            {
                using (var context = new YemekhaneContext())
                {
                    // 📌 DateTimePicker'dan tarihleri al
                    DateTime baslangic = dtpBaslangic.Value.Date;
                    DateTime bitis = dtpBitis.Value.Date.AddDays(1).AddSeconds(-1); // Bitis tarihini dahil etmek için 23:59:59

                    var okutmalar = await context.Okutmalar
                        .Include(o => o.calisan)
                        .Where(o =>
                            o.calisan.aktiflik == true &&
                            o.aktif == true &&
                            o.OkutmaTarihi >= baslangic &&
                            o.OkutmaTarihi <= bitis
                        )
                        .Select(o => new
                        {
                            OkutmaID = o.OkutmalarID,
                            CalisanID = o.calisanID,
                            CalisanAdi = o.calisan.calisanIsmi + " " + o.calisan.calisanSoyad,
                            Tarih = o.OkutmaTarihi,
                            JokerGecis = o.jokerGecis,
                            GecisSayisi = o.gecisCount
                        })
                        .ToListAsync();

                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Okutmalar");

                        // Başlıklar
                        worksheet.Cell(1, 1).Value = "Okutma ID";
                        worksheet.Cell(1, 2).Value = "Çalışan ID";
                        worksheet.Cell(1, 3).Value = "Çalışan Adı";
                        worksheet.Cell(1, 4).Value = "Tarih";
                        worksheet.Cell(1, 5).Value = "Joker Geçiş";
                        worksheet.Cell(1, 6).Value = "Geçiş Sayısı";

                        int row = 2;
                        foreach (var o in okutmalar)
                        {
                            worksheet.Cell(row, 1).Value = o.OkutmaID;
                            worksheet.Cell(row, 2).Value = o.CalisanID;
                            worksheet.Cell(row, 3).Value = o.CalisanAdi;
                            worksheet.Cell(row, 4).Value = o.Tarih.ToString("g");
                            worksheet.Cell(row, 5).Value = o.JokerGecis ? "Evet" : "Hayır";
                            worksheet.Cell(row, 6).Value = o.GecisSayisi;
                            row++;
                        }

                        workbook.SaveAs(dosyaYolu);
                    }

                    MessageBox.Show("Excel dosyası başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Seçilen satırdan ÇalışanID'yi al
                int okutmaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CalisanID"].Value);

                using (var context = new YemekhaneContext())
                {
                    // İlgili çalışanı bul
                    var calisan = context.Okutmalar.FirstOrDefault(c => c.OkutmalarID == okutmaId);

                    if (calisan != null)
                    {
                        calisan.aktif = false; // Aktifliği false yap
                        context.SaveChanges(); // Veritabanına kaydet

                        MessageBox.Show("Çalışan pasif hale getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Listeyi yeniden yükle
                        ListelemeForm_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Çalışan bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Seçilen satırdan ÇalışanID'yi al
                int calisanId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OkutmaID"].Value);

                using (var context = new YemekhaneContext())
                {
                    // İlgili çalışanı bul
                    var calisan = context.Okutmalar.FirstOrDefault(c => c.OkutmalarID == calisanId);

                    if (calisan != null)
                    {
                        calisan.aktif = false; // Aktifliği false yap
                        context.SaveChanges(); // Veritabanına kaydet

                        MessageBox.Show("Çalışan pasif hale getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Listeyi yeniden yükle
                        ListelemeForm_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Çalışan bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dtpBaslangic_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpBitis_ValueChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            string girilenKartID = maskedTextBox1.Text.Replace(" ", "").Trim(); // Boşlukları temizle

            if (girilenKartID.Length != 10)
                return;

            using (var context = new YemekhaneContext())
            {
                // 1. Kart numarası ile eşleşen aktif çalışanı bul
                var calisan = context.Calisanlar
                    .FirstOrDefault(c => c.calisanKartNo == girilenKartID && c.aktiflik == true);

                if (calisan == null)
                {
                    MessageBox.Show("❗ Bu kart ile kayıtlı aktif bir çalışan bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedTextBox1.Text = "";
                    maskedTextBox1.SelectionStart = 0;
                    maskedTextBox1.Focus();
                    return;
                }

                // 2. Bugünkü yapılan geçiş sayısını bul
                DateTime bugun = DateTime.Today;
                int bugunkuGecisSayisi = context.Okutmalar
                    .Count(o => o.calisanID == calisan.calisanID && o.OkutmaTarihi.Date == bugun && o.aktif == true);

                // 3. Geçiş hakkını (gecisCount) en son aktif kayıttan al
                var sonOkutmaKaydi = context.Okutmalar
                    .Where(o => o.calisanID == calisan.calisanID && o.aktif == true)
                    .OrderByDescending(o => o.OkutmaTarihi)
                    .FirstOrDefault();

                int gecisHakki = sonOkutmaKaydi?.gecisCount ?? 1;

                if (bugunkuGecisSayisi >= gecisHakki)
                {
                    MessageBox.Show($"🚫 {calisan.calisanIsmi} {calisan.calisanSoyad} bugün maksimum {gecisHakki} kez yemek alabilir!\nLimit doldu.", "Yemek Hakkı Doldu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    maskedTextBox1.Text = "";
                    maskedTextBox1.SelectionStart = 0;
                    maskedTextBox1.Focus();
                    return;
                }

                // 4. Yeni okutma kaydı oluştur
                var yeniOkutma = new Okutmalar
                {
                    calisanID = calisan.calisanID,
                    OkutmaTarihi = DateTime.Now,
                    aktif = true,
                    jokerGecis = false,
                    gecisCount = gecisHakki
                };

                context.Okutmalar.Add(yeniOkutma);
                context.SaveChanges();

                MessageBox.Show($"✅ {calisan.calisanIsmi} {calisan.calisanSoyad} için okutma kaydı eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                maskedTextBox1.Text = "";
                maskedTextBox1.SelectionStart = 0;
                maskedTextBox1.Focus();
            }

            // 5. Listeyi güncelle
            OkutmalariYenile();



        }
        private void OkutmalariYenile()
        {
            using (var context = new YemekhaneContext())
            {
                var okutmaListesi = context.Okutmalar
                    .Include(o => o.calisan)
                    .Where(o => o.calisan.aktiflik == true && o.aktif == true)
                    .OrderByDescending(o => o.OkutmaTarihi)
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

                dataGridView1.DataSource = null; // önce temizle
                dataGridView1.DataSource = okutmaListesi;

                dataGridView1.Columns["OkutmaID"].HeaderText = "Okutma ID";
                dataGridView1.Columns["CalisanID"].HeaderText = "Çalışan ID";
                dataGridView1.Columns["CalisanAdi"].HeaderText = "Çalışan Adı";
                dataGridView1.Columns["Tarih"].HeaderText = "Tarih";
                dataGridView1.Columns["GecisSayisi"].HeaderText = "Geçiş Sayısı";
                // dataGridView1.Columns["JokerGecis"].HeaderText = "Joker Geçiş"; // gerekirse aç
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 frmo = new Form1();
            frmo.ShowDialog();  
            this.Hide();
        }
    }
}