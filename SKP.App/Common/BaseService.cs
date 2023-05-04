using Newtonsoft.Json;
using SKP.App.Abstract;
using SKP.Domain.Common;
using SKP.Domain.Entity;
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
            Items= new List<T>();
        }

        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public int UpdateItem(T item)
        {
            T entity = Items.FirstOrDefault(p => p.Id == item.Id);
            if (entity != null)
            {
                entity = item;
            }
            return entity.Id;
        }
        public int GetLastId()
        {
            int lastId;
            if(Items.Count > 0)
            {
                lastId = Items.OrderBy(p => p.Id).Last().Id;
            }
            else
            {
                lastId= 0;
            }
            return lastId;
        }

        public T GetItemById(int id)
        {
            T item = Items.FirstOrDefault(p => p.Id == id);
            return item;                      
        }

        public void Save()
        {
            string value = JsonConvert.SerializeObject(Items);
            using StreamWriter sw = new StreamWriter($"{typeof(T).Name}.json");
            using JsonWriter writer = new JsonTextWriter(sw);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, Items);
        }

        public void Read()
        {
            using StreamReader sr = new StreamReader($"{typeof(T).Name}.json");
            string file = sr.ReadToEnd();
            Items = JsonConvert.DeserializeObject<List<T>>(file);
        }
    }
}
