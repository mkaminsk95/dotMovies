﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotMovies.Controllers.User {
    public class UserController : Controller {


        [HttpGet]
        public IActionResult Register() {

            return View();
        }


        [HttpGet]
        public IActionResult Login() {
            
            return View();
        }


    }
}
