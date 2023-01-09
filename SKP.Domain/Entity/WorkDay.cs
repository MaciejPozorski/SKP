using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP
{
    public class WorkDay
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateOnly Day { get; set; }
        public int Hours { get; set; }

        public WorkDay(int id, int personId, DateOnly day, int hours)
        {
            Id = id;
            PersonId = personId;
            Day = day;
            Hours = hours;
        }

        //public WorkDay()
        //{
        //}
    }
}
