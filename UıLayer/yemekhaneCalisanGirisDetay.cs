using DocumentFormat.OpenXml.Spreadsheet;
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
using YemekhaneDataAccesLayer.Repositories;
using YemekhaneEntityLayer.Entities;

namespace UıLayer
{
    public partial class yemekhaneCalisanGirisDetay : Form
    {
        public yemekhaneCalisanGirisDetay()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();

        }
        GenericRepository<YemekhaneCalisan> adminRepo = new GenericRepository<YemekhaneCalisan>();
        private void button2_Click(object sender, EventArgs e)
        {

            string tc = textBox1.Text.Trim();
            string sifre = textBox2.Text;

            // 1️⃣ Boş alan kontrolü
            if (string.IsNullOrEmpty(tc) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("❗ Lütfen TC ve şifre alanlarını boş bırakmayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new YemekhaneContext())
            {
                // 2️⃣ TC ve Şifre ile çalışanı kontrol et
                var calisan = context.yemekhaneCalisanlar
                    .FirstOrDefault(c => c.tc == tc && c.sifre == sifre);

                if (calisan != null)
                {
                    // 3️⃣ Giriş başarılı → Ana sayfa formunu aç
                    MessageBox.Show("✅ Giriş başarılı. Hoş geldiniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide(); // Giriş formunu gizle
                    YemekhaneciAnaSayfa anaSayfa = new YemekhaneciAnaSayfa();
                    anaSayfa.ShowDialog(); // Modal olarak aç
                    this.Show(); // Ana sayfa kapanınca giriş formunu geri getir
                }
                else
                {
                    // 4️⃣ Hatalı giriş
                    MessageBox.Show("❌ TC veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }






        }
    }
}
