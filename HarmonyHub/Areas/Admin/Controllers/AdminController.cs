using HarmonyHub.Data.EntityMappings;
using HarmonyHub.Data.Models;
using HarmonyHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HarmonyHub.Data.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HarmonyHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly ISongService songService;
        private readonly IArtistService artistService;
        private readonly IObjectUploadService objectUploadService;

        public AdminController(ISongService songService,
                               IArtistService artistService,
                               IObjectUploadService objectUploadService
            )
        {
            this.songService = songService;
            this.artistService = artistService;
            this.objectUploadService = objectUploadService;
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
            return View(await GetSongFormModel());
        }
        [Route("Admin/Create")]
        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SongFormModel collection)
        {
            if (ModelState.IsValid)
            {
                var songFile = Request.Form.Files.FirstOrDefault(f => f.Name == "audio-file");
                var coverFile = Request.Form.Files.FirstOrDefault(f => f.Name == "cover-file");
                var songFileName = songFile.FileName;
                var coverFileName = coverFile.FileName;

                var uniqueAudioKey = FileNameUtility.CreateUniqueFileName(songFileName);
                var uniqueCoverKey = FileNameUtility.CreateUniqueFileName(coverFileName);

                var songPath = objectUploadService.UploadFormFile(songFile, uniqueAudioKey);
                var coverPath = objectUploadService.UploadFormFile(coverFile, uniqueCoverKey);
                Console.WriteLine(coverPath);
				var songEntity = collection.ToNormalizedSongModel().ToSongEntity
                (
		            songFileName,
		            songPath,
		            coverFileName,
		            coverPath
		        );
				foreach (var id in collection.ArtistFormIds)
                {
                    songEntity.Artists.Add(await artistService.GetArtistByIdAsync(int.Parse(id)));
                }
                var song = await songService.AddSongAsync(songEntity);
                Console.WriteLine(song.Name);
            }
            return View(await GetSongFormModel());
        }

        private async Task<SongFormModel> GetSongFormModel()
        {
            var artists = (await artistService.GetAllArtistsAsync()).ToArtistModels();
            SongFormModel song = new SongFormModel();
            song.AllArtists = artists;
            return song;
        }
    }
}
