using System;
namespace ApiToDo.DTOs
{
public class ToDoDTOs
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Boolean IsComplete { get; set; }
    }
}