using SKP.App.Abstract;
using SKP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Concrete
{
    public class FileService
    {
        

        public void Save(IService<Person> _personService)
        {
            _personService.Save();
            Console.WriteLine("Save complited!");
            Console.ReadLine();
        }

        public void Save(IService<WorkDay> _workDayService)
        {
            _workDayService.Save();
            Console.WriteLine("Save complited!");
            Console.ReadLine();
        }

        public bool fileChecker(string file)
        {
            bool exist = File.Exists(file);
            return exist;
        }
    }
}
