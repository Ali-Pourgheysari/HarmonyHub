using HarmonyHub.Data;
using HarmonyHub.Data.Entities;
using HarmonyHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Services
{
    public class ArtistService : IArtistService
    {
        private readonly HarmonyHubDbContext dbContext;

        public ArtistService(HarmonyHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Artist>> GetAllArtistsAsync(Artist artist)
        {
            return await dbContext.Artists
                .Include(x => x.Songs)
                .ToListAsync();
        }
    }
}
