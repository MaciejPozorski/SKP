using SKP.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Managers
{
    public class OvervievMenager
    {
        private MenuService _menuService = new MenuService();
        OverviewSerivce _overviewSerivce;
        XlsxMenager _xlsxMenager;
        public OvervievMenager(PersonService personService, WorkDayService workDayService)
        {
            _overviewSerivce = new OverviewSerivce(personService, workDayService);
            _xlsxMenager = new XlsxMenager(personService, workDayService);
        }

        public void MenuView()
        {
            Console.Clear();
            _menuService.showMenu("ovv");
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
                case "3":
                    Console.Clear();
                    _xlsxMenager.MenuView();
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
