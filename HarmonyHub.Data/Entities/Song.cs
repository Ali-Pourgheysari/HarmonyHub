using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarmonyHub.Data.Entities
{
    public class Song : EntityBase
    {
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        public int? AudioStorageFileId { get; set; }
        [ForeignKey(nameof(AudioStorageFileId))]
        public StorageFile? AudioStorageFile { get; set; }
        public int CoverStorageId { get; set; }
        [ForeignKey(nameof(CoverStorageId))]
        public StorageFile? CoverStorageFile { get; set; }
        public ICollection<ArtistSong> Artists { get; set; } = new List<ArtistSong>();
    }
}
