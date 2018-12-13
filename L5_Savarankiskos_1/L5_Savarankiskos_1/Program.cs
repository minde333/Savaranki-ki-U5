using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L5_Savarankiskos_1
{
    class Program
    {
        public const int MaxNumberOfBranches = 10;
        public const int MaxNumberOfAnimals = 50;
        public const int MaxNumberOfBreeds = 50;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Program p = new Program();

            Branch[] branches = new Branch[MaxNumberOfBranches];

            int NumberOfBranches = 0;
            const string DataDir = @"..\..\Data";
            p.ReadData(DataDir, branches, ref NumberOfBranches);

            Console.WriteLine("Užregistruoti šunys:");
            p.PrintAnimalsToConsole(branches[0], branches[0].Town, 'D');
            Console.WriteLine();

            Console.WriteLine("Užregistruotos katės:");
            p.PrintAnimalsToConsole(branches[0], branches[0].Town, 'c');
            Console.WriteLine();

            Console.WriteLine("Agresyvūs šunys\n {0}: {1}", branches[0].Town, p.CountAggressive(branches[0]));
            Console.WriteLine("Agresyvūs šunys\n {0}: {1}", branches[0].Town, p.CountAggressive(branches[1]));

            Console.WriteLine("Populiariausia šunų veislė\n {0}: {1}", branches[0].Town, p.GetMostPopularBreed(p.GetAnimals("Filialas: {0} Gyvūnas: šuo", branches[0], 'D')));
            Console.WriteLine("Populiariausia kačių veislė\n {0}: {1}", branches[1].Town, p.GetMostPopularBreed(p.GetAnimals("Filialas: {0} Gyvūnas: katė", branches[1], 'C')));
            Console.WriteLine();

            Console.WriteLine("Pagal lusto Nr. surūšiuotas filialų šunų sąrašas:");
            Branch allDogs = p.GetAllAnimals(branches, NumberOfBranches, "Visi šunys", 'D');
            allDogs.SortAnimals();
            p.PrintAnimalsToConsole(allDogs, allDogs.Town, '-');
            Console.WriteLine();

            Console.WriteLine("Pagal lusto Nr. surūšiuotas filialų kačių sąrašas:");
            Branch allCats = p.GetAllAnimals(branches, NumberOfBranches, "Visos katės", 'C');
            allCats.SortAnimals();
            p.PrintAnimalsToConsole(allCats, allCats.Town, '-');
            Console.WriteLine();

            Console.WriteLine("Pagal vardus surūšiuotos jūrų kiaulytės:");
            Branch allGuineaPigs = p.GetAllAnimals(branches, NumberOfBranches, "Visos jūrų kiaulytės", 'G');
            allGuineaPigs.SortAnimals();
            p.PrintAnimalsToConsole(allGuineaPigs, allGuineaPigs.Town, '-');
            Console.WriteLine();
        }

        /// <summary>
        /// Perskaito filialo duomenis iš failo
        /// </summary>
        /// <param name="file"> aplanko vardas </param>
        /// <param name="branches"> filialai, į kuriuos sudedami duomenys </param>
        /// <param name="number"> filialų skaičius </param>
        private void ReadData(string file, Branch[] branches, ref int number)
        {
            string[] filePaths = Directory.GetFiles(file, "*.csv");
            foreach (string path in filePaths)
            {
                ReadAnimalData(path, branches, ref number);
            }
        }

        /// <summary>
        /// Perskaito filialo duomenis iš failo
        /// </summary>
        /// <param name="file"> failo vardas </param>
        /// <param name="branches"> filialas, į kurį sudedami duomenys </param>
        /// <param name="number"> filialų skaičius </param>
        private void ReadAnimalData(string file, Branch[] branches, ref int number)
        {
            using (StreamReader reader = new StreamReader(file, Encoding.UTF8))
            {
                string line = reader.ReadLine();
                Branch branch = GetBranchByTown(branches, ref number, line);
                while (null != (line = reader.ReadLine()))
                {
                    switch (line[0])
                    {
                        case 'D':
                            branch.AddAnimal(new Dog(line));
                            break;
                        case 'C':
                            branch.AddAnimal(new Cat(line));
                            break;
                        case 'G':
                            branch.AddAnimal(new GuineaPig(line));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// suranda filialą pagal pavadinimą
        /// </summary>
        /// <param name="branches"> filialų masyvas </param>
        /// <param name="number"> filialų skaičius </param>
        /// <param name="town"> miestas </param>
        /// <returns> surastas arba naujai sukurtas Branch objektas </returns>
        private Branch GetBranchByTown(Branch[] branches, ref int number, string town)
        {
            for (int i = 0; i < number; i++)
            {
                if (branches[i].Town == town)
                {
                    return branches[i];
                }
            }
            branches[number++] = new Branch(town);
            return branches[number - 1];
        }

        /// <summary>
        /// Išveda filialo duomenis į ekraną
        /// </summary>
        /// <param name="ba"> filialas </param>
        /// <param name="title"> lentelės pavadinimas </param>
        /// <param name="type"> spausdinamo gyvūno tipas </param>
        void PrintAnimalsToConsole(Branch ba, string title, char type)
        {
            string s = new string('-', ba.GetAnimal(0).ToString().Length);
            Console.WriteLine(title);
            Console.WriteLine(s);
            for (int i = 0; i < ba.Count; i++)
            {
                switch (type)
                {
                    case 'D':
                    case 'd':
                        if (ba.GetAnimal(i) is Dog)
                            Console.WriteLine(ba.GetAnimal(i));
                        break;
                    case 'C':
                    case 'c':
                        if (ba.GetAnimal(i) is Cat)
                            Console.WriteLine(ba.GetAnimal(i));
                        break;
                    case 'G':
                    case 'g':
                        if (ba.GetAnimal(i) is GuineaPig)
                            Console.WriteLine(ba.GetAnimal(i));
                        break;

                    default:
                        Console.WriteLine(ba.GetAnimal(i));
                        break;
                }
            }
            Console.WriteLine(s);
        }

        /// <summary>
        /// Iš gyvūnų sąrašo išrenkami tik reikiami gyvūnai - šunys, katės arba jūrų kiaulytės
        /// </summary>
        /// <param name="forma"> kuriamo rinkinio įvardinimas </param>
        /// <param name="ba"> filialas </param>
        /// <param name="type"> gyvūnų tipas </param>
        /// <returns> Branch objektas,kuriame yra tik nurodyto tipo gyvūnai </returns>
        private Branch GetAnimals(string forma, Branch ba, char type)
        {
            Branch animals = new Branch(String.Format(forma, ba.Town));
            for (int i = 0; i < ba.Count; i++)
            {
                switch (type)
                {
                    case 'D':
                    case 'd':
                        if (ba.GetAnimal(i) is Dog)
                            animals.AddAnimal(ba.GetAnimal(i));
                        break;
                    case 'C':
                    case 'c':
                        if (ba.GetAnimal(i) is Cat)
                            animals.AddAnimal(ba.GetAnimal(i));
                        break;
                    case 'G':
                    case 'g':
                        if (ba.GetAnimal(i) is GuineaPig)
                            animals.AddAnimal(ba.GetAnimal(i));
                        break;
                }
            }
            return animals;
        }

        /// <summary>
        /// Suformuojamas filiale užregistruotų veislių rinkinys
        /// </summary>
        /// <param name="ba"> filialas </param>
        /// <param name="breeds"> skirtingų veislių masyvas </param>
        /// <param name="breedCount"> skirtingų veislių kiekis </param>
        private void GetBreeds(Branch ba, out string[] breeds, out int breedCount)
        {
            breeds = new string[MaxNumberOfBreeds];
            breedCount = 0;
            for (int i = 0; i < ba.Count; i++)
            {
                if (!breeds.Contains(ba.GetAnimal(i).Breed))
                {
                    breeds[breedCount++] = ba.GetAnimal(i).Breed;
                }
            }
        }

        /// <summary>
        /// Išrenkami tk nurodytos veislės gyvūnai
        /// </summary>
        /// <param name="ba"> filialas </param>
        /// <param name="breed"> veislės pavadinimas </param>
        /// <returns></returns>
        private Branch FilteredByBreed(Branch ba, string breed)
        {
            Branch filtered = new Branch(breed);
            for (int i = 0; i < ba.Count; i++)
            {
                if (ba.GetAnimal(i).Breed == breed)
                    filtered.AddAnimal(ba.GetAnimal(i));
            }
            return filtered;
        }

        /// <summary>
        /// Suskaičiuoja agresyvių šunų kiekį filiale
        /// </summary>
        /// <param name="ba"> filialas </param>
        /// <returns> agresyvių šunų kiekis </returns>
        private int CountAggressive(Branch ba)
        {
            int counter = 0;
            for (int i = 0; i < ba.Count; i++)
            {
                if ((ba.GetAnimal(i) is Dog) && (ba.GetAnimal(i) as Dog).Aggressive)
                    counter++;
            }
            return counter;
        }

        /// <summary>
        /// Suranda populiariausios filiale veislės pavadinimą
        /// </summary>
        /// <param name="ba"> filialas </param>
        /// <returns> veislės pavadinimas </returns>
        private string GetMostPopularBreed(Branch ba)
        {
            String popular = "not found";
            int count = 0;

            int breedCount = 0;
            string[] breeds;

            GetBreeds(ba, out breeds, out breedCount);

            for (int i = 0; i < breedCount; i++)
            {
                Branch filtered = FilteredByBreed(ba, breeds[i]);
                if (filtered.Count > count)
                {
                    popular = breeds[i];
                    count = filtered.Count;
                }
            }
            return popular;
        }

        /// <summary>
        /// Iš visų filialų gyvūnų sąrašo išrenkami tik reikiami gyvūnai - šunys, katės arba jūrų kiaulytės
        /// </summary>
        /// <param name="ba"> filialų masyvas </param>
        /// <param name="NumberOfBranches"> filialų skaičius </param>
        /// <param name="forma"> įvardijimas </param>
        /// <param name="type"> gyvūno tipas </param>
        /// <returns> gyvūnų sąrašas </returns>
        private Branch GetAllAnimals(Branch[] ba, int NumberOfBranches, string forma, char type)
        {
            Branch allAnimals = new Branch(forma);
            for (int i = 0; i < NumberOfBranches; i++)
            {
                Branch animals = GetAnimals(forma, ba[i], type);
                allAnimals += animals;
            }
            return allAnimals;
        }
    }
}
