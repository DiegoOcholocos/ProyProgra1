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
    public class UsersInfoController: Controller
    {
        private readonly ILogger<UsersInfoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager; 

        public UsersInfoController(ApplicationDbContext context,
            ILogger<UsersInfoController> logger,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;

        }
        
        public async Task<IActionResult> Index(){
        var userID = _userManager.GetUserName(User);
        var items = from o in _context.DataUsersInfo select o;
        items = items.
                Where(w => w.UserID.Equals(userID));
        var datos = await items.ToListAsync();

        dynamic model = new ExpandoObject();
        model.elementosDatos = datos;

        return View(model);
        }

        // GET: Producto/Edit/5
    
        

        private bool DataExists(int id)
        {
            return _context.DataUsersInfo.Any(e => e.Id == id);
        }
    }
}

