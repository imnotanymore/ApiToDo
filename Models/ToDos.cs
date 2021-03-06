using System;

namespace ApiToDo.Models
{
    public record ToDo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Boolean IsComplete { get; set; }
    }
}
