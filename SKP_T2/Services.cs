using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP_T2
{
    public class Services
    {
        private List<Person> people { get; set; }
        private List<WorkDay> workDays { get; set; }
        public Services()
        {
            people = new List<Person>();
            workDays = new List<WorkDay>();
        }
        MenuBuilder menuBuilder = new MenuBuilder();

        public List<Person> EditService(List<Person> people)
        {
            this.people = people;
            string input;

            Console.WriteLine();
            Console.WriteLine("Edit list.");
            Console.WriteLine("Choose action (0: exit):");
            menuBuilder.showMenu("eworker");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddWorker();
                    Console.Clear();
                    ShowList(this.people);
                    Console.WriteLine("Done!");
                    Console.WriteLine("Press any key to leave");
                    Console.ReadLine();
                    Console.Clear();
                    return this.people;


                case "2":
                    RemoveWorker();
                    Console.Clear();
                    ShowList(this.people);
                    Console.WriteLine("Done!");
                    Console.WriteLine("Press any key to leave");
                    Console.ReadLine();
                    Console.Clear();
                    return this.people;

                default:
                    Console.Clear();
                    return this.people;


            }
        }

        public List<WorkDay> EditService(List<WorkDay> workDays)
        {
            this.workDays = workDays;
            string input;

            Console.WriteLine("Edit list.");
            Console.WriteLine("Choose action (0: exit):");
            menuBuilder.showMenu("eday");

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddWorkDay();
                    Console.Clear();
                    ShowList(this.workDays);
                    Console.WriteLine("Done!");
                    Console.WriteLine("Press any key to leave");
                    Console.ReadLine();
                    Console.Clear();

                    return this.workDays;
                    break;


                case "2":
                    RemoveWorkDay();
                    Console.Clear();
                    ShowList(this.workDays);
                    Console.WriteLine("Done!");
                    Console.WriteLine("Press any key to leave");
                    Console.ReadLine();
                    Console.Clear();
                    return this.workDays;
                    break;



                default:
                    Console.Clear();
                    return this.workDays;
                    break;

            }


        }

        private void RemoveWorkDay()
        {
            Console.WriteLine("Type day of work id to remove:");
            string id = Console.ReadLine();
            foreach (var item in workDays.ToList())
            {
                if (item.Id == Int32.Parse(id))
                {
                    workDays.Remove(item);
                }
            }
        }


        private void RemoveWorker()
        {
            Console.WriteLine("Type worker id to remove:");
            string id = Console.ReadLine();
            foreach (var item in people.ToList())
            {
                if (item.Id == Int32.Parse(id))
                {
                    people.Remove(item);
                }
            }
        }

        public void ShowList(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"Id: {person.Id}  " +
                    $"FirstName: {person.FirstName}  " +
                    $"LastName: {person.LastName}  " +
                    $"PhoneNumber: {person.PhoneNumber}  " +
                    $"Pesel: {person.Pesel}  " +
                    $"BirthDate: {person.BirthDate}");
                Console.WriteLine("");
            }
        }

        public void ShowList(List<WorkDay> workDays)
        {
            foreach (var day in workDays)
            {
                Console.WriteLine($"Id: {day.Id}  " +
                    $"PersonId: {day.PersonId}  " +
                    $"Day: {day.Day}  " +
                    $"Hours: {day.Hours}");
                Console.WriteLine("");
            }
        }

        private void AddWorkDay()
        {
            Console.WriteLine("PersonID Day(dd/mm/yyyy) Hours");
            string input = Console.ReadLine();
            WorkDay finalResult = new WorkDay();
            StringBuilder word = new StringBuilder();
            int i = 0;
            string[] result = new string[6];
            foreach (char item in input)
            {
                if (item == ' ')
                {
                    result[i] = word.ToString();
                    i++;
                    word.Clear();
                }
                else
                {
                    word.Append(item.ToString());
                }

            }
            result[i] = word.ToString();
            finalResult.Id = workDays.Last().Id + 1;
            finalResult.PersonId = Int32.Parse(result[0]);
            finalResult.Day = DateOnly.Parse(result[1]);
            finalResult.Hours = Int32.Parse(result[2]);

            workDays.Add(finalResult);
        }

        private void AddWorker()
        {
            Console.WriteLine("firstname lastname phone pesel birth(dd/mm/yyyy)");
            string input = Console.ReadLine();
            Person finalResult = new Person();
            StringBuilder word = new StringBuilder();
            int i = 0;
            string[] result = new string[6];
            foreach (char item in input)
            {
                if (item == ' ')
                {
                    result[i] = word.ToString();
                    i++;
                    word.Clear();
                }
                else
                {
                    word.Append(item.ToString());
                }

            }
            result[i] = word.ToString();
            finalResult.Id = people.Last().Id + 1;
            finalResult.FirstName = result[0].ToString();
            finalResult.LastName = result[1].ToString();
            finalResult.PhoneNumber = double.Parse(result[2]);
            finalResult.Pesel = double.Parse(result[3]);
            finalResult.BirthDate = DateOnly.Parse(result[4]);

            people.Add(finalResult);
        }


    }
}
