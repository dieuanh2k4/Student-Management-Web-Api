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
                Id = studentModel.Id,
                Name = studentModel.Name,
                StudentCode = studentModel.StudentCode,
                DateOfBirth = studentModel.DateOfBirth
            };
        }
    }
}