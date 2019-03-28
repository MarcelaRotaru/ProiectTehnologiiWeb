using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProiectTW.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProiectTW.Controllers
{
    public class UsersController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            UsersStoreContext context = HttpContext.RequestServices.GetService(typeof(ProiectTW.Models.UsersStoreContext)) as UsersStoreContext;

            return View(context.GetAllUsers());
        }
    }
}
