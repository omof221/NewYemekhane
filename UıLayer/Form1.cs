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
    }
}
