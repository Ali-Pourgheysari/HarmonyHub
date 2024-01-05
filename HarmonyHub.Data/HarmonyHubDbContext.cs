using HarmonyHub.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HarmonyHub.Data
{
    public class HarmonyHubDbContext : IdentityDbContext<User>
    {
        public DbSet<PlayList> PlayList { get; set; }

        public DbSet<PlayListSong> PlayListSongs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<StorageFile> StorageFiles { get; set; }

        public HarmonyHubDbContext(DbContextOptions<HarmonyHubDbContext> options) : base(options) { }
    }
}

