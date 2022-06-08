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

        public async Task<IActionResult> Index(string? searchString,string? searchString2){
            var items = from o in _context.DataPagos select o;
            items = items.Where(w => w.Status.Equals("PAGADO"));
            items = items.Where(s => s.Curso.Contains(searchString));
            items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            var datos1 = await items.OrderByDescending(w => w.Id).ToListAsync();
    
            String seleccurso = searchString;
            var cursos1 = 0;
            if (seleccurso == "Confeccion Textil")
            {
                cursos1 = 1;
            }
            else if (seleccurso == "Manejo de Maquinaria Industrial")
            {
                cursos1 = 2;
            }
            else if (seleccurso == "Diseño Grafico")
            {
                cursos1 = 3;
            }
            else if (seleccurso == "Mantenimiento de Equipos")
            {
                cursos1 = 4;
            }
            else if (seleccurso == "Curso de Excel")
            {
                cursos1 = 5;
            }
            else if (seleccurso == "Digitalizacion y Ofimatica")
            {
                cursos1 = 6;
            }
            else if (seleccurso == "Corte de Cabello")
            {
                cursos1 = 7;
            }
            dynamic model = new ExpandoObject();
            model.elementosConfeccion = datos1;
            model.elementocurso = cursos1;

            return View(model);
        }

    }
}