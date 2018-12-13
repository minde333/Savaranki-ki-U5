using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_Savarankiskos_1
{
    class GuineaPig : Animal
    {
        private static int VaccinationDurationMonths = 6;

        public GuineaPig(string name, string breed, string owner,
            string phone, DateTime vaccinationDate) : base(name, breed,
        owner, phone, vaccinationDate)
        {
        }

        public GuineaPig(string data) : base(data)
        {
            SetData(data);
        }

        public override void SetData(string line)
        {
            string[] values = line.Split(',');
            Name = values[1];
            Breed = values[2];
            Owner = values[3];
            Phone = values[4];
            VaccinationDate = DateTime.Parse(values[5]);
        }

        public override bool isVaccinationExpired()
        {
            return VaccinationDate.AddMonths(VaccinationDurationMonths).CompareTo(DateTime.Now) > 0;
        }

        public override bool Compare(Animal lhs, Animal rhs)
        {
            return (lhs as GuineaPig) <= (rhs as GuineaPig);
        }
        public override string ToString()
        {
            return String.Format("|{0,-20}|{1,-9}|{2,-10} ({3})|{4:yyyy-MM-dd}|",
                Breed, Name, Owner, Phone, VaccinationDate);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as GuineaPig);
        }

        public bool Equals(GuineaPig guineaPig)
        {
            return base.Equals(guineaPig);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator ==(GuineaPig lhs, GuineaPig rhs)
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

        public static bool operator !=(GuineaPig lhs, GuineaPig rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator <=(GuineaPig lhs, GuineaPig rhs)
        {
            return lhs.Name.CompareTo(rhs.Name) <= 0;
        }

        public static bool operator >=(GuineaPig lhs, GuineaPig rhs)
        {
            return lhs.Name.CompareTo(rhs.Name) >= 0;
        }
    }
}
