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

            // 🔒 Gizli ID kolonu (ListelemeForm ile uyum için)
            dataGridView1.Columns.Add("CalisanID", "Çalışan ID");
            dataGridView1.Columns["CalisanID"].Visible = false;

            // ✅ Görünen kolonlar
            dataGridView1.Columns.Add("Sicil", "Sicil No");
            dataGridView1.Columns.Add("IsimSoyisim", "İsim Soyisim");

            dataGridView1.Rows.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.AllowUserToAddRows = false;

            ApplyZebraStyle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arama = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(arama))
            {
                MessageBox.Show("Lütfen geçerli bir arama terimi giriniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string aramaLower = arama.ToLower();

            using (var context = new YemekhaneContext())
            {
                var sonuc = context.Calisanlar
                    .Where(c => c.aktiflik == true &&
                        (
                            (c.calisanIsmi ?? "").ToLower().Contains(aramaLower) ||
                            (c.calisanSoyad ?? "").ToLower().Contains(aramaLower) ||
                            (c.sicil ?? "").ToLower().Contains(aramaLower)   // ✅ sicil ile arama
                        ))
                    .Select(c => new
                    {
                        c.calisanID,
                        c.sicil,
                        IsimSoyisim = (c.calisanIsmi ?? "") + " " + (c.calisanSoyad ?? "")
                    })
                    .ToList();

                dataGridView1.Rows.Clear();

                if (sonuc.Any())
                {
                    foreach (var calisan in sonuc)
                    {
                        // Sıra: (gizli) CalisanID, Sicil, IsimSoyisim
                        dataGridView1.Rows.Add(
                            calisan.calisanID,
                            string.IsNullOrWhiteSpace(calisan.sicil) ? "-" : calisan.sicil,
                            calisan.IsimSoyisim
                        );
                    }
                    ApplyZebraStyle();
                }
                else
                {
                    MessageBox.Show("Hiçbir çalışan bulunamadı.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int calisanId = Convert.ToInt32(
                    dataGridView1.Rows[e.RowIndex].Cells["CalisanID"].Value);

                if (!SecilenCalisanIdListesi.Contains(calisanId))
                {
                    SecilenCalisanIdListesi.Add(calisanId);
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    SecilenCalisanIdListesi.Remove(calisanId);
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        (e.RowIndex % 2 == 0) ? Color.White : Color.Gainsboro;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Zebra görünüm
        private void ApplyZebraStyle()
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
