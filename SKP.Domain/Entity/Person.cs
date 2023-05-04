using SKP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SKP.Domain.Entity
{
    public class Person : BaseEntity
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("PhoneNumber")]
        public double PhoneNumber { get; set; }
        [XmlElement("Pesel")]
        public double Pesel { get; set; }
        [XmlElement("BirthDate")]
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

        public override string ToString()
        {
            return $"Id: {Id.ToString()}  " +
                        $"FirstName: {FirstName.ToString()}  " +
                        $"LastName: {LastName.ToString()}  " +
                        $"PhoneNumber: {PhoneNumber.ToString()}  " +
                        $"Pesel: {Pesel.ToString()}  " +
                        $"BirthDate: {BirthDate.ToString()}";
        }
    }


}
