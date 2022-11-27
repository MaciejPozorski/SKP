using System.Collections.Generic;

namespace SKP_T2;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<WorkDay> workdays = new List<WorkDay>();
        MenuBuilder menuBuilder = new MenuBuilder();
        Services services = new Services();
        #region zaladowanie danych
        people.Add(new Person(1, "Adam", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
        people.Add(new Person(2, "Maciej", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
        people.Add(new Person(3, "Zbychu", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
        people.Add(new Person(4, "Kasia", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));

        workdays.Add(new WorkDay(1, 2, new DateOnly(2000, 12, 1), 8));
        workdays.Add(new WorkDay(2, 1, new DateOnly(2000, 12, 1), 8));
        workdays.Add(new WorkDay(3, 4, new DateOnly(2000, 12, 1), 8));
        workdays.Add(new WorkDay(4, 4, new DateOnly(2000, 12, 1), 8));
        #endregion
        string input;
        do
        {

            Console.WriteLine("MAIN");
            Console.WriteLine("Press what you want to do (0: exit):");
            menuBuilder.showMenu("main");

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    services.ShowList(people);
                    people = services.EditService(people);
                    break;

                case "2":
                    Console.Clear();
                    services.ShowList(workdays);
                    services.EditService(workdays);
                    break;
                    
                case "0":
                    Console.WriteLine("Bye!");
                    break;


                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        } while (input != "0");

    }


}