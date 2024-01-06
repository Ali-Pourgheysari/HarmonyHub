using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarmonyHub.Data.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public StorageFile? AudioStorageFile { get; set; }
        public StorageFile? CoverStorageFile { get; set; }
        public ICollection<Artist> Artists { get; set; } = new List<Artist>();
    }
}
