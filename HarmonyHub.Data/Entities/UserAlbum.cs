using System.ComponentModel.DataAnnotations.Schema;

namespace HarmonyHub.Data.Entities
{
    public class UserAlbum : EntityBase
    {
        public int AlbumId { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public Album? Album { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
