using HarmonyHub.Data.Entities;
using HarmonyHub.Data;
using HarmonyHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Services
{
    public class PlayListService : IPlayListService
    {
        private readonly HarmonyHubDbContext dbContext;
        private readonly IUserService userService;

        public PlayListService(
            HarmonyHubDbContext dbContext,
            IUserService userService
            )
        {
            this.dbContext = dbContext;
            this.userService = userService;            
        }

        public async Task<PlayListSong> AddToPlayListAsync(int songId, PlayList playList)
        {
            var playListSong = new PlayListSong
            {
                SongId = songId,
                PlayListId = playList.Id
            };
            playList.Songs.Add(playListSong);
            await dbContext.SaveChangesAsync();
            return playListSong;
        }

        public async Task<int> RemoveFromPlayListAsync(int songId, PlayList playList)
        {
            var playListSong = playList.Songs.FirstOrDefault(s => s.SongId == songId);
            if (playListSong != null)
            {
                playList.Songs.Remove(playListSong);
            }
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int songId, PlayList playList)
        {
            return await Task.FromResult(playList.Songs.Any(s => s.SongId == songId));
        }
    }
}
