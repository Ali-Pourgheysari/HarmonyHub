using HarmonyHub.Data.Entities;
using HarmonyHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Utilities
{
	public static class PlayListUtility
	{
		public static List<SongModel> MarkPlayListSongs(this List<SongModel> songs, User user)
		{
            if (user != null)
			{
				// create a list of playlist song ids
				var playListSongIds = user.PlayList.Songs.Select(s => s.SongId).ToList();
				// for each song in the artist's songs
				foreach (var song in songs)
				{
						// check if the song id is in the list
						song.InPLayList = playListSongIds.Contains(song.Id);
				}
            }
			return songs;
		}
	}
}
