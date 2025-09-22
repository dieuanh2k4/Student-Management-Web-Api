using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using studentManagement.src.Data;
using studentManagement.src.Dtos.Student;
using studentManagement.src.Interfaces;
using studentManagement.src.Mappers;

namespace studentManagement.src.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentrepository _studentrepository;
        public StudentController(ApplicationDbContext context, IStudentrepository studentrepository)
        {
            _studentrepository = studentrepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentrepository.GetAllAsync();

            var studentdto = students.Select(s => s.ToStudentDto());

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var students = await _context.Student.FindAsync(id);

            if (students == null)
            {
                return NotFound();
            }

            return Ok(students.ToStudentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto studentDto)
        {
            var studentModel = studentDto.ToStudentFromCreateDto();
            await _context.Student.AddAsync(studentModel);
            await _context.SaveChangesAsync();

            // return CreatedAtAction(nameof(GetStudentById), new { id = studentModel.Id }, studentModel.ToStudentDto());
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentRequestDto updateDto)
        {
            var studentModel = await _context.Student.FirstOrDefaultAsync(x => x.Id == id);

            if (studentModel == null)
            {
                return NotFound();
            }

            studentModel.Name = updateDto.Name;
            studentModel.DateOfBirth = updateDto.DateOfBirth;
            studentModel.StudentCode = updateDto.StudentCode;

            await _context.SaveChangesAsync();

            return Ok(studentModel.ToStudentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var studentModel = await _context.Student.FirstOrDefaultAsync(x => x.Id == id);

            if (studentModel == null)
            {
                return NotFound();
            }

            _context.Student.Remove(studentModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}