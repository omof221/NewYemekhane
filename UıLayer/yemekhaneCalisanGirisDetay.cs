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
using System;
using System.Threading;
using System.Windows.Forms;
namespace UıLayer
{
    public partial class yemekhaneCalisanGirisDetay : Form
    {
        public yemekhaneCalisanGirisDetay()
        {

            InitializeComponent();
            textBox1.Focus();
            textBox1.Clear();
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


        public class AutoClosingMessageBox
        {
            System.Threading.Timer timeoutTimer;
            string caption;

            private AutoClosingMessageBox(string text, string caption, int timeout)
            {
                this.caption = caption;
                timeoutTimer = new System.Threading.Timer(OnTimerElapsed, null, timeout, Timeout.Infinite);
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }

            private void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow(null, caption);
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                timeoutTimer.Dispose();
            }

            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
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
                    // 3️⃣ Ana sayfa formunu hemen aç
                    YemekhaneciAnaSayfa anaSayfa = new YemekhaneciAnaSayfa();
                    anaSayfa.Show();  // Direkt aç, modal değil!




                    // Giriş başarılı mesajı otomatik 3 saniyede kapanır
                    AutoClosingMessageBox.Show("✅ Giriş başarılı. Hoş geldiniz!", "Bilgi", 1600);

                    this.Hide(); // Giriş formunu gizle
                }
                else
                {
                    // 5️⃣ Hatalı giriş
                    MessageBox.Show("❌ TC veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox1.Focus();
                    textBox2.Clear();
                }
            }







        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus(); // Şifre kutusuna geçiş
                e.Handled = true;
                e.SuppressKeyPress = true; // Enter sesi bastırılır
            }
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick(); // Giriş butonunu tetikle
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void yemekhaneCalisanGirisDetay_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Adminn adminn = new Adminn();
            adminn.Show();
            this.Close();   

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKullaniciAdi_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
