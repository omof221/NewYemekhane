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
using static UıLayer.yemekhaneCalisanGirisDetay;

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
        //yamok
        private string dosyaYolu = @"C:\Users\Hp\OneDrive\Desktop\KartVerileri";
        //omof
        //private string dosyaYolu = @"C:\Users\omery\OneDrive\Masaüstü\kartverileri";
        private string oncekiKartID = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void mskTxtSıfırlayıcı()
        {
            //maskedTextBoxKartID.Clear();
            //comboBoxAktiflik.SelectedIndex = 0;
            //maskedTextBoxKartID.Focus();
            //if (maskedTextBoxKartID.SelectionStart > 0)
            //{
            //    maskedTextBoxKartID.SelectionStart -= 1;
            //}
            maskedTextBoxKartID.Mask = "0000000000"; // 10 haneli rakam
            maskedTextBoxKartID.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            maskedTextBoxKartID.ResetOnPrompt = true;
            maskedTextBoxKartID.ResetOnSpace = true;
            maskedTextBoxKartID.SkipLiterals = true;

            maskedTextBoxKartID.Clear();
            maskedTextBoxKartID.Focus();
            int pos = maskedTextBoxKartID.SelectionStart;

            // Eğer imleç zaten başta değilse, bir birim sola kaydır
            if (pos > 0)
            {
                maskedTextBoxKartID.SelectionStart = pos - 1;
            }
            maskedTextBoxKartID.SelectionStart = 0; // imleç tam başa
            maskedTextBoxKartID.SelectionStart = Math.Max(0, maskedTextBoxKartID.SelectionStart - 1);
            this.BeginInvoke((MethodInvoker)(() =>
            {
               maskedTextBoxKartID.SelectionStart = 0;
                maskedTextBoxKartID.SelectionStart = Math.Max(0, maskedTextBoxKartID.SelectionStart - 1);
            }));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //yoruma aldım
        //private void kartKullanıcıEkleme_Load(object sender, EventArgs e)
        //{

        private void kartKullanıcıEkleme_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;         // İsteğe bağlı: kenarlık kaldırılır
            this.StartPosition = FormStartPosition.CenterScreen; // Ekranın ortasında başlasın
            comboBoxAktiflik.Items.Clear();
            comboBoxAktiflik.Items.Add("Aktif");
            comboBoxAktiflik.Items.Add("Pasif");
            comboBoxAktiflik.SelectedIndex = 0;
            CalisanlariListele();
            //checkBoxAktif.Checked = true;

            // ✅ TextBox ve diğer input kontrollerin yazı boyutunu büyüt
            txtIsim.Font = new System.Drawing.Font("Segoe UI", 14);
            txtSoyad.Font = new System.Drawing.Font("Segoe UI", 14);
            txtGorevv.Font = new System.Drawing.Font("Segoe UI", 14);
            txtsicil.Font = new System.Drawing.Font("Segoe UI", 14);
            txtgecis.Font = new System.Drawing.Font("Segoe UI", 14);
            maskedTextBoxKartID.Font = new System.Drawing.Font("Segoe UI", 14);
            comboBoxAktiflik.Font = new System.Drawing.Font("Segoe UI", 14);
            txtgecis.Text = "1";


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

                //maskedTextBoxKartID.Text = "";
                //maskedTextBoxKartID.SelectionStart = 0;
                mskTxtSıfırlayıcı();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!maskedTextBoxKartID.Focused)
                /* maskedTextBoxKartID.Focus();*/
                mskTxtSıfırlayıcı();
            // Fokus hep burada kalsın
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
            string sicil = txtsicil.Text.Trim();
            string gecis = txtgecis.Text.Trim();
            bool aktifMi = comboBoxAktiflik.SelectedIndex == 0; // "Aktif" seçiliyse true, "Pasif" seçiliyse false  

            // 1. Kontrol: Tüm alanlar dolu mu?
            if (string.IsNullOrWhiteSpace(kartID) ||
                string.IsNullOrWhiteSpace(isim) ||
                string.IsNullOrWhiteSpace(soyad) ||
                string.IsNullOrWhiteSpace(gorev) ||
                string.IsNullOrWhiteSpace(sicil) ||
                string.IsNullOrWhiteSpace(gecis))
            {
                MessageBox.Show("Tüm alanlar (Kart ID, İsim, Soyad, Görev, Sicil, Günlük Geçiş Sayısı) doldurulmalıdır.");
                return;
            }

            // 2. Kontrol: Kart ID sadece rakam mı ve 10 karakter mi?
            if (!Regex.IsMatch(kartID, @"^\d{10}$"))
            {
                MessageBox.Show("Kart ID 10 haneli bir sayı olmalıdır.");
                return;
            }

            // 3. Kontrol: txtgecis alanı sayı mı?
            if (!int.TryParse(gecis, out int gecisSayisi))
            {
                MessageBox.Show("Günlük geçiş sayısı sadece sayısal bir değer olmalıdır.");
                txtgecis.Focus();
                return;
            }

            // 4. Kontrol: Kart ID '00' ile başlamıyorsa kullanıcıya isim ve soyadıyla birlikte onay sor
            if (!kartID.StartsWith("00"))
            {
                DialogResult sonuc = MessageBox.Show(
                    $"Kart numaranız ({kartID}) {isim} {soyad} adlı çalışan için kaydedilecek. Onaylıyor musunuz?",
                    "Kart Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (sonuc != DialogResult.Yes)
                {
                    MessageBox.Show("Kayıt işlemi iptal edildi.");
                    return;
                }
            }

            // 5. Kontrol: Aynı Kart ID veritabanında var mı?
            using (var context = new YemekhaneContext())
            {
                bool kartZatenVar = context.Calisanlar.Any(c => c.calisanKartNo == kartID);

                if (kartZatenVar)
                {
                    MessageBox.Show("Bu Kart ID zaten kayıtlı.");
                   
                    txtIsim.Clear();
                    txtSoyad.Clear();
                    txtGorevv.Clear();
                    txtsicil.Clear();
                    txtgecis.Clear();
                    mskTxtSıfırlayıcı();
                    //maskedTextBoxKartID.Clear();
                    //maskedTextBoxKartID.Focus();
                    //maskedTextBoxKartID.SelectionStart = 0;
                    comboBoxAktiflik.SelectedIndex = 0;

                    return;
                }

                var yeniCalisan = new Calisan
                {
                    calisanKartNo = kartID,
                    calisanIsmi = isim,
                    calisanSoyad = soyad,
                    calisanGorevi = gorev,
                    sicil = sicil,
                    gecisSayısı = gecisSayisi, // Sayıya dönüştürülmüş haliyle kaydedildi
                    aktiflik = aktifMi
                };

                context.Calisanlar.Add(yeniCalisan);
                context.SaveChanges();

                //MessageBox.Show("Çalışan başarıyla kaydedildi.");
                AutoClosingMessageBox.Show($"✅ Çalışan başarıyla kaydedildi.", "Bilgi", 800);

                // Temizle
              
                txtIsim.Clear();
                txtSoyad.Clear();
                txtGorevv.Clear();
                txtsicil.Clear();
                txtgecis.Clear();
                mskTxtSıfırlayıcı();
                //maskedTextBoxKartID.Clear();
                //maskedTextBoxKartID.Focus();
                //maskedTextBoxKartID.SelectionStart = 0;
                comboBoxAktiflik.SelectedIndex = 0;


                CalisanlariListele(); // Güncel listeyi göster
            }


        }

        private void maskedTextBoxKartID_TextChanged_1(object sender, EventArgs e)
        {
            string kartID = maskedTextBoxKartID.Text.Trim();
            //yamok
            // string dosyaYolu = @"C:\Users\Hp\OneDrive\Desktop\KartVerileri";
            //omof
            string dosyaYolu = @"C:\Users\omery\OneDrive\Masaüstü\kartverileri";
            Directory.CreateDirectory(Path.GetDirectoryName(dosyaYolu));
            File.AppendAllText(dosyaYolu, kartID + Environment.NewLine);

            //lblDurum.Text = $"Yazıldı: {kartID}";

            mskTxtSıfırlayıcı();
            //maskedTextBoxKartID.Clear(); // temizle
            //maskedTextBoxKartID.Focus();
            //maskedTextBoxKartID.SelectionStart = 0;


        }

        private void kartKullanıcıEkleme_Shown(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                mskTxtSıfırlayıcı();
                //maskedTextBoxKartID.Clear();
                //maskedTextBoxKartID.Focus();
                //maskedTextBoxKartID.SelectionStart = 0; // imleç en başa gelsin
            });
        }

        private void checkBoxAktif_CheckedChanged_1(object sender, EventArgs e)
        {

        }
        private void CalisanlariListele()
        {
            using (var context = new YemekhaneContext())
            {
                var liste = context.Calisanlar
                    .Select(c => new
                    {
                        ID = c.calisanID,
                        AktifMi = c.aktiflik,
                        Isim = c.calisanIsmi,
                        Soyad = c.calisanSoyad,
                        Gorev = c.calisanGorevi,
                        Sicil = c.sicil,
                        GecisSayısı = c.gecisSayısı,
                        KartNo = c.calisanKartNo
                    })
                    .OrderByDescending(c => c.AktifMi)
                    .ThenByDescending(c => c.ID)
                    .ToList();

                dataGridView1.DataSource = liste;

                // ✅ Alternatif satır renklendirmesi
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dataGridView1.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
                dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

                dataGridView1.RowTemplate.Height = 30;
                dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold);

                // ✅ Tüm sütunları yatayda eşit sığdırma
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                txtgecis.Text = "1";


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
            if (string.IsNullOrWhiteSpace(maskedTextBoxKartID.Text) ||
    string.IsNullOrWhiteSpace(txtIsim.Text) ||
    string.IsNullOrWhiteSpace(txtSoyad.Text) ||
    string.IsNullOrWhiteSpace(txtGorevv.Text) ||
    string.IsNullOrWhiteSpace(txtsicil.Text) ||
    string.IsNullOrWhiteSpace(txtgecis.Text) ||
    comboBoxAktiflik.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                    string isimSoyad = $"{calisan.calisanIsmi} {calisan.calisanSoyad}";

                    DialogResult onay = MessageBox.Show(
                        $"Seçilen çalışan: {isimSoyad}\n\nBu çalışanı güncellemek istiyor musunuz?",
                        "Güncelleme Onayı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (onay == DialogResult.Yes)
                    {
                        calisan.calisanKartNo = maskedTextBoxKartID.Text.Trim();
                        calisan.calisanIsmi = txtIsim.Text.Trim();
                        calisan.calisanSoyad = txtSoyad.Text.Trim();
                        calisan.calisanGorevi = txtGorevv.Text.Trim();
                        calisan.sicil = txtsicil.Text.Trim();
                        calisan.gecisSayısı = Convert.ToInt32(txtgecis.Text.Trim());
                        calisan.aktiflik = comboBoxAktiflik.SelectedIndex == 0;

                        context.SaveChanges();

                        //MessageBox.Show("Çalışan bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AutoClosingMessageBox.Show($"✅ Çalışan başarıyla güncellendi.", "Bilgi", 800);
                    }
                    else
                    {
                        AutoClosingMessageBox.Show($"❗ {isimSoyad} adlı çalışan güncellenmedi.", "Bilgi", 1000); // 1 saniyede kapanır
                    }

                    // Temizle ve resetle (her iki durumda da)
                    secilenCalisanID = 0;
                    txtIsim.Clear();
                    txtSoyad.Clear();
                    txtGorevv.Clear();
                    txtsicil.Clear();
                    txtgecis.Clear();
                    //maskedTextBoxKartID.Clear();
                    comboBoxAktiflik.SelectedIndex = 0;
                    //maskedTextBoxKartID.Focus();
                    mskTxtSıfırlayıcı();


                    // Listeyi yenile
                    CalisanlariListele();
                }
                else
                {
                    MessageBox.Show("Seçilen çalışan veritabanında bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtsicil.Text = satir.Cells["Sicil"].Value.ToString();
                txtgecis.Text = satir.Cells["GecisSayısı"].Value.ToString(); // Günlük geçiş sayısını al
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
            txtsicil.Clear();
            txtgecis.Clear();
            //maskedTextBoxKartID.Clear();
            //comboBoxAktiflik.SelectedIndex = 0;
            //maskedTextBoxKartID.Focus();
            mskTxtSıfırlayıcı();

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
                        txtsicil.Clear();
                        txtgecis.Clear();
                        //maskedTextBoxKartID.Clear();
                        comboBoxAktiflik.SelectedIndex = 0;
                        //maskedTextBoxKartID.Focus();
                        //if (maskedTextBoxKartID.SelectionStart > 0)
                        //{
                        //    maskedTextBoxKartID.SelectionStart -= 1;
                        //}
                        mskTxtSıfırlayıcı();


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

        private void button4_Click(object sender, EventArgs e)
        {
            YemekhaneciAnaSayfa anaSayfa = new YemekhaneciAnaSayfa();
            anaSayfa.Show();
            this.Close();
        }

        private void maskedTextBoxKartID_TextChanged_2(object sender, EventArgs e)
        {
            string girilenKartID = maskedTextBoxKartID.Text.Trim();

            if (girilenKartID.Length != 10) // Veya senin sistemdeki uzunluk
                return;

            using (var context = new YemekhaneContext())
            {
                var calisan = context.Calisanlar
                    .FirstOrDefault(c => c.calisanKartNo == girilenKartID);

                if (calisan != null)
                {
                    // ✅ ID'yi güncelleme için tut
                    secilenCalisanID = calisan.calisanID;

                    txtIsim.Text = calisan.calisanIsmi;
                    txtSoyad.Text = calisan.calisanSoyad;
                    txtGorevv.Text = calisan.calisanGorevi;
                    txtsicil.Text = calisan.sicil;
                    txtgecis.Text = calisan.gecisSayısı.ToString();

                    comboBoxAktiflik.SelectedItem = calisan.aktiflik ? "Aktif" : "Pasif";
                }
                else
                {
                    // Veri yoksa alanları temizle
                    secilenCalisanID = 0;
                    txtIsim.Clear();
                    txtSoyad.Clear();
                    txtGorevv.Clear();
                    txtgecis.Clear();
                    txtgecis.Text = "1";
                    txtsicil.Clear();
                    comboBoxAktiflik.SelectedIndex = 0;
                }
            }
        }

        private void txtIsim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtSoyad.Focus(); // Sonraki alana odaklan   
                e.Handled = true;
                e.SuppressKeyPress = true; // Enter sesi bastırılır
            }
        }

        private void txtSoyad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGorevv.Focus(); // Sonraki alana odaklan   
                e.Handled = true;
                e.SuppressKeyPress = true; // Enter sesi bastırılır
            }
        }

        private void maskedTextBoxKartID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtIsim.Focus(); // Sonraki alana odaklan   
                e.Handled = true;
                e.SuppressKeyPress = true; // Enter sesi bastırılır
            }
        }

        private void txtGorevv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtsicil.Focus(); // Sonraki alana odaklan   
                e.Handled = true;
                e.SuppressKeyPress = true; // Enter sesi bastırılır
            }

        }

        private void txtsicil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnKaydet.PerformClick(); // Kaydet butonuna tıkla
                e.Handled = true;
                e.SuppressKeyPress = true; // Enter tuşunun sesini bastır
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtgecis_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBoxKartID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtIsim_TextChanged(object sender, EventArgs e)
        {


        }
    }
}