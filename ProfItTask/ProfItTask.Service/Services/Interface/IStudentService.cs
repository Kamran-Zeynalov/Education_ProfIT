using ProfItTask.Core.Entities;

namespace ProfItTask.Service.Services.Interface
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAll();
        public Task<Student> Get(int id);
        public Task Create(Student student);
        public Task Update(int id, Student student);
        public Task Delete(int id);
    }
}
