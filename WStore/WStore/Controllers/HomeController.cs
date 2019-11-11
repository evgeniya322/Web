using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WStore.Models;

namespace WStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private static readonly List<EmployeeView> _Employees = new List<EmployeeView>
        {
            new EmployeeView{Id=1, FirstName="Иван", Patronymic="Иванович",SurName="Иванов", Age=25 },
            new EmployeeView{Id=2, FirstName="Петр", Patronymic="Петрович",SurName="Петров", Age=45 },
            new EmployeeView{Id=3, FirstName="Андрей", Patronymic="Андреевич",SurName="Андреев", Age=29 }
        };

        public IActionResult GetEmployes()
        {
            return View(_Employees);
        }
    }
}