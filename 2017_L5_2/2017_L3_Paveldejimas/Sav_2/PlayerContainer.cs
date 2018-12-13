using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_2
{
    class PlayerContainer
    {
        private Player[] Players;
        public int Count { get; private set; }

        public PlayerContainer(int size)
        {
            Players = new Player[size];
            Count = 0;
        }
        public void AddPlayer(Player player)
        {
            Players[Count++] = player;
        }
        public Player GetPlayer(int index)
        {
            return Players[index];
        }
    }
}
