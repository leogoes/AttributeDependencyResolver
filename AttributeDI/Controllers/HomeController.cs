using AttributeDI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AttributeDI.Attribute;
using AttributeDI.Filters;

namespace AttributeDI.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ICurrentUser _user;

        public HomeController(ICurrentUser user, ILogger<HomeController> logger)
        {
            _user = user;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult ResolveByAddToClassFilter()
        {
            return View("Index");
        }
        
        [ServiceFilter(typeof(ResolvedByServiceFilter))]
        public IActionResult ResolvedByServiceFilter()
        {
            return View("Index");
        }

        [TypeFilter(typeof(ResolvedByTypeFilter))]
        public IActionResult ResolvedByTypeFilter()
        {
            return View("Index");
        }       
        
        [DependencyInjectionFilterFactory(typeof(ResolvedByFactoryFilter))]
        public IActionResult ResolvedByFactoryFilter()
        {
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
