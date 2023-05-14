using SKP.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Managers
{
    public class ConsoleOvervievMenager
    {
        private PersonService _personService;
        private WorkDayService _workDayService;
        private MenuService _menuService;
        OverviewSerivce _overviewSerivce;
        public ConsoleOvervievMenager(PersonService personService, WorkDayService workDayService, MenuService menuService)
        {
            _personService = personService;
            _workDayService = workDayService;
            _menuService = menuService;
            _overviewSerivce = new OverviewSerivce(personService, workDayService);

        }

        public void MenuView()
        {
            Console.Clear();
            _menuService.showMenu("cwovv");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    ShowPersonOverview();
                    break;

                case "2":
                    Console.Clear();
                    _overviewSerivce.FullOverviewWriter();
                    Console.ReadLine();
                    break;
            }
        }


        private void ShowPersonOverview()
        {
            Console.WriteLine("Type worker id to show:");
            string id = Console.ReadLine();
            int rId;

            if (Int32.TryParse(id, out rId))
            {
                _overviewSerivce.OverviewWriterById(rId);
                Console.WriteLine("Done!");
                Console.WriteLine("Press any key to leave");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wrong input!!!");
                Console.ReadLine();
            }
        }
    }
}
