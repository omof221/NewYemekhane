using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YemekhaneDataAccesLayer.Context;
using YemekhaneEntityLayer.Entities;

namespace UıLayer
{
    public partial class YeniOkutmaEkleForm : Form
    {
        private int calisanID;
        public YeniOkutmaEkleForm()
        {
            InitializeComponent();
            this.calisanID = calisanID;
        }

        private void YeniOkutmaEkleForm_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Focus();
            ListeleOkutmalar();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        private void ListeleOkutmalar()
        {
            using (var context = new YemekhaneContext())
            {
                var liste = context.Okutmalar
                    .Include(o => o.calisan)
                    .Select(o => new
                    {
                        o.OkutmalarID,
                        AdSoyad = o.calisan.calisanIsmi + " " + o.calisan.calisanSoyad,
                        o.OkutmaTarihi,
                        o.jokerGecis,
                        o.gecisCount,
                        o.aktif
                    })
                    .ToList()
                    .OrderByDescending(x => x.aktif)              // önce aktif = true
                    .ThenByDescending(x => x.aktif ? x.OkutmaTarihi : DateTime.MinValue) // aktif olanları en yeni başa
                    .ThenBy(x => !x.aktif ? x.OkutmaTarihi : DateTime.MaxValue)          // pasif olanları en eski başa
                    .ToList();

                dataGridView1.DataSource = liste;
            }
        }
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            string girilenKartID = maskedTextBox1.Text.Trim();

            if (girilenKartID.Length != 10)
                return;

            using (var context = new YemekhaneContext())
            {
                var calisan = context.Calisanlar
                    .FirstOrDefault(c => c.calisanKartNo == girilenKartID && c.aktiflik);

                if (calisan == null)
                {
                    MessageBox.Show("❗ Bu kart ile kayıtlı aktif bir çalışan bulunamadı.");
                    maskedTextBox1.Clear();
                    maskedTextBox1.Focus();
                    return;
                }

                DateTime bugun = DateTime.Today;

                // 1️⃣ Bugünkü aktif geçişleri çek
                var bugunkuGecisler = context.Okutmalar
                    .Where(o => o.calisanID == calisan.calisanID && o.OkutmaTarihi.Date == bugun && o.aktif && !o.jokerGecis)
                    .OrderBy(o => o.OkutmaTarihi)
                    .ToList();

                // 2️⃣ O gün yapılmış aktif geçiş sayısı
                int bugunkuGecisSayisi = bugunkuGecisler.Count;

                // 3️⃣ İlk geçişteki izinli geçiş sayısını referans al
                int izinliGecisSayisi = bugunkuGecisler.FirstOrDefault()?.gecisCount ?? 1;

                if (bugunkuGecisSayisi >= izinliGecisSayisi)
                {
                    MessageBox.Show("⚠️ Bu çalışanın bugünkü geçiş hakkı dolmuştur.");
                    maskedTextBox1.Clear();
                    maskedTextBox1.Focus();
                    return;
                }

                // ✅ Yeni geçiş ekle
                Okutmalar yeniOkutma = new Okutmalar
                {
                    calisanID = calisan.calisanID,
                    OkutmaTarihi = DateTime.Now,
                    aktif = true,
                    jokerGecis = false,
                    gecisCount = izinliGecisSayisi,
                    jokerGecisCount = 1
                };

                context.Okutmalar.Add(yeniOkutma);
                context.SaveChanges();

                ListeleOkutmalar(); // datagrid güncelle

                maskedTextBox1.Clear();
                maskedTextBox1.Focus();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen önce bir satır seçin.");
                return;
            }

            // Seçili satırdan OkutmalarID'yi al
            int okutmaID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["OkutmalarID"].Value);

            using (var context = new YemekhaneContext())
            {
                var okutma = context.Okutmalar
                    .Include(o => o.calisan)
                    .FirstOrDefault(o => o.OkutmalarID == okutmaID);

                if (okutma == null)
                {
                    MessageBox.Show("Okutma kaydı bulunamadı.");
                    return;
                }

                // Onay mesajı
                var adSoyad = okutma.calisan.calisanIsmi + " " + okutma.calisan.calisanSoyad;
                var result = MessageBox.Show($"Seçilen {adSoyad} isimli çalışanın geçişini pasif yapmak istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    okutma.aktif = false;
                    context.SaveChanges();
                    MessageBox.Show("Geçiş pasif hale getirildi.");
                    ListeleOkutmalar(); // Listeyi yenile
                }
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
