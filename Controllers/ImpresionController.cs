using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using appproy.Models;
using appproy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using appproy.Util;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace appproy.Controllers
{
    public class ImpresionController: Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public ImpresionController(ApplicationDbContext context,
            ILogger<CatalogoController> logger,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;

        }

        public async Task<IActionResult> Index(){
            var items = from o in _context.DataPagos select o;
            items = items.Where(w => w.Status.Equals("PAGADO"));
            items = items.Where(s => s.Curso.Contains("Diseño Grafico"));
            var datos1 = await items.OrderByDescending(w => w.Id).ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosConfeccion = datos1;

            return View(model);
        }

    }
}