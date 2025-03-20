using ProfItTask.Core.Entities;

namespace ProfItTask.Service.Services.Interface
{
    public interface ILessonService
    {
        public Task<List<Lesson>> GetAll();
        public Task<Lesson> Get(int id);
        public Task Create(Lesson lesson);
        public Task Update(int id, Lesson lesson);
        public Task Delete(int id);
    }
}
