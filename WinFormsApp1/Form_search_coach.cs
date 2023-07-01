using Lib_data;
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
    public partial class Form_search_coach : Form
    {
        int flag_admin_;
        public Form_search_coach(int flag_admin)
        {
            InitializeComponent();
            flag_admin_ = flag_admin;
        }

        string fio;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            fio = textBox1.Text;
            Form_search_coach_display form_user_search_coach_display = new Form_search_coach_display(this.fio, flag_admin_);
            form_user_search_coach_display.FormClosed += (s, args) => { this.Show(); this.Location = form_user_search_coach_display.Location; this.Size = form_user_search_coach_display.Size; };
            form_user_search_coach_display.Show();
            form_user_search_coach_display.Location = this.Location;
            form_user_search_coach_display.Size = this.Size;
        }
    }
}
