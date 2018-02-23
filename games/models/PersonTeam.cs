using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GAMES.Models
{
    public class PersonTeam
    {
        [Key]
        public int PersonTeamId { get; set; }
        public Person Person { get; set; }
        public Team Team { get; set; }
    }
}
