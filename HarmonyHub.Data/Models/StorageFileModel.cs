using System.ComponentModel.DataAnnotations;

namespace HarmonyHub.Data.Models
{
    public class StorageFileModel
    {
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public string? FilePath { get; set; }
    }
}
