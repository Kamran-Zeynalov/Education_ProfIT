using Microsoft.EntityFrameworkCore;
using ProfItTask.Core.Entities;
using ProfItTask.Data.DAL;
using ProfItTask.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfItTask.Service.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly ProfitDbContext _context;

        public StudentService(ProfitDbContext context) => _context = context;

        public async Task Create(Student student)
        {
            if (student is null) throw new ArgumentNullException("Model is null");
            
            bool exists = await _context.Students.AnyAsync(s => s.Number == student.Number);
            if (exists) throw new InvalidOperationException("The student already exist");
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id == 0) throw new ArgumentNullException("id");
            Student? student= await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student is null) throw new ArgumentNullException("Student");
            _context.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> Get(int id)
        {
            if (id == 0) throw new ArgumentException("id");
            Student? student= await _context.Students.FirstOrDefaultAsync(l => l.Id == id);
            if (student is null) throw new ArgumentNullException($"Lesson is null");
            return student;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task Update(int id, Student student)
        {
            if (id == 0) throw new ArgumentNullException("id");
            if (student is null) throw new ArgumentNullException("Student is null");
            Student? updatedStudent = await _context.Students.FirstOrDefaultAsync(l => l.Id == id);
            if (updatedStudent is null) throw new ArgumentNullException("Student Not Found");

            bool exists = await _context.Students.AnyAsync(s =>
             (s.Number == student.Number) && s.Id != id);

            if (exists)
                throw new InvalidOperationException("The Student already exists.");

            updatedStudent.Number = student.Number;
            updatedStudent.Name= student.Name;
            updatedStudent.Surname = student.Surname;
            updatedStudent.Class = student.Class;
            await _context.SaveChangesAsync();
        }
    }
}
