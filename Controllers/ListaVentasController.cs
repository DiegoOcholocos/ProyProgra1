using Microsoft.AspNetCore.Mvc;
using appproy.Models;
using appproy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;
namespace appproy.Controllers
{
    public class ListaVentasController: Controller
     
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager; 
        public ListaVentasController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
        var items = from o in _context.DataPago select o;
        var datos = await items.ToListAsync();

        dynamic model = new ExpandoObject();
        model.elementosDatos = datos;
        
        return View(model);
        }

         public async Task<IActionResult> Details(Pago UserID)
        {  
            var items = from e in _context.DataDetallePedido select e;
        var cont = await items.ToListAsync();

        dynamic model = new ExpandoObject();
        model.elementosDe = cont;
        
        return View(model);
        }
        

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.DataContactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,email,numero,subject,AnotacionAdmin,Status")] Contacto contacto)
        {
            if (id != contacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contacto);
        }

        private bool ContactoExists(int id)
        {
            return _context.DataContactos.Any(e => e.Id == id);
        }
    }
    
}