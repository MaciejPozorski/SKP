using SKP.App.Common;
using SKP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Concrete
{
    public class MenuService : BaseService<Menu>
    {
        public MenuService()
        {
            Initialize();
        }
        private void Initialize()
        {
            AddItem(new Menu(1, "Show list of workers", "main"));
            AddItem(new Menu(2, "Show list days of work", "main"));

            AddItem(new Menu(1, "Add worker", "eworker"));
            AddItem(new Menu(2, "Remove worker", "eworker"));

            AddItem(new Menu(1, "Add work day", "eday"));
            AddItem(new Menu(2, "Remove work day", "eday"));

        }
        public void showMenu(string menuName)
        {
            foreach (var item in Items)
            {
                if (item.MenuName == menuName)
                {
                    Console.WriteLine($"{item.Id}: {item.ActionName}.");
                }
            }
        }

    }
}
