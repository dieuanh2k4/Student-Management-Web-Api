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
                Id = classModel.Id,
                Name = classModel.Name,
                ClassCode = classModel.ClassCode,
                MaxOfStudents = classModel.MaxOfStudents
            };
        }
    }
}