using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKP.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }
        List<T> EditItem(T item);
        void RemoveItem();
        void ShowItemList(T item);
        void Additem();
    }
}
