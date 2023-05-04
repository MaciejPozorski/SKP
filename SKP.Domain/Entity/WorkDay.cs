using SKP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SKP.Domain.Entity
{
    public class WorkDay : BaseEntity
    {
        [XmlElement("PersonId")]
        public int PersonId { get; set; }
        [XmlElement("Day")]
        public DateOnly Day { get; set; }
        [XmlElement("Hours")]
        public int Hours { get; set; }

        public WorkDay(int id, int personId, DateOnly day, int hours)
        {
            Id = id;
            PersonId = personId;
            Day = day;
            Hours = hours;
        }

        public WorkDay()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id.ToString()}  " +
                    $"PersonId: {PersonId.ToString()}  " +
                    $"Day: {Day.ToString()}  " +
                    $"Hours: {Hours.ToString()}";
        }

        
    }
}
