using HarmonyHub.Data.EntityMappings;
using HarmonyHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HarmonyHub.Controllers
{
    public class PlayListController : Controller
    {
        private readonly IUserService userService;
        private readonly ISongService songService;
        private readonly IPlayListService playListService;

        public PlayListController(
            IUserService userService,
            ISongService songService,
            IPlayListService playListService
            )
        {
            this.userService = userService;
            this.songService = songService;
            this.playListService = playListService;
        }
        // GET: PlayList
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var userName = User.Identity?.Name;
            if (userName != null)
            {
                var user = await userService.GetUserByEmailAsync(userName);
                var playList = user?.PlayList?.ToPlayListModel();
                return View(playList);
            }
            return NotFound();
        }
        [Authorize]
        public async Task<ActionResult> AddSong(int id)
        {
            var userName = User.Identity?.Name;
            if (userName != null)
            {
                var user = await userService.GetUserByEmailAsync(userName);
                if (user != null)
                {
                    // check if the song is already in the playlist
                    var song = await playListService.Exists(id, user.PlayList);
                    if (!song)
                    {
                        // add the song to the playlist
                        await playListService.AddToPlayListAsync(id, user.PlayList);
                    } else
                    {
                        // remove the song from the playlist
                        await playListService.RemoveFromPlayListAsync(id, user.PlayList);
                    }
                    // redirect to the referrer page
                    return Redirect(Request.Headers["Referer"].ToString());
                }
            }
            return NotFound();
        }
    }
}
