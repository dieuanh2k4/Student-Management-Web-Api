using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = await _context.Class.ToListAsync();
            var classesDto = classes.Select(s => s.ToClassDto());

            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById([FromRoute] int id)
        {
            var classes = await _context.Class.FindAsync(id);

            if (classes == null)
            {
                return NotFound();
            }

            return Ok(classes.ToClassDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] CreateClassDto classdto)
        {
            var classModel = classdto.ToCreateClassDto();
            await _context.Class.AddAsync(classModel);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClassDto updatedto)
        {
            var classModel = await _context.Class.FirstOrDefaultAsync(x => x.Id == id);

            if (classModel == null)
            {
                return NotFound();
            }

            classModel.Name = updatedto.Name;
            classModel.ClassCode = updatedto.ClassCode;
            classModel.MaxOfStudents = updatedto.MaxOfStudents;

            await _context.SaveChangesAsync();

            return Ok(classModel.ToClassDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var classModel = await _context.Class.FirstOrDefaultAsync(x => x.Id == id);
 
            if (classModel == null)
            {
                return NotFound();
            }

            _context.Class.Remove(classModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}