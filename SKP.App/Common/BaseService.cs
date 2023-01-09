using SKP.App.Abstract;
using SKP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService() 
        { 
        Items = new List<T>();
        }

        public void Additem()
        {
          
        }

        public List<T> EditItem(T item)
        {
            return item;
        }

        public void RemoveItem()
        {
          
        }

        public void ShowItemList(T item)
        {
          
        }
    }
}
