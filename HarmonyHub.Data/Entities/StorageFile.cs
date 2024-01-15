using System.ComponentModel.DataAnnotations;

namespace HarmonyHub.Data.Entities
{
    public class StorageFile : EntityBase
    {
        [Required, MaxLength(100)]
        public string? DisplayName { get; set; }

        [Required, MaxLength(500)]
        public string? FilePath { get; set; }
    }
}
