using System;
using System.Collections.Generic;
using ApiToDo.Models;


namespace ApiToDo.Repositories
{
     public interface IToDosRepository
    {
        ToDo GetItem(Guid id);
        IEnumerable<ToDo> GetItems();
    
        void CreateToDo(ToDo item);
    }

}