﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities.Identity;
using WStore.Infrasructure.Interface;
using WStore.Models;

namespace WStore.Controllers
{
    [Authorize]
    [Route("users")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _employeesData;

        public EmployeesController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }
        /// <summary>
        /// Вывод списка
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_employeesData.GetAll());
        }


        /// <summary>
        /// Детали о сотруднике
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns></returns>
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            // Получаем сотрудника по Id
            var employee = _employeesData.GetById(id);

            // Если такого не существует
            if (ReferenceEquals(employee, null))
                return NotFound();// возвращаем результат 404 Not Found

            // Иначе возвращаем сотрудника
            return View(employee);
        }

        [Authorize(Roles = Role.Administrator)]
        /// <summary>
        /// Добавление или редактирование сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            EmployeeView model;
            if (id.HasValue)
            {
                model = _employeesData.GetById(id.Value);
                if (ReferenceEquals(model, null))
                    return NotFound();// возвращаем результат 404 Not Found
            }
            else
            {
                model = new EmployeeView();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        [Route("edit/{id?}")]
        public IActionResult Edit(EmployeeView model)
        {
            if (model is null)
                throw new ArgumentOutOfRangeException(nameof(model));

            if (model.Age < 18 || model.Age > 75)
            {
                ModelState.AddModelError(nameof(EmployeeView.Age), "Ошибка возраста!");
            }

            if (!ModelState.IsValid) return View(model);

            if (model.Id > 0)
                {
                    var dbItem = _employeesData.GetById(model.Id);

                    if (ReferenceEquals(dbItem, null))
                        // возвращаем результат 404 Not Found
                        return NotFound();// возвращаем результат 404 Not Found

                    dbItem.FirstName = model.FirstName;
                    dbItem.SurName = model.SurName;
                    dbItem.Age = model.Age;
                    dbItem.Patronymic = model.Patronymic;
                    dbItem.Position = dbItem.Position;
                }
                else
                {
                    _employeesData.AddNew(model);
                }
                _employeesData.Commit();

                return RedirectToAction(nameof(Index));


        }

        [Authorize(Roles = Role.Administrator)]
        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns></returns>
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _employeesData.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}