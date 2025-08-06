using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YemekhaneDataAccesLayer.Context;
using YemekhaneEntityLayer.Entities;
using ClosedXML.Excel;

namespace UıLayer
{
    public partial class ListelemeForm : Form
    {
        private bool tumPersonellerSecili = true;
        private List<int> secilenCalisanlar = new List<int>();

        public ListelemeForm()
        {
            InitializeComponent();
        }
        private void ListeleOkutmalar()
        {
            DateTime baslangic = dtpBaslangic.Value.Date;
            DateTime bitis = dtpBitis.Value.Date.AddDays(1).AddSeconds(-1);

            using (var context = new YemekhaneContext())
            {
                var query = context.Okutmalar
                    .Include(o => o.calisan)
                    .Where(o => o.aktif && o.calisan.aktiflik && o.OkutmaTarihi >= baslangic && o.OkutmaTarihi <= bitis);

                if (!tumPersonellerSecili && secilenCalisanlar.Any())
                {
                    query = query.Where(o => secilenCalisanlar.Contains(o.calisanID));
                }

                var raporListesi = query.Select(o => new
                {
                    OkutmaID = o.OkutmalarID,
                    CalisanID = o.calisanID,
                    CalisanAdi = o.calisan.calisanIsmi + " " + o.calisan.calisanSoyad,
                    Tarih = o.OkutmaTarihi,
                    JokerGecis = o.jokerGecis,
                    GecisSayisi = o.gecisCount
                }).ToList();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = raporListesi;
                dataGridView1.Columns["OkutmaID"].HeaderText = "Okutma ID";
                dataGridView1.Columns["CalisanID"].HeaderText = "Çalışan ID";
                dataGridView1.Columns["CalisanAdi"].HeaderText = "Çalışan Adı";
                dataGridView1.Columns["Tarih"].HeaderText = "Tarih";
                dataGridView1.Columns["GecisSayisi"].HeaderText = "Geçiş Sayısı";
                ApplyZebraStyle(dataGridView1);

            }
        }

        private void ListelemeForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Alınan Toplam Yemek Raporu");
            comboBox1.Items.Add("Detaylı Yemek Raporu");
            comboBox1.SelectedIndex = 0;

            //cbTumPersonel.Checked = true;
            ListeleOkutmalar();

            // 📌 DataGridView tam otursun
            dataGridView1.Dock = DockStyle.Top; // Formun üst kısmını kaplasın
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Başlık stilini güzelleştir
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 14);

