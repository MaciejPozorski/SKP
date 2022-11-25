using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP_T2
{
    public class Menu
    {
        public int EnterNr { get; set; }
        public string ActionName { get; set; }
        public string MenuName { get; set; }

        public Menu(int enterNr, string actionName, string menuName)
        {
            EnterNr = enterNr;
            ActionName = actionName;
            MenuName = menuName;
        }
    }
}
