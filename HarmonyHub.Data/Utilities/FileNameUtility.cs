using HarmonyHub.Data.Entities;
using HarmonyHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Utilities
{
    public static class FileNameUtility
    {
        // Extension to include name in the song model
        public static SongModel ToNormalizedSongModel(this SongFormModel song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }

            var audioStorageFile = new StorageFileModel()
            {
                DisplayName = song.AudioStorageFile?.FilePath?.Split('\\').Last(),
                FilePath = song.AudioStorageFile?.FilePath
            };

            var coverStorageFile = new StorageFileModel()
            {
                DisplayName = song.CoverStorageFile?.FilePath?.Split('\\').Last(),
                FilePath = song?.CoverStorageFile?.FilePath
            };

            return new SongModel()
            {
                Artists = song.Artists,
                Name = song.Name,
                AudioStorageFile = audioStorageFile,
                CoverStorageFile = coverStorageFile,
            };
        }
    }
}
