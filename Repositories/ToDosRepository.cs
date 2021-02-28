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

    }
}