using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HarmonyHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        [Route("Admin")]
        // GET: HomeController
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Create));
        }
        [Route("Admin/Create")]
        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }
        [Route("Admin/Create")]
        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
