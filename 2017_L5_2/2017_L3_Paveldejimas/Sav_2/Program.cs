using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_2
{
    class Program
    {
        public const int containerSize = 50;

        static void Main(string[] args)
        {
            var p = new Program();
            var AllPlayers = p.ReadPlayerData("NBA.csv", "FIFA.csv");
            var AllTeams = p.ReadTeamData("TEAMS.csv");

            PlayerContainer filteredB = p.FilterPlayers(AllPlayers, AllTeams, "krepsininkas");
            PlayerContainer filteredF = p.FilterPlayers(AllPlayers, AllTeams, "footbolininkas");


            Console.WriteLine("Krepsinio zaidejai zaide visuose komandos zaidimuose ir yra rezultatyvus nemaziau kaip komandos vidurkis");
            Console.WriteLine();
            for (int i = 0; i < filteredB.Count; i++)
            {
                Console.WriteLine(filteredB.GetPlayer(i).ToString());
                Console.WriteLine($"Taskai : {filteredB.GetPlayer(i).GetPlayerScoreInfo()} , komandos vidurkis : {AllTeams.GetTeam(AllTeams.GetNameID(filteredB.GetPlayer(i).Team)).AverageScore} ");
                Console.WriteLine($"atkovoti Kamuoliai : {filteredB.GetPlayer(i).GetPlayerSpecialInfo()} , komandos vidurkis : {AllTeams.GetTeam(AllTeams.GetNameID(filteredB.GetPlayer(i).Team)).AverageSpecial} ");
                Console.WriteLine();
            }

            for (int i = 0; i < 1; i++)
                Console.WriteLine();

            Console.WriteLine("Futbolo zaidejai zaide visuose komandos zaidimuose ir yra rezultatyvus nemaziau kaip komandos vidurkis");
            Console.WriteLine();
            for (int i = 0; i < filteredF.Count; i++)
            {
                Console.WriteLine(filteredF.GetPlayer(i).ToString());
                Console.WriteLine($"Taskai : {filteredF.GetPlayer(i).GetPlayerScoreInfo()} , komandos vidurkis : {AllTeams.GetTeam(AllTeams.GetNameID(filteredF.GetPlayer(i).Team)).AverageScore} ");
                Console.WriteLine($"Geltonos korteles : {filteredF.GetPlayer(i).GetPlayerSpecialInfo()} , komandos vidurkis : {AllTeams.GetTeam(AllTeams.GetNameID(filteredF.GetPlayer(i).Team)).AverageSpecial} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        PlayerContainer ReadPlayerData(string fileName1, string fileName2)
        {
            var temp = new PlayerContainer(containerSize);
            string line;
            string[] lines;

            using (var reader = new StreamReader(fileName1))
            {
                while (null != (line = reader.ReadLine()))
                {
                    lines = line.Split(',');
                    var team = lines[0];
                    var name = lines[1];
                    var secondName = lines[2];
                    var date = lines[3];
                    var ammount = int.Parse(lines[4]);
                    var score = int.Parse(lines[5]);
                    var getback = int.Parse(lines[6]);
                    var assist = int.Parse(lines[7]);
                    var temp2 = new BasketBall(score, getback, assist, team, name, secondName, date, ammount);
                    temp.AddPlayer(temp2);
                }
            }
            using (var reader = new StreamReader(fileName2))
            {
                while (null != (line = reader.ReadLine()))
                {
                    lines = line.Split(',');
                    var team = lines[0];
                    var name = lines[1];
                    var secondName = lines[2];
                    var date = lines[3];
                    var ammount = int.Parse(lines[4]);
                    var goal = int.Parse(lines[5]);
                    var yellow = int.Parse(lines[6]);
                    var temp2 = new FootBall(goal, yellow, team, name, secondName, date, ammount);
                    temp.AddPlayer(temp2);
                }
            }

            return temp;
        }
        TeamContainer ReadTeamData(string fileName)
        {
            TeamContainer temp = new TeamContainer(containerSize);
            string line;
            string[] lines;

            using (var reader = new StreamReader(fileName))
            {
                while (null != (line = reader.ReadLine()))
                {
                    lines = line.Split(',');
                    var name = lines[0];
                    var town = lines[1];
                    var trainer = lines[2];
                    var games = int.Parse(lines[3]);
                    var temp2 = new Team(name, town, trainer, games);
                    temp.AddTeam(temp2);
                }
            }
            return temp;
        }
        PlayerContainer FilterPlayers(PlayerContainer original, TeamContainer teams, string sport)
        {
            PlayerContainer Filtered = new PlayerContainer(containerSize);

            int allScore = 0;
            double averageScore = 0;

            int allSpecial = 0;
            double averageSpecial = 0;

            int members = 0;

            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = 0; j < original.Count; j++)
                {
                    if (original.GetPlayer(j).Sport == sport)
                        if (teams.GetTeam(i).Name == original.GetPlayer(j).Team)
                            if (teams.GetTeam(i).Games == original.GetPlayer(j).Ammount)
                            {
                                allScore += original.GetPlayer(j).GetPlayerScoreInfo();
                                allSpecial += original.GetPlayer(j).GetPlayerSpecialInfo();

                                members++;
                            }
                }

                if (members > 0)
                {
                    averageScore = allScore / members;
                    averageSpecial = allSpecial / members;
                    teams.GetTeam(i).AverageScore = averageScore;
                    teams.GetTeam(i).AverageSpecial = averageSpecial;
                }

                for (int j = 0; j < original.Count; j++)
                {
                    if (original.GetPlayer(j).Sport == sport)
                        if (teams.GetTeam(i).Name == original.GetPlayer(j).Team)
                            if (teams.GetTeam(i).Games == original.GetPlayer(j).Ammount)
                                if (original.GetPlayer(j).GetPlayerScoreInfo() >= averageScore)
                                    if (original.GetPlayer(j).GetPlayerSpecialInfo() >= averageSpecial)
                                    {
                                        Filtered.AddPlayer(original.GetPlayer(j));
                                    }
                }
            }

            return Filtered;
        }
    }
}
