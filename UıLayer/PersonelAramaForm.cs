
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Windows.Forms;
//using YemekhaneDataAccesLayer.Context;
//using YemekhaneEntityLayer.Entities;

//namespace UıLayer
//{
//    public partial class PersonelAramaForm : Form
//    {
//        [System.ComponentModel.Browsable(false)]
//        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
//        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
//        public List<int> SecilenCalisanIdListesi { get; private set; } = new List<int>();
//        public event Action<List<int>> SecilenCalisanlarGonder;

//        public PersonelAramaForm()
//        {
//            InitializeComponent();
//        }

//        private void PersonelAramaForm_Load(object sender, EventArgs e)
//        {
//            dataGridView1.Columns.Clear();
//            dataGridView1.Columns.Add("CalisanID", "Çalışan ID");
//            dataGridView1.Columns.Add("IsimSoyisim", "İsim Soyisim");

//            dataGridView1.Rows.Clear();
//            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
//            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick; // Çift tıklama olayı bağlandı
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            string arama = textBox1.Text.Trim().ToLower();

//            using (var context = new YemekhaneContext())
//            {
//                var sonuc = context.Calisanlar
//                    .Where(c => c.aktiflik == true &&
//                        (c.calisanIsmi.ToLower().Contains(arama) ||
//                         c.calisanSoyad.ToLower().Contains(arama) ||
//                         c.calisanID.ToString().Contains(arama)))
//                    .ToList();

//                dataGridView1.Rows.Clear();

//                if (sonuc.Any())
//                {
//                    foreach (var calisan in sonuc)
//                    {
//                        dataGridView1.Rows.Add(
//                            calisan.calisanID,
//                            calisan.calisanIsmi + " " + calisan.calisanSoyad);
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("Hiçbir çalışan bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            SecilenCalisanlarGonder?.Invoke(SecilenCalisanIdListesi);
//            this.Close();
//        }

//        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex >= 0)
//            {
//                int calisanId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CalisanID"].Value);

//                if (!SecilenCalisanIdListesi.Contains(calisanId))
//                {
//                    SecilenCalisanIdListesi.Add(calisanId);
//                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen; // Seçildi göstergesi
//                }
//                else
//                {
//                    SecilenCalisanIdListesi.Remove(calisanId);
//                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // Seçim iptal
//                }
//            }
//        }

//        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {

//        }
//    }
//}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YemekhaneDataAccesLayer.Context;
using YemekhaneEntityLayer.Entities;

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

            dataGridView1.Rows.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            ApplyZebraStyle(); // Zebra görünümü form açılışında da uygula
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arama = textBox1.Text.Trim().ToLower();

            using (var context = new YemekhaneContext())
            {
                var sonuc = context.Calisanlar
                    .Where(c => c.aktiflik == true &&
                        (c.calisanIsmi.ToLower().Contains(arama) ||
                         c.calisanSoyad.ToLower().Contains(arama) ||
                         c.calisanID.ToString().Contains(arama)))
                    .ToList();

                dataGridView1.Rows.Clear();

                if (sonuc.Any())
                {
                    foreach (var calisan in sonuc)
                    {
                        dataGridView1.Rows.Add(
                            calisan.calisanID,
                            calisan.calisanIsmi + " " + calisan.calisanSoyad);
                    }

                    ApplyZebraStyle(); // Arama sonrası zebra stilini yeniden uygula
                }
                else
                {
                    MessageBox.Show("Hiçbir çalışan bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SecilenCalisanlarGonder?.Invoke(SecilenCalisanIdListesi);
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int calisanId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CalisanID"].Value);

                if (!SecilenCalisanIdListesi.Contains(calisanId))
                {
                    SecilenCalisanIdListesi.Add(calisanId);
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    SecilenCalisanIdListesi.Remove(calisanId);
                    // Zebra görünümüne uygun olarak geri döndür
                    if (e.RowIndex % 2 == 0)
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    else
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // ✅ Zebra görünüm fonksiyonu
        private void ApplyZebraStyle()
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
    }
}


