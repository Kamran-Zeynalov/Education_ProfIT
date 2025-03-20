using Microsoft.AspNetCore.Mvc;
using ProfItTask.Core.Entities;
using ProfItTask.Data.DAL;
using ProfItTask.Service.Services.Interface;

namespace ProfItTask.Controllers
{
    [Route("Lesson")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
           ;
            return Ok(await _lessonService.GetAll());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]Lesson lesson)
        {
            if(lesson == null) return NotFound();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please check values");
                return BadRequest();
            }
            
           await _lessonService.Create(lesson);
            return Ok();
        }

        [HttpGet]
        [Route("UpdateView")]
        public async Task<IActionResult> UpdateView([FromQuery]int id)
        {
            
            return Ok(await _lessonService.Get(id));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromQuery]int id,[FromBody]Lesson lesson)
        {
            if (lesson == null) return NotFound();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something is wrong");
                return BadRequest();
            }
            await _lessonService.Update(id, lesson);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            await _lessonService.Delete(id);
            return Ok();
        }
    }
}
