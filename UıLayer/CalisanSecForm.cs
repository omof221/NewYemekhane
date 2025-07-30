using Microsoft.Extensions.Logging;
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
    public partial class CalisanSecForm : Form
    {
        public CalisanSecForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var satir = dataGridView1.Rows[e.RowIndex];

                string isim = satir.Cells["calisanIsmi"].Value.ToString();
                string soyad = satir.Cells["calisanSoyad"].Value.ToString();
                string gorev = satir.Cells["calisanGorevi"].Value.ToString();
                string kartNo = satir.Cells["calisanKartNo"].Value.ToString();
                int calisanID = Convert.ToInt32(satir.Cells["calisanID"].Value);

                string mesaj = $"👤 Ad: {isim} {soyad}\n🧑‍💼 Görev: {gorev}\n\n🕒 Bugün için yemek eklemek istiyor musunuz?";
                DialogResult sonuc = MessageBox.Show(mesaj, "Yemek Ekleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    // Ana forma bilgiyi gönder
                    this.Tag = calisanID; // calisanID'yi tag ile gönderiyoruz
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string arama = txtArama.Text.Trim().ToLower();

            using (var context = new YemekhaneContext())
            {
                var sonuc = context.Calisanlar
                    .Where(c => c.aktiflik &&
                                (c.calisanIsmi.ToLower().Contains(arama) || c.calisanSoyad.ToLower().Contains(arama)))
                    .Select(c => new
                    {
                        c.calisanID,
                        c.calisanIsmi,
                        c.calisanSoyad,
                        c.calisanGorevi,
                        c.calisanKartNo
                    })
                    .ToList();

                dataGridView1.DataSource = sonuc;
            }
        }

        private void CalisanSecForm_Load(object sender, EventArgs e)
        {

        }
    }
}
