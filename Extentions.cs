using ApiToDo.DTOs;
using ApiToDo.Models;

namespace ApiToDo
{
    public static class Extentions 
    {
        public static ToDoDTOs AsDto(this ToDo item)
        {
            return new ToDoDTOs
            {
                Id = item.Id,
                Name = item.Name,
                IsComplete = item.IsComplete
            };
        }
    }
}