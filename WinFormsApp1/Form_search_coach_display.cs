using Lib_data;
using Newtonsoft.Json;
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
    public partial class Form_search_coach_display : Form
    {
        int kol_click = 1;
        int kol_coach = 0;
        List<int> res_search = new List<int>();

        public Form_search_coach_display(string fio, int flag_admin)
        {
            InitializeComponent();
            Program.search_coach(label1, label2, label3, label4, label5, label6, label7, fio, ref res_search, label11, button1, button3);
            kol_coach = res_search.Count;
            if (kol_coach == 1)
            {
                button1.Enabled = false;
                button1.Hide();
            }
            label11.Text = $"Найдено {res_search.Count} тренеров, открыт {kol_click} тренер.";
            if (kol_click - 1 == 0)
            {
                button2.Enabled = false;
                button2.Hide();
            }
            if (flag_admin == 0)
            {
                button3.Enabled = false;
                button3.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kol_click += 1;
            int index = kol_click - 1;
            if (kol_click == kol_coach)
            {
                button1.Enabled = false;
                button1.Hide();
            }
            if (kol_click < kol_coach + 1)
            {
                Program.input_coach(res_search, index, label1, label2, label3, label4, label5, label6, label7);
            }
            label11.Text = $"Найдено {kol_coach} тренеров, открыт {kol_click} тренер.";
            button2.Enabled = true;
            button2.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kol_click -= 1;
            int index = kol_click - 1;
            if (kol_click == 1)
            {
                button2.Enabled = false;
                button2.Hide();
            }
            Program.input_coach(res_search, index, label1, label2, label3, label4, label5, label6, label7);
            label11.Text = $"Найдено {kol_coach} тренеров, открыт {kol_click} тренер.";
            button1.Enabled = true;
            button1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = kol_click - 1;
            this.Hide();
            Form_admin_editing_data_coach form_admin_editing_data_coach = new Form_admin_editing_data_coach(ref res_search, ref index);
            form_admin_editing_data_coach.FormClosed += (s, args) => { this.Show(); this.Location = form_admin_editing_data_coach.Location; this.Size = form_admin_editing_data_coach.Size; };
            form_admin_editing_data_coach.Show();
            form_admin_editing_data_coach.Size = this.Size;
            form_admin_editing_data_coach.Location = this.Location;
        }
    }
}
