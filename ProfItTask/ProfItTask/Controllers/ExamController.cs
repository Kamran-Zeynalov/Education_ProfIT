using Microsoft.AspNetCore.Mvc;
using ProfItTask.Core.Entities;
using ProfItTask.Service.Services.Interface;

namespace ProfItTask.Controllers
{
    [Route("Exam")]
    public class ExamController:ControllerBase
    {
        private readonly IExamService _examService;
        private readonly ILessonService _lessonService;
        private readonly IStudentService _studentService;

        public ExamController(IExamService examService, ILessonService lessonService, IStudentService studentService)
        { 
            _examService = examService;
            _lessonService = lessonService;
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _examService.GetAll());
        }


        [HttpGet]
        [Route("SelectList")]
        public async Task<IActionResult> CreateView()
        {
            List<Lesson> lessons = await _lessonService.GetAll();
            List<Student> students = await _studentService.GetAll();
            var response = new
            {
                Lessons = lessons,
                Students = students
            };
            return Ok(response);
        }



        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromQuery] string lCode, [FromQuery] int sNumber, [FromBody] Exam exam)
        {
            await _examService.Create(lCode, sNumber, exam);
            return Ok();
        }
    }
}
