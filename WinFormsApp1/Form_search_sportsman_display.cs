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
using System.Windows.Input;

namespace WinFormsApp1
{
    public partial class Form_search_sportsman_display : Form
    {
        int kol_click = 1;
        int kol_sportsman = 0;
        List<int> ind_res_search = new List<int>();
        

        public Form_search_sportsman_display(string fio, int flag_admin)
        {
            InitializeComponent();
            Program.search_sportsman(label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, fio, ref ind_res_search, label11, button1, button2, button3);
            kol_sportsman = ind_res_search.Count;
            if(kol_sportsman == 1) 
            {
                button1.Enabled= false;
                button1.Hide();
                button2.Enabled= false;
                button2.Hide();
            }
            label11.Text = $"Найдено {kol_sportsman} спортсменов, открыт {kol_click} спортсмен.";
            if(kol_click - 1 == 0) 
            {
                button2.Enabled = false;
                button2.Hide();
            }
            if(flag_admin == 0)
            {
                button3.Enabled= false;
                button3.Hide();
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            kol_click += 1;
            int index = kol_click - 1; 
            if (kol_click == kol_sportsman)
            {
                button1.Enabled = false;
                button1.Hide();
            }
            if(kol_click < kol_sportsman + 1)
            {
                Program.input_sportsman(ind_res_search, index, label1, label2, label3, label4, label5, label6, label7, label8, label9, label10);
                label11.Text = $"Найдено {kol_sportsman} спортсменов, открыт {kol_click} спортсмен.";
            }
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
            Program.input_sportsman(ind_res_search, index, label1, label2, label3, label4, label5, label6, label7, label8, label9, label10);
            label11.Text = $"Найдено {kol_sportsman} спортсменов, открыт {kol_click} спортсмен.";
            button1.Enabled = true;
            button1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = kol_click - 1;
            this.Hide();
            Form_admin_editing_data_sportsman form_admin_editing_data_sportsman = new Form_admin_editing_data_sportsman(ind_res_search, index);
            form_admin_editing_data_sportsman.FormClosed += (s, args) => { this.Show(); this.Location = form_admin_editing_data_sportsman.Location; this.Size = form_admin_editing_data_sportsman.Size; };
            form_admin_editing_data_sportsman.Show();
            form_admin_editing_data_sportsman.Size = this.Size;
            form_admin_editing_data_sportsman.Location = this.Location;
        }
    }
}

