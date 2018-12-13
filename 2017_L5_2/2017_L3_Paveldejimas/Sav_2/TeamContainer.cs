using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_2
{
    class TeamContainer
    {
        private Team[] Teams;
        public int Count { get; private set; }

        public TeamContainer(int size)
        {
            Teams = new Team[size];
            Count = 0;
        }
        public void AddTeam(Team team)
        {
            Teams[Count++] = team;
        }
        public Team GetTeam(int index)
        {
            return Teams[index];
        }
        
        public int GetNameID(string name)
        {
            for (int i = 0; i < Count; i++)
                if (Teams[i].Name == name) return i;
            return -1;
        }
    }
}
