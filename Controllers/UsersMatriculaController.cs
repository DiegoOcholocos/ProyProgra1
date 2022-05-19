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
    public class UsersMatriculaController: Controller
    {
        private readonly ILogger<UsersMatriculaController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager; 

        public UsersMatriculaController(ApplicationDbContext context,
            ILogger<UsersMatriculaController> logger,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;

        }
        
        public async Task<IActionResult> Index(){
        var userID = _userManager.GetUserName(User);
        var items = from o in _context.DataUsersMatricula select o;
        items = items.
                Where(w => w.UserID.Equals(userID));
        var datos = await items.ToListAsync();

        dynamic model = new ExpandoObject();
        model.elementosDatos = datos;

        return View(model);
        }

        public async Task<IActionResult> Create([Bind("id,UserID,Name,LastName,DNI,Pasaporte,Carnet_de_extranjeria,Nacionalidad,BirthDate,Edad,Celular,Operador,Sexo,Grado_Academico,Correo-GMAIL,Direccion,Distrito,Vacuna,Computacion_info,Confeccion_info,Estetica_info,Horario,Foto_DNI_Cara,Foto_DNI_Sello,Codigo_Voucher,Foto_Voucher,Status,Apuntes,Creacion")] UsersMatricula produto)

        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            if (ModelState.IsValid)

            {

                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
                _context.Add(produto);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

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

            var produto = await _context.DataUsersMatricula
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
            var produto = await _context.DataUsersMatricula.FindAsync(id);
            _context.DataUsersMatricula.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

            private bool ProdutoExists(int id)
        {
            return _context.DataUsersMatricula.Any(e => e.Id == id);
        }
    }
}

