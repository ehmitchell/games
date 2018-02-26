using GAMES.Data;

namespace GAMES.Service
{
    public class PersonService
    {
        private readonly GamesContext _dbContext;
        private readonly TeamService _teamService;

        public PersonService(GamesContext context
            , TeamService teamService)
        {
            _dbContext = context;
            _teamService = teamService;
        }
    }
}