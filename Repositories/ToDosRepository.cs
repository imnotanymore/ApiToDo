using System;
using System.Linq;
using System.Collections.Generic;
using ApiToDo.Models;

namespace ApiToDo.Repositories
{
   
    public class ToDosRepository : IToDosRepository
    {
        private readonly List<ToDo> items = new()
        {
            new ToDo { Id = Guid.NewGuid(), Name = "", IsComplete = false }
        };

        public IEnumerable<ToDo> GetItems()
        {
            return items;
        }

        public ToDo GetItem(Guid id)
        {
            return items.Where(items => items.Id == id).SingleOrDefault();
        }

        public void CreateToDo(ToDo item)
        {
            items.Add(item);
        }
        public void UpdateToDo(ToDo item)       
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }
        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}