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


            //_personService.AddItem(new Person(1, "Adam", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
            //_personService.AddItem(new Person(2, "Maciej", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
            //_personService.AddItem(new Person(3, "Zbychu", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
            //_personService.AddItem(new Person(4, "Kasia", "Pączek", 123456789, 12345678911, new DateOnly(1111, 11, 11)));
            _personService.Read();
        }
        public void EditView()
        {
            string input;

            Console.WriteLine("Edit list.");
            Console.WriteLine("Choose action (0: exit):");
            _menuService.showMenu("eworker");

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddPersonView();
                    break;


                case "2":
                    RemovePersonView();
                    Console.Clear();
                    _personService.ToString();
                    Console.ReadLine();
                    Console.Clear();

                    break;



                default:
                    Console.Clear();
                    break;

            }
        }

        private void RemovePersonView()
        {
            Console.WriteLine("Type worker id to remove:");
            string id = Console.ReadLine();
            int rId;
            if (Int32.TryParse(id, out rId))
            {
                RemovePersonById(rId);
                Console.WriteLine("Done!");
                Console.WriteLine("Press any key to leave");
            }
            else
            {
                Console.WriteLine("Wrong input!!!");
                Console.ReadLine();
            }
        }

        private void AddPersonView()
        {
            Console.WriteLine("firstname lastname phone pesel birth(dd/mm/yyyy)");
            string input = Console.ReadLine();
            Person finalResult = new Person();
            string[] result = input.Split(' ');
            try
            {
                if (result.Length != 5)
                {
                    throw new ArgumentException(message: "Wrong input");
                }

                finalResult.Id = _personService.GetLastId() + 1;
                finalResult.FirstName = result[0].ToString();
                finalResult.LastName = result[1].ToString();
                finalResult.PhoneNumber = double.Parse(result[2]);
                finalResult.Pesel = double.Parse(result[3]);
                finalResult.BirthDate = DateOnly.Parse(result[4]);

                AddPerson(finalResult);

                Console.Clear();
                Console.WriteLine("Done!");
                Console.WriteLine("last item:");
                Console.WriteLine(
                    _personService.GetItemById(
                        _personService.GetLastId())
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
                    _personService.GetItemById(
                        _personService.GetLastId())
                    );
                Console.ReadLine() ;
                Console.Clear();
            }

        }

        public void ShowList()
        {
            foreach (var item in _personService.GetAllItems())
            {
                Console.WriteLine(item);
            }
        }

        public Person GetPersonById(int id)
        {
            Person item = _personService.GetItemById(id);
            return item;
        }

        public void RemovePersonById(int id)
        {
            Person p = _personService.GetItemById(id);
            _personService.RemoveItem(p);
        }

        public void AddPerson(Person person)
        {
            _personService.AddItem(person);
        }


    }
}
