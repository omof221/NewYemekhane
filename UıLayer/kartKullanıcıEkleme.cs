using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YemekhaneDataAccesLayer.Context;
using YemekhaneEntityLayer.Entities;

namespace UıLayer
{
    public partial class kartKullanıcıEkleme : Form
    {
        public kartKullanıcıEkleme()
        {
            InitializeComponent();
            Directory.CreateDirectory(Path.GetDirectoryName(dosyaYolu));
            //timer1.Start();
        }
        private string dosyaYolu = @"C:\Users\Hp\OneDrive\Desktop\KartVerileri";
        private string oncekiKartID = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //yoruma aldım
        //private void kartKullanıcıEkleme_Load(object sender, EventArgs e)
        //{

        private void kartKullanıcıEkleme_Load(object sender, EventArgs e)
        {

            //maskedTextBoxKartID.Focus();
            //checkBoxAktif.Checked = true;
        }


        private void maskedTextBoxKartID_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBoxKartID.Text.Length >= 10) // Kart ID uzunluk kontrolü
            {
                string kartID = maskedTextBoxKartID.Text.Trim();

                if (kartID != oncekiKartID)
                {
                    File.AppendAllText(dosyaYolu, kartID + Environment.NewLine);
                    //lblDurum.Text = $"Kart ID yazıldı: {kartID}";
                    oncekiKartID = kartID;
                }

                maskedTextBoxKartID.Clear(); // bir sonraki okutma için temizle
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!maskedTextBoxKartID.Focused)
                maskedTextBoxKartID.Focus(); // Fokus hep burada kalsın
        }

        //yoruma aldım
        //private void checkBoxAktif_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBoxAktif.Checked)
        //        checkBoxPasif.Checked = false;
        //}

        private void checkBoxAktif_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBoxAktif.Checked)
            //    checkBoxPasif.Checked = false;
        }

        private void checkBoxPasif_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBoxPasif.Checked)
            //    checkBoxAktif.Checked = false;
        }
        //YemekhaneContext<Calisan> 
        private void button1_Click(object sender, EventArgs e)
        {
            string kartID = maskedTextBoxKartID.Text.Trim();
            string isim = txtIsim.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string gorev = txtGorevv.Text.Trim();
            //bool aktifMi = checkBoxAktif.Checked;
            if (string.IsNullOrWhiteSpace(kartID) ||
                string.IsNullOrWhiteSpace(isim) ||
                string.IsNullOrWhiteSpace(soyad) ||
                string.IsNullOrWhiteSpace(gorev))
            {
                MessageBox.Show("Tüm alanlar (Kart ID, İsim, Soyad, Görev) doldurulmalıdır.");
                return;
            }

            // 2. Kontrol: Kart ID sadece rakam mı ve 10 karakter mi?
            if (!Regex.IsMatch(kartID, @"^\d{10}$"))
            {
                MessageBox.Show("Kart ID 10 haneli bir sayı olmalıdır.");
                return;
            }

            // 3. Kontrol: Kart ID '00' ile başlamıyorsa kullanıcıya onay sor
            if (!kartID.StartsWith("00"))
            {
                DialogResult sonuc = MessageBox.Show($"Kart numaranız ({kartID}) kayıt edilecek. Onaylıyor musunuz?",
                                                      "Kart Onayı",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (sonuc != DialogResult.Yes)
                {
                    MessageBox.Show("Kayıt işlemi iptal edildi.");
                    return;
                }
            }

            // 4. Kontrol: Aynı Kart ID veritabanında var mı?
            using (var context = new YemekhaneContext())
            {
                bool kartZatenVar = context.Calisanlar.Any(c => c.calisanKartNo == kartID);

                if (kartZatenVar)
                {
                    MessageBox.Show("Bu Kart ID zaten kayıtlı.");
                    return;
                }

                var yeniCalisan = new Calisan
                {
                    calisanKartNo = kartID,
                    calisanIsmi = isim,
                    calisanSoyad = soyad,
                    calisanGorevi = gorev,
                    //yoruma aldım
                    //aktiflik = aktifMi 
                };

                context.Calisanlar.Add(yeniCalisan);
                context.SaveChanges();

                MessageBox.Show("Çalışan başarıyla kaydedildi.");

                // Temizle
                maskedTextBoxKartID.Clear();
                txtIsim.Clear();
                txtSoyad.Clear();
                txtGorevv.Clear();
                //checkBoxAktif.Checked = true;
                //checkBoxPasif.Checked = false;
                maskedTextBoxKartID.Focus();
                comboBoxAktiflik.SelectedIndex = 0;

                CalisanlariListele(); // Güncel listeyi göster
            }

        }

        private void maskedTextBoxKartID_TextChanged_1(object sender, EventArgs e)
        {
            string kartID = maskedTextBoxKartID.Text.Trim();

            string dosyaYolu = @"C:\Users\Hp\OneDrive\Desktop\KartVerileri";
            Directory.CreateDirectory(Path.GetDirectoryName(dosyaYolu));
            File.AppendAllText(dosyaYolu, kartID + Environment.NewLine);

            //lblDurum.Text = $"Yazıldı: {kartID}";
            maskedTextBoxKartID.Clear(); // temizle

        }

        private void kartKullanıcıEkleme_Shown(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                maskedTextBoxKartID.Focus();
                maskedTextBoxKartID.SelectionStart = 0; // imleç en başa gelsin
            });
        }

        private void checkBoxAktif_CheckedChanged_1(object sender, EventArgs e)
        {

        }
        private void CalisanlariListele()
        {
            using (var context = new YemekhaneContext())
            {
                // Önce aktif olanlar, sonra pasif olanlar, ikisi de kendi içinde sondan başa doğru sıralanacak
                var liste = context.Calisanlar
                    .Select(c => new
                    {
                        ID = c.calisanID,
                        AktifMi = c.aktiflik,
                        Isim = c.calisanIsmi,
                        Soyad = c.calisanSoyad,
                        Gorev = c.calisanGorevi,
                        KartNo = c.calisanKartNo
                    })
                    .OrderByDescending(c => c.AktifMi)  // Aktif olanlar önce
                    .ThenByDescending(c => c.ID)        // Aynı gruptakilerde son eklenen önce
                    .ToList();

                dataGridView1.DataSource = liste;
            }
        }



        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int secilenCalisanID = 0;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (secilenCalisanID == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir satır seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new YemekhaneContext())
            {
                var calisan = context.Calisanlar.FirstOrDefault(c => c.calisanID == secilenCalisanID);
                if (calisan != null)
                {
                    calisan.calisanKartNo = maskedTextBoxKartID.Text.Trim();
                    calisan.calisanIsmi = txtIsim.Text.Trim();
                    calisan.calisanSoyad = txtSoyad.Text.Trim();
                    calisan.calisanGorevi = txtGorevv.Text.Trim();
                    calisan.aktiflik = comboBoxAktiflik.SelectedItem.ToString() == "Aktif";

                    context.SaveChanges();

                    MessageBox.Show("Çalışan bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Temizle ve resetle
                    secilenCalisanID = 0;
                    txtIsim.Clear();
                    txtSoyad.Clear();
                    txtGorevv.Clear();
                    maskedTextBoxKartID.Clear();
                    comboBoxAktiflik.SelectedIndex = 0;
                    maskedTextBoxKartID.Focus();

                    // Listeyi yenile
                    CalisanlariListele();
                }
                else
                {
                    MessageBox.Show("Seçilen çalışan bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];

                // ID'yi kaydet
                secilenCalisanID = Convert.ToInt32(satir.Cells["ID"].Value);

                // Form alanlarını doldur
                maskedTextBoxKartID.Text = satir.Cells["KartNo"].Value.ToString();
                txtIsim.Text = satir.Cells["Isim"].Value.ToString();
                txtSoyad.Text = satir.Cells["Soyad"].Value.ToString();
                txtGorevv.Text = satir.Cells["Gorev"].Value.ToString();

                // Aktiflik durumunu combobox'a yükle
                bool aktiflik = Convert.ToBoolean(satir.Cells["AktifMi"].Value);
                comboBoxAktiflik.SelectedItem = aktiflik ? "Aktif" : "Pasif";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secilenCalisanID = 0;
            txtIsim.Clear();
            txtSoyad.Clear();
            txtGorevv.Clear();
            maskedTextBoxKartID.Clear();
            comboBoxAktiflik.SelectedIndex = 0;
            maskedTextBoxKartID.Focus();

            // Listeyi yenile
            CalisanlariListele();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (secilenCalisanID == 0)
            {
                MessageBox.Show("Lütfen pasifleştirmek için bir çalışan seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new YemekhaneContext())
            {
                var calisan = context.Calisanlar.FirstOrDefault(c => c.calisanID == secilenCalisanID);

                if (calisan != null)
                {
                    if (!calisan.aktiflik)
                    {
                        MessageBox.Show("Seçilen çalışanın durumu zaten PASİF!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Onay mesajı
                    DialogResult onay = MessageBox.Show(
                        $"Adı Soyadı: {calisan.calisanIsmi} {calisan.calisanSoyad}\nGörevi: {calisan.calisanGorevi}\n\nBu çalışanı PASİF yapmak istiyor musunuz?",
                        "Pasifleştirme Onayı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (onay == DialogResult.Yes)
                    {
                        calisan.aktiflik = false;
                        context.SaveChanges();

                        MessageBox.Show("Çalışan başarıyla pasif hale getirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Temizle ve sıfırla
                        secilenCalisanID = 0;
                        txtIsim.Clear();
                        txtSoyad.Clear();
                        txtGorevv.Clear();
                        maskedTextBoxKartID.Clear();
                        comboBoxAktiflik.SelectedIndex = 0;
                        maskedTextBoxKartID.Focus();

                        // Listeyi yenile
                        CalisanlariListele();
                    }
                }
                else
                {
                    MessageBox.Show("Seçilen çalışan veritabanında bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}