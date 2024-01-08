using HarmonyHub.Data.Entities;
using HarmonyHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Utilities
{
	public static class FollowingArtistUtility
	{
		public static ArtistModel MarkFollowedArtist(this ArtistModel artist, User user)
		{
			if (user != null)
			{
				// create a list of followed artist ids
				var followedArtistIds = user.FollowingArtists.Select(a => a.ArtistId).ToList();
				// check if the artist id is in the list
				artist.IsFollowed = followedArtistIds.Contains(artist.Id);
			}
			return artist;
		}
		public static List<ArtistModel> MarkFollowedArtists(this List<ArtistModel> artists, User user)
		{
			if (user != null)
			{
				// create a list of followed artist ids
				var followedArtistIds = user.FollowingArtists.Select(a => a.ArtistId).ToList();
				// for each artist in the list of artists
				foreach (var artist in artists)
				{
					// check if the artist id is in the list
					artist.IsFollowed = followedArtistIds.Contains(artist.Id);
				}
			}
			return artists;
		}
	}
}
