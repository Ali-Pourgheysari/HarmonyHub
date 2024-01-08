using HarmonyHub.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
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
        }
    }
}