            // 🧠 Form genişledikçe otomatik olarak boyutu koru
            this.Resize += (s, ev) =>
            {
                dataGridView1.Width = this.ClientSize.Width;
            };
        }

        private void cmbRaporSeçimi(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Alınan Toplam Yemek Raporu");
            comboBox1.Items.Add("Detaylı Yemek Raporu");
            comboBox1.SelectedIndex = 0;

            //cbTumPersonel.Checked = true;
            ListeleOkutmalar();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

        }

        //private void cmbRaporSeçimi(object sender, EventArgs e) { }

        private void dtpBaslangic_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBaslangic.Value > dtpBitis.Value)
            {
                MessageBox.Show("Başlangıç tarihi, bitiş tarihinden büyük olamaz.", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpBaslangic.Value = dtpBitis.Value.Date;
                return;
            }

            ListeleOkutmalar();
        }

        private void dtpBitis_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBitis.Value < dtpBaslangic.Value)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden küçük olamaz.", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpBitis.Value = dtpBaslangic.Value.Date;
                return;
            }

            ListeleOkutmalar();
        }

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    using (var context = new YemekhaneContext())
        //    {
        //        if (cbTumPersonel.Checked)
        //        {
        //            secilenCalisanlar = context.Calisanlar.Where(c => c.aktiflik).Select(c => c.calisanID).ToList();
        //            tumPersonellerSecili = true;
        //        }
        //        else
        //        {
        //            secilenCalisanlar.Clear();
        //            tumPersonellerSecili = false;
        //        }
        //    }
        //    ListeleOkutmalar();
        //}

        private void CalisanFiltrele(List<int> calisanIdListesi)
        {
            secilenCalisanlar = calisanIdListesi;
            tumPersonellerSecili = false;
            ListeleOkutmalar();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var aramaForm = new PersonelAramaForm();
            aramaForm.SecilenCalisanlarGonder += CalisanFiltrele;
            aramaForm.ShowDialog();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string klasorYolu = @"C:\Users\Hp\OneDrive\Desktop\excelçıktıları";
            string zamanDamgasi = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            string dosyaAdi = $"Yemek_{zamanDamgasi}.xlsx";
            string dosyaYolu = Path.Combine(klasorYolu, dosyaAdi);

            try
            {
                using (var context = new YemekhaneContext())
                {
                    DateTime baslangic = dtpBaslangic.Value.Date;
                    DateTime bitis = dtpBitis.Value.Date.AddDays(1).AddSeconds(-1);

                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Yemek Raporu");

                        if (comboBox1.SelectedItem.ToString() == "Alınan Toplam Yemek Raporu")
                        {
                            var query = context.Okutmalar.Include(o => o.calisan)
                                .Where(o => o.aktif && o.calisan.aktiflik && o.OkutmaTarihi >= baslangic && o.OkutmaTarihi <= bitis);

                            if (!tumPersonellerSecili && secilenCalisanlar.Any())
                            {
                                query = query.Where(o => secilenCalisanlar.Contains(o.calisanID));
                            }

                            var toplamlar = await query.GroupBy(o => new
                            {
                                o.calisanID,
                                o.calisan.calisanIsmi,
                                o.calisan.calisanSoyad,
                                o.calisan.calisanGorevi,
                                o.calisan.calisanKartNo
                            }).Select(g => new
                            {
                                g.Key.calisanID,
                                g.Key.calisanIsmi,
                                g.Key.calisanSoyad,
                                g.Key.calisanGorevi,
                                g.Key.calisanKartNo,
                                ToplamOkutmaSayisi = g.Count()
                            }).ToListAsync();

                            worksheet.Cell(1, 1).Value = "Çalışan ID";
                            worksheet.Cell(1, 2).Value = "Ad";
                            worksheet.Cell(1, 3).Value = "Soyad";
                            worksheet.Cell(1, 4).Value = "Görev";
                            worksheet.Cell(1, 5).Value = "Kart No";
                            worksheet.Cell(1, 6).Value = "Toplam Okutma";

                            int row = 2;
                            foreach (var t in toplamlar)
                            {
                                worksheet.Cell(row, 1).Value = t.calisanID;
                                worksheet.Cell(row, 2).Value = t.calisanIsmi;
                                worksheet.Cell(row, 3).Value = t.calisanSoyad;
                                worksheet.Cell(row, 4).Value = t.calisanGorevi;
                                worksheet.Cell(row, 5).Value = t.calisanKartNo;
                                worksheet.Cell(row, 6).Value = t.ToplamOkutmaSayisi;
                                row++;
                            }
                            worksheet.Columns().AdjustToContents();
                            worksheet.Style.Alignment.WrapText = true;
                            worksheet.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


                            var headerRange = worksheet.Range(1, 1, 1, 6); // 6 sütunluk başlık
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        }
                        else if (comboBox1.SelectedItem.ToString() == "Detaylı Yemek Raporu")
                        {
                            var okutmalar = await context.Okutmalar
                                .Include(o => o.calisan)
                                .Where(o => o.calisan.aktiflik && o.aktif && o.OkutmaTarihi >= baslangic && o.OkutmaTarihi <= bitis)
                                .Select(o => new
                                {
                                    OkutmaID = o.OkutmalarID,
                                    CalisanID = o.calisanID,
                                    Ad = o.calisan.calisanIsmi,
                                    Soyad = o.calisan.calisanSoyad,
                                    Tarih = o.OkutmaTarihi,
                                    JokerGecis = o.jokerGecis,
                                    GecisSayisi = o.gecisCount
                                }).ToListAsync();

                            worksheet.Cell(1, 1).Value = "Okutma ID";
                            worksheet.Cell(1, 2).Value = "Çalışan ID";
                            worksheet.Cell(1, 3).Value = "Ad";
                            worksheet.Cell(1, 4).Value = "Soyad";
                            worksheet.Cell(1, 5).Value = "Tarih";
                            worksheet.Cell(1, 6).Value = "Joker Geçiş";
                            worksheet.Cell(1, 7).Value = "Geçiş Sayısı";

                            int row = 2;
                            foreach (var o in okutmalar)
                            {
                                worksheet.Cell(row, 1).Value = o.OkutmaID;
                                worksheet.Cell(row, 2).Value = o.CalisanID;
                                worksheet.Cell(row, 3).Value = o.Ad;
                                worksheet.Cell(row, 4).Value = o.Soyad;
                                worksheet.Cell(row, 5).Value = o.Tarih.ToString("g");
                                worksheet.Cell(row, 6).Value = o.JokerGecis ? "Evet" : "Hayır";
                                worksheet.Cell(row, 7).Value = o.GecisSayisi;
                                row++;
                            }

                            // Görsel düzenlemeler:
                            worksheet.Columns().AdjustToContents();
                            var headerRange = worksheet.Range(1, 1, 1, 7);
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int okutmaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CalisanID"].Value);

                using (var context = new YemekhaneContext())
                {
                    var calisan = context.Okutmalar.FirstOrDefault(c => c.OkutmalarID == okutmaId);
                    if (calisan != null)
                    {
                        calisan.aktif = false;
                        context.SaveChanges();
                        MessageBox.Show("Çalışan pasif hale getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListeleOkutmalar();
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
                int calisanId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OkutmaID"].Value);

                using (var context = new YemekhaneContext())
                {
                    var calisan = context.Okutmalar.FirstOrDefault(c => c.OkutmalarID == calisanId);
                    if (calisan != null)
                    {
                        calisan.aktif = false;
                        context.SaveChanges();
                        MessageBox.Show("Çalışan pasif hale getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListeleOkutmalar();
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
                    //maskedTextBox1.Text = "";
                    //maskedTextBox1.SelectionStart = 0;
                    //maskedTextBox1.Focus();
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
                ApplyZebraStyle(dataGridView1);

                // dataGridView1.Columns["JokerGecis"].HeaderText = "Joker Geçiş"; // gerekirse aç
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 frmo = new Form1();
            frmo.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YemekhaneciAnaSayfa anaSayfa = new YemekhaneciAnaSayfa();
            anaSayfa.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void ApplyZebraStyle(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // 🧹 Seçilen Personel Listesini Sıfırla
            secilenCalisanlar.Clear();
            tumPersonellerSecili = true; // Tüm personeller aktif sayılır

            // 📅 Tarihleri Bugünün Tarihine Çek
            dtpBaslangic.Value = DateTime.Today;
            dtpBitis.Value = DateTime.Today;

            // 🧠 Listeyi Tamamen Default Haliyle Güncelle
            ListeleOkutmalar();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
