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
    public class LessonService : ILessonService
    {
        private readonly ProfitDbContext _context;

        public LessonService(ProfitDbContext context)
        {
            _context = context;
        }
        public async Task Create(Lesson lesson)
        {
            if (lesson is null) throw new ArgumentNullException("Model is null");

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if(id == 0) throw new ArgumentNullException("id");
            Lesson? lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == id);
            if (lesson is null) throw new ArgumentNullException("Lesson");
            _context.Remove(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task<Lesson> Get(int id)
        {
            if (id == 0) throw new ArgumentException("id");
            Lesson? lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);
            if(lesson is null) throw new ArgumentNullException($"Lesson is null");
            return lesson;
        }

        public async Task<List<Lesson>> GetAll()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task Update(int id, Lesson lesson)
        {
            if(id == 0) throw new ArgumentNullException("id");
            if (lesson is null) throw new ArgumentNullException("Lesson is null");
            Lesson? updatedLesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);
            if (updatedLesson is null) throw new ArgumentNullException("Lesson Not Found");
            updatedLesson.TeacherName = lesson.TeacherName;
            updatedLesson.TeacherSurname = lesson.TeacherSurname;
            updatedLesson.LessonCode = lesson.LessonCode;
            updatedLesson.Name = lesson.Name;
            updatedLesson.Class = lesson.Class;
            await _context.SaveChangesAsync();
        }
    }
}
