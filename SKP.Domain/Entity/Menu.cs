using SKP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.Domain.Entity
{
    public class Menu : BaseEntity
    {
        public string ActionName { get; set; }
        public string MenuName { get; set; }

        public Menu(int enterNr, string actionName, string menuName)
        {
            Id = enterNr;
            ActionName = actionName;
            MenuName = menuName;
        }
    }
}
