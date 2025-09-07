using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using studentManagement.src.Models;

namespace studentManagement.src.Data
{
    public class ApplicationDbContext : DbContext
    {
        // gõ ctor
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}