using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentManagement.src.Dtos.Student;
using studentManagement.src.Models;

namespace studentManagement.src.Mappers
{
    public static class StudentMapper
    {
        public static StudentDto ToStudentDto(this Student studentModel)
        {
            return new StudentDto
            {
                Name = studentModel.Name,
                StudentCode = studentModel.StudentCode,
                DateOfBirth = studentModel.DateOfBirth
            };
        }

        public static Student ToStudentFromCreateDto(this CreateStudentDto studentdto) {
            return new Student
            {
                Name = studentdto.Name,
                StudentCode = studentdto.StudentCode,
                DateOfBirth = studentdto.DateOfBirth
            };
        }
    }
}