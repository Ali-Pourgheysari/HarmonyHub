using HarmonyHub.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Services.Interfaces
{
    public interface IArtistService
    {
        Task<List<Artist>> GetAllArtistsAsync(Artist artist);
        Task<Artist> GetArtistByIdAsync(int id);
    }
}
