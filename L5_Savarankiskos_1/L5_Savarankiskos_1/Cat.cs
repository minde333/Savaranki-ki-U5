using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_Savarankiskos_1
{
    class Cat : AnimalMarked
    {
        private static int VaccinationDurationMonths = 6;

        public Cat(string name, int chipId, string breed, string owner,
            string phone, DateTime vaccinationDate) : base(name, chipId, breed,
        owner, phone, vaccinationDate)
        {
        }

        public Cat(string data) : base(data)
        {
            SetData(data);
        }

        public override bool isVaccinationExpired()
        {
            return VaccinationDate.AddMonths(VaccinationDurationMonths).CompareTo(DateTime.Now) > 0;
        }

        public override bool Compare(Animal lhs, Animal rhs)
        {
            return (lhs as Cat) <= (rhs as Cat);
        }

        public override string ToString()
        {
            return String.Format("|{0,-3}|{1,-20}|{2,-9}|{3,-10} ({4})|{5:yyyy-MM-dd}|",
                ChipId, Breed, Name, Owner, Phone, VaccinationDate);
        }

        public bool Equals(Cat cat)
        {
            return base.Equals(cat);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Cat);
        }

        public override int GetHashCode()
        {
            return ChipId.GetHashCode() ^ Name.GetHashCode();
        }

        public static bool operator ==(Cat lhs, Cat rhs)
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

        public static bool operator !=(Cat lhs, Cat rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator <=(Cat lhs, Cat rhs)
        {
            return lhs.ChipId <= rhs.ChipId;
        }

        public static bool operator >=(Cat lhs, Cat rhs)
        {
            return lhs.ChipId >= rhs.ChipId;
        }
    }
}
