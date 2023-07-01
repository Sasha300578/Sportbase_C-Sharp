using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_data
{
    // ������������ �����
    public class Person
    {
        // ���� ������
        string surname; // s
        string name; // n
        string patronymic; // p
        DateTime? date_birth; // b
        string pole; // po
        string type_sport; // t
        List<string> teams = new List<string>();

        // �����������
        public Person(string s, string n, string p, DateTime? b, string po, string t)
        {
            Surname = s;
            Name = n;
            Patronymic = p;
            Date_birth = b;
            Pole = po; 
            Type_sport = t;
        }

        // ����������� �������
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        public string Pole // ��� ��������
        {
            get { return pole; }
            set { pole = value; }
        }
        public List<string> Teams
        {
            get { return teams; }
            set { teams = value; }
        }
        // �������� � ������������ �������� ������
        public DateTime? Date_birth
        {
            get
            { return date_birth; }
            set
            {
                date_birth = value;
                DateTime now = DateTime.Now;
                if (now > date_birth)
                {
                    date_birth = value;
                }
                else
                {
                    date_birth = null;
                }
            }
        }
        public string Type_sport
        {
            get { return type_sport; }
            set { type_sport = value; }
        }

        // ������� ������
        // ���������� ���������� ������ � ������
        public List<string> add_new_team(string new_team)
        {
            this.teams.Add(new_team);
            return this.teams;
        }
        // �������� ���������� ������
        public List<string> del_team(string old_team)
        {
            this.teams.Remove(old_team);
            return this.teams;
        }
    }
}

