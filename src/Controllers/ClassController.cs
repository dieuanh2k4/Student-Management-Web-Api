using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using studentManagement.src.Data;
using studentManagement.src.Mappers;

namespace studentManagement.src.Controllers
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllClasses()
        {
            var classes = _context.Classes.ToList()
                .Select(s => s.ToClassDto());

            return Ok(classes);
        }

        [HttpGet("{id}")]
        public IActionResult GetClassById([FromRoute] int id)
        {
            var classes = _context.Classes.Find(id);

            if (classes == null)
            {
                return NotFound();
            }

            return Ok(classes.ToClassDto());
        }
    }
}