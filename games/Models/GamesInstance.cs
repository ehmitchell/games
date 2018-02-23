using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GAMES.Models
{
    public class GamesInstance
    {
        [Key]
        public int GamesInstanceId { get; set; }
        public int PersonTeamSize { get; set; }
        public string Tagline { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
