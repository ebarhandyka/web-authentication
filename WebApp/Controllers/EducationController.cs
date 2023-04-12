using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;
using WebApp.Repositories.Contracts;

namespace WebApp.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;

        public EducationController(IEducationRepository educationRepository, IUniversityRepository universityRepository)
        {
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var entities = _educationRepository.GetAll();
            return View(entities);
        }

        // DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create()
        {
            var universities = _universityRepository.GetAll();
            var SelectListUniversities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.ID.ToString(),
            });
            ViewBag.UniversityID = SelectListUniversities;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Education education)
        {
            _educationRepository.Insert(education);
            return RedirectToAction("Index");
        }

        // EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var universities = _universityRepository.GetAll();
            var SelectListUniversities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.ID.ToString(),
            });
            ViewBag.UniversityID = SelectListUniversities;
            
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Education education)
        {
            _educationRepository.Update(education);
            return RedirectToAction("Index");
        }

        // DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _educationRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
