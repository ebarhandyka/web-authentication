using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories.Contracts;

namespace WebApp.Controllers
{
    public class ProfilingController : Controller
    {
        private readonly IProfilingRepository _profilingRepository;

        public ProfilingController(IProfilingRepository profilingRepository)
        {
            _profilingRepository = profilingRepository;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var entities = _profilingRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(string nik)
        {
            var entity = _profilingRepository.GetById(nik);
            return View(entity);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Profiling profiling)
        {
            _profilingRepository.Insert(profiling);
            return RedirectToAction("Index");
        }

        // EDIT
        [HttpGet]
        public IActionResult Edit(string nik)
        {
            var entity = _profilingRepository.GetById(nik);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Profiling profiling)
        {
            _profilingRepository.Update(profiling);
            return RedirectToAction("Index");
        }

        // DELETE
        [HttpGet]
        public IActionResult Delete(string nik)
        {
            var entity = _profilingRepository.GetById(nik);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(string nik)
        {
            _profilingRepository.Delete(nik);
            return RedirectToAction("Index");
        }
    }
}
