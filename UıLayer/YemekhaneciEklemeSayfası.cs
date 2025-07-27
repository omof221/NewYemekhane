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
            AdminleriListele();
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


        private void AdminleriListele()
        {
            listBox1.Items.Clear();

            using (var con = new YemekhaneContext())
            {
                var adminler = con.Adminler.ToList();

                foreach (var admin in adminler)
                {
                    string satir = $"{admin.adminID} - {admin.adminIsim} {admin.adminSoyad} - {admin.adminEmail} - {admin.adminUsername} - {admin.adminSifre}";
                    listBox1.Items.Add(satir);
                }
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
                var kitapListesi = context.Adminler.ToList(); // Tüm verileri çeker
                dataGridView2.DataSource = kitapListesi;
            }
        }
        GenericRepository<Admin> adminRepo = new GenericRepository<Admin>();

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void VerileriYenile()
        {
            dataGridView2.DataSource = adminRepo.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                // Emin misiniz? popup
                DialogResult sonuc = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (sonuc == DialogResult.Yes)
                {
                    // ID'yi al
                    int secilenId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["adminID"].Value);

                    // Nesneyi getir
                    Admin silinecekAdmin = adminRepo.GetById(secilenId);

                    if (silinecekAdmin != null)
                    {
                        adminRepo.Delete(silinecekAdmin);
                        MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VerileriYenile();
                     
                        AdminleriListele();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                secilenAdminId = Convert.ToInt32(satir.Cells["adminID"].Value);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (secilenAdminId == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir satır seçin!");
                return;
            }

            DialogResult onay = MessageBox.Show("Bu kaydı güncellemek istediğinize emin misiniz?", "Güncelleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                var guncellenecekAdmin = adminRepo.GetById(secilenAdminId);
                if (guncellenecekAdmin != null)
                {
                    guncellenecekAdmin.adminIsim = textBox1.Text.Trim();
                    guncellenecekAdmin.adminSoyad = textBox2.Text.Trim();
                    guncellenecekAdmin.adminEmail = textBox3.Text.Trim();
                    guncellenecekAdmin.adminUsername = textBox4.Text.Trim();
                    guncellenecekAdmin.adminSifre = textBox5.Text.Trim();

                    adminRepo.Update(guncellenecekAdmin);

                    //LoggerService.Logla("Admin", "Güncelleme", aktifKullanici, $"ID = {guncellenecekAdmin.Id} güncellendi");

                    MessageBox.Show("Güncelleme başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    VerileriYenile();
                    AdminleriListele();
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
                    bool calisanVarMi = con.mekhaneCalisanlar.Any(c =>
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
                    var yeniCalisan = new mekhaneCalisanlar
                    {
                        tc = tc,
                        ad = isim,
                        soyad = soyad,
                        kullaniciAdi = kullaniciAdi,
                        sifre = sifre
                    };

                    con.mekhaneCalisanlar.Add(yeniCalisan);
                    con.SaveChanges();

                    MessageBox.Show("Yeni çalışan başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Listeyi güncelle (varsa)
                CalisanlariListele();
                VerileriTemizle(); // textbox'ları temizlemek istersen

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }
    }
}

