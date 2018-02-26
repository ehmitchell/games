using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> 9f30ccd33f25dd419cf685a2cd55361877831111
using System.Linq;
using System.Threading.Tasks;

namespace GAMES.Models
{
    public class PersonTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonTeamId { get; set; }
        public Person Person { get; set; }
        public Team Team { get; set; }
    }
}
