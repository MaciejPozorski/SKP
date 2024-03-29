﻿using SKP.Domain.Entity;
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
        List<T> GetAllItems();
        int AddItem(T item);
        void RemoveItem(T item);
        int UpdateItem(T item);
        int GetLastId();
        T GetItemById(int id);
        void Save();
        void Read();
    }
}
