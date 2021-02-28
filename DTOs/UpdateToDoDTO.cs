using System;

namespace ApiToDo.DTOs
{
    public record UpdateToDoDTO
    {

        public string Name { get; set; }

        public Boolean IsComplete { get; set; }
    }
}