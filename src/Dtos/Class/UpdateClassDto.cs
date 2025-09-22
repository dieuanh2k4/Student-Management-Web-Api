using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentManagement.src.Dtos.Class
{
    public class UpdateClassDto
    {
        public required string Name { get; set; }
        public string ClassCode { get; set; } = string.Empty;
        public int MaxOfStudents { get; set; }
    }
}