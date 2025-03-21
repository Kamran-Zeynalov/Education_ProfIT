using Microsoft.EntityFrameworkCore;
using ProfItTask.Core.Entities;
using ProfItTask.Data.DAL;
using ProfItTask.Service.Services.Interface;

namespace ProfItTask.Service.Services.Implementation
{
    public class ExamService : IExamService
    {
        private readonly ProfitDbContext _context;

        public ExamService(ProfitDbContext context)
        {
            _context = context;
        }
        public async Task<Exam> Get(int id)
        {
            if (id == 0) throw new ArgumentException("id");
            Exam? exam = await _context.Exams.FirstOrDefaultAsync(l => l.Id == id);
            if (exam is null) throw new ArgumentNullException($"exam is null");
            return exam;
        }
        public async Task Create(string lCode, int sNumber, Exam exam)
        {
            if (exam == null) throw new ArgumentNullException("Model is null");
            List<Lesson> lessons = await _context.Lessons.ToListAsync();
            List<Student> students = await _context.Students.ToListAsync();

            foreach (Lesson lesson in lessons)
            {
                if(lesson.LessonCode == lCode)
                {
                    exam.LessonCode = lCode;
                }
            }
            foreach (Student student in students)
            {
                if (student.Number == sNumber)
                {
                    exam.Number = sNumber;
                }
            }
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Exam>> GetAll()
        {
            List<Exam> exams =  await _context.Exams
                                        .Include(e => e.Lesson)
                                        .Include(e => e.Student)
                                        .ToListAsync();
            return exams;
        }

    }
}
