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

namespace UıLayer
{
    public partial class loglar : Form
    {
        public loglar()
        {
            InitializeComponent();
        }
        private void GirisLoglariListele()
        {
            using (var context = new YemekhaneContext())
            {
                var logListesi = context.girisLoglar
                    .Include(g => g.Calisan) // Calisan bilgilerini dahil ediyoruz
                    .OrderByDescending(g => g.GirisLoglariId) // SON EKLENENİ EN ÜSTE GETİRİR
                    .Select(g => new
                    {
                        g.GirisLoglariId,
                        g.GirisZamani,
                        g.Basarili,
                        KullaniciAdi = g.Calisan != null ? g.Calisan.kullaniciAdi : "Bilinmiyor",
                        AdSoyad = g.Calisan != null ? g.Calisan.ad + " " + g.Calisan.soyad : "Bilinmiyor",
                        TC = g.Calisan != null ? g.Calisan.tc : "Bilinmiyor"
                    })
                    .ToList();

                dataGridView1.DataSource = logListesi;
            }
        }
        private void loglar_Load(object sender, EventArgs e)
        {
            GirisLoglariListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adminn admn = new Adminn();
            admn.Show();
            this.Close();   
        }
    }
}
