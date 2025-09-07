using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using studentManagement.src.Data;

namespace studentManagement.src.Controllers
{
    [Route("apt/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var students = _context.Students.ToList();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            var students = _context.Students.Find(id);

            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }
    }
}