using SKP.App.Abstract;
using SKP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SKP.App.Concrete
{

    public class XmlService
    {
        private IService<Person> _personService;
        private IService<WorkDay> _workDayService;
        public XmlService(IService<Person> personService, IService<WorkDay> workDayService)
        {
            _personService = personService;
            _workDayService = workDayService;
        }

        public void GetWorkersByDay()
        {
            var innerJoin = _workDayService.GetAllItems().Join(
                _personService.GetAllItems(),
                w => w.PersonId,
                p => p.Id,
                (w, p) => new
                {
                    workdayName = w.Day,
                    personName = p.FirstName
                }
                );

        }

        public void WorkDayToXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "WorkDays";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<WorkDay>), root);

            using StreamWriter sw = new StreamWriter("workDays.xml");
            xmlSerializer.Serialize(sw, _workDayService.GetAllItems());
            Console.WriteLine( "xml done!");
            Console.ReadLine();
        }
    }
}
