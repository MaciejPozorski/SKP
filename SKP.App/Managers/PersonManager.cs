using SKP.App.Abstract;
using SKP.App.Concrete;
using SKP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Managers
{
    public class PersonManager
    {
        private readonly MenuService _menuService;
        private IService<Person> _personService;

        public PersonManager(MenuService menuService, IService<Person> personService)
        {
            _menuService = menuService;
            _personService = personService;


           _personService.AddItem(new Person(1, "Adam", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
           _personService.AddItem(new Person(2, "Maciej", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
           _personService.AddItem(new Person(3, "Zbychu", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
           _personService.AddItem(new Person(4, "Kasia", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
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
                    AddPerson();
                    Console.Clear();
                    ShowList();
                    Console.WriteLine("Done!");
                    Console.WriteLine("Press any key to leave");
                    Console.ReadLine();
                    Console.Clear();

                    break;


                case "2":
                    RemovePerson();
                    Console.Clear();
                    ShowList();
                    Console.ReadLine();
                    Console.Clear();

                    break;



                default:
                    Console.Clear();
                    break;

            }
        }

        private void RemovePerson()
        {
            Console.WriteLine("Type worker id to remove:");
            string id = Console.ReadLine();
            int rId;
            if (Int32.TryParse(id, out rId))
            {
                _personService.RemoveItem(_personService.GetItemById(rId));
                Console.WriteLine("Done!");
                Console.WriteLine("Press any key to leave");
            }
            else
            {
                Console.WriteLine("Wrong input!!!");
                Console.ReadLine();
            }
        }

        private void AddPerson()
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
            finalResult.Id = _personService.GetLastId() + 1;
            finalResult.FirstName = result[0].ToString();
            finalResult.LastName = result[1].ToString();
            finalResult.PhoneNumber = double.Parse(result[2]);
            finalResult.Pesel = double.Parse(result[3]);
            finalResult.BirthDate = DateOnly.Parse(result[4]);

            _personService.AddItem(finalResult);
        }

        public void ShowList()
            {
                foreach (var person in _personService.GetAllItems())
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
    }
}
