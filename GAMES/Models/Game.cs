using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAMES.Models
{
    public enum GameType {
        Time,
        Score
    }

    public enum GameScoreOrder {
        Ascending,
        Descending
    }

    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public GamesInstance GamesInstance { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public bool IsTeamScore { get; set; }
        public GameType GameType { get; set; }
        public GameScoreOrder GameScoreOrder { get; set; }
    }
}
