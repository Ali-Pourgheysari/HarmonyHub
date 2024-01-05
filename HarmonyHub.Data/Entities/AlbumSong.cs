using System.ComponentModel.DataAnnotations.Schema;

namespace HarmonyHub.Data.Entities
{
    public class AlbumSong : EntityBase
    {
        public int AlbumId { get; set; }

        public int SongId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public Album? Album { get; set; }

        [ForeignKey(nameof(SongId))]
        public Song? Song { get; set; }
    }
}
