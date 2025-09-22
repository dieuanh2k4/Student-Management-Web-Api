using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using studentManagement.src.Data;
using studentManagement.src.Interfaces;
using studentManagement.src.Models;

namespace studentManagement.src.Repository
{
    public class Studentrepository : IStudentrepository
    {
        private readonly ApplicationDbContext _context;
        public Studentrepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Student>> GetAllAsync()
        {
            return _context.Student.ToListAsync();
        }
    }
}