using HarmonyHub.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Services.Interfaces
{
    public interface IUserFollowingService
    {
        Task<UserFollowing> FollowArtistAsync(int artistId, User user);
        Task<int> UnfollowArtistAsync(int artistId, User user);
        Task<bool> Exists(int artistId, User user);
    }
}
