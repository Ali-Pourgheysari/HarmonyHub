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
    public class UserService : IUserService
    {
        private readonly HarmonyHubDbContext dbContext;
        public UserService(HarmonyHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await dbContext.Users
                .Include(u => u.FollowingArtists)
                    .ThenInclude(fa => fa.Artist)
                .Include(u => u.PlayList)
                    .ThenInclude(pl => pl.Songs)
                        .ThenInclude(s => s.Song)
                            .ThenInclude(s => s.Artists)
                .FirstAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await dbContext.Users
                .Include(u => u.FollowingArtists)
                    .ThenInclude(fa => fa.Artist)
                .Include(u => u.PlayList)
                    .ThenInclude(pl => pl.Songs)
                        .ThenInclude(s => s.Song)
                            .ThenInclude(s => s.Artists)
                .FirstAsync(u => u.Id == id);
        }
    }
}
