using SKP.App.Common;
using SKP.Domain;
using SKP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Concrete
{
    public class WorkDayService : BaseService<WorkDay>
    {


        //private List<WorkDay> workDays { get; set; }
        //public WorkDayService()
        //{            
        //    workDays = new List<WorkDay>();
        //}
        //MenuBuilder menuBuilder = new MenuBuilder();

        //public List<WorkDay> EditService(List<WorkDay> workDays)
        //{
        //    this.workDays = workDays;
        //    string input;

        //    Console.WriteLine("Edit list.");
        //    Console.WriteLine("Choose action (0: exit):");
        //    menuBuilder.showMenu("eday");

        //    input = Console.ReadLine();
        //    switch (input)
        //    {
        //        case "1":
        //            AddWorkDay();
        //            Console.Clear();
        //            ShowList(this.workDays);
        //            Console.WriteLine("Done!");
        //            Console.WriteLine("Press any key to leave");
        //            Console.ReadLine();
        //            Console.Clear();

        //            return this.workDays;
        //            break;


        //        case "2":
        //            RemoveWorkDay();
        //            Console.Clear();
        //            ShowList(this.workDays);
        //            Console.WriteLine("Done!");
        //            Console.WriteLine("Press any key to leave");
        //            Console.ReadLine();
        //            Console.Clear();
        //            return this.workDays;
        //            break;



        //        default:
        //            Console.Clear();
        //            return this.workDays;
        //            break;

        //    }


        //}

      

        //public void ShowList(List<WorkDay> workDays)
        //{
        //    foreach (var day in workDays)
        //    {
        //        Console.WriteLine($"Id: {day.Id}  " +
        //            $"PersonId: {day.PersonId}  " +
        //            $"Day: {day.Day}  " +
        //            $"Hours: {day.Hours}");
        //        Console.WriteLine("");
        //    }
        //}

        
    }
}
