using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Models
{
    public class SongFormModel : SongModel
    {
        public List<ArtistModel>? AllArtists { get; set; }
        public List<string> ArtistFormIds { get; set; }
    }
}
