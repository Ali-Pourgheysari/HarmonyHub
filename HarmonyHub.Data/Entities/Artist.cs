using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarmonyHub.Data.Entities
{
    public class Artist : EntityBase
    {
        [Required, MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
