using HarmonyHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HarmonyHub.Data
{
    public class HarmonyHubDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public DbSet<AlbumSong> AlbumSongs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<StorageFile> StorageFiles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAlbum> UserAlbums { get; set; }


        public HarmonyHubDbContext(DbContextOptions<HarmonyHubDbContext> options) : base(options) { }

    }
}

