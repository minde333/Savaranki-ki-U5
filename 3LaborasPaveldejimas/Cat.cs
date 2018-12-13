using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3LaborasPaveldejimas
{
    class Cat : Animal
    {
        private static int VaccinationDurationMonths = 6;
        public Cat(string name, int chipId, string breed, string owner, string phone,
        DateTime vaccinationDate)
        : base(name, chipId, breed, owner, phone, vaccinationDate)
        {
        }

        public Cat(string data)
        : base(data)
        {
            SetData(data);
        }
        //abstraktaus Animal klasės metodo realizacija
        public override bool isVaccinationExpired()
        {
            return
           VaccinationDate.AddMonths(VaccinationDurationMonths).CompareTo(DateTime.Now) > 0;
        }
        public override String ToString()
        {
            return String.Format("ChipId: {0,-5} Breed: {1,-20} Name: {2,-10} Owner: {3,-10} ({4})" +
                                 " Last vaccination date: {5:yyyy - MM - dd} ",
                                 ChipId, Breed, Name, Owner, Phone, VaccinationDate);
        }
    }
}
