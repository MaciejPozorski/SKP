using SKP.App.Abstract;
using SKP.Domain.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Concrete
{
    public class OverviewSerivce
    {
        private PersonService _personService;
        private WorkDayService _workDayService;
        public OverviewSerivce(PersonService personService, WorkDayService workDayService)
        {         
            _personService = personService;
            _workDayService = workDayService;
        }


        public void OverviewWriterById(int id)
        {
            Person person = _personService.GetItemById(id);

            Console.WriteLine($"{person.FirstName} {person.LastName}:");
            OverviewWriter((IEnumerable<dynamic>)WorkDayInfoGetterByPersonId(id));
        }

        public IEnumerable WorkDayInfoGetterByPersonId(int id)
        {
            var data = _workDayService.GetAllItems()
                .Where(x => x.PersonId == id)
                .Select(i => new { i.Day, i.Hours }).ToList();
            return data;
        }

        private void OverviewWriter(IEnumerable<dynamic> workDayList)
        {
            foreach (var item in workDayList)
            {
                Console.WriteLine($"{item.Day} przepracowano: {item.Hours} godzin.");
            }
        }

        public void FullOverviewWriter()
        {
            foreach (var item in _personService.GetAllItems())
            {
                OverviewWriterById(item.Id);
            }
        }
    }
}
