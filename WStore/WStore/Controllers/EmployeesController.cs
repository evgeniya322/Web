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

    }
}