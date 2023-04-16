using System;
using Microsoft.EntityFrameworkCore;
using RockBand4.API.Models;

namespace RockBand4.API.DbContext
{
    public partial class MariaDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MariaDbContext(DbContextOptions<MariaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersistedSong> Songs { get; set; }
    }
}

