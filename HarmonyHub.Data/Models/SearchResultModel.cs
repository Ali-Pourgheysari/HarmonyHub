using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Models
{
    public class SearchResultModel
    {
        public string Query { get; set; }
        public List<SongModel> Songs { get; set; } = new();
        public List<ArtistModel> Artists { get; set; } = new();
    }
}
