using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using studentManagement.src.Data;
using studentManagement.src.Dtos.Class;
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
            var classes = _context.Class.ToList()
                .Select(s => s.ToClassDto());

            return Ok(classes);
        }

        [HttpGet("{id}")]
        public IActionResult GetClassById([FromRoute] int id)
        {
            var classes = _context.Class.Find(id);

            if (classes == null)
            {
                return NotFound();
            }

            return Ok(classes.ToClassDto());
        }

        [HttpPost]
        public IActionResult CreateClass([FromBody] CreateClassDto classdto)
        {
            var classModel = classdto.ToCreateClassDto();
            _context.Class.Add(classModel);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateClassDto updatedto)
        {
            var classModel = _context.Class.FirstOrDefault(x => x.Id == id);

            if (classModel == null)
            {
                return NotFound();
            }

            classModel.Name = updatedto.Name;
            classModel.ClassCode = updatedto.ClassCode;
            classModel.MaxOfStudents = updatedto.MaxOfStudents;

            _context.SaveChanges();

            return Ok(classModel.ToClassDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var classModel = _context.Class.FirstOrDefault(x => x.Id == id);

            if (classModel == null)
            {
                return NotFound();
            }

            _context.Class.Remove(classModel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}