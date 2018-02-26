using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GAMES.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GAMES.Data
{
    public class GamesContext : DbContext
    {
        public GamesContext (DbContextOptions<GamesContext> options)
            : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamScore> TeamScores { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PersonScore> PersonScores { get; set; }
        public DbSet<GamesInstance> GamesInstances { get; set; }
        public DbSet<PersonTeam> PersonTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamesInstance>()
                .Property(b => b.CreatedDate)
                .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<GamesInstance>()
                .Property(b => b.IsActive)
                .HasDefaultValue(true);
        }
    }
}
