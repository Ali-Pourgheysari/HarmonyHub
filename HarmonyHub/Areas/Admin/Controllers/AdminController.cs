using HarmonyHub.Data.EntityMappings;
using HarmonyHub.Data.Models;
using HarmonyHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HarmonyHub.Data.Utilities;

namespace HarmonyHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ISongService songService;
        private readonly IArtistService artistService;

        public AdminController(ISongService songService,
                               IArtistService artistService)
        {
            this.songService = songService;
            this.artistService = artistService;
        }

        [Route("Admin")]
        // GET: HomeController
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Create));
        }
        [Route("Admin/Create")]
        // GET: HomeController/Create
        public async Task<ActionResult> Create()
        {
            var artists = (await artistService.GetAllArtistsAsync()).ToArtistModels();
            SongFormModel song = new SongFormModel();
            song.AllArtists = artists;
            return View(song);
        }
        [Route("Admin/Create")]
        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SongFormModel collection)
        {
            var songEntity = collection.ToNormalizedSongModel().ToSongEntity();
            foreach(var id in collection.ArtistFormIds)
            {
                songEntity.Artists.Add(await artistService.GetArtistByIdAsync(int.Parse(id)));
            }
            var song = await songService.AddSongAsync(songEntity);
            Console.WriteLine(song.Name);
            return RedirectToAction(nameof(Create));
        }
    }
}
