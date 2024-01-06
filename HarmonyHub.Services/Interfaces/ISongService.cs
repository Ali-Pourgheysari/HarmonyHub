using HarmonyHub.Data.Entities;
using HarmonyHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Services.Interfaces
{
    public interface ISongService
    {
        Task<Song> AddSongAsync(Song song);
        Task<List<Song>> GetAllSongsAsync();
        Task<List<Song>> GetRandomSongsAsync(int count);
    }
}
