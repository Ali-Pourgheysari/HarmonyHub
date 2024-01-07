﻿using HarmonyHub.Data.Entities;
using HarmonyHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.EntityMappings
{
    public static class ProfileMappingsExtension
    {
        public static ProfileModel ToProfileModel(this User user)
        {
            var artistModels = new List<ArtistModel>();
            foreach (var artist in user.FollowingArtists)
            {
                if (artist.Artist != null)
                {
                    artistModels.Add(artist.Artist.ToArtistModel());
                }
            }
            return new ProfileModel
            {
                Name = user.FirstName + " " + user.LastName,
                Email = user?.Email,
                FollowingArtists = artistModels,
                PlayList = user?.PlayList?.ToPlayListModel()
            };
        }

        public static User ToEditProfileModel(this EditProfileModel editProfileModel)
        {
            return new User
            {
                Id = editProfileModel.Id,
                FirstName = editProfileModel.FirstName,
                LastName = editProfileModel.LastName,
                PhoneNumber = editProfileModel.PhoneNumber
            };
        }
    }
}
