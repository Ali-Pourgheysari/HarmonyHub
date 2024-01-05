using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarmonyHub.Data.Entities
{
    public class PlayList : EntityBase
    {
        public User? User { get; set; }
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public ICollection<PlayListSong> Songs { get; set; } = new List<PlayListSong>();
    }
}
