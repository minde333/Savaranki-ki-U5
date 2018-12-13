using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_2
{
    abstract class Player
    {
        public string Team { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Date { get; set; }
        public int Ammount { get; set; }
        public string Sport { get; set; }

        public Player(string team, string name, string secondname, string date, int ammount)
        {
            Team = team;
            Name = name;
            SecondName = secondname;
            Date = date;
            Ammount = ammount;
        }
        abstract public int GetPlayerScoreInfo();

        abstract public int GetPlayerSpecialInfo();

        public override string ToString()
        {
            return string.Format("Komandos " + Team + " Zaidejas, " + Sport + " : " + Name + " " + SecondName + "  gimes - " + Date);
        }

    }
}
