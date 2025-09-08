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
        public DbSet<Student> Student { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<StudentOfClass> StudentOfClass { get; set; }

        // gõ ctor
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
                entity.Property(s => s.Name)
                    .IsUnicode(true)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(s => s.StudentCode)
                    .IsUnicode(false)
                    .HasMaxLength(10)
                    .IsRequired();
                entity.Property(s => s.DateOfBirth)
                    .HasColumnType("date")
                    .IsRequired();
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
                entity.Property(c => c.Name)
                    .IsUnicode()
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(c => c.ClassCode)
                    .IsUnicode()
                    .HasMaxLength(10)
                    .IsRequired();
            });

            modelBuilder.Entity<StudentOfClass>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
                entity.HasOne<Student>()
                    .WithMany()
                    .HasForeignKey(e => e.StudentId);
                entity.HasOne<Class>()
                    .WithMany()
                    .HasForeignKey(e => e.ClassId);
            });
        }
    }
}