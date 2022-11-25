using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP_T2
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double PhoneNumber { get; set; }
        public double Pesel { get; set; }
        public DateOnly BirthDate { get; set; }
    }

    public class WorkDay
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime Day { get; set; }
        public int Hours { get; set; }
    }
}
