using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appproy.Data;
using appproy.Models;
using Microsoft.AspNetCore.Mvc;

namespace appproy.Controllers
{
    public class DataUsersContoller : Controller
    {
        private readonly ILogger<DataUsersContoller> _logger;
        private readonly ApplicationDbContext _context;

        public DataUsersContoller(ApplicationDbContext context,
            ILogger<DataUsersContoller> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}