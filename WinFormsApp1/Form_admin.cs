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
    public partial class Form_admin : System.Windows.Forms.Form
    {
        public Form_admin()
        {
            InitializeComponent();
        }

        int flag = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_admin_add_admin form_admin_add_admin = new Form_admin_add_admin();
            form_admin_add_admin.FormClosed += (s, args) => { this.Show(); this.Location = form_admin_add_admin.Location; this.Size = form_admin_add_admin.Size; } ;
            form_admin_add_admin.Show();
            form_admin_add_admin.Size = this.Size;
            form_admin_add_admin.Location = this.Location;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_search_sportsman form_search_sportsman = new Form_search_sportsman(flag);
            form_search_sportsman.FormClosed += (s, args) => { this.Show(); this.Location = form_search_sportsman.Location; this.Size = form_search_sportsman.Size; };
            form_search_sportsman.Show();
            form_search_sportsman.Size = this.Size;
            form_search_sportsman.Location= this.Location;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            int flag_admin = 1;
            Form_search_coach form_search_coach = new Form_search_coach(flag_admin);
            form_search_coach.FormClosed += (s, args) => { this.Show(); this.Location = form_search_coach.Location; this.Size = form_search_coach.Size; };
            form_search_coach.Show();
            form_search_coach.Size = this.Size;
            form_search_coach.Location = this.Location;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_admin_add_sportsman form_admin_add_sportsman = new Form_admin_add_sportsman();
            form_admin_add_sportsman.FormClosed += (s, args) => { this.Show(); this.Location = form_admin_add_sportsman.Location; this.Size = form_admin_add_sportsman.Size; };
            form_admin_add_sportsman.Show();
            form_admin_add_sportsman.Size= this.Size;
            form_admin_add_sportsman.Location = this.Location;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_admin_add_coach form_admin_add_coach = new Form_admin_add_coach();
            form_admin_add_coach.FormClosed += (s, args) => { this.Show(); this.Location = form_admin_add_coach.Location; this.Size = form_admin_add_coach.Size; };
            form_admin_add_coach.Show();
            form_admin_add_coach.Size= this.Size;
            form_admin_add_coach.Location= this.Location;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_admin_del_admin form_admin_del_admin = new Form_admin_del_admin();
            form_admin_del_admin.FormClosed += (s, args) => { this.Show(); this.Location = form_admin_del_admin.Location; this.Size = form_admin_del_admin.Size; };
            form_admin_del_admin.Show();
            form_admin_del_admin.Size = this.Size;
            form_admin_del_admin.Location = this.Location;
        }
    }
}
