using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentManagement.src.Dtos.Class;
using studentManagement.src.Models;

namespace studentManagement.src.Mappers
{
    public static class ClassMapper
    {
        public static ClassDto ToClassDto(this Class classModel)
        {
            return new ClassDto
            {
                Name = classModel.Name,
                ClassCode = classModel.ClassCode,
                MaxOfStudents = classModel.MaxOfStudents
            };
        }

        public static Class ToCreateClassDto(this CreateClassDto createClass)
        {
            return new Class
            {
                Name = createClass.Name,
                ClassCode = createClass.ClassCode,
                MaxOfStudents = createClass.MaxOfStudents
            };
        }
    }
}