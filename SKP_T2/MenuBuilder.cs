using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP
{
    public class MenuBuilder
    {
        private List<Menu> menus;
        public MenuBuilder()
        {
            menus = new List<Menu>();
            menus.Add(new Menu(1, "Show list of workers", "main"));
            menus.Add(new Menu(2, "Show list days of work", "main"));

            menus.Add(new Menu(1, "Add worker", "eworker"));
            menus.Add(new Menu(2, "Remove worker", "eworker"));

            menus.Add(new Menu(1, "Add work day", "eday"));
            menus.Add(new Menu(2, "Remove work day", "eday"));
        }
        public void showMenu(string menuName)
        {
            foreach (var item in menus)
            {
                if (item.MenuName == menuName)
                {
                    Console.WriteLine($"{item.EnterNr}: {item.ActionName}.");
                }
            }
        }
    }
}
