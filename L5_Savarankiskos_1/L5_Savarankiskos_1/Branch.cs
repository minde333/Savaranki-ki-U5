using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_Savarankiskos_1
{
    class Branch
    {
        public string Town { get; set; }
        private Animal[] Animals;
        public int Count { get; private set; }

        public Branch(string town = "")
        {
            Town = town;
            Animals = new Animal[Program.MaxNumberOfAnimals];
        }

        public void AddAnimal(Animal a)
        {
            Animals[Count] = a;
            Count++;
        }

        public Animal GetAnimal(int index)
        {
            return Animals[index];
        }

        public void SortAnimals()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                int m = i;
                for (int j = i + 1; j < Count; j++)
                {
                    if (Animals[j].Compare(Animals[j], Animals[m]))
                        m = j;
                }
                Animal a = Animals[i];
                Animals[i] = Animals[m];
                Animals[m] = a;
            }
        }

        // Sujungia du gyvūnų rinkinius į trečią rinkinį
        public static Branch operator +(Branch a, Branch b)
        {
            Branch c = new Branch(a.Town);
            for (int i = 0; i < a.Count; i++)
            {
                c.AddAnimal(a.Animals[i]);
            }
            for (int i = 0; i < b.Count; i++)
            {
                c.AddAnimal(b.Animals[i]);
            }
            return c;
        }
    }
}
