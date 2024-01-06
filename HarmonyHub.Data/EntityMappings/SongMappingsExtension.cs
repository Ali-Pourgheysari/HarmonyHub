using HarmonyHub.Data.Entities;
using HarmonyHub.Data.Models;
using HarmonyHub.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.EntityMappings
{
    public static class SongMappingsExtension
    {
        public static SongModel ToSongModel(this Song song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }

            var artists = new List<ArtistModel>();
            foreach (var item in song.Artists)
            {
                artists.Add(item.Artist.ToArtistModel());
            }

            return new SongModel
            {
                Id = song.Id,
                Artists = artists,
                Name = song.Name,
                AudioStorageFile = song.AudioStorageFile?.ToStorageFileModel(),
                CoverStorageFile = song.CoverStorageFile?.ToStorageFileModel(),
            };
        }

        public static List<SongModel> ToSongModels(this List<Song> songs)
        {
            var songModels = new List<SongModel>();

            if (songs == null)
            {
                throw new ArgumentNullException(nameof(songs));
            }

            foreach (var song in songs)
            {
                songModels.Add(song.ToSongModel());
            }
            return songModels;
        }

        public static Song ToSongFormEntity(this SongFormModel song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }

            var artists = new List<ArtistSong>();
            foreach (var item in song.Artists)
            {
                artists.Add(new ArtistSong
                {
                    Artist = item.ToArtistEntity(),
                    ArtistId = item.Id
                });
            }

            song = song.ToNormalizedSongFormModel();
            var songEntity = new Song()
            {
                Artists = artists,
                Name = song.Name,
                AudioStorageFile = song.AudioStorageFile?.ToStorageFileEntity(),
                CoverStorageFile = song.CoverStorageFile?.ToStorageFileEntity(),
            };

            foreach (var item in artists)
            {
                item.Song = songEntity;
                item.SongId = songEntity.Id;
            }

            return songEntity;
        }
    }
}
