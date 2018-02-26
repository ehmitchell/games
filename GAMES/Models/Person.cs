using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAMES.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public List<PersonTeam> PersonTeams { get; set; }
        public List<PersonScore> PersonScores { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsTeamParticipant { get; set; }
        public Guid? UserId { get; set; }
    }
}
