using HarmonyHub.Data.Entities;
using HarmonyHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.EntityMappings
{
    public static class StorageFileMappingsExtension
    {
        public static StorageFileModel ToStorageFileModel(this StorageFile storageFile)
        {
            if (storageFile == null) throw new ArgumentNullException(nameof(storageFile));

            return new StorageFileModel
            {
                Id = storageFile.Id,
                DisplayName = storageFile.DisplayName,
                FilePath = storageFile.FilePath,
            };
        }

        public static StorageFile ToStorageFileEntity(this StorageFileModel storageFile, string fileName, string path)
        {
            if (storageFile == null) throw new ArgumentNullException(nameof(storageFile));

            return new StorageFile
            {
                Id = storageFile.Id,
                DisplayName = fileName,
                FilePath = path,
            };
        }
    }
}
