using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WStore.Models;

namespace WStore.Controllers
{

    public class EmployeesController : Controller
    {
        private static readonly List<EmployeeView> _Employees = new List<EmployeeView>
        {
            new EmployeeView{Id=1, FirstName="Иван", Patronymic="Иванович",SurName="Иванов", Age=25, City="Томск" },
            new EmployeeView{Id=2, FirstName="Петр", Patronymic="Петрович",SurName="Петров", Age=45, City="Москва" },
            new EmployeeView{Id=3, FirstName="Андрей", Patronymic="Андреевич",SurName="Андреев", Age=29, City="Екатеринбург" }
        };


        public IActionResult Index()
        {
            
            return View(_Employees);
        }

        public IActionResult Details(int? Id)
        {
            if (Id is null)
                return BadRequest();

            var employee = _Employees.FirstOrDefault(e => e.Id == Id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        public IActionResult DetailsName(string FirstName, string LastName)
        {
            if (FirstName is null && LastName is null)
                return BadRequest();

            IEnumerable<EmployeeView> employees = _Employees;
            if (!string.IsNullOrWhiteSpace(FirstName))
                employees = employees.Where(e => e.FirstName == FirstName);
            if (!string.IsNullOrWhiteSpace(LastName))
                employees = employees.Where(e => e.SurName == LastName);

            var employee = employees.FirstOrDefault();

            if (employee is null)
                return NotFound();

            return View(nameof(Details), employee);
        }
    }
}