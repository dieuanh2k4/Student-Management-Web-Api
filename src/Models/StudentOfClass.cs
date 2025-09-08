using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentManagement.src.Models
{
    public class StudentOfClass
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
    }
}