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
    public partial class Form_admin_add_sportsman : Form
    {
        public Form_admin_add_sportsman()
        {
            InitializeComponent();
            button1.BackColor = Color.RosyBrown;
        }

        string pol = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (!((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (pol != "") && (textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox11.Text != "")))
            {
                label5.Text = "Введите все данные, которые помечены *.";
                if (textBox1.Text == "")
                {
                    label1.Text = "Введите фамилию спортсмена: *";
                }
                else
                {
                    label1.Text = "Введите фамилию спортсмена: ";
                }
                if (textBox2.Text == "")
                {
                    label2.Text = "Введите имя спортсмена:  *";
                }
                else
                {
                    label2.Text = "Введите имя спортсмена: ";
                }
                if (textBox3.Text == "")
                {
                    label3.Text = "Введите отчество спортсмена:  *";
                }
                else
                {
                    label3.Text = "Введите отчество спортсмена: ";
                }
                if (textBox4.Text == "")
                {
                    label4.Text = "Введите дату рождения (дд.мм.гггг) спортсмена: *";
                }
                else
                {
                    label4.Text = "Введите дату рождения (дд.мм.гггг) спортсмена: ";
                }
                if (textBox7.Text == "")
                {
                    label7.Text = "Введите вид спорта, которым занимается спортсмен:  *";
                }
                else
                {
                    label7.Text = "Введите вид спорта, которым занимается спортсмен: ";
                }
                if (textBox8.Text == "")
                {
                    label8.Text = "Введите вес спортсмена в кг.: *";
                }
                else
                {
                    label8.Text = "Введите вес спортсмена в кг.: ";
                }
                if (pol == "")
                {
                    label6.Text = "Выберите пол спортсмена:  *";
                }
                else
                {
                    label6.Text = "Выберите пол спортсмена: ";
                }
                if (textBox8.Text == "")
                {
                    label8.Text = "Введите вес спортсмена в кг.: *";
                }
                else
                {
                    label8.Text = "Введите вес спортсмена в кг.: ";
                }
                if (textBox9.Text == "")
                {
                    label9.Text = "Введите спортивное звание спортсмена: *";
                }
                else
                {
                    label9.Text = "Введите спортивное звание спортсмена: ";
                }
                if (textBox10.Text == "")
                {
                    label10.Text = "Введите дату окончания действия допуска спортсмена (дд.мм.гггг):*";
                }
                else
                {
                    label10.Text = "Введите дату окончания действия допуска спортсмена (дд.мм.гггг):";
                }
                if (textBox11.Text == "")
                {
                    label11.Text = "Введите дату окончания действия страховки спортсмена (дд.мм.гггг): *";
                }
                else
                {
                    label11.Text = "Введите дату окончания действия страховки спортсмена (дд.мм.гггг):";
                }
            }

            if (kol % 2 != 0)
            {
                if((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (pol != "") && (textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox11.Text != ""))
                {
                    Program.create_sportsman(textBox1, textBox2, textBox3, textBox4, pol, textBox7, textBox8, textBox9, textBox10, textBox11, label5);
                }
                else
                {
                    label5.Text = "Введите все данные.";
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
