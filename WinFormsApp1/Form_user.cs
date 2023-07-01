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
    public partial class Form_user : System.Windows.Forms.Form
    {
        int flag_admin = 0;
        public Form_user()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            int admin_flag = 0;
            Form_search_coach form_user_search_coach = new Form_search_coach(admin_flag);
            form_user_search_coach.FormClosed += (s, args) => { this.Show(); this.Location = form_user_search_coach.Location; this.Size = form_user_search_coach.Size; } ;
            form_user_search_coach.Show();
            form_user_search_coach.Location = this.Location;
            form_user_search_coach.Size = this.Size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_search_sportsman form_user_search_sportsman = new Form_search_sportsman(flag_admin);
            form_user_search_sportsman.FormClosed += (s, args) => { this.Show(); this.Location = form_user_search_sportsman.Location; this.Size = form_user_search_sportsman.Size; };
            form_user_search_sportsman.Show();
            form_user_search_sportsman.Location = this.Location;
            form_user_search_sportsman.Size = this.Size;
        }
    }
}
