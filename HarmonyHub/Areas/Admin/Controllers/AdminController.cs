using HarmonyHub.Data.EntityMappings;
using HarmonyHub.Data.Models;
using HarmonyHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HarmonyHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ISongService songService;

        public AdminController(ISongService songService)
        {
            this.songService = songService;
        }

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
        public async Task<ActionResult> Create(SongModel collection)
        {
            var song = await songService.AddSongAsync(collection.ToSongEntity());
            Console.WriteLine(song.Name);
            return View();
        }
    }
}
