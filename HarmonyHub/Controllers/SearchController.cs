using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HarmonyHub.Data.Models;
using HarmonyHub.Services.Interfaces;
using HarmonyHub.Data.EntityMappings;
using HarmonyHub.Data.Utilities;

namespace HarmonyHub.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISongService songService;
        private readonly IArtistService artistService;
        private readonly IUserService userService;

        public SearchController(
            ISongService songService,
            IArtistService artistService,
            IUserService userService
            )
        {
            this.songService = songService;
            this.artistService = artistService;
            this.userService = userService;
        }
        // GET: Search?query=foo
        public async Task<ActionResult> Index(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
				return View(new SearchResultModel());
			}

            var artist = await artistService.SearchArtistByString(query);
            var songs = await songService.SearchSongByString(query);
            var model = new SearchResultModel()
            {
                Query = query,
                Artists = artist.ToArtistModels(),
                Songs = songs.ToSongModels()
            };

            var username = User.Identity.Name;
            if (username != null)
            {
				var user = await userService.GetUserByEmailAsync(username);
                if (user != null)
                {
					model.Artists = model.Artists.MarkFollowedArtists(user);
					model.Songs = model.Songs.MarkPlayListSongs(user);
				}
			}

            return View(model);
        }
    }
}
