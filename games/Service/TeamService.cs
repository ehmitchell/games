using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAMES.Data;
using GAMES.Models;

namespace GAMES.Service
{
    public class TeamService
    {
        private GamesContext _dbContext;
        private static Random rng = new Random();

        public TeamService(GamesContext context)
        {
            _dbContext = context;
        }

        internal List<Team> GenerateRandomTeams(int gamesInstanceId)
        {
            GamesInstance gamesInstance = _dbContext.GamesInstances.Find(gamesInstanceId);
            List<Person> activePeople = _dbContext.Persons.Where(p => p.IsActive).ToList();
            activePeople = Shuffle<Person>(activePeople);

            List<Team> teams = Enumerable
                .Range(0, (int)Math.Ceiling(activePeople.Count / (double)gamesInstance.PersonTeamSize))
                .Select(t => new Team { GamesInstance = gamesInstance }).ToList();

            _dbContext.Teams.AddRange(teams);

            //I had to use an old school for loop here to have access to i, it pains me
            for (int i = 0; i < activePeople.Count; i++)
            {
                _dbContext.PersonTeams.Add(new PersonTeam
                {
                    Team = teams[i % teams.Count],
                    Person = activePeople[i]
                });
            }

            _dbContext.SaveChanges();
           
            return teams;
        }

        private List<T> Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}