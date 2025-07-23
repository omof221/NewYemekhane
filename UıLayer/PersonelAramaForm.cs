using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using YemekhaneDataAccesLayer.Context;
using YemekhaneEntityLayer.Entities; // Calisan sınıfı burada tanımlı olmalı

namespace UıLayer
{
    public partial class PersonelAramaForm : Form
    {
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public List<int> SecilenCalisanIdListesi { get; private set; } = new List<int>();
        public event Action<List<int>> SecilenCalisanlarGonder;

        public PersonelAramaForm()
        {
            InitializeComponent();
        }

        private void PersonelAramaForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("CalisanID", "Çalışan ID");
            dataGridView1.Columns.Add("IsimSoyisim", "İsim Soyisim");

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Secildi",
                HeaderText = "Seç",
                Width = 50
            };
            dataGridView1.Columns.Add(checkBoxColumn);

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = "OkutmaEkle",
                HeaderText = "Yeni Okutma",
                Text = "Ekle",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dataGridView1.Columns.Add(buttonColumn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arama = textBox1.Text.Trim().ToLower();

            using (var context = new YemekhaneContext())
            {
                var sonuc = context.Calisanlar
                    .Where(c => c.calisanIsmi.ToLower().Contains(arama) ||
                                c.calisanSoyad.ToLower().Contains(arama) ||
                                c.calisanID.ToString().Contains(arama))
                    .ToList();

                dataGridView1.Rows.Clear();

                foreach (var calisan in sonuc)
                {
                    dataGridView1.Rows.Add(
                        calisan.calisanID, 
                        calisan.calisanIsmi + " " + calisan.calisanSoyad, 
                        false);
                }
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    SecilenCalisanIdListesi.Clear();

        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        if (Convert.ToBoolean(row.Cells["Secildi"].Value) == true)
        //        {
        //            int calisanId = Convert.ToInt32(row.Cells["CalisanID"].Value);
        //            SecilenCalisanIdListesi.Add(calisanId);
        //        }
        //    }

        //    SecilenCalisanlarGonder?.Invoke(SecilenCalisanIdListesi);
        //    this.Close();
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            SecilenCalisanIdListesi.Clear();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Secildi"].Value) == true)
                {
                    int calisanId = Convert.ToInt32(row.Cells["CalisanID"].Value);
                    SecilenCalisanIdListesi.Add(calisanId);
                }
            }

            SecilenCalisanlarGonder?.Invoke(SecilenCalisanIdListesi);
            this.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "OkutmaEkle" && e.RowIndex >= 0)
            {
                int calisanId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CalisanID"].Value);

                using (var context = new YemekhaneContext())
                {
                    var okutma = new Okutmalar
                    {
                        calisanID = calisanId ,
                        OkutmaTarihi = DateTime.Now
                    };

                    context.Okutmalar.Add(okutma);
                    context.SaveChanges();
                }

                MessageBox.Show($"Çalışan ID {calisanId} için okutma eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
