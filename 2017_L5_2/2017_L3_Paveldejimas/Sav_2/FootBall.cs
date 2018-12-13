using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_2
{
    class FootBall : Player
    {
        public int Goal { get; set; }
        public int Yellow { get; set; }

        public FootBall(int goal, int yellow, string team, string name, string secondname, string date, int ammount) : base(team, name, secondname, date, ammount)
        {
            Goal = goal;
            Yellow = yellow;
            Sport = "footbolininkas";
        }

        public override int GetPlayerScoreInfo()
        {
            return Goal;
        }

        public override int GetPlayerSpecialInfo()
        {
            return Yellow;
        }
    }
}
