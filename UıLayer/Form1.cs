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
            Admin admn = new Admin();
            admn.Show();
            this.Hide();    
        }
    }
}
