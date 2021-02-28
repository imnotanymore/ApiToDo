using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiToDo.Models;
using ApiToDo.Repositories;
using System.Linq;
using ApiToDo.DTOs;

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
    
    
    }
}