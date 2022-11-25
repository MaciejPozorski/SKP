using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP_T2
{
    public class MenuBuilder
    {
        private List<Menu> menus;
        public MenuBuilder()
        {
            menus = new List<Menu>();
            menus.Add(new Menu() { EnterNr = 1, ActionName = "Show list of workers", MenuName = "main" });
            menus.Add(new Menu() { EnterNr = 2, ActionName = "Show list days of work", MenuName = "main" });

            menus.Add(new Menu() { EnterNr = 1, ActionName = "Add worker", MenuName = "eworker" });
            menus.Add(new Menu() { EnterNr = 2, ActionName = "Remove worker", MenuName = "eworker" });

            menus.Add(new Menu() { EnterNr = 1, ActionName = "Add work day", MenuName = "eday" });
            menus.Add(new Menu() { EnterNr = 2, ActionName = "Remove work day", MenuName = "eday" });
        }

        public void AddAction(int enterNr, string actionName, string menuName)
        {
            Menu menu = new Menu() { EnterNr = enterNr, ActionName = actionName, MenuName = menuName };
            menus.Add(menu);
        }
        public List<Menu> ReturnMenu()
        {
            return menus;
        }
        public List<Menu> ReturnMenu(string menuName)
        {
            List<Menu> result = new List<Menu>();
            foreach (var item in menus)
            {
                if (item.MenuName == menuName)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
