using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_2
{
    class Team
    {
        public string Name { get; set; }
        public string Town { get; set; }
        public string Trainer { get; set; }
        public int Games { get; set; }
        public double AverageScore { get; set; }
        public double AverageSpecial { get; set; }

        public Team(string name, string town, string trainer, int games)
        {
            Name = name;
            Town = town;
            Trainer = trainer;
            Games = games;
        }
    }
}
