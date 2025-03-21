using Microsoft.EntityFrameworkCore;
using ProfItTask.Core.Entities;
using ProfItTask.Data.DAL;
using ProfItTask.Service.Services.Interface;

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

            bool exists = await _context.Lessons.AnyAsync(s => s.LessonCode == lesson.LessonCode);
            if (exists) throw new InvalidOperationException("The Lesson already exist");

            if (lesson.LessonCode.Length != 3)
                throw new InvalidOperationException("LessonCode Length must be 3 char");

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
            if (id == 0) throw new ArgumentNullException("id");
            if (lesson is null) throw new ArgumentNullException("Lesson is null");
            Lesson? updatedLesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);
            if (updatedLesson is null) throw new ArgumentNullException("Lesson Not Found");

            bool exists = await _context.Lessons.AnyAsync(l =>
                 (l.LessonCode == lesson.LessonCode) && l.Id != id);

            if (exists)
                throw new InvalidOperationException("The Lesson already exists.");

            if (lesson.LessonCode.Length != 3)
                throw new InvalidOperationException("LessonCode Length must be 3 char");

            updatedLesson.TeacherName = lesson.TeacherName;
            updatedLesson.TeacherSurname = lesson.TeacherSurname;
            updatedLesson.LessonCode = lesson.LessonCode;
            updatedLesson.Name = lesson.Name;
            updatedLesson.Class = lesson.Class;
            await _context.SaveChangesAsync();
        }
    }
}
