using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Models
{
    public class SongFormModel : SongModel
    {
        public List<ArtistModel>? AllArtists { get; set; }
        [Required(ErrorMessage = "Please select at least one artist")]
        public List<string> ArtistFormIds { get; set; }
    }
}
