using EntityCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityCRUD.Controllers
{
    public class EntityController : Controller
    {
        private readonly IDataAcess _dataAccess;

        public EntityController(IDataAcess dataAcess)
        {
            _dataAccess = dataAcess;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> result = _dataAccess.GetAllEmployees();
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var result = _dataAccess.GetAllEmployees(id);
            if (result.Count != 0)
            {
                var employee = result[0];
                return View(employee);
            }
            return RedirectToRoute("Index", "Home");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _dataAccess.GetAllEmployees(id);
            return View(result[0]);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var result = _dataAccess.UpdateEmployees(employee);
            return RedirectToAction("Index", "Entity");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var result = _dataAccess.CreateEmployees(employee);
            return RedirectToAction("Index", "Entity");
        }

    }
}
