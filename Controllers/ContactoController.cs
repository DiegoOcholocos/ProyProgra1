using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appproy.Models;
using Microsoft.AspNetCore.Mvc;

namespace appproy.Controllers;

        public class ContactoController: Controller
    {
            private readonly ILogger<ContactoController> _logger;

            public ContactoController(ILogger<ContactoController> logger)
            {
                _logger = logger;
            }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
    {
        return View("index");
    }
    }

