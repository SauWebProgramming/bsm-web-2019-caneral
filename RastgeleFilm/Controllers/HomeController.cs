using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        protected UserManager<IdentityUser> mUserManager;

        protected SignInManager<IdentityUser> mSignInManager;
        public HomeController(
            DataContext context)
        {
            _context = context;       
        }

        public IActionResult Index()
        {//Rastgele veri çekmek için kullanıyorum.
            var rastgeleGonder = _context.Filmler.OrderBy(u => Guid.NewGuid()).Take(1).ToList();
            return View(rastgeleGonder.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
