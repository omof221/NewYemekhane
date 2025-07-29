using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UıLayer
{
    public partial class Admin_Detay : Form
    {
        public Admin_Detay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanıcıİşlemleri yeniYemekhaneCalisaniEkleme = new Kullanıcıİşlemleri();
            yeniYemekhaneCalisaniEkleme.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adminn adminn = new();
            adminn.Show();
            this.Close();
        }

        private void Admin_Detay_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;         // İsteğe bağlı: kenarlık kaldırılır
            this.StartPosition = FormStartPosition.CenterScreen; // Ekranın ortasında başlasın

        }
    }
}
