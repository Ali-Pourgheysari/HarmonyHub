using HarmonyHub.Data.Entities;
using HarmonyHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.EntityMappings
{
    public static class PlayListMappingsExtensions
    {
        public static PlayListModel ToPlayListModel(this PlayList playList)
        {
            var songModels = new List<SongModel>();
            foreach (var song in playList.Songs)
            {
                if (song.Song != null)
                {
                    songModels.Add(song.Song.ToSongModel());
                }
            }
            return new PlayListModel
            {
                UserName = playList.User?.UserName,
                Songs = songModels
            };
        }
    }
}
