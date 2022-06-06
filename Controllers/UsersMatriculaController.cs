using Microsoft.AspNetCore.Mvc;
using appproy.Models;
using appproy.Data;
using Microsoft.EntityFrameworkCore;
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


        public async Task<IActionResult> vista(string? searchString)
        { var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataUsersMatricula select o;
            items = items.
                Where(w => w.UserID.Equals(userID));
            var datos = await items.ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosDatos = datos;

            return View(model);
        }
           

        public async Task<IActionResult> vistaCentral(string? searchString)
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataUsersMatricula select o;
            var datos = await items.ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosDatos = datos;

            return View(model);
        }

        public async Task<IActionResult> vistaPagados(string? searchString)
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataUsersMatricula select o;
            items = items.Where(s => s.Status.Contains("PAGADO"));
            var datos = await items.ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosDatos = datos;

            return View(model);
        }

        public async Task<IActionResult> vistaPendiente(string? searchString)
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataUsersMatricula select o;
            items = items.Where(s => s.Status.Contains("PENDIENTE"));
            var datos = await items.ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosDatos = datos;

            return View(model);
        }

        public async Task<IActionResult> vistasinResolver(string? searchString)
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataUsersMatricula select o;
            items = items.Where(s => s.Status.Contains("SIN_RESOLVER"));
            var datos = await items.ToListAsync();

            dynamic model = new ExpandoObject();
            model.elementosDatos = datos;

            return View(model);
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
        

        public async Task<IActionResult> Create([Bind("Id,UserID,Name,LastName,DNI,Pasaporte,Carnet_de_extranjeria,Nacionalidad,Año,Edad,Celular,Operador,Sexo,Grado_Academico,Correo,Direccion,Distrito,Vacuna,Area,Curso,Horario,Foto_DNI_Cara,Foto_DNI_Sello,Codigo_Voucher,Foto_Voucher,Mes_Matricula,Status,Apuntes")] UsersMatricula produto)

        {
            if (ModelState.IsValid)

            {
                _context.Add(produto);
                await _context.SaveChangesAsync();

                var usuario1 = await _userManager.GetUserAsync(User);
                var role = await _userManager.GetRolesAsync(usuario1);
                if (role.Contains("admin"))
                {
                    return RedirectToAction(nameof(vistaCentral));
                }else
                {
                    return RedirectToAction(nameof(vista));
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
            var usuario1 = await _userManager.GetUserAsync(User);
                var role = await _userManager.GetRolesAsync(usuario1);
                if (role.Contains("admin"))
                {
                    return RedirectToAction(nameof(vistaCentral));
                }else
                {
                    return RedirectToAction(nameof(vista));
                }
        }


        


        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.DataUsersMatricula.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,Name,LastName,DNI,Pasaporte,Carnet_de_extranjeria,Nacionalidad,Año,Edad,Celular,Operador,Sexo,Grado_Academico,Correo,Direccion,Distrito,Vacuna,Area,Curso,Horario,Foto_DNI_Cara,Foto_DNI_Sello,Codigo_Voucher,Foto_Voucher,Mes_Matricula,Status,Apuntes")] UsersMatricula data)
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
                    return RedirectToAction(nameof(vistaCentral));
                }else
                {
                    return RedirectToAction(nameof(vista));
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

            var data = await _context.DataUsersMatricula.FindAsync(id);
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
        public async Task<IActionResult> EditSimple(int id, [Bind("Id,UserID,Name,LastName,DNI,Pasaporte,Carnet_de_extranjeria,Nacionalidad,Año,Edad,Celular,Operador,Sexo,Grado_Academico,Correo,Direccion,Distrito,Vacuna,Area,Curso,Horario,Foto_DNI_Cara,Foto_DNI_Sello,Codigo_Voucher,Foto_Voucher,Mes_Matricula,Status,Apuntes")] UsersMatricula data)
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
                    return RedirectToAction(nameof(vistaCentral));
                }else
                {
                    return RedirectToAction(nameof(vista));
                }
            }
            return View(data);
        }
        public async Task<IActionResult> Details(int? id)
        {
            UsersMatricula objProduct = await _context.DataUsersMatricula.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        private bool DataExists(int id)
        {
            return _context.DataUsersMatricula.Any(e => e.Id == id);
        }

    }
}

