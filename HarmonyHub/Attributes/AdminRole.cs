using HarmonyHub.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace HarmonyHub.Attributes
{
    public class AdminRole: System.Attribute
    {
        public AdminRole(string role, SignInManager<User> signInManager)
        {
            SignInManager = signInManager;
        }

        public SignInManager<User> SignInManager { get; }
    }
}
