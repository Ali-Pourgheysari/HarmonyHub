using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHub.Data.Models
{
    public class EditProfileModel
    {
        public string Id { get; set; }
        public string? FirstName{ get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
