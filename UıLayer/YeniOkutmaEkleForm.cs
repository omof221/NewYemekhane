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
using System.Media;
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
            maskedTextBox1.Mask = "0000000000"; // 10 haneli rakam
            maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            maskedTextBox1.ResetOnPrompt = true;
            maskedTextBox1.ResetOnSpace = true;
            maskedTextBox1.SkipLiterals = true;

            maskedTextBox1.Clear();
            maskedTextBox1.Focus();
            maskedTextBox1.SelectionStart = 0; // imleç tam başa

            ListeleOkutmalar();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        private void ListeleOkutmalar()
        {
            using (var context = new YemekhaneContext())
            {
                DateTime bugun = DateTime.Today;
                DateTime yarin = bugun.AddDays(1);

                var liste = context.Okutmalar
                    .Include(o => o.calisan)
                    .Where(o => o.aktif == true && o.OkutmaTarihi >= bugun && o.OkutmaTarihi < yarin)
                    .Select(o => new
                    {
                        o.OkutmalarID,
                        AdSoyad = o.calisan.calisanIsmi + " " + o.calisan.calisanSoyad,
                        o.OkutmaTarihi,
                        o.jokerGecis,
                        o.gecisCount,
                        o.aktif
                    })
                    .OrderByDescending(x => x.OkutmaTarihi)
                    .ToList();

                dataGridView1.DataSource = liste;

                // ✅ Zebra efekti (alternatif satır renkleri)
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            //using (var context = new YemekhaneContext())
            //{
            //    DateTime bugun = DateTime.Today;
            //    DateTime yarin = bugun.AddDays(1);

            //    var liste = context.Okutmalar
            //        .Include(o => o.calisan)
            //        .Where(o => o.aktif == true && o.OkutmaTarihi >= bugun && o.OkutmaTarihi < yarin)
            //        .Select(o => new
            //        {
            //            o.OkutmalarID,
            //            AdSoyad = o.calisan.calisanIsmi + " " + o.calisan.calisanSoyad,
            //            o.OkutmaTarihi,
            //            o.jokerGecis,
            //            o.gecisCount,
            //            o.aktif
            //        })
            //        .OrderByDescending(x => x.OkutmaTarihi)
            //        .ToList();

            //    dataGridView1.DataSource = liste;

            //    // ✅ Zebra efekti (alternatif satır renkleri)
            //    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            //    dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            //    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            //    dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            //}
            using (var context = new YemekhaneContext())
            {
                DateTime bugun = DateTime.Today;
                DateTime yarin = bugun.AddDays(1);

                var liste = context.Okutmalar
                    .Include(o => o.calisan)
                    .Where(o => o.aktif == true && o.OkutmaTarihi >= bugun && o.OkutmaTarihi < yarin)
                    .Select(o => new
                    {
                        o.OkutmalarID,
                        AdSoyad = o.calisan.calisanIsmi + " " + o.calisan.calisanSoyad,
                        o.OkutmaTarihi,
                        o.jokerGecis,
                        o.gecisCount,
                        o.aktif
                    })
                    .OrderByDescending(x => x.OkutmaTarihi)
                    .ToList();

                dataGridView1.DataSource = liste;

                // ✅ Zebra efekti (alternatif satır renkleri)
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
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

                    this.BeginInvoke((MethodInvoker)(() =>
                    {
                        maskedTextBox1.SelectionStart = 0;
                    }));

                    return;
                }

                DateTime bugun = DateTime.Today;

                // 🔍 Bugünkü geçişleri al (aktif ve joker olmayanlar)
                var bugunkuGecisler = context.Okutmalar
                    .Where(o => o.calisanID == calisan.calisanID && o.OkutmaTarihi.Date == bugun && o.aktif && !o.jokerGecis)
                    .ToList();

                int bugunkuGecisSayisi = bugunkuGecisler.Count;
                int izinliGecisSayisi = calisan.gecisSayısı; // ✅ Artık geçiş hakkı buradan alınıyor

                if (bugunkuGecisSayisi >= izinliGecisSayisi)
                {
                    SoundPlayer player = new SoundPlayer(Application.StartupPath + @"\Kenan Doğulu - Ara Beni Lütfen (Official Video) #Festival [PHG83uTG3-8] (1).wav");
                    player.Play();

                    MessageBox.Show("⚠️ Bu çalışanın bugünkü geçiş hakkı dolmuştur.");

                    maskedTextBox1.Clear();
                    maskedTextBox1.Focus();

                    this.BeginInvoke((MethodInvoker)(() =>
                    {
                        maskedTextBox1.SelectionStart = 0;
                    }));

                    return;
                }

                // ✅ Geçiş izni varsa yeni geçişi kaydet
                Okutmalar yeniOkutma = new Okutmalar
                {
                    calisanID = calisan.calisanID,
                    OkutmaTarihi = DateTime.Now,
                    aktif = true,
                    jokerGecis = false,
                    gecisCount = izinliGecisSayisi,    // Bu alan artık gerekmiyorsa yine de saklanabilir
                    jokerGecisCount = 1
                };

                context.Okutmalar.Add(yeniOkutma);
                context.SaveChanges();

                ListeleOkutmalar();

                maskedTextBox1.Clear();
                maskedTextBox1.Focus();

                this.BeginInvoke((MethodInvoker)(() =>
                {
                    maskedTextBox1.SelectionStart = 0;
                }));
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen önce bir satır seçin.");
                maskedTextBox1.Clear();
                maskedTextBox1.Focus();
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
                maskedTextBox1.Clear();
                maskedTextBox1.Focus();
                maskedTextBox1.SelectionStart = Math.Max(0, maskedTextBox1.SelectionStart - 1);

            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCalisanAra_Click(object sender, EventArgs e)
        {
            CalisanSecForm form = new CalisanSecForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                int secilenCalisanID = (int)form.Tag;
                DateTime bugun = DateTime.Today;

                using (var context = new YemekhaneContext())
                {
                    var calisan = context.Calisanlar.FirstOrDefault(c => c.calisanID == secilenCalisanID && c.aktiflik);
                    if (calisan == null) return;

                    var bugunkuGecisler = context.Okutmalar
                        .Where(o => o.calisanID == secilenCalisanID && o.OkutmaTarihi.Date == bugun && o.aktif && !o.jokerGecis)
                        .ToList();

                    int bugunkuGecisSayisi = bugunkuGecisler.Count;
                    int izinliGecis = bugunkuGecisler.FirstOrDefault()?.gecisCount ?? 1;

                    if (bugunkuGecisSayisi >= izinliGecis)
                    {
                        MessageBox.Show("⚠️ Bu çalışanın bugünkü geçiş hakkı dolmuştur.");
                        maskedTextBox1.Clear();
                        maskedTextBox1.Focus();
                        return;
                    }

                    // Geçişi ekle
                    Okutmalar yeni = new Okutmalar
                    {
                        calisanID = secilenCalisanID,
                        OkutmaTarihi = DateTime.Now,
                        aktif = true,
                        jokerGecis = false,
                        gecisCount = izinliGecis,
                        jokerGecisCount = 1
                    };

                    context.Okutmalar.Add(yeni);
                    context.SaveChanges();
                    ListeleOkutmalar(); // Güncelleme
                    maskedTextBox1.Clear();
                    maskedTextBox1.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YemekhaneciAnaSayfa anaSayfa = new YemekhaneciAnaSayfa();       
            anaSayfa.Show();
            this.Close(); // Mevcut formu gizle, böylece kullanıcı ana sayfaya dönebilir
        }
    }
}
