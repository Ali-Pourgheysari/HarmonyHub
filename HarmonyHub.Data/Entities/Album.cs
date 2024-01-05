using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarmonyHub.Data.Entities
{
    public class Album : EntityBase
    {
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<AlbumSong> AlbumSongs { get; set; } = new List<AlbumSong>();
    }
}
