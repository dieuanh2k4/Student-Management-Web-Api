using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentManagement.src.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
    }
}