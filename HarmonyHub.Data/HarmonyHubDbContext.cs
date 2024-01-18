using HarmonyHub.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Reflection.Emit;

namespace HarmonyHub.Data
{
    public class HarmonyHubDbContext : IdentityDbContext<User>
    {
        public DbSet<PlayList> PlayLists { get; set; }

        public DbSet<UserFollowing> UserFollowings { get; set; }

        public DbSet<PlayListSong> PlayListSongs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<StorageFile> StorageFiles { get; set; }

        public HarmonyHubDbContext(DbContextOptions<HarmonyHubDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // delete properties related to one user when the user is deleted
            builder.Entity<User>()
                .HasOne(u => u.PlayList)
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(u => u.FollowingArtists)
                .WithOne(f => f.User)
                .OnDelete(DeleteBehavior.Cascade);

            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new User
            {
                Id = ADMIN_ID,
                Email = "Admin@gmail.com",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Admini",
                UserName = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM"
            };

            //set user password
            PasswordHasher<User> ph = new PasswordHasher<User>();
            appUser.PasswordHash = ph.HashPassword(appUser, "#Admin123");

            //seed user
            builder.Entity<User>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            // seed play list for admin
            builder.Entity<PlayList>().HasData(new PlayList
            {
                Id = -1,
                UserId = ADMIN_ID,
            });
        }
    }
}

