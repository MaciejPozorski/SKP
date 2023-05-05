using SKP.App.Abstract;
using SKP.App.Concrete;
using SKP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Managers
{
    public class WorkDayManager
    {
        private readonly MenuService _menuService;
        private IService<WorkDay> _workDayService;
        public WorkDayManager(MenuService menuService, IService<WorkDay> workDayService)
        {
            _menuService = menuService;
            _workDayService = workDayService;


            //_workDayService.AddItem(new WorkDay(1, 2, new DateOnly(2000, 12, 1), 8));
            //_workDayService.AddItem(new WorkDay(2, 1, new DateOnly(2000, 12, 1), 8));
            //_workDayService.AddItem(new WorkDay(3, 4, new DateOnly(2000, 12, 1), 8));
            //_workDayService.AddItem(new WorkDay(4, 4, new DateOnly(2000, 12, 1), 8));
            _workDayService.Read();
        }

        public void EditView()
        {
            string input;

            Console.WriteLine("Edit list.");
            Console.WriteLine("Choose action (0: exit):");
            _menuService.showMenu("eday");

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddWorkDayView();

                    break;


                case "2":
                    RemoveWorkDayView();
                    Console.Clear();
                    _workDayService.ToString();
                    Console.ReadLine();
                    Console.Clear();

                    break;



                default:
                    Console.Clear();
                    break;

            }
        }

        private void RemoveWorkDayView()
        {
            Console.WriteLine("Type day of work id to remove:");
            string id = Console.ReadLine();
            int rId;
            if (Int32.TryParse(id, out rId))
            {
                _workDayService.RemoveItem(_workDayService.GetItemById(rId));
                Console.WriteLine("Done!");
                Console.WriteLine("Press any key to leave");
            }
            else
            {
                Console.WriteLine("Wrong input!!!");
                Console.ReadLine();
            }
        }

        private void AddWorkDayView()
        {
            Console.WriteLine("PersonID Day(dd/mm/yyyy) Hours");
            string input = Console.ReadLine();
            WorkDay finalResult = new WorkDay();
            StringBuilder word = new StringBuilder();
            int i = 0;
            string[] result = input.Split(' ');
            try
            {
                if (result.Length != 3)
                {
                    throw new ArgumentException(message: "Wrong input");
                }

                result[i] = word.ToString();
                finalResult.Id = _workDayService.GetLastId() + 1;
                finalResult.PersonId = Int32.Parse(result[0]);
                finalResult.Day = DateOnly.Parse(result[1]);
                finalResult.Hours = Int32.Parse(result[2]);

                _workDayService.AddItem(finalResult);

                Console.Clear();
                Console.WriteLine("Done!");
                Console.WriteLine("last item:");
                Console.WriteLine(
                    _workDayService.GetItemById(
                        _workDayService.GetLastId())
                    );
                Console.WriteLine("Press any key to leave");
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e} exception caught");
                Console.WriteLine("List not defected. Last item:");
                Console.WriteLine(
                    _workDayService.GetItemById(
                        _workDayService.GetLastId())
                    );
                Console.ReadLine();
                Console.Clear();
            }

        }

        public void ShowList()
        {
            foreach (var item in _workDayService.GetAllItems())
            {
                Console.WriteLine(item);
            }
        }

        public WorkDay GetWorkDayById(int id)
        {
            WorkDay day = _workDayService.GetItemById(id);
            return day;
        }


    }
}
