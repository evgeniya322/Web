﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WStore.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false,
                  ErrorMessage = "Имя является обязательным")]
        [Display(Name = "Имя")]
        [StringLength(maximumLength: 200, MinimumLength = 2,
             ErrorMessage = "В имени должно быть не менее 2х и не более 200 символов")]
        [RegularExpression(@"(?:[А-ЯЁ][а-яё]+)|(?:[A-Z][a-z]+)", ErrorMessage = "Странное имя")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false,
                  ErrorMessage = "Фамилия является обязательной")]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false,
                  ErrorMessage = "Возраст является обязательным")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false,
                 ErrorMessage = "Должность является обязательной")]
        [Display(Name = "Должность")]
        public string Position { get; set; }
    }
}
