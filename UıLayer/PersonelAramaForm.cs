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
    public partial class PersonelAramaForm : Form
    {
        public List<int> SecilenCalisanIdListesi { get; private set; } = new List<int>();
        public event Action<List<int>> SecilenCalisanlarGonder;
        public PersonelAramaForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
