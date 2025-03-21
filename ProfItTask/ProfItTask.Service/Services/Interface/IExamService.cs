using ProfItTask.Core.Entities;

namespace ProfItTask.Service.Services.Interface
{
    public interface IExamService
    {
        public Task<List<Exam>> GetAll();
        public Task<Exam> Get(int id);
        public Task Create(string lCode, int sNumber, Exam exam);
    }
}
