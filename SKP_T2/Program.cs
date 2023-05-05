using SKP.App.Abstract;
using SKP.App.Concrete;
using SKP.App.Managers;
using SKP.Domain.Entity;
using System.Collections.Generic;

namespace SKP;

public class Program
{
    static void Main(string[] args)
    {
        WorkDayService workDayService = new WorkDayService();
        PersonService personService= new PersonService();
        MenuService menuService = new MenuService();
        MemoryService memoryService = new MemoryService();
        WorkDayManager workDayManager = new WorkDayManager(menuService, workDayService);
        PersonManager personManager = new PersonManager(menuService, personService);
        XmlService xmlService = new XmlService(personService, workDayService);
        
        string input;
        do
        {

            Console.WriteLine("MAIN");
            Console.WriteLine("Choose action (0: exit):");
            menuService.showMenu("main");

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    personManager.ShowList();
                    personManager.EditView();
                    memoryService.Save(personService);
                    break;

                case "2":
                    Console.Clear();
                    workDayManager.ShowList();
                    workDayManager.EditView();
                    memoryService.Save(workDayService);
                    break;
                case "3":
                    Console.Clear();
                    xmlService.GetWorkersByDay();
                    break;
                case "4":
                    Console.Clear();
                    xmlService.WorkDayToXml();
                    break;

                case "0":
                    Console.WriteLine("Bye!");
                    break;


                default:
                    Console.Clear();
                    Console.WriteLine("Wrong input.");
                    break;
            }
        } while (input != "0");

    }


}