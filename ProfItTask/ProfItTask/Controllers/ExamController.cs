using Microsoft.AspNetCore.Mvc;
using ProfItTask.Core.Entities;
using ProfItTask.Service.Services.Interface;

namespace ProfItTask.Controllers
{
    [Route("Exam")]
    public class ExamController:ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService) => _examService = examService;


        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _examService.GetAll());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromQuery]string lCode,[FromQuery] int sNumber, [FromBody]Exam exam)
        {
            await _examService.Create(lCode, sNumber, exam);
            return Ok();
        }
    }
}
