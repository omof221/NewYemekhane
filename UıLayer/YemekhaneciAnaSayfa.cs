using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class YemekhaneciAnaSayfa : Form
    {
        public YemekhaneciAnaSayfa()
        {
            InitializeComponent();
            //textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            YeniOkutmaEkleForm okt = new YeniOkutmaEkleForm();
            okt.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kartKullanıcıEkleme krt = new kartKullanıcıEkleme();
            krt.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListelemeForm lst = new ListelemeForm();
            lst.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yemekhaneCalisanGirisDetay yemekhaneCalisanGirisDetay = new yemekhaneCalisanGirisDetay();
            yemekhaneCalisanGirisDetay.Show();
            this.Close();
        }

        private void YemekhaneciAnaSayfa_Load(object sender, EventArgs e)
        {
            //textBox1.Focus();   
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
