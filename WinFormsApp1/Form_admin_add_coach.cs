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
    public partial class Form_admin_add_coach : Form
    {
        public Form_admin_add_coach()
        {
            InitializeComponent();
            button1.BackColor = Color.RosyBrown;
        }

        string pol = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (!((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox7.Text != "") && (textBox8.Text != "") && (pol != "")))
            {
                label5.Text = "Введите все данные, которые помечены *.";
                if (textBox1.Text == "")
                {
                    label1.Text = "Введите фамилию тренера: *";
                }
                else
                {
                    label1.Text = "Введите фамилию тренера: ";
                }
                if (textBox2.Text == "")
                {
                    label2.Text = "Введите имя тренера:  *";
                }
                else
                {
                    label2.Text = "Введите имя тренера: ";
                }
                if (textBox3.Text == "")
                {
                    label3.Text = "Введите отчество тренера:  *";
                }
                else
                {
                    label3.Text = "Введите отчество тренера: ";
                }
                if (textBox4.Text == "")
                {
                    label4.Text = "Введите дату рождения (дд.мм.гггг) тренера:  *";
                }
                else
                {
                    label4.Text = "Введите дату рождения (дд.мм.гггг) тренера: ";
                }
                if (textBox7.Text == "")
                {
                    label7.Text = "Введите вид спорта, с которым связан тренер:  *";
                }
                else
                {
                    label7.Text = "Введите вид спорта, с которым связан тренер: ";
                }
                if (textBox8.Text == "")
                {
                    label8.Text = "Введите количество высоквалифицированных спортсменов тренера за всё время:  *";
                }
                else
                {
                    label8.Text = "Введите количество высоквалифицированных спортсменов тренера за всё время: ";
                }
                if (pol == "")
                {
                    label6.Text = "Выберите пол тренера:  *";
                }
                else
                {
                    label6.Text = "Выберите пол тренера: ";
                }
            }

            if (kol%2 != 0)
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox7.Text != "") && (textBox8.Text != "") && (pol != ""))
                {
                    Program.create_coach(textBox1, textBox2, textBox3, textBox4, pol, textBox7, textBox8, label5);
                }
            }
            else
            {
                label5.Text += " Вы не дали согласие на сохранение данных.";
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pol = "Мужской";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pol = "Женский";
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
