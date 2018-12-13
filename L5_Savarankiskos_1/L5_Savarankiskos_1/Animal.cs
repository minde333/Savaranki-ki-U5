using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_Savarankiskos_1
{
    abstract class Animal
    {
        public string Name { get; set; }

        public string Breed { get; set; }
        public string Owner { get; set; }
        public string Phone { get; set; }
        public DateTime VaccinationDate { get; set; }

        public Animal(string name, string breed, string owner,
            string phone, DateTime vaccinationDate)
        {
            Name = name;
            Breed = breed;
            Owner = owner;
            Phone = phone;
            VaccinationDate = vaccinationDate;
        }

        public Animal(string data)
        {
            SetData(data);
        }

        public abstract void SetData(string line);

        public abstract bool Compare(Animal lhs, Animal rhs);  // lyginami gyvūnai

        abstract public bool isVaccinationExpired();

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Animal);
        }

        public static bool operator ==(Animal lhs, Animal rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Animal lhs, Animal rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator <=(Animal lhs, Animal rhs)
        {
            return lhs.Name.CompareTo(rhs.Name) < 0;
        }

        public static bool operator >=(Animal lhs, Animal rhs)
        {
            return lhs.Name.CompareTo(rhs.Name) > 0;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
