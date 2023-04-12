using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories.Contracts;

namespace WebApp.Controllers
{
    public class AccounRoleController : Controller
    {
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccounRoleController(IAccountRoleRepository accountRoleRepository)
        {
            _accountRoleRepository = accountRoleRepository;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var entities = _accountRoleRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _accountRoleRepository.GetById(id);
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
        public IActionResult Create(AccountRole accountRole)
        {
            _accountRoleRepository.Insert(accountRole);
            return RedirectToAction("Index");
        }

        // EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _accountRoleRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AccountRole accountRole)
        {
            _accountRoleRepository.Update(accountRole);
            return RedirectToAction("Index");
        }

        // DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _accountRoleRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _accountRoleRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
