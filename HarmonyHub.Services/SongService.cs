using HarmonyHub.Data;
using HarmonyHub.Data.Entities;
using HarmonyHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Services
{
    public class SongService : ISongService
    {
        private readonly HarmonyHubDbContext dbContext;

        public SongService(HarmonyHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Song AddSong(Song song)
        {
            dbContext.Add(song);
            dbContext.SaveChanges();
            return song;
        }

        public List<Song> GetSongsList()
        {
            List<Song> list = new List<Song>();
            list = dbContext.Songs.ToList();
            return list;
        }
    }
}
