using Microsoft.EntityFrameworkCore;
using ProfItTask.Core.Entities;

namespace ProfItTask.Data.DAL
{
    public class ProfitDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Lesson> Lessons{ get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
               .HasIndex(s => s.Number)
               .IsUnique();

            modelBuilder.Entity<Lesson>()
                .HasIndex(l => l.LessonCode)
                .IsUnique();
        }

    }
}
