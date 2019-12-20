using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using RastgeleFilm.Models;

namespace RastgeleFilm.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //Kurucu fonksiyon(veriyi çekmek için gerekli)
        private readonly DataContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        protected UserManager<IdentityUser> mUserManager;

        protected SignInManager<IdentityUser> mSignInManager;
        public HomeController(DataContext context, IStringLocalizer<HomeController> localizer)
        {
            _context = context;
            _localizer = localizer;
        }
        
        public IActionResult Index()
        {//Rastgele veri çekmek için kullanıyorum.
            var rastgeleGonder = _context.Filmler.OrderBy(u => Guid.NewGuid()).Take(1).ToList();
            
            return View(rastgeleGonder.ToList());
        }
        

        public IActionResult Contact()
        {
            ViewData["Message"] = _localizer["Dene"];
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
            );

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
