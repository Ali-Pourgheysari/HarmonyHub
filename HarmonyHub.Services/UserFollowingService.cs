using HarmonyHub.Data.Entities;
using HarmonyHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Services
{
    public class UserFollowingService : IUserFollowingService
    {
        private readonly IUserService userService;
        public UserFollowingService(IUserService userService)
        {
            this.userService = userService;
        }

        public Task<bool> Exists(int artistId, User user)
        {
            return Task.FromResult(user.FollowingArtists.Any(fa => fa.ArtistId == artistId));
        }

        public async Task<UserFollowing> FollowArtistAsync(int artistId, User user)
        {
            var userFollowing = new UserFollowing
            {
                ArtistId = artistId,
                UserId = user.Id
            };
            user.FollowingArtists.Add(userFollowing);
            await userService.UpdateUserAsync(user);
            return userFollowing;
        }

        public async Task<int> UnfollowArtistAsync(int artistId, User user)
        {
            user.FollowingArtists.Remove(user.FollowingArtists.First(fa => fa.ArtistId == artistId));
            return await userService.UpdateUserAsync(user);
        }
    }
}
