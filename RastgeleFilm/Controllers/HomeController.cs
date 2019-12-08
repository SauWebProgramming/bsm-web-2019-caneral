using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RastgeleFilm.Models;

namespace RastgeleFilm.Controllers
{
    public class HomeController : Controller
    {
        //Kurucu fonksiyon(veriyi çekmek için gerekli)
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }
        //private readonly ILogger<HomeController> _logger;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        */
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmler.ToListAsync());
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
