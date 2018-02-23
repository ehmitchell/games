using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GAMES.Models
{
    public class Person
    {
        [Key] public Guid ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsTeamParticipant { get; set; }
        public Guid? UserId { get; set; }
    }
}
