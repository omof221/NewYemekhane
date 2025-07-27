using Microsoft.Data.SqlClient;
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
using YemekhaneDataAccesLayer.Repositories;
using YemekhaneEntityLayer.Entities;

namespace UıLayer
{
    public partial class YemekhaneciEklemeSayfası : Form
    {
        YemekhaneContext context = new YemekhaneContext();
        private void YemekhaneciEklemeSayfası_Load(object sender, EventArgs e)
        {
            CalisanlariListele();
            VerileriGoster();
        }


        public YemekhaneciEklemeSayfası()
        {
            InitializeComponent();
            dataGridView2.CellClick += dataGridView2_CellClick;


        }

        private void button1_Click(object sender, EventArgs e)
        {


        }


        private void CalisanlariListele()
        {
            using (var con = new YemekhaneContext())
            {
                var calisanlar = con.yemekhaneCalisanlar
                    .Select(c => new
                    {
                        ID = c.yemekhaneCalisanId,
                        TC = c.tc,
                        Ad = c.ad,
                        Soyad = c.soyad,
                        KullaniciAdi = c.kullaniciAdi,
                        Sifre = c.sifre
                    })
                    .ToList();

                dataGridView2.DataSource = calisanlar;

                // Kolon isimlerini isteğe göre özelleştir
                dataGridView2.Columns["ID"].HeaderText = "ID";
                dataGridView2.Columns["TC"].HeaderText = "T.C.";
                dataGridView2.Columns["Ad"].HeaderText = "Ad";
                dataGridView2.Columns["Soyad"].HeaderText = "Soyad";
                dataGridView2.Columns["KullaniciAdi"].HeaderText = "Kullanıcı Adı";
                dataGridView2.Columns["Sifre"].HeaderText = "Şifre";

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void YemekhaneciEklemeSayfası_Load_1(object sender, EventArgs e)
        {

        }

        private void VerileriGoster()
        {
            using (var context = new YemekhaneContext())
            {
                var kitapListesi = context.yemekhaneCalisanlar.ToList(); // Tüm verileri çeker
                dataGridView2.DataSource = kitapListesi;
            }
        }
        GenericRepository<Admin> adminRepo = new GenericRepository<Admin>();
        GenericRepository<YemekhaneCalisan> calisanRepo = new GenericRepository<YemekhaneCalisan>();    
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void VerileriYenile()
        {
            dataGridView2.DataSource = calisanRepo.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                DialogResult sonuc = MessageBox.Show(
                    "Bu çalışan kaydını silmek istediğinizden emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (sonuc == DialogResult.Yes)
                {
                    // ID'yi al (yemekhaneCalisanId)
                    int secilenId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["yemekhaneCalisanId"].Value);

                    using (var context = new YemekhaneContext())
                    {
                        var silinecekCalisan = context.yemekhaneCalisanlar
                            .FirstOrDefault(c => c.yemekhaneCalisanId == secilenId);

                        if (silinecekCalisan != null)
                        {
                            context.yemekhaneCalisanlar.Remove(silinecekCalisan);
                            context.SaveChanges();

                            MessageBox.Show("Çalışan başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CalisanlariListele(); // Listeyi güncelle
                        }
                        else
                        {
                            MessageBox.Show("Silinecek çalışan bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Detay adm1 = new();
            adm1.Show();
            this.Close();

        }




        int secilenAdminId;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView2.Rows[e.RowIndex];
                //textBox1.Text = satir.Cells["adminIsim"].Value.ToString();
                //textBox2.Text = satir.Cells["adminSoyad"].Value.ToString();
                //textBox3.Text = satir.Cells["adminEmail"].Value.ToString();
                //textBox4.Text = satir.Cells["adminUsername"].Value.ToString();
                //textBox5.Text = satir.Cells["adminSifre"].Value.ToString();
                textBox1.Text = satir.Cells[1].Value.ToString();
                textBox2.Text = satir.Cells[2].Value.ToString();
                textBox3.Text = satir.Cells[3].Value.ToString();
                textBox4.Text = satir.Cells[4].Value.ToString();
                textBox5.Text = satir.Cells[5].Value.ToString();


                // Id'yi geçici olarak tut (güncellemede lazım olacak)
                secilenAdminId = Convert.ToInt32(satir.Cells["yemekhaneCalisanId"].Value);
            }
        }
        int secilenCalisanId;
        private void button4_Click(object sender, EventArgs e)
        {
            if (secilenCalisanId == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir çalışan seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult onay = MessageBox.Show("Bu çalışanın bilgilerini güncellemek istediğinize emin misiniz?",
                "Güncelleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                var guncellenecekCalisan = calisanRepo.GetById(secilenCalisanId); // ID ile veritabanından çek

                if (guncellenecekCalisan != null)
                {
                    // TextBox'lardan gelen değerlerle güncelle
                    guncellenecekCalisan.ad = textBox1.Text.Trim();
                    guncellenecekCalisan.soyad = textBox2.Text.Trim();
                    guncellenecekCalisan.tc = textBox3.Text.Trim();
                    guncellenecekCalisan.kullaniciAdi = textBox4.Text.Trim();
                    guncellenecekCalisan.sifre = textBox5.Text.Trim();

                    calisanRepo.Update(guncellenecekCalisan); // Güncellemeyi işle

                    // Loglama istersen açabilirsin:
                    // LoggerService.Logla("YemekhaneCalisan", "Güncelleme", aktifKullanici, $"ID = {guncellenecekCalisan.yemekhaneCalisanId} güncellendi");

                    MessageBox.Show("Güncelleme başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    VerileriYenile();         // DataGridView yenilensin
                    CalisanlariListele();     // Liste yenilensin
                }
                else
                {
                    MessageBox.Show("Güncellenecek çalışan bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {




            try
            {
                using (var con = new YemekhaneContext())
                {
                    string isim = textBox1.Text.Trim();      // Ad
                    string soyad = textBox2.Text.Trim();     // Soyad
                    string tc = textBox3.Text.Trim();        // TC
                    string kullaniciAdi = textBox4.Text.Trim();  // Kullanıcı Adı
                    string sifre = textBox5.Text;            // Şifre

                    // 🔒 Aynı veriye sahip çalışan var mı kontrol et
                    bool calisanVarMi = con.yemekhaneCalisanlar.Any(c =>
                        c.tc == tc &&
                        c.ad == isim &&
                        c.soyad == soyad &&
                        c.kullaniciAdi == kullaniciAdi &&
                        c.sifre == sifre);

                    if (calisanVarMi)
                    {
                        MessageBox.Show("Bu bilgilerle kayıtlı bir çalışan zaten var!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // ➕ Yeni çalışan nesnesi oluştur
                    var yeniCalisan = new YemekhaneCalisan
                    {
                        tc = tc,
                        ad = isim,
                        soyad = soyad,
                        kullaniciAdi = kullaniciAdi,
                        sifre = sifre
                    };

                    con.yemekhaneCalisanlar.Add(yeniCalisan);
                    con.SaveChanges();

                    MessageBox.Show("Yeni çalışan başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Listeyi güncelle (varsa)
                CalisanlariListele();
                //VerileriTemizle(); // textbox'ları temizlemek istersen

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }
    }
}

