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
    public partial class YemekhaneciEklemeSayfası : Form
    {
        YemekhaneContext context = new YemekhaneContext();
        private void YemekhaneciEklemeSayfası_Load(object sender, EventArgs e)
        {
            AdminleriListele();
        }


        public YemekhaneciEklemeSayfası()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new YemekhaneContext())
                {
                    Admin admin = new Admin();
                    admin.adminIsim = textBox1.Text.Trim();
                    admin.adminSoyad = textBox2.Text.Trim();
                    admin.adminEmail = textBox3.Text.Trim();
                    admin.adminUsername = textBox4.Text.Trim();
                    admin.adminSifre = textBox5.Text;

                    con.Adminler.Add(admin);
                    con.SaveChanges();

                    MessageBox.Show("Yeni admin başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                AdminleriListele(); // listeyi güncelle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
    }
}

