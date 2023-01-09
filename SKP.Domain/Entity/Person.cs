using SKP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.Domain.Entity
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double PhoneNumber { get; set; }
        public double Pesel { get; set; }
        public DateOnly BirthDate { get; set; }

        public Person(int id, string firstName, string lastName, double phoneNumber, double pesel, DateOnly birthDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Pesel = pesel;
            BirthDate = birthDate;
        }

        public Person()
        {
        }
    }


}
