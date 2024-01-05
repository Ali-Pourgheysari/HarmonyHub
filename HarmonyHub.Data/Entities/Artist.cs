using System.ComponentModel.DataAnnotations;

namespace HarmonyHub.Data.Entities
{
    public class Artist : EntityBase
    {
        [Required, MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
    }
}
