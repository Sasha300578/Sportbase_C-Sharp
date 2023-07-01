using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_data;
using System.Xml.Linq;

namespace Lib_data
{
    // Второй дочерний класс
    public class Coach : Person
    {
        int sporstman_count; // c
        List<string> sportsmans = new List<string>();
        public Coach(string s, string n, string p, DateTime? b, string po, string t, int c) : base(s, n, p, b, po, t)
        {
            Sportsman_count = c; // Количество квалифицированных спортсменов за всё время
        }

        // Свойство поля
        public List<string> Sportsmans
        {
            get { return sportsmans; }
            set { sportsmans = value; }
        }
        // Ограничение вводимых данных
        public int Sportsman_count
        {
            get
            {
                return sporstman_count;
            }
            set
            {
                sporstman_count = value;
                if (value < 0)
                {
                    sporstman_count = 0;
                }
            }
        }

        // Функция, добавляющая спортсменов в список
        public List<string> add_new_sportsman(string new_sportsman) // Список спортсменов на данный момент 
        {
            this.sportsmans.Add(new_sportsman);
            return this.sportsmans;
        }
        // Функция для удаления спортсмена из списка
        public List<string> del_sportsman(string old_sportsman)
        {
            this.sportsmans.Remove(old_sportsman);
            return this.sportsmans;
        }
    }
}
