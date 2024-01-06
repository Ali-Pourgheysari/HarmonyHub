using System.ComponentModel.DataAnnotations;

namespace HarmonyHub.Data.Models
{
    public class ArtistModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
