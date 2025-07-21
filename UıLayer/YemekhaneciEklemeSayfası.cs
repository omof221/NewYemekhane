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
            //try
            //{
            //    using (var con = new YemekhaneContext())
            //    {
            //        Admin admin = new Admin();
            //        admin.adminIsim = textBox1.Text.Trim();
            //        admin.adminSoyad = textBox2.Text.Trim();
            //        admin.adminEmail = textBox3.Text.Trim();
            //        admin.adminUsername = textBox4.Text.Trim();
            //        admin.adminSifre = textBox5.Text;

            //        con.Adminler.Add(admin);
            //        con.SaveChanges();

            //        MessageBox.Show("Yeni admin başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    AdminleriListele(); // listeyi güncelle
            //    VerileriGoster();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}





            try
            {
                using (var con = new YemekhaneContext())
                {
                    string isim = textBox1.Text.Trim();
                    string soyad = textBox2.Text.Trim();
                    string email = textBox3.Text.Trim();
                    string username = textBox4.Text.Trim();
                    string sifre = textBox5.Text;

                    // Aynı veriye sahip admin var mı kontrol et
                    bool adminVarMi = con.Adminler.Any(a =>
                        a.adminIsim == isim &&
                        a.adminSoyad == soyad &&
                        a.adminEmail == email &&
                        a.adminUsername == username &&
                        a.adminSifre == sifre);

                    if (adminVarMi)
                    {
                        MessageBox.Show("Bu bilgilerle kayıtlı bir admin zaten var!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // eklemeyi iptal et
                    }

                    // Yeni admin oluştur
                    Admin admin = new Admin
                    {
                        adminIsim = isim,
                        adminSoyad = soyad,
                        adminEmail = email,
                        adminUsername = username,
                        adminSifre = sifre
                    };

                    con.Adminler.Add(admin);
                    con.SaveChanges();

                    MessageBox.Show("Yeni admin başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                AdminleriListele(); // listeyi güncelle
                VerileriGoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }
    }
}

