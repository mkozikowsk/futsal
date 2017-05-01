using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    /// <summary>
    /// Class TeamsModel
    /// </summary>
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int CoachId { get; set; }

        public virtual Coach Choach { get; set; }
        public virtual List<Player> Players { get; set; }

    }
}