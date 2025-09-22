using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using studentManagement.src.Data;
using studentManagement.src.Dtos.Student;
using studentManagement.src.Mappers;

namespace studentManagement.src.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.Student.ToList()
                .Select(s => s.ToStudentDto());

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            var students = _context.Student.Find(id);

            if (students == null)
            {
                return NotFound();
            }

            return Ok(students.ToStudentDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentDto studentDto)
        {
            var studentModel = studentDto.ToStudentFromCreateDto();
            _context.Student.Add(studentModel);
            _context.SaveChanges();

            // return CreatedAtAction(nameof(GetStudentById), new { id = studentModel.Id }, studentModel.ToStudentDto());
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStudentRequestDto updateDto)
        {
            var studentModel = _context.Student.FirstOrDefault(x => x.Id == id);

            if (studentModel == null)
            {
                return NotFound();
            }

            studentModel.Name = updateDto.Name;
            studentModel.DateOfBirth = updateDto.DateOfBirth;
            studentModel.StudentCode = updateDto.StudentCode;

            _context.SaveChanges();

            return Ok(studentModel.ToStudentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var studentModel = _context.Student.FirstOrDefault(x => x.Id == id);

            if (studentModel == null)
            {
                return NotFound();
            }

            _context.Student.Remove(studentModel);

            _context.SaveChanges();

            return NoContent();
        }
    }
}