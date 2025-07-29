namespace UıLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adminn admn = new Adminn();
            admn.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yemekhaneCalisanGirisDetay dty = new yemekhaneCalisanGirisDetay();
            dty.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            kartKullanıcıEkleme kre = new kartKullanıcıEkleme();
            kre.Show();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YeniOkutmaEkleForm yeniOkutmaEkleForm = new YeniOkutmaEkleForm();
            yeniOkutmaEkleForm.Show();
            this.Hide();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Kullanıcıİşlemleri yeniYemekhaneCalisaniEkleme = new Kullanıcıİşlemleri();
            yeniYemekhaneCalisaniEkleme.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
