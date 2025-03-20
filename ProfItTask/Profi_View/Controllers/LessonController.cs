using Microsoft.AspNetCore.Mvc;
using Profi_View.Models;
using Profi_View.Service;
using ProfItTask.Core.Entities;
using System.Diagnostics;

namespace Profi_View.Controllers
{
    public class LessonController : Controller
    {
        private readonly Api_Service _api;

        public LessonController(Api_Service api)
        {
            _api = api;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                var isSuccess = await _api.CreateLesson(lesson);
                if (isSuccess)
                    return RedirectToAction("Index");
            }
            return View(lesson);

        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _api.GetCreate());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
