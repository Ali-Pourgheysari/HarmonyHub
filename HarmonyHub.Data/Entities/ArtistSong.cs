using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Entities
{
    public class ArtistSong : EntityBase
    {
        public int ArtistId { get; set; }
        [ForeignKey(nameof(ArtistId))]
        public Artist Artist { get; set; } = null!;
        public int SongId { get; set; }
        [ForeignKey(nameof(SongId))]
        public Song Song { get; set; } = null!;
    }
}
