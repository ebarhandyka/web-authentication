using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories.Contracts;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var entities = _employeeRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(string nik)
        {
            var entity = _employeeRepository.GetById(nik);
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
        public IActionResult Create(Employee employee)
        {
            _employeeRepository.Insert(employee);
            return RedirectToAction("Index");
        }

        // EDIT
        [HttpGet]
        public IActionResult Edit(string nik)
        {
            var entity = _employeeRepository.GetById(nik);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            _employeeRepository.Update(employee);
            return RedirectToAction("Index");
        }

        // DELETE
        [HttpGet]
        public IActionResult Delete(string nik)
        {
            var entity = _employeeRepository.GetById(nik);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(string nik)
        {
            _employeeRepository.Delete(nik);
            return RedirectToAction("Index");
        }
    }
}
