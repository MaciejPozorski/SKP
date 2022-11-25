using System.Collections.Generic;

namespace SKP_T2;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("cyfra");
        List<Person> people = new List<Person>();
        MenuBuilder menuBuilder = new MenuBuilder();
        Services services = new Services();


        while (true)
        {
            Console.WriteLine("Press what you want to do (0: exit):");
            services.showMenu("main");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":

                    services.editService("eworker");
                    break;

                case "2":

                    services.editService("eday");
                    break;


                default:
                    break;
            }
        }

    }

}