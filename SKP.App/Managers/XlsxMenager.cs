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
        XlsxService xlsxService;
        public XlsxMenager(PersonService personService, WorkDayService workDayService)
        {
            _personService = personService;
            _workDayService = workDayService;
            xlsxService = new XlsxService(personService, workDayService);
        }


        public void MenuView()
        {
            string input;
            do
            {
                Console.Clear();
                _menuService.showMenu("xlsxovv");
                input = Console.ReadLine();
                switch (input)
                {

                    case "1":
                        OnePersonOvvGeneratorView();
                        break;
                    case "2":
                        FullOvvGeneratorView();
                        break;

                    default:
                        Console.WriteLine("Wrong input.");
                        break;
                }
                Console.Clear();
            } while (input != "0");
        }

        private void FullOvvGeneratorView()
        {
            if (xlsxService.OverviewFileGenerator())
            {
                Console.WriteLine("Save complited!");
            }
            else
            {
                Console.WriteLine("Something went wong :(");
            }
            Console.ReadKey();
        }

        private void OnePersonOvvGeneratorView()
        {
            foreach (var item in _personService.GetAllItems())
            {
                Console.WriteLine($"Id: {item.Id}, {item.FirstName} {item.LastName}");
            }
            Console.WriteLine("Type person id to generate overview:");
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int i))
            {
                if (_personService.GetItemById(i) != null)
                {
                    if (xlsxService.OverviewFileGenerator(i))
                    {
                        Console.WriteLine("Save complited!");
                    }
                    else
                    {
                        Console.WriteLine("Something went wong :(");
                    }
                }
                else
                {
                    Console.WriteLine("Person does not exist");
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }
            Console.ReadKey();
        }
    }
}
