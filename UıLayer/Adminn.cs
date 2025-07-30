using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YemekhaneDataAccesLayer.Repositories;
using YemekhaneEntityLayer.Entities;

namespace UıLayer
{
    public partial class Adminn : Form
    {
        public Adminn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        GenericRepository<Admin> adminRepo = new GenericRepository<Admin>();
        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            // Admin tablosunda kullanıcı adı ve şifre eşleşiyor mu?
            var admin = adminRepo
                         .GetByFilter(a => a.adminUsername == kullaniciAdi && a.adminSifre == sifre)
                         .FirstOrDefault();

            if (admin != null)
            {
                // Giriş başarılı, yeni formu aç
                Admin_Detay admnDetay = new Admin_Detay();
                admnDetay.Show();
                this.Hide();
            }
            else
            {
                // Hatalı giriş
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();

        }

        private void Adminn_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;         // İsteğe bağlı: kenarlık kaldırılır
            this.StartPosition = FormStartPosition.CenterScreen; // Ekranın ortasında başlasın

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
