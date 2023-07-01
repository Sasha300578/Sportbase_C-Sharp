using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form_admin_editing_data_coach : Form
    {
        List<int> ind_res_search = new List<int>();
        int index_;
        public Form_admin_editing_data_coach(ref List<int> res_search, ref int index)
        {
            InitializeComponent();
            index_ = index;
            ind_res_search = res_search;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string team = textBox1.Text;
            if(team != "")
            {
                Program.coach_add_new_team(ind_res_search, index_, team, label10);
            }
            else
            {
                label10.Text = "Введите данные.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string team = textBox2.Text;
            if(team != "")
            {
                Program.coach_del_old_team(ind_res_search, index_, team, label9);
            }
            else
            {
                label9.Text = "Введите данные.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sportsman = textBox3.Text;
            if(sportsman != "")
            {
                Program.coach_add_new_sportsman(ind_res_search, index_, sportsman, label11);
            }
            else
            {
                label11.Text = "Введите данные.";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sportsman = textBox4.Text;
            if (sportsman != "")
            {
                Program.coach_del_old_sportsman(ind_res_search, index_, sportsman, label12);
            }
            else
            {
                label12.Text = "Введите данные.";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.del_coach(ind_res_search, index_, label13);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox6.Text != "")
            {
                Program.chahge_kol_kval_sp(ind_res_search, index_, textBox6, label16);
            }
            else
            {
                label16.Text = "Введите данные.";
            }
        }
    }
}
