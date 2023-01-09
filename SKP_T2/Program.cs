﻿using System.Collections.Generic;

namespace SKP;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<WorkDay> workdays = new List<WorkDay>();
        MenuBuilder menuBuilder = new MenuBuilder();
        PersonService personServices = new PersonService();
        WorkDayService workDayServices = new WorkDayService();
        #region loadTestData
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
            Console.WriteLine("Choose action (0: exit):");
            menuBuilder.showMenu("main");

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    personServices.ShowList(people);
                    personServices.EditService(people);
                    break;

                case "2":
                    Console.Clear();
                    workDayServices.ShowList(workdays);
                    workDayServices.EditService(workdays);
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