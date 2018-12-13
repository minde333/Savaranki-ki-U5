using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_2
{
    class BasketBall : Player
    {
        public int Score { get; set; }
        public int GetBack { get; set; }
        public int Assist { get; set; }

        public BasketBall(int score, int getback, int assist, string team, string name, string secondname, string date, int ammount) : base(team, name, secondname, date, ammount)
        {
            Score = score;
            GetBack = getback;
            Assist = assist;
            Sport = "krepsininkas";
        }
        public override int GetPlayerScoreInfo()
        {
            return Score;
        }

        public override int GetPlayerSpecialInfo()
        {
            return GetBack;
        }
    }
}
