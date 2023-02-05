using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Services.Abstract;
using System.Diagnostics;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployees();
            return View(employees);
        }

        public async Task<IActionResult> OrderDetail(int employeeId)
        {
            var orders = await _employeeService.GetEmployeeOrders(employeeId);
            if (orders == null)
            {
                return NotFound("Herhangi bir kayıt bulunamadı");
            }
            return View(orders);
        }

        public async Task<IActionResult> EmployeeTerritories(int employeeId)
        {
            var territories = await _employeeService.GetEmployeeTerritories(employeeId);
            return View(territories);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee inputEmployee)
        {
            var employee = await _employeeService.Add(inputEmployee);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}