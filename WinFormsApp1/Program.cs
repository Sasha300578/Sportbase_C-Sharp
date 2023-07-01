using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Lib_data;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Microsoft.VisualBasic.Logging;
using System.Reflection;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]


        // Обновление данных из БД спортсмены и тренеры
        public static void date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list)
        {
            sportsman_list = new List<Sportsman>();
            coach_list = new List<Coach>();
            string path_sp = "..\\..\\..\\..\\Данные (Json)\\sportsmans.json";
            string path_co = "..\\..\\..\\..\\Данные (Json)\\coachs.json";

            if (File.Exists(path_sp))
            {
                sportsman_list = JsonConvert.DeserializeObject<List<Sportsman>>(File.ReadAllText(path_sp));
            }
            if (File.Exists(path_co))
            {
                coach_list = JsonConvert.DeserializeObject<List<Coach>>(File.ReadAllText(path_co));
            }
        }


        // Обновление данных из БД админы
        public static void date_update_admin(out List<Admin> admin_list)
        {
            admin_list = new List<Admin>();
            string path_a = "..\\..\\..\\..\\Данные (Json)\\admins.json";
            if (File.Exists(path_a))
            {
                admin_list = JsonConvert.DeserializeObject<List<Admin>>(File.ReadAllText(path_a));
            }
        }


        // Вывод спортсменов (если их больше 1)
        public static void input_sportsman(List<int> ind_res_search, int index, Label label1, Label label2, Label label3, Label label4, Label label5, Label label6, Label label7, Label label8, Label label9, Label label10)
        {
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            label1.Text = "Ф.И.О. : " + sportsman_list[ind_res_search[index]].Surname.Substring(0, 1).ToUpper() + sportsman_list[ind_res_search[index]].Surname.Substring(1) + " " + sportsman_list[ind_res_search[index]].Name.Substring(0, 1).ToUpper() + sportsman_list[ind_res_search[index]].Name.Substring(1) + " " + sportsman_list[ind_res_search[index]].Patronymic.Substring(0, 1).ToUpper() + sportsman_list[ind_res_search[index]].Patronymic.Substring(1);
            if (sportsman_list[ind_res_search[index]].Date_birth.ToString().Length > 0)
            {
                label2.Text = "Дата рождения: " + sportsman_list[ind_res_search[index]].Date_birth.ToString().Substring(0, sportsman_list[ind_res_search[index]].Date_birth.ToString().Length - 8);
            }
            else
            {
                label2.Text = "Дата рождения: " + sportsman_list[ind_res_search[index]].Date_birth.ToString();
            }
            label3.Text = "Пол: " + sportsman_list[ind_res_search[index]].Pole;
            label4.Text = "Вид спорта: " + sportsman_list[ind_res_search[index]].Type_sport;
            label5.Text = "Спортивное звание: " + sportsman_list[ind_res_search[index]].Zvanie;
            label6.Text = "Вес: " + sportsman_list[ind_res_search[index]].Weight.ToString();
            if (sportsman_list[ind_res_search[index]].Date_dopusk.ToString().Length > 0)
            {
                label7.Text = "Дата окончания допуска: " + sportsman_list[ind_res_search[index]].Date_dopusk.ToString().Substring(0, sportsman_list[ind_res_search[index]].Date_dopusk.ToString().Length - 8);
            }
            else
            {
                label7.Text = "Дата окончания допуска: " + sportsman_list[ind_res_search[index]].Date_dopusk.ToString();
            }

            if (sportsman_list[ind_res_search[index]].Date_strahovka.ToString().Length > 0)
            {
                label8.Text = "Дата окончания страховки: " + sportsman_list[ind_res_search[index]].Date_strahovka.ToString().Substring(0, sportsman_list[ind_res_search[index]].Date_strahovka.ToString().Length - 8);
            }
            else
            {
                label8.Text = "Дата окончания страховки: " + sportsman_list[ind_res_search[index]].Date_strahovka.ToString();
            }

            label9.Text = "Спортивные команды: " + String.Join(",", sportsman_list[ind_res_search[index]].Teams);
            label10.Text = "Список тренеров, которые есть в базе данных: ";
            //label10.Text = label10.Text + String.Join(",", sportsman.Coachs);
            foreach (string coach_s in sportsman_list[ind_res_search[index]].Coachs)
            {
                string[] coach_fio = coach_s.Split(new char[] { ' ' });
                int flag_found_coach = 0;
                foreach (Coach coach in coach_list)
                {
                    if ((coach.Surname == coach_fio[0]) && (coach.Name == coach_fio[1]) && (coach.Patronymic == coach_fio[2]))
                    {
                        flag_found_coach += 1;
                        string date_birth;
                        
                        if (coach.Date_birth.ToString().Length > 0)
                        {
                            date_birth = coach.Date_birth.ToString().Substring(0, coach.Date_birth.ToString().Length - 8);
                        }
                        else
                        {
                            date_birth = coach.Date_birth.ToString();
                        }
                        label10.Text = label10.Text + coach_fio[0].Substring(0, 1).ToUpper() + coach_fio[0].Substring(1) + " " + coach_fio[1].Substring(0, 1).ToUpper() + coach_fio[1].Substring(1) + " " + coach_fio[2].Substring(0, 1).ToUpper() + coach_fio[2].Substring(1) + " " + date_birth + "; ";
                    }
                }
            }
        }


        // Поиск спортсмена для формы (вывод первого из найденных)
        public static void search_sportsman(Label label1, Label label2, Label label3, Label label4, Label label5, Label label6, Label label7, Label label8, Label label9, Label label10, string fio, ref List<int> ind_res_search, Label Label11, Button button1, Button button2, Button button3)
        {
            int flag = 0;
            fio = fio.ToLower();
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            string[] words = fio.Split(new char[] { ' ' });
            try
            {
                for (int i = 0; i < sportsman_list.Count; i++) 
                {
                    Sportsman sportsman = sportsman_list[i];
                    if ((sportsman.Surname == words[0]) && (sportsman.Name == words[1]) && (sportsman.Patronymic == words[2]))
                    {
                        flag = 1;
                        ind_res_search.Add(i);
                        if (ind_res_search.Count == 1)
                        {
                            label1.Text = label1.Text + words[0].Substring(0, 1).ToUpper() + words[0].Substring(1) + " " + words[1].Substring(0, 1).ToUpper() + words[1].Substring(1) + " " + words[2].Substring(0, 1).ToUpper() + words[2].Substring(1);
                            if (sportsman.Date_birth.ToString().Length > 0)
                            {
                                label2.Text = label2.Text + sportsman.Date_birth.ToString().Substring(0, sportsman.Date_birth.ToString().Length - 8);
                            }
                            else
                            {
                                label2.Text = label2.Text + sportsman.Date_birth.ToString();
                            }
                            label3.Text = label3.Text + sportsman.Pole;
                            label4.Text = label4.Text + sportsman.Type_sport;
                            label5.Text = label5.Text + sportsman.Zvanie;
                            label6.Text = label6.Text + sportsman.Weight.ToString();
                            if (sportsman.Date_dopusk.ToString().Length > 0)
                            {
                                label7.Text = label7.Text + sportsman.Date_dopusk.ToString().Substring(0, sportsman.Date_dopusk.ToString().Length - 8);
                            }
                            else
                            {
                                label7.Text = label7.Text + sportsman.Date_dopusk.ToString();
                            }

                            if (sportsman.Date_strahovka.ToString().Length > 0)
                            {
                                label8.Text = label8.Text + sportsman.Date_strahovka.ToString().Substring(0, sportsman.Date_strahovka.ToString().Length - 8);
                            }
                            else
                            {
                                label8.Text = label8.Text + sportsman.Date_strahovka.ToString();
                            }

                            label9.Text = label9.Text + String.Join(",", sportsman.Teams);
                            //label10.Text = label10.Text + String.Join(",", sportsman.Coachs);
                            foreach (string coach_s in sportsman.Coachs)
                            {
                                string[] coach_fio = coach_s.Split(new char[] { ' ' });
                                foreach (Coach coach in coach_list)
                                {
                                    if ((coach.Surname == coach_fio[0]) && (coach.Name == coach_fio[1]) && (coach.Patronymic == coach_fio[2]))
                                    {
                                        string date_birth;
                                        if (coach.Date_birth.ToString().Length > 0)
                                        {
                                            date_birth = coach.Date_birth.ToString().Substring(0, coach.Date_birth.ToString().Length - 8);
                                        }
                                        else
                                        {
                                            date_birth = coach.Date_birth.ToString();
                                        }
                                        label10.Text = label10.Text + coach_fio[0].Substring(0, 1).ToUpper() + coach_fio[0].Substring(1) + " " + coach_fio[1].Substring(0, 1).ToUpper() + coach_fio[1].Substring(1) + " " + coach_fio[2].Substring(0, 1).ToUpper() + coach_fio[2].Substring(1) + " " + date_birth + "; ";
                                    }
                                }
                            }
                        }
                    }
                }
                if (flag == 0)
                {
                    label1.Hide();
                    label2.Hide();
                    label3.Hide();
                    label4.Hide();
                    label5.Hide();
                    label6.Dock = DockStyle.Fill;
                    label6.TextAlign = ContentAlignment.MiddleCenter;
                    label6.Text = "Спортсмены не найдены!";
                    label7.Hide();
                    label8.Hide();
                    label9.Hide();
                    label10.Hide();
                    Label11.Hide();
                    button1.Enabled = false;
                    button1.Hide();
                    button2.Enabled = false;
                    button2.Hide();
                    button3.Enabled = false;
                    button3.Hide();
                }
            }
            catch(Exception ex) { }
        }


        // Вывод тренеров (если их больше 1)
        public static void input_coach(List<int> res_search, int index, Label label1, Label label2, Label label3, Label label4, Label label5, Label label6, Label label7)
        {
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            label1.Text = "Ф.И.О. : " + coach_list[res_search[index]].Surname.Substring(0, 1).ToUpper() + coach_list[res_search[index]].Surname.Substring(1) + " " + coach_list[res_search[index]].Name.Substring(0, 1).ToUpper() + coach_list[res_search[index]].Name.Substring(1) + " " + coach_list[res_search[index]].Patronymic.Substring(0, 1).ToUpper() + coach_list[res_search[index]].Patronymic.Substring(1);
            if (coach_list[res_search[index]].Date_birth.ToString().Length > 0)
            {
                label2.Text = "Дата рождения: " + coach_list[res_search[index]].Date_birth.ToString().Substring(0, coach_list[res_search[index]].Date_birth.ToString().Length - 8);
            }
            else
            {
                label2.Text = "Дата рождения: " + coach_list[res_search[index]].Date_birth.ToString();
            }
            label3.Text = "Пол: " + coach_list[res_search[index]].Pole;
            label4.Text = "Вид спорта: " + coach_list[res_search[index]].Type_sport;
            label5.Text = "Спортивные команды: " + String.Join(",", coach_list[res_search[index]].Teams);
            label6.Text = "Количество высоковалифицированных спортсменов тренера за всё время: " + coach_list[res_search[index]].Sportsman_count.ToString();
            label7.Text = "Спортсмены тренера на данный момент, которые есть в базе данных: ";
            //label7.Text = label7.Text + String.Join(",", res_search[index].Sportsmans);
            foreach (string sportsman_c in coach_list[res_search[index]].Sportsmans)
            {
                string[] sportsman_fio = sportsman_c.Split(new char[] { ' ' });
                foreach (Sportsman sportsman in sportsman_list)
                {
                    if ((sportsman.Surname == sportsman_fio[0]) && (sportsman.Name == sportsman_fio[1]) && (sportsman.Patronymic == sportsman_fio[2]))
                    {
                        string date_birth;
                        if (sportsman.Date_birth.ToString().Length > 0)
                        {
                            date_birth = sportsman.Date_birth.ToString().Substring(0, sportsman.Date_birth.ToString().Length - 8);
                        }
                        else
                        {
                            date_birth = sportsman.Date_birth.ToString();
                        }
                        label7.Text += sportsman_fio[0].Substring(0, 1).ToUpper() + sportsman_fio[0].Substring(1)  + " " + sportsman_fio[1].Substring(0, 1).ToUpper() + sportsman_fio[1].Substring(1) + " " + sportsman_fio[2].Substring(0, 1).ToUpper() + sportsman_fio[2].Substring(1) + " " + date_birth + "; ";
                    }
                }
            }
        }


        // Поиск тренера для формы (вывод первого из найденных)
        public static void search_coach(Label label1, Label label2, Label label3, Label label4, Label label5, Label label6, Label label7, string fio, ref List<int> res_search, Label label11, Button button1, Button button3)
        {
            int flag = 0;
            fio = fio.ToLower();
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            // Поиск тренеров в списке по ФИО, а также их спортсменов
            string[] words = fio.Split(new char[] { ' ' });
            try
            {
                for (int i = 0; i < coach_list.Count; i++)
                {
                    Coach coach = coach_list[i];
                    if ((coach.Surname == words[0]) && (coach.Name == words[1]) && (coach.Patronymic == words[2]))
                    {
                        flag = 1;
                        res_search.Add(i);
                        if (res_search.Count == 1)
                        {
                            label1.Text = label1.Text + words[0].Substring(0, 1).ToUpper() + words[0].Substring(1) + " " + words[1].Substring(0, 1).ToUpper() + words[1].Substring(1) + " " + words[2].Substring(0, 1).ToUpper() + words[2].Substring(1);
                            if (coach.Date_birth.ToString().Length > 0)
                            {
                                label2.Text = label2.Text + coach.Date_birth.ToString().Substring(0, coach.Date_birth.ToString().Length - 8);
                            }
                            else
                            {
                                label2.Text = label2.Text + coach.Date_birth.ToString();
                            }
                            label3.Text = label3.Text + coach.Pole;
                            label4.Text = label4.Text + coach.Type_sport;
                            label5.Text = label5.Text + String.Join(",", coach.Teams);
                            label6.Text = label6.Text + coach.Sportsman_count.ToString();
                            //label7.Text = label7.Text + String.Join(",", coach.Sportsmans);
                            foreach (string sportsman_c in coach.Sportsmans)
                            {
                                string[] sportsman_fio = sportsman_c.Split(new char[] { ' ' });
                                foreach (Sportsman sportsman in sportsman_list)
                                {
                                    if ((sportsman.Surname == sportsman_fio[0]) && (sportsman.Name == sportsman_fio[1]) && (sportsman.Patronymic == sportsman_fio[2]))
                                    {
                                        string date_birth;
                                        if (sportsman.Date_birth.ToString().Length > 0)
                                        {
                                            date_birth = sportsman.Date_birth.ToString().Substring(0, sportsman.Date_birth.ToString().Length - 8);
                                        }
                                        else
                                        {
                                            date_birth = sportsman.Date_birth.ToString();
                                        }
                                        label7.Text += sportsman_fio[0].Substring(0, 1).ToUpper() + sportsman_fio[0].Substring(1) + " " + sportsman_fio[1].Substring(0, 1).ToUpper() + sportsman_fio[1].Substring(1) + " " + sportsman_fio[2].Substring(0, 1).ToUpper() + sportsman_fio[2].Substring(1) + " " + date_birth + "; ";
                                    }
                                }
                            }
                        }
                    }
                }
                if (flag == 0)
                {
                    label1.Hide();
                    label2.Hide();
                    label3.Hide();
                    label4.Hide();
                    label5.Dock = DockStyle.Fill;
                    label5.TextAlign = ContentAlignment.MiddleCenter;
                    label5.Text = "Тренеры не найдены!";
                    label6.Hide();
                    label7.Hide();
                    label11.Hide();
                    button1.Enabled = false;
                    button1.Hide();
                    button3.Enabled = false;
                    button3.Hide();
                }
            }
            catch(Exception ex) { }
        }

        // Проверка админа
        public static void check_admin(ref int flag, string login, string password, Label label3)
        {
            date_update_admin(out List<Admin> admin_list);
            label3.Text = "";
            int flag_login = 0; int flag_password = 0;

            if(login != "")
            {
                flag_login = 1;
            }
            else
            {
                label3.Text = " Введите логин. ";
            }
            if(password != "")
            {
                flag_password = 1;
            }
            else
            {
                label3.Text += " Введите пароль. ";
            }

            if ((flag_login == 1) && (flag_password == 1))
            {
                foreach (Admin admin in admin_list)
                {
                    if ((admin.Login == login) && (admin.Password == password))
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    label3.Text = "Ошибка. Данные неверны. Попробуйте ещё раз...";
                }
            }
        }


        // Добавление админа
        public static void add_admin(string login, string password, ref int flag)
        {
            date_update_admin(out List<Admin> admin_list);
            foreach (Admin admin in admin_list.ToList())
            {
                if ((admin.Login == login) && (admin.Password == password))
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
            {
                admin_list.Add(new Admin(login, password));
                string path_a = "..\\..\\..\\..\\Данные (Json)\\admins.json";
                File.WriteAllText(path_a, JsonConvert.SerializeObject(admin_list, Formatting.Indented));
            }
        }


        // Удаление админа 
        public static void del_admin(TextBox textBox1, TextBox textBox2, TextBox textBox3, Label label4, int kol)
        {
            string path_a = "..\\..\\..\\..\\Данные (Json)\\admins.json";
            date_update_admin(out List<Admin> admin_list);
            int i = -1;
            int flag_soglasie = 0; int flag_sovpadenie = 0; int flag_failing_password = 0; int flag_login = 0;
            label4.Text = "";

            if(kol % 2 != 0)
            {
                flag_soglasie = 1;
            }
            else
            {
                label4.Text += " Вы не дали согласие на удаление данных.";
            }
            if(textBox2.Text == textBox3.Text)
            {
                flag_sovpadenie = 1;
            }
            else
            {
                label4.Text += " Пароли не совпадают.";
            }
            if((textBox2.Text == textBox3.Text) && (textBox2.Text == ""))
            {
                flag_failing_password = 1;
                label4.Text += " Введите пароль.";
            }
            if(textBox1.Text != "")
            {
                flag_login = 1;
            }
            else
            {
                label4.Text += " Введите логин.";
            }

            if((flag_soglasie == 1) && (flag_sovpadenie == 1) && (flag_failing_password == 0) && (flag_login == 1)) 
            {
                int flag_del = 0;
                foreach (Admin admin in admin_list)
                {
                    i = i + 1;
                    if ((admin.Login == textBox1.Text) && (admin.Password == textBox2.Text))
                    {
                        admin_list.RemoveAt(i);
                        File.WriteAllText(path_a, JsonConvert.SerializeObject(admin_list, Formatting.Indented));
                        flag_del = 1;
                        break;
                    }
                }
                if (flag_del== 1)
                {
                    label4.Text = "Удалено.";
                }
                else
                {
                    label4.Text = "Такой администратор не найден.";
                }
            }
        }

        // Добавление спортивной команды спортсмену
        public static void sportsman_add_new_team(List<int> ind_res_search, int index_, string new_team, Label label10)
        {
            string path_sp = "..\\..\\..\\..\\Данные (Json)\\sportsmans.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            try
            {
                sportsman_list[ind_res_search[index_]].add_new_team(new_team);
                File.WriteAllText(path_sp, JsonConvert.SerializeObject(sportsman_list, Formatting.Indented));
                label10.Text = "Добавлено";
            }
            catch(Exception ex) { }
        }


        // Удаление спортивной команды спортсмена
        public static void sportsman_del_old_team(List<int> ind_res_search, int index_, string old_team, Label label11)
        {
            string path_sp = "..\\..\\..\\..\\Данные (Json)\\sportsmans.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            try
            {
                sportsman_list[ind_res_search[index_]].del_team(old_team);
                File.WriteAllText(path_sp, JsonConvert.SerializeObject(sportsman_list, Formatting.Indented));
                label11.Text = "Удалено";
            }
            catch(Exception ex) { }
        }


        // Добавление тренера спортсмена
        public static void sportsman_add_new_coach(List<int> ind_res_search, int index_, string new_coach, Label label12)
        {
            string path_sp = "..\\..\\..\\..\\Данные (Json)\\sportsmans.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            try
            {
                sportsman_list[ind_res_search[index_]].add_new_coach(new_coach.ToLower());
                File.WriteAllText(path_sp, JsonConvert.SerializeObject(sportsman_list, Formatting.Indented));
                label12.Text = "Добавлено";
            } 
            catch(Exception ex) { }
        }


        // Удаление тренера спортсмена
        public static void sportsman_del_old_coach(List<int> ind_res_search, int index_, string coach, Label label13)
        {
            string path_sp = "..\\..\\..\\..\\Данные (Json)\\sportsmans.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            try
            {
                sportsman_list[ind_res_search[index_]].del_coach(coach.ToLower());
                File.WriteAllText(path_sp, JsonConvert.SerializeObject(sportsman_list, Formatting.Indented));
                label13.Text = "Удалено";
            }
            catch(Exception ex) { }
        }


        // Изменение спортивного разряда
        public static void sportsman_change_kval(List<int> ind_res_search, int index_, string new_kval, Label label16)
        {
            string path_sp = "..\\..\\..\\..\\Данные (Json)\\sportsmans.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            try
            {
                sportsman_list[ind_res_search[index_]].Zvanie = new_kval;
                File.WriteAllText(path_sp, JsonConvert.SerializeObject(sportsman_list, Formatting.Indented));
                label16.Text = "Изменено";
                        
            } 
            catch(Exception ex) { }
        }


        // Удаление спортсмена
        public static void del_sportsman(List<int> ind_res_search, int index_, Label label14)
        {
            string path_sp = "..\\..\\..\\..\\Данные (Json)\\sportsmans.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            int i = -1;
            try
            {
                sportsman_list.Remove(sportsman_list[ind_res_search[index_]]);
                File.WriteAllText(path_sp, JsonConvert.SerializeObject(sportsman_list, Formatting.Indented));
                label14.Text = "Удалено";
            } 
            catch(Exception ex) { }
        }


        // Добавление спортивной команды тренеру
        public static void coach_add_new_team(List<int> res_search, int index, string new_team, Label label10)
        {
            string path_co = "..\\..\\..\\..\\Данные (Json)\\coachs.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            try
            {
                coach_list[res_search[index]].add_new_team(new_team);
                File.WriteAllText(path_co, JsonConvert.SerializeObject(coach_list, Formatting.Indented));
                label10.Text = "Добавлено";
            }
            catch(Exception ex) { }
        }



        // Удаление спортивной команды тренера
        public static void coach_del_old_team(List<int> res_search, int index, string old_team, Label label9)
        {
            string path_co = "..\\..\\..\\..\\Данные (Json)\\coachs.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            try
            {
                coach_list[res_search[index]].del_team(old_team);
                File.WriteAllText(path_co, JsonConvert.SerializeObject(coach_list, Formatting.Indented));
                label9.Text = "Удалено";
            } 
            catch(Exception ex) { }
        }


        // Добавление спортсмена тренера
        public static void coach_add_new_sportsman(List<int> res_search, int index, string sportsman, Label label11)
        {
            string path_co = "..\\..\\..\\..\\Данные (Json)\\coachs.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            try
            {

                coach_list[res_search[index]].add_new_sportsman(sportsman.ToLower());
                File.WriteAllText(path_co, JsonConvert.SerializeObject(coach_list, Formatting.Indented));
                label11.Text = "Добавлено";
            } 
            catch(Exception ex) { }
        }


        // Удаление спортсмена тренера
        public static void coach_del_old_sportsman(List<int> res_search, int index, string sportsman, Label label12)
        {
            string path_co = "..\\..\\..\\..\\Данные (Json)\\coachs.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            try
            {
                coach_list[res_search[index]].del_sportsman(sportsman.ToLower());
                File.WriteAllText(path_co, JsonConvert.SerializeObject(coach_list, Formatting.Indented));
                label12.Text = "Удалено";
            }
            catch(Exception ex) { }
        }


        // Удаление тренера
        public static void del_coach(List<int> res_search, int index, Label label13)
        {
            string path_co = "..\\..\\..\\..\\Данные (Json)\\coachs.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            try
            {
                coach_list.Remove(coach_list[res_search[index]]);
                File.WriteAllText(path_co, JsonConvert.SerializeObject(coach_list, Formatting.Indented));
                label13.Text = "Удалено";
            }
            catch(Exception ex) { }
        }


        // Создание спортсмена
        public static void create_sportsman(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, string pol, TextBox textBox7, TextBox textBox8, TextBox textBox9, TextBox textBox10, TextBox textBox11, Label label5)
        {
            string path_sp = "..\\..\\..\\..\\Данные (Json)\\sportsmans.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            string surname = textBox1.Text.ToLower();
            string name = textBox2.Text.ToLower();
            string patronymic = textBox3.Text.ToLower();
            string date_birthday_ = textBox4.Text;
            DateTime.TryParse(date_birthday_, out DateTime date_birthday);
            string pole = pol;
            string type_sport = textBox7.Text;
            string weight = textBox8.Text;
            string zvanie = textBox9.Text;
            string date_dopusk_ = textBox10.Text;
            DateTime.TryParse(date_dopusk_, out DateTime date_dopusk);
            string date_strahovka_ = textBox11.Text;
            DateTime.TryParse(date_strahovka_, out DateTime date_strahovka);
            try
            {
                sportsman_list.Add(new Sportsman(surname, name, patronymic, date_birthday, pole, type_sport, Convert.ToDouble(textBox8.Text), zvanie, date_dopusk, date_strahovka));
                File.WriteAllText(path_sp, JsonConvert.SerializeObject(sportsman_list, Formatting.Indented));
                label5.Text = "Создан";
            }
            catch 
            {
                label5.Text = "Возникла ошибка. Проверьте корректность введеных данных.";
            }

        }


        // Создание тренера
        public static void create_coach(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, string pol, TextBox textBox7, TextBox textBox8, Label label5)
        {
            string path_co = "..\\..\\..\\..\\Данные (Json)\\coachs.json";
            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            string surname = textBox1.Text.ToLower();
            string name = textBox2.Text.ToLower();
            string patronymic = textBox3.Text.ToLower();
            string date_birthday_ = textBox4.Text;
            DateTime.TryParse(date_birthday_, out DateTime date_birthday);
            string pole = pol;
            string type_sport = textBox7.Text;
            string count_kval_sp = textBox8.Text;
            try
            {
                coach_list.Add(new Coach(surname, name, patronymic, date_birthday, pole, type_sport, Convert.ToInt32(count_kval_sp)));
                File.WriteAllText(path_co, JsonConvert.SerializeObject(coach_list, Formatting.Indented));
                label5.Text = "Создан";
            }
            catch
            {
                label5.Text = "Возникла ошибка. Проверьте корректность введеных данных.";
            }
        }


        // Изменение количества высококвалифицированных спортсменов тренера
        public static void chahge_kol_kval_sp(List<int> res_search, int index, TextBox textBox6, Label label16)
        {
            try
            {
                int kol = Convert.ToInt32(textBox6.Text);
                string path_co = "..\\..\\..\\..\\Данные (Json)\\coachs.json";
                date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
                coach_list[res_search[index]].Sportsman_count = kol;
                File.WriteAllText(path_co, JsonConvert.SerializeObject(coach_list, Formatting.Indented));
                label16.Text = "Изменено";
            }
            catch(Exception ex) { }
            
        }


        static void Main()
        {
            // Пути к файлам данных
            //string path_sp = "C:\\Users\\User\\Desktop\\WinFormsApp1\\Данные (Json)\\sportsmans.json";
            //string path_co = "C:\\Users\\User\\Desktop\\WinFormsApp1\\Данные (Json)\\coachs.json";
            //string path_a = "C:\\Users\\User\\Desktop\\WinFormsApp1\\Данные (Json)\\admins.json";
            string path_sp = "..\\..\\..\\..\\Данные (Json)\\sportsmans.json";
            string path_co = "..\\..\\..\\..\\Данные (Json)\\coachs.json";
            string path_a = "..\\..\\..\\..\\Данные (Json)\\admins.json";

            // Флаг на наличие админов
            int flag = 0;

            if (!File.Exists(path_sp))
            {
                File.Create(path_sp).Close();
            }
            if(!File.Exists(path_co)) 
            {
                File.Create(path_co).Close();
            }
            if (!File.Exists(path_a))
            {
                File.Create(path_a).Close();
                flag = 1;
            }

            date_update_sportsman_and_coach(out List<Sportsman> sportsman_list, out List<Coach> coach_list);
            date_update_admin(out List<Admin> admin_list);

            // Проверка пустой ли файл админов
            if (File.Exists(path_a))
            {
                if(admin_list.Count == 0)
                {
                    flag = 1;
                }
            }

            // Если нет админов, то добавляем одного
            if (flag == 1) 
            {
                admin_list.Add(new Admin("aaaa", "0000"));
                File.WriteAllText(path_a, JsonConvert.SerializeObject(admin_list, Formatting.Indented));
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}