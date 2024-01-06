using HarmonyHub.Data;
using HarmonyHub.Data.Entities;
using HarmonyHub.Data.Models;
using HarmonyHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Song> AddSongAsync(Song song)
        {
            await Task.Run(() =>
            {
                dbContext.Songs.Add(song);
                dbContext.SaveChanges();
            });

            return song;
        }


        public async Task<List<Song>> GetAllSongsAsync()
        {
            List<Song> list = await dbContext.Songs
                .Include(s => s.Artists)
                .Include(s => s.CoverStorageFile)
                .ToListAsync();

            return list;
        }


        public async Task<List<Song>> GetRandomSongsAsync(int count)
        {
            List<Song> list = await dbContext.Songs
                .Include(s => s.Artists)
                .Include(s => s.CoverStorageFile)
                .OrderBy(s => Guid.NewGuid())
                .Take(count)
                .ToListAsync();
            return list;
        }

        public async Task<Song> GetSongByIdAsync(int id)
        {
            return await dbContext.Songs
                .Include(s => s.Artists)
                .Include(s => s.CoverStorageFile)
                .FirstAsync(s => s.Id == id);
        }
    }
}
