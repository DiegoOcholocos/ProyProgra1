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
//ÍNFORMACION
    public class PagosController: Controller
    {
        private readonly ILogger<PagosController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager; 

        public PagosController(ApplicationDbContext context,
            ILogger<PagosController> logger,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;

        }
        
        public async Task<IActionResult> Index(){
        var userID = _userManager.GetUserName(User);
        var items = from o in _context.DataPagos select o;
        items = items.
                Where(w => w.UserID.Equals(userID));
        var datos = await items.OrderByDescending(w => w.UserID).ToListAsync();

        dynamic model = new ExpandoObject();
        model.elementosDatos = datos;

        return View(model);
        }

        
        public async Task<IActionResult> vistaP(string? searchString,string? searchString2)
        { var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataPagos select o;
            items = items.
                Where(w => w.UserID.Equals(userID));
            
            if(!String.IsNullOrEmpty(searchString) & !String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.Curso.Contains(searchString));
                items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            }
            else if(!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Curso.Contains(searchString));
            }
            else if(!String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            }else{
                
            }

            var datos = await items.OrderByDescending(w => w.Id).ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosDatos = datos;

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Pagos objProduct = await _context.DataPagos.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public async Task<IActionResult> Indexadmin(string? searchString,string? searchString2)
        { var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataPagos select o;

            if(!String.IsNullOrEmpty(searchString) & !String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.Curso.Contains(searchString));
                items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            }
            else if(!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Curso.Contains(searchString));
            }
            else if(!String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            }else{
                
            }

            var datos = await items.OrderByDescending(w => w.Id).ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosDatos = datos;

            return View(model);
        }


        public async Task<IActionResult> IndexadminPagados(string? searchString,string? searchString2)
        { var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataPagos select o;
            items = items.
                Where(w => w.Status.Equals("PAGADO"));

            if(!String.IsNullOrEmpty(searchString) & !String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.Curso.Contains(searchString));
                items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            }
            else if(!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Curso.Contains(searchString));
            }
            else if(!String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            }else{
                
            }

            var datos = await items.OrderByDescending(w => w.Id).ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosDatos = datos;

            return View(model);
        }
        public async Task<IActionResult> IndexadminSinResolver(string? searchString,string? searchString2)
        { var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataPagos select o;
            items = items.
                Where(w => w.Status.Equals("SIN_RESOLVER"));

            if(!String.IsNullOrEmpty(searchString) & !String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.Curso.Contains(searchString));
                items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            }
            else if(!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Curso.Contains(searchString));
            }
            else if(!String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            }else{
                
            }

            var datos = await items.OrderByDescending(w => w.Id).ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosDatos = datos;

            return View(model);
        }
        public async Task<IActionResult> IndexadminPendientes(string? searchString,string? searchString2)
        { var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataPagos select o;
            items = items.
                Where(w => w.Status.Equals("PENDIENTE"));

            if(!String.IsNullOrEmpty(searchString) & !String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.Curso.Contains(searchString));
                items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            }
            else if(!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Curso.Contains(searchString));
            }
            else if(!String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.Mes_Matricula.Contains(searchString2));
            }else{
                
            }
            var datos = await items.OrderByDescending(w => w.Id).ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosDatos = datos;

            return View(model);
        }

        public async Task<IActionResult> Create([Bind("Id,UserID,Name,LastName,DNI,Celular,Area,Curso,Turno,Monto,Codigo_recibo,Foto_recibo,Status,Apuntes,Mes_Matricula,Año,CreationDate")] Pagos produto)

        {
        
            if (ModelState.IsValid)

            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                var usuario1 = await _userManager.GetUserAsync(User);
                var role = await _userManager.GetRolesAsync(usuario1);
                if (role.Contains("admin"))
                {
                    return RedirectToAction(nameof(Indexadmin));
                }else
                {
                    return RedirectToAction(nameof(Index));
                }
                
                

            }

            return View(produto);

    }

    // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.DataPagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.DataPagos.FindAsync(id);
            _context.DataPagos.Remove(produto);
            await _context.SaveChangesAsync();
                var usuario1 = await _userManager.GetUserAsync(User);
                var role = await _userManager.GetRolesAsync(usuario1);
                if (role.Contains("admin"))
                {
                return RedirectToAction(nameof(Indexadmin));
                }else{
                return RedirectToAction(nameof(vistaP));    
                }
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.DataPagos.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,Name,LastName,DNI,Celular,Area,Curso,Turno,Monto,Codigo_recibo,Foto_recibo,Status,Apuntes,Mes_Matricula,Año,CreationDate")] Pagos data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataExists((int)data.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var usuario1 = await _userManager.GetUserAsync(User);
                var role = await _userManager.GetRolesAsync(usuario1);
                if (role.Contains("admin"))
                {
                return RedirectToAction(nameof(Indexadmin));
                }else{
                return RedirectToAction(nameof(vistaP));    
                }
            }
            return View(data);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> EditSimple(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.DataPagos.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("EditSimple")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSimple(int id, [Bind("Id,UserID,Name,LastName,DNI,Celular,Area,Curso,Turno,Monto,Codigo_recibo,Foto_recibo,Status,Apuntes,Mes_Matricula,Año,CreationDate")] Pagos data)
        {
            if (id != data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataExists((int)data.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var usuario1 = await _userManager.GetUserAsync(User);
                var role = await _userManager.GetRolesAsync(usuario1);
                if (role.Contains("admin"))
                {
                return RedirectToAction(nameof(Indexadmin));
                }else{
                return RedirectToAction(nameof(vistaP));    
                }
            }
            return View(data);
        }
        private bool DataExists(int id)
        {
            return _context.DataPagos.Any(e => e.Id == id);
        }
    }
}

    


