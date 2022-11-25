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
        
        public void editService(string menuName)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Edit list.");
                Console.WriteLine("Press what you want to do (0: exit):");
                menuBuilder.showMenu(menuName);
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        addWorker();
                        break;

                    case "2":
                        break;

                    default:
                        break;
                }
            }
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
