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
    public partial class YeniYemekhaneCalisaniEkleme : Form
    {
        public YeniYemekhaneCalisaniEkleme()
        {
            InitializeComponent();
        }

        private void CalisanlariListele()
        {
            using (var context = new YemekhaneContext())
            {
                var calisanlar = context.yemekhaneCalisanlar
                    .OrderByDescending(c => c.durum) // true olanlar önce
                    .ThenBy(c => c.yemekhaneCalisanId) // eski kayıt önce
                    .ToList();

                dataGridView1.DataSource = calisanlar;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (var context = new YemekhaneContext())
            {
                var yeni = new YemekhaneCalisan
                {
                    tc = txtTc.Text.Trim(),
                    ad = txtAd.Text.Trim(),
                    soyad = txtSoyad.Text.Trim(),
                    kullaniciAdi = txtKullaniciAdi.Text.Trim(),
                    sifre = txtSifre.Text,
                    durum = cmbDurum.SelectedItem.ToString() == "Aktif"
                };

                context.yemekhaneCalisanlar.Add(yeni);
                context.SaveChanges();
            }

            MessageBox.Show("✅ Yeni çalışan eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CalisanlariListele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenId == 0)
            {
                MessageBox.Show("Lütfen bir satır seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult onay = MessageBox.Show("Bu çalışanı güncellemek istiyor musunuz?", "Güncelleme", MessageBoxButtons.YesNo);
            if (onay != DialogResult.Yes) return;

            using (var context = new YemekhaneContext())
            {
                var calisan = context.yemekhaneCalisanlar.FirstOrDefault(x => x.yemekhaneCalisanId == secilenId);
                if (calisan != null)
                {
                    calisan.tc = txtTc.Text.Trim();
                    calisan.ad = txtAd.Text.Trim();
                    calisan.soyad = txtSoyad.Text.Trim();
                    calisan.kullaniciAdi = txtKullaniciAdi.Text.Trim();
                    calisan.sifre = txtSifre.Text;
                    calisan.durum = cmbDurum.SelectedItem.ToString() == "Aktif";

                    context.SaveChanges();
                    MessageBox.Show("Güncelleme başarılı!", "Bilgi");
                    CalisanlariListele();
                }
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenId == 0)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult onay = MessageBox.Show("Bu çalışanı pasif hale getirmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (onay != DialogResult.Yes) return;

            using (var context = new YemekhaneContext())
            {
                var calisan = context.yemekhaneCalisanlar.FirstOrDefault(x => x.yemekhaneCalisanId == secilenId);
                if (calisan != null)
                {
                    calisan.durum = false;
                    context.SaveChanges();

                    MessageBox.Show("Çalışan pasif hale getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CalisanlariListele();
                }
            }
        }
        int secilenId = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var satir = dataGridView1.Rows[e.RowIndex];
                secilenId = Convert.ToInt32(satir.Cells["yemekhaneCalisanId"].Value);
                txtTc.Text = satir.Cells["tc"].Value.ToString();
                txtAd.Text = satir.Cells["ad"].Value.ToString();
                txtSoyad.Text = satir.Cells["soyad"].Value.ToString();
                txtKullaniciAdi.Text = satir.Cells["kullaniciAdi"].Value.ToString();
                txtSifre.Text = satir.Cells["sifre"].Value.ToString();
                cmbDurum.SelectedItem = (bool)satir.Cells["durum"].Value ? "Aktif" : "Pasif";
            }

        }

        private void YeniYemekhaneCalisaniEkleme_Load(object sender, EventArgs e)
        {
            CalisanlariListele();
            cmbDurum.Items.Add("Aktif");
            cmbDurum.Items.Add("Pasif");
            cmbDurum.SelectedIndex = 0;
        }
    }
}
