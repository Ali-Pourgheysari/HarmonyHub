using HarmonyHub.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Models
{
    public class ProfileModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public PlayListModel PlayList { get; set; } = new PlayListModel();
        public List<ArtistModel> Artists { get; set; } = new List<ArtistModel>();
    }
}
