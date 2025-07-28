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
            YeniYemekhaneCalisaniEkleme yeniYemekhaneCalisaniEkleme = new YeniYemekhaneCalisaniEkleme();
            yeniYemekhaneCalisaniEkleme.Show();
            this.Close();   

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adminn adminn = new();
            adminn.Show();
            this.Close();   
        }
    }
}
