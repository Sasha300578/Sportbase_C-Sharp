using Lib_data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lib_data
{
    // Первый дочерний класс
    public class Sportsman : Person
    {
        DateTime? date_dopusk; // d // В конце сделать, чтобы прикреплялся скан допуска 
        double weight; // w
        string zvanie; // z
        List<string> coachs = new List<string>();
        DateTime? date_strahovka; // str
        public Sportsman(string s, string n, string p, DateTime? b, string po, string t, double w, string z, DateTime? d, DateTime? str) : base(s, n, p, b, po, t)
        {
            Date_dopusk = d;
            Weight = w;
            Zvanie = z;
            Date_strahovka = str;
        }

        // Свойства
        public string Zvanie
        {
            get { return zvanie; }
            set { zvanie = value; }
        }
        public List<string> Coachs
        {
            get { return coachs; }
            set { coachs = value; }
        }
        // Свойства с ограничением вводных данных
        public double Weight
        {
            get
            { return weight; }
            set
            {
                weight = value;
                if (value < 0)
                {
                    weight = 0;
                }
            }
        }
        public DateTime? Date_dopusk
        {
            get
            { return date_dopusk; }
            set
            {
                date_dopusk = value;
                DateTime now = DateTime.Now;
                if (now < date_dopusk)
                {
                    date_dopusk = value;
                }
                else
                {
                    date_dopusk = null;
                }
            }
        }
        public DateTime? Date_strahovka
        {
            get
            { return date_strahovka; }
            set
            {
                date_strahovka = value;
                DateTime now = DateTime.Now;
                if (now < date_strahovka)
                {
                    date_strahovka = value;
                }
                else
                {
                    date_strahovka = null;
                }
            }
        }

        // Функция для добавления тренеров
        public List<string> add_new_coach(string new_coach)
        {
            this.coachs.Add(new_coach);
            return this.coachs;
        }
        // Функция для удаления тренеров
        public List<string> del_coach(string old_coach)
        {
            this.coachs.Remove(old_coach);
            return this.coachs;
        }
    }

}
