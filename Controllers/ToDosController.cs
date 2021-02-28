using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiToDo.Models;
using ApiToDo.Repositories;
using System.Linq;
using ApiToDo.DTOs;
using System;

namespace ApiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDosController : ControllerBase
    {
        private readonly IToDosRepository repository;

        public ToDosController(IToDosRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ToDoDTOs> GetItems()
        {
            var items = repository.GetItems().Select( item => item.AsDto()); 
            return items;
        }
        [HttpGet("{id}")]
        public ActionResult<ToDoDTOs> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }
        [HttpPost]
        public ActionResult<ToDoDTOs> CreateToDo(CreateToDoDTO ToDoDTOs)
        {
             ToDo item = new()
             {
                Id = Guid.NewGuid(),
                Name = ToDoDTOs.Name,
                IsComplete = false

             };

             repository.CreateToDo(item);

             return CreatedAtAction(nameof(GetItems), new { id = item.Id}, item.AsDto());
        }
        [HttpPut("{id}")]
        public ActionResult UpdateToDo(Guid id, UpdateToDoDTO ToDoDTO)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            ToDo UpdatedToDo = existingItem with
            {
                Name = ToDoDTO.Name,
                IsComplete = true
            };

            repository.UpdateToDo(UpdatedToDo);
            
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
             var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItem(id);

            return NoContent();
        }
    }
}