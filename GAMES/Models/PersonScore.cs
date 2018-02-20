using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GAMES.Models
{
    public class PersonScore
    {
        [Key] public Guid ID { get; set; }
        public int Score { get; set; }
        public Person PersonId { get; set; }
        public Game GameId { get; set; }
    }
}
