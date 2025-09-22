using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentManagement.src.Models;

namespace studentManagement.src.Interfaces
{
    public interface IStudentrepository
    {
        Task<List<Student>> GetAllAsync();
    }
}