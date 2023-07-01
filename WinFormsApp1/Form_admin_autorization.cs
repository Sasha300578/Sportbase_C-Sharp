using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form_admin_autorization : Form
    {
        public Form_admin_autorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login, password;
            login = textBox1.Text;
            password = textBox2.Text;
            int flag = 0;
            Program.check_admin(ref flag, login, password, label3);
            // Если данные верны
            if (flag == 1)
            {
                this.Hide();
                Form_admin admin = new Form_admin();
                admin.FormClosed += (s, args) => { this.Show(); this.Location = admin.Location; this.Size = admin.Size; };
                admin.Show();
                admin.Size = this.Size;
                admin.Location = this.Location;
                textBox1.Text = ""; 
                textBox2.Text = "";
                label3.Text = "";
            }
        }
    }
}
