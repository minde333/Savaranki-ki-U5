using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_Savarankiskos_1
{
    class Dog : AnimalMarked
    {
        private static int VaccinationDuration = 1;

        public bool Aggressive { get; set; }

        public Dog(string name, int chipId, string breed, string owner,
            string phone, DateTime vaccinationDate, bool aggressive) : base(name, chipId, breed,
            owner, phone, vaccinationDate)
        {
            Aggressive = aggressive;
        }

        public Dog(string data) : base(data)
        {
            SetData(data);
        }

        public override void SetData(string line)
        {
            base.SetData(line);
            string[] values = line.Split(',');
            Aggressive = bool.Parse(values[7]);
        }

        public override bool isVaccinationExpired()
        {
            return VaccinationDate.AddMonths(VaccinationDuration).CompareTo(DateTime.Now) > 0;
        }

        public override bool Compare(Animal lhs, Animal rhs)
        {
            return (lhs as Dog) <= (rhs as Dog);
        }

        public override string ToString()
        {
            return String.Format("|{0,-3}|{1,-20}|{2,-9}|{3,-10} ({4})|{5:yyyy-MM-dd}|{6}|",
                ChipId, Breed, Name, Owner, Phone, VaccinationDate, Aggressive ? '+' : ' ');
        }

        public bool Equals(Dog dog)
        {
            return base.Equals(dog);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Dog);
        }

        public override int GetHashCode()
        {
            return ChipId.GetHashCode() ^ Name.GetHashCode();
        }

        public static bool operator ==(Dog lhs, Dog rhs)
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

        public static bool operator !=(Dog lhs, Dog rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator <=(Dog lhs, Dog rhs)
        {
            return lhs.ChipId <= rhs.ChipId;
        }

        public static bool operator >=(Dog lhs, Dog rhs)
        {
            return lhs.ChipId >= rhs.ChipId;
        }
    }
}
