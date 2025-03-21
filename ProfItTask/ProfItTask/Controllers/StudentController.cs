using Microsoft.AspNetCore.Mvc;
using ProfItTask.Core.Entities;
using ProfItTask.Service.Services.Interface;

namespace ProfItTask.Controllers
{
    [Route("Student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService) => _studentService = studentService;

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ;
            return Ok(await _studentService.GetAll());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            if (student== null) return NotFound();
            await _studentService.Create(student);
            return Ok();
        }

        [HttpGet]
        [Route("UpdateView")]
        public async Task<IActionResult> UpdateView([FromQuery] int id)
        {
            return Ok(await _studentService.Get(id));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] Student student)
        {
            if (student == null) return NotFound();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something is wrong");
                return BadRequest();
            }
            await _studentService.Update(id, student);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _studentService.Delete(id);
            return Ok();
        }
    }
}
