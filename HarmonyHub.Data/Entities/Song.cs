using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarmonyHub.Data.Entities
{
    public class Song : EntityBase
    {
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int? AudioStorageFileId { get; set; }
        [ForeignKey(nameof(AudioStorageFileId))]
        public StorageFile? AudioStorageFile { get; set; }
    }
}
