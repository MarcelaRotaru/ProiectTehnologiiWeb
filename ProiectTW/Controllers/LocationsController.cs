using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProiectTW.Models;

namespace ProiectTW.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Home  
        List<Locations> list = new List<Locations>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Location()
        {
           UsersStoreContext context = HttpContext.RequestServices.GetService(typeof(ProiectTW.Models.UsersStoreContext)) as UsersStoreContext;

            list =context.GetAllUsersLocations(2);
            string markers = "[";
            foreach (Locations item in list) {
                markers += "{";
                markers += string.Format("'title': '{0}',", item.CityName);
                markers += string.Format("'lat': '{0}',", item.Latitude);
                markers += string.Format("'lng': '{0}',", item.Longitude);
                markers += string.Format("'description': '{0}'", item.Description);
                markers += "},";
            }
            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }
        
    }
}