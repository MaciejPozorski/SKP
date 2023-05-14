using DocumentFormat.OpenXml.Wordprocessing;
using SKP.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Managers
{
    public class XlsxMenager
    {
        PersonService _personService;
        WorkDayService _workDayService;
        MenuService _menuService = new MenuService();
        public XlsxMenager(PersonService personService, WorkDayService workDayService)
        {
            _personService = personService;
            _workDayService = workDayService;
            XlsxService xlsxService = new XlsxService(personService, workDayService);
        }


        public void MenuView()
        {
            string input;
            do
            {
                _menuService.showMenu("xlsxovv");
                input = Console.ReadLine();
                switch (input)
                {

                    case "1":
                        OnePersonGeneratorView();
                        break;

                    default:
                        Console.WriteLine("Wrong input.");
                        break;
                }
                Console.Clear();
            } while (input != "0");
        }

        private void OnePersonGeneratorView()
        {
            
        }
    }
}
