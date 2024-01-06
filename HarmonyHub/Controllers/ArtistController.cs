using HarmonyHub.Data.EntityMappings;
using HarmonyHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HarmonyHub.Controllers
{
	public class ArtistController : Controller
	{
		private readonly IArtistService artistService;

		public ArtistController(IArtistService artistService)
        {
			this.artistService = artistService;
		}
        // GET: Artist/Details/1
        public async Task<ActionResult> Details(int id)
		{
			var artist = await artistService.GetArtistByIdAsync(id);
			var artistModel = artist.ToArtistModel();
			return View(artistModel);
		}
	}
}
