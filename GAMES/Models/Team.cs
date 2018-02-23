using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GAMES.Models
{
    public class Team
    {
        [Key] public Guid ID { get; set; }
        public GamesInstance GamesInstance { get; set; }
        public string Name { get; set; }
    }
}
