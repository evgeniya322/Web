﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WStore.Infrasructure.Interface;
using WStore.Models;

namespace WStore.Infrasructure.Implementation
{
    public class InMemoryEmployeesData:IEmployeesData
    {
        private readonly List<EmployeeView> _employees;

        public InMemoryEmployeesData()
        {
            _employees = new List<EmployeeView>(3)
            {
                new EmployeeView(){Id = 1, FirstName = "Вася", SurName = "Пупкин", Patronymic = "Иванович", Age = 22, Position = "Директор"},
                new EmployeeView(){Id = 2, FirstName = "Иван", SurName = "Холявко", Patronymic = "Александрович", Age = 30, Position = "Программист"},
                new EmployeeView(){Id = 3, FirstName = "Роберт", SurName = "Серов", Patronymic = "Сигизмундович", Age = 50, Position = "Зав. склада"}
            };
        }
        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }

        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id==id);
        }

        public void Commit()
        {
            // ничего не делаем
        }

        public void AddNew(EmployeeView model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            model.Id = _employees.Count == 0 ? 1 : _employees.Max(e => e.Id) + 1;
            _employees.Add(model);
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

    }
}
