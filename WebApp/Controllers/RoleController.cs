using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories.Contracts;

namespace WebApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var entities = _roleRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _roleRepository.GetById(id);
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
        public IActionResult Create(Role role)
        {
            _roleRepository.Insert(role);
            return RedirectToAction("Index");
        }

        // EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Role role)
        {
            _roleRepository.Update(role);
            return RedirectToAction("Index");
        }

        // DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _roleRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
