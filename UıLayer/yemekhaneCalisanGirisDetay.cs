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
            //int tc = int.Parse(textBox1.Text.Trim());
            string tc =textBox1.Text.Trim();
            string sifre = textBox2.Text.Trim();
            var yemekhanekullanıcı = adminRepo.GetByFilter(a => a.tc == tc && a.sifre == sifre);
            if (yemekhanekullanıcı != null)
            {
                // Giriş başarılı, yeni formu aç
             ListelemeForm listelemeForm = new ListelemeForm(); 
                listelemeForm.Show();
                this.Close();
            }
            else
            {
                // Hatalı giriş
                MessageBox.Show("Tc veya şifre hatalı!", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }








        }
    }
}
