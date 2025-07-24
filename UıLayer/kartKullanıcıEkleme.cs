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
    public partial class kartKullanıcıEkleme : Form
    {
        public kartKullanıcıEkleme()
        {
            InitializeComponent();
            Directory.CreateDirectory(Path.GetDirectoryName(dosyaYolu));
            timer1.Start();
        }
        private string dosyaYolu = @"C:\Users\Hp\OneDrive\Desktop\KartVerileri";
        private string oncekiKartID = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void kartKullanıcıEkleme_Load(object sender, EventArgs e)
        {

            maskedTextBoxKartID.Focus();
            checkBoxAktif.Checked = true;
        }



        private void maskedTextBoxKartID_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBoxKartID.Text.Length >= 10) // Kart ID uzunluk kontrolü
            {
                string kartID = maskedTextBoxKartID.Text.Trim();

                if (kartID != oncekiKartID)
                {
                    File.AppendAllText(dosyaYolu, kartID + Environment.NewLine);
                    lblDurum.Text = $"Kart ID yazıldı: {kartID}";
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


        private void checkBoxAktif_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAktif.Checked)
                checkBoxPasif.Checked = false;
        }

        private void checkBoxPasif_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPasif.Checked)
                checkBoxAktif.Checked = false;
        }
        //YemekhaneContext<Calisan> 
        private void button1_Click(object sender, EventArgs e)
        {
            string kartID = maskedTextBoxKartID.Text.Trim();
            if (!int.TryParse(kartID, out int kartNo))
            {
                MessageBox.Show("Kart ID yalnızca rakamlardan oluşmalıdır.");
                return;
            }
            string isim = txtIsim.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string gorev = txtGorevv.Text.Trim();
            bool aktifMi = checkBoxAktif.Checked;
            if (string.IsNullOrWhiteSpace(kartID) ||
    string.IsNullOrWhiteSpace(isim) ||
    string.IsNullOrWhiteSpace(soyad) ||
    string.IsNullOrWhiteSpace(gorev))
            {
                MessageBox.Show("Tüm alanlar (Kart ID, İsim, Soyad, Görev) doldurulmalıdır.");
                return;
            }

            if (string.IsNullOrEmpty(kartID))
            {
                MessageBox.Show("Kart ID boş olamaz.");
                return;
            }

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
                    aktiflik = aktifMi
                };

                context.Calisanlar.Add(yeniCalisan);
                context.SaveChanges();

                MessageBox.Show("Çalışan başarıyla kaydedildi.");

                // Temizle
                maskedTextBoxKartID.Clear();
                txtIsim.Clear();
                txtSoyad.Clear();
                txtGorevv.Clear();
                checkBoxAktif.Checked = true;
                checkBoxPasif.Checked = false;
                maskedTextBoxKartID.Focus();
            }
        }

        private void maskedTextBoxKartID_TextChanged_1(object sender, EventArgs e)
        {
            string kartID = maskedTextBoxKartID.Text.Trim();

            string dosyaYolu = @"C:\Users\Hp\OneDrive\Desktop\KartVerileri";
            Directory.CreateDirectory(Path.GetDirectoryName(dosyaYolu));
            File.AppendAllText(dosyaYolu, kartID + Environment.NewLine);

            lblDurum.Text = $"Yazıldı: {kartID}";
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
    }
}
