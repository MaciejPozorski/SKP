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
        PersonService personService = new PersonService();
        MenuService menuService = new MenuService();
        FileService memoryService = new FileService();
        WorkDayManager workDayManager = new WorkDayManager(menuService, workDayService);
        PersonManager personManager = new PersonManager(menuService, personService);
        OvervievMenager consoleOvervievMenager = new OvervievMenager(personService, workDayService);
        string input;
        do
        {

            Console.Clear();
            Console.WriteLine("MAIN");
            menuService.showMenu("main");

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    personManager.ShowList();
                    personManager.EditView();
                    memoryService.Save(personService);
                    break;

                case "2":
                    workDayManager.ShowList();
                    workDayManager.EditView();
                    memoryService.Save(workDayService);
                    break;
                case "3":
                    consoleOvervievMenager.MenuView();
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