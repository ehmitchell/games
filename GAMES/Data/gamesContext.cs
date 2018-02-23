using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GAMES.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GAMES.Models
{
    public class GamesContext : DbContext
    {
        public GamesContext (DbContextOptions<GamesContext> options)
            : base(options)
        {
        }
        public DbSet<GAMES.Models.Person> Person { get; set; }
        public DbSet<GAMES.Models.Team> Team { get; set; }
        public DbSet<GAMES.Models.TeamScore> TeamScore { get; set; }
        public DbSet<GAMES.Models.Game> Game { get; set; }
        public DbSet<GAMES.Models.PersonScore> PersonScore { get; set; }
<<<<<<< HEAD

        //public DbSet<GAMES.Models.ApplicationUser> ApplicationUser
        //Replace below with GAMES tables
    //    public DbSet<engineering.Models.Client> Client { get; set; }
    //    public DbSet<engineering.Models.Project> Project { get; set; }
    //    public DbSet<engineering.Models.Review> Review { get; set; }
=======
        public DbSet<GAMES.Models.GamesInstance> GamesInstance { get; set; }
        public DbSet<GAMES.Models.PersonTeam> PersonTeam { get; set; }
>>>>>>> corrected models

    }
}
