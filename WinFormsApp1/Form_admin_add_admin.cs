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
    public partial class Form_admin_add_admin : Form
    {
        public Form_admin_add_admin()
        {
            InitializeComponent();
            button1.BackColor = Color.RosyBrown;
        }

        string country, post;

        private void button1_Click(object sender, EventArgs e)
        {
            string login, password;
            int flag = 0;
            login = textBox1.Text;
            password = textBox2.Text;
            int flag_soglasie = 0; int flag_sovpadenie = 0; int flag_failing_password = 0; int flag_login = 0;
            label4.Text = "";

            if (kol % 2 != 0)
            {
                flag_soglasie = 1;
            }
            else
            {
                label4.Text += " Вы не дали согласие на удаление данных.";
            }
            if (textBox2.Text == textBox3.Text)
            {
                flag_sovpadenie = 1;
            }
            else
            {
                label4.Text += " Пароли не совпадают.";
            }
            if ((textBox2.Text == textBox3.Text) && (textBox2.Text == ""))
            {
                flag_failing_password = 1;
                label4.Text += " Введите пароль.";
            }
            if (textBox1.Text != "")
            {
                flag_login = 1;
            }
            else
            {
                label4.Text += " Введите логин.";
            }


            if ((flag_soglasie == 1) && (flag_sovpadenie == 1) && (flag_failing_password == 0) && (flag_login == 1))
            {
                Program.add_admin(login, password, ref flag);
                if(flag == 1)
                {
                    label4.Text = "Такой администратор существует. "; 
                }
                if(flag == 0)
                {
                    label4.Text = "Администратор создан.";
                }
            }
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
