using GAMES.Data;
using GAMES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAMES.Service
{
    public class GamesInstanceService
    {
        private readonly GamesContext _dbContext;
        private readonly TeamService _teamService;

        public GamesInstanceService(GamesContext context,
            TeamService teamService)
        {
            _dbContext = context;
            _teamService = teamService;
        }

        internal List<GamesInstance> GetAllGames()
        {
            return _dbContext.GamesInstances.ToList();
        }

        internal bool GenerateRandomTeams(int gamesInstanceId)
        {
            return true;
        }

        internal GamesInstance Get(int gamesInstanceId)
        {
            return _dbContext.GamesInstances.Find(gamesInstanceId);
        }

        internal void CreateGamesInstance(GamesInstance gamesInstance)
        {
            List<GamesInstance> ActiveInstances = _dbContext.GamesInstances.Where(g => g.IsActive).ToList();
            ActiveInstances.ForEach(a => a.IsActive = false);

            _dbContext.Add(gamesInstance);
            _dbContext.SaveChanges();
        }
    }
}
