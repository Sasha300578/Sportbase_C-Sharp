using Lib_data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form_admin_editing_data_sportsman : Form
    {
        List<int> ind_res_search = new List<int>();
        int index_;
        public Form_admin_editing_data_sportsman(List<int> res_search, int index)
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
                Program.sportsman_add_new_team(ind_res_search, index_, team, label10);
            }
            else
            {
                label10.Text = "Введите данные.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string team = textBox2.Text;
            if(team != "")
            {
                Program.sportsman_del_old_team(ind_res_search, index_, team, label11);
            }
            else
            {
                label11.Text = "Введите данные.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string coach = textBox3.Text;
            if(coach != "")
            {
                Program.sportsman_add_new_coach(ind_res_search, index_, coach, label12);
            }
            else
            {
                label12.Text = "Введите данные.";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string coach = textBox4.Text;
            if(coach != "")
            {
                Program.sportsman_del_old_coach(ind_res_search, index_, coach, label13);
            }
            else
            {
                label13.Text = "Введите данные.";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Program.del_sportsman(ind_res_search, index_, label14);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string new_kval = textBox6.Text;
            if(new_kval != "")
            {
                Program.sportsman_change_kval(ind_res_search, index_, new_kval, label16);
            }
            else
            {
                label16.Text = "Введите данные.";
            }
        }
    }
}
