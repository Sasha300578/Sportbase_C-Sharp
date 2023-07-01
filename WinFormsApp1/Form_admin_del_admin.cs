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
    public partial class Form_admin_del_admin : Form
    {
        public Form_admin_del_admin()
        {
            InitializeComponent();
            button1.BackColor = Color.RosyBrown;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.del_admin(textBox1, textBox2, textBox3, label4, kol);
        }
        int kol = 0;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            kol++;
            if (kol % 2 != 0)
            {
                button1.BackColor = Color.Green;
            }
            else
            {
                button1.BackColor = Color.RosyBrown;
            }
        }
    }
}
