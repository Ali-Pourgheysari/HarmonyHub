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

            return new SongModel
            {
                Id = song.Id,
                Artists = song.Artists.ToList().ToArtistModels(),
                Name = song.Name,
                AudioStorageFile = song.AudioStorageFile?.ToStorageFileModel(),
                CoverStorageFile = song.CoverStorageFile?.ToStorageFileModel(),
            };
        }

        public static SongModel ToSongModelShallow(this Song song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }
            return new SongModel
            {
                Id = song.Id,
                Name = song.Name,
                AudioStorageFile = song.AudioStorageFile?.ToStorageFileModel(),
                CoverStorageFile = song.CoverStorageFile?.ToStorageFileModel()
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

        public static List<SongModel> ToSongModelsShallow(this List<Song> songs)
        {
            var songModels = new List<SongModel>();

            if (songs == null)
            {
                throw new ArgumentNullException(nameof(songs));
            }

            foreach (var song in songs)
            {
                songModels.Add(song.ToSongModelShallow());
            }
            return songModels;
        }

        public static Song ToSongFormEntity(this SongFormModel song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }

            song = song.ToNormalizedSongFormModel();
            return new Song()
            {
                Artists = song.Artists.ToList().ToArtistEntityList(),
                Name = song.Name,
                AudioStorageFile = song.AudioStorageFile?.ToStorageFileEntity(),
                CoverStorageFile = song.CoverStorageFile?.ToStorageFileEntity(),
            };
        }
    }
}
