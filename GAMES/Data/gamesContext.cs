using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GAMES.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GAMES.Models
{
    public class gamesContext : DbContext
    {
        public gamesContext (DbContextOptions<gamesContext> options)
            : base(options)
        {
        }
        public DbSet<GAMES.Models.Person> Person { get; set; }
        public DbSet<GAMES.Models.Team> Team { get; set; }
        public DbSet<GAMES.Models.TeamScore> TeamScore { get; set; }
        public DbSet<GAMES.Models.Game> Game { get; set; }
        public DbSet<GAMES.Models.PersonScore> PersonScore { get; set; }

        //public DbSet<GAMES.Models.ApplicationUser> ApplicationUser
        //Replace below with GAMES tables
    //    public DbSet<engineering.Models.Client> Client { get; set; }
    //    public DbSet<engineering.Models.Project> Project { get; set; }
    //    public DbSet<engineering.Models.Review> Review { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Client>().ToTable("Client");
    //        modelBuilder.Entity<Project>().ToTable("Project");
    //        modelBuilder.Entity<Review>().ToTable("Review");

    //    }

    //    public DbSet<GAMES.Models.Recommendation> Recommendation { get; set; }
    }
}
