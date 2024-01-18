using HarmonyHub.Data.Entities;
using HarmonyHub.Data.EntityMappings;
using HarmonyHub.Data.Models;
using HarmonyHub.Models;
using HarmonyHub.Services;
using HarmonyHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HarmonyHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly ISongService songService;

        public HomeController(
            ILogger<HomeController> logger,
            SignInManager<User> signInManager,
            ISongService songService
            )
        {
            _logger = logger;
            this._signInManager = signInManager;
            this.songService = songService;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }


        [Authorize]
        [HttpGet]
        [Route("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var count = 24;
            var songs = await songService.GetRandomSongsAsync(count);
            
            // convert the songs to a list of SongModel objects
            var songModels = songs.ToSongModels();

            // divide the songs into three lists
            var trends = songModels.Take(count/3).ToList();
            var newSongs = songModels.Skip(count/3).Take(count/3).ToList();
            var topSongs = songModels.Skip(2*(count/3)).Take(count/3).ToList();

            // create a DashboardModel object
            var dashboardModel = new DashboardModel
            {
                Trends = trends,
                NewSongs = newSongs,
                TopSongs = topSongs
            };

            return View(dashboardModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}