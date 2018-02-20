using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GAMES.Models
{
    public enum gameType {
        Time,
        Score
    }

    public enum gameScoreOrder {
        Ascending,
        Descending
    }

    public class Game
    {
        [Key] public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public bool IsTeamScore { get; set; }
        public gameType GameType { get; set; }
        public gameScoreOrder GameScoreOrder { get; set; }
    }
}
