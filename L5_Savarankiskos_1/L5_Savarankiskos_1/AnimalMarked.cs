using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_Savarankiskos_1
{
    abstract class AnimalMarked : Animal
    {
        public int ChipId { get; set; }

        public AnimalMarked(string name, int chipId, string breed, string owner,
            string phone, DateTime vaccinationDate) : base(name, breed,
            owner, phone, vaccinationDate)
        {
            ChipId = chipId;
        }

        public AnimalMarked(string data) : base(data)
        {
            SetData(data);
        }

        public override void SetData(string line)
        {
            string[] values = line.Split(',');
            Name = values[1];
            ChipId = int.Parse(values[2]);
            Breed = values[3];
            Owner = values[4];
            Phone = values[5];
            VaccinationDate = DateTime.Parse(values[6]);
        }


        public bool Equals(AnimalMarked animal)
        {
            if (Object.ReferenceEquals(animal, null))
            {
                return false;
            }
            if (this.GetType() != animal.GetType())
            {
                return false;
            }
            return (ChipId == animal.ChipId) && (Name == animal.Name);
        }

        public override int GetHashCode()
        {
            return ChipId.GetHashCode() ^ Name.GetHashCode();
        }

        public static bool operator <=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return lhs.ChipId <= rhs.ChipId;
        }

        public static bool operator >=(AnimalMarked lhs, AnimalMarked rhs)
        {
            return lhs.ChipId >= rhs.ChipId;
        }
    }
}
