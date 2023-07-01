using Microsoft.VisualBasic.ApplicationServices;

namespace WinFormsApp1
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_user user = new Form_user();
            user.FormClosed += (s, args) => { this.Show(); this.Location = user.Location; this.Size = user.Size; };
            user.Show();
            user.Location = this.Location;
            user.Size = this.Size;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_admin_autorization form_admin_autorization = new Form_admin_autorization();
            form_admin_autorization.FormClosed += (s, args) => { this.Show(); this.Location = form_admin_autorization.Location; this.Size = form_admin_autorization.Size; };
            form_admin_autorization.Show();
            form_admin_autorization.Location = this.Location;
            form_admin_autorization.Size = this.Size;
        }
    }
}