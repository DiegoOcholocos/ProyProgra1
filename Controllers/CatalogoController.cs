using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using appproy.Models;
using appproy.Data;
using Microsoft.EntityFrameworkCore;

namespace appproy.Controllers
{
    public class ProductoController:  Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context,
            ILogger<ProductoController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult>Index()
        {
            var productos = from o in _context.DataProductos select o;
            return View(await productos.ToListAsync());
        }
    }
}