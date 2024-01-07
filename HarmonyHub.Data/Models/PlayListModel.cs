using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Models
{
    public class PlayListModel
    {
        public string? UserName { get; set; }
        public List<SongModel> Songs { get; set; } = new();
    }
}
