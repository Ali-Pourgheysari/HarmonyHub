using HarmonyHub.Data.Entities;
using HarmonyHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.EntityMappings
{
    public static class ArtistMappingsExtension
    {
        public static ArtistModel ToArtistModel(this Artist artist)
        {
            if (artist == null)
            {
                throw new ArgumentNullException(nameof(artist));
            }

            return new ArtistModel
            {
                Id = artist.Id,
                FirstName = artist.FirstName,
                LastName = artist.LastName
            };
        }

        public static List<ArtistModel> ToArtistModels(this List<Artist> artists)
        {
            var artistModels = new List<ArtistModel>();

            if (artists == null)
            {
                throw new ArgumentNullException(nameof(artists));
            }

            foreach (var artist in artists)
            {
                artistModels.Add(artist.ToArtistModel());
            }
            return artistModels;
        }
    }
}
