using System.ComponentModel.DataAnnotations.Schema;

namespace HarmonyHub.Data.Entities
{
    public class PlayListSong : EntityBase
    {
        public int PlayListId { get; set; }
        public int SongId { get; set; }
        [ForeignKey(nameof(PlayListId))]
        public PlayList? PlayList { get; set; }
        [ForeignKey(nameof(SongId))]
        public Song? Song { get; set; }
    }
}
