using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Entities
{
    public class UserFollowing : EntityBase
    {
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey(nameof(ArtistId))]
        public Artist? Artist { get; set; }
    }
}
