using System;

namespace ApiToDo.DTOs
{
    public record CreateToDoDTO
    {

        public string Name { get; set; }

        public Boolean IsComplete { get; set; }
    }
}