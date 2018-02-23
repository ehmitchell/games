using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GAMES.Models;

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
        public DbSet<GAMES.Models.GamesInstance> GamesInstance { get; set; }
        public DbSet<GAMES.Models.PersonTeam> PersonTeam { get; set; }

    }
}
