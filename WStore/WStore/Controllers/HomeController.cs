﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WStore.Models;

namespace WStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()=> View();


        public IActionResult Blog() => View();
        public IActionResult BlogSingle() => View();
        public IActionResult Cart() => View();
        public IActionResult CheckOut() => View();
        public IActionResult ContactUs() => View();
        public IActionResult Login() => View();
        public IActionResult ProductDetails() => View();
        public IActionResult Shop() => View();
        public IActionResult Error404() => View();


    }
}