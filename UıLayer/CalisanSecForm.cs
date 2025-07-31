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

        private void CalisanSecForm_Load(object sender, EventArgs e)
        {
            // Zebra görünüm
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dataGridView1.AllowUserToAddRows = false;

            // Otomatik sütun oluşturmayı kapat
            dataGridView1.AutoGenerateColumns = false;

            // Sütunları elle ekle
            dataGridView1.Columns.Clear();

            // ID
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.HeaderText = "Çalışan ID";
            colID.DataPropertyName = "calisanID";
            colID.Name = "calisanID";
            dataGridView1.Columns.Add(colID);

            // İsim
            DataGridViewTextBoxColumn colIsim = new DataGridViewTextBoxColumn();
            colIsim.HeaderText = "İsim";
            colIsim.DataPropertyName = "calisanIsmi";
            colIsim.Name = "calisanIsmi";
            dataGridView1.Columns.Add(colIsim);

            // Soyad
            DataGridViewTextBoxColumn colSoyad = new DataGridViewTextBoxColumn();
            colSoyad.HeaderText = "Soyad";
            colSoyad.DataPropertyName = "calisanSoyad";
            colSoyad.Name = "calisanSoyad";
            dataGridView1.Columns.Add(colSoyad);

            // Görev
            DataGridViewTextBoxColumn colGorev = new DataGridViewTextBoxColumn();
            colGorev.HeaderText = "Görev";
            colGorev.DataPropertyName = "calisanGorevi";
            colGorev.Name = "calisanGorevi";
            dataGridView1.Columns.Add(colGorev);

            // Kart No
            DataGridViewTextBoxColumn colKartNo = new DataGridViewTextBoxColumn();
            colKartNo.HeaderText = "Kart No";
            colKartNo.DataPropertyName = "calisanKartNo";
            colKartNo.Name = "calisanKartNo";
            dataGridView1.Columns.Add(colKartNo);

            // Sicil
            DataGridViewTextBoxColumn colSicil = new DataGridViewTextBoxColumn();
            colSicil.HeaderText = "Sicil";
            colSicil.DataPropertyName = "sicil";
            colSicil.Name = "sicil";
            dataGridView1.Columns.Add(colSicil);

            // Görünüm ayarları
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            txtArama.KeyDown += txtArama_KeyDown;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string arama = txtArama.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(arama))
            {
                MessageBox.Show("Lütfen bir isim, soyisim veya sicil giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new YemekhaneContext())
            {
                var sonuc = context.Calisanlar
                    .Where(c => c.aktiflik &&
                                (c.calisanIsmi.ToLower().Contains(arama) ||
                                 c.calisanSoyad.ToLower().Contains(arama) ||
                                 c.sicil.ToString().Contains(arama)))
                    .Select(c => new
                    {
                        c.calisanID,
                        c.calisanIsmi,
                        c.calisanSoyad,
                        c.calisanGorevi,
                        c.calisanKartNo,
                        c.sicil
                    })
                    .ToList();

                dataGridView1.DataSource = sonuc;
            }
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

                string mesaj = $"👤 Ad: {isim} {soyad}\n🧑‍💼 Görev: {gorev}\n\n Kişisine yemek eklemek istiyor musunuz?";
                DialogResult sonuc = MessageBox.Show(mesaj, "Yemek Ekleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    this.Tag = new Tuple<int, DateTime>(calisanID, dtpSecilenTarih.Value); // ID + seçilen tarih birlikte gönderiliyor
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void txtArama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAra.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
