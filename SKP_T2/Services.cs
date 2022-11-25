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

        public List<Person> editService(List<Person> people)
        {
            this.people = people;
            string input;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Edit list.");
                Console.WriteLine("Press what you want to do (0: exit):");
                menuBuilder.showMenu("eworker");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        addWorker();
                        return this.people;


                    case "2":
                        removeWorker();
                        return this.people;


                    case "0":
                        return this.people;


                    default:
                        return this.people;

                }
                Console.Clear();
            }
            while (input == "0");
        }

        public List<WorkDay> editService(List<WorkDay> workDays)
        {
            this.workDays = workDays;
            string input;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Edit list.");
                Console.WriteLine("Press what you want to do (0: exit):");
                menuBuilder.showMenu("eday");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        addWorkDay();
                        return this.workDays;


                    case "2":
                        removeWorkDay();
                        return this.workDays;


                    case "0":
                        return this.workDays;


                    default:
                        return this.workDays;

                }
                Console.Clear();
            }
            while (input == "0");
        }

        private void removeWorkDay()
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


        private void removeWorker()
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

        public void showList(List<Person> people)
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

        public void showList(List<WorkDay> workDays)
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

        private void addWorkDay()
        {
            Console.WriteLine("Id PersonID Day(dd/mm/yyyy) Hours");
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
            finalResult.Id = Int32.Parse(result[0]);
            finalResult.PersonId = Int32.Parse(result[1]);
            finalResult.Day = DateOnly.Parse(result[2]);
            finalResult.Hours = Int32.Parse(result[3]);

            workDays.Add(finalResult);
        }

        private void addWorker()
        {
            Console.WriteLine("id firstname lastname phone pesel birth(dd/mm/yyyy)");
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
            finalResult.Id = Int32.Parse(result[0]);
            finalResult.FirstName = result[1].ToString();
            finalResult.LastName = result[2].ToString();
            finalResult.PhoneNumber = double.Parse(result[3]);
            finalResult.Pesel = double.Parse(result[4]);
            finalResult.BirthDate = DateOnly.Parse(result[5]);

            people.Add(finalResult);
        }


    }
}
