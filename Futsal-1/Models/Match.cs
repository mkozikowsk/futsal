using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }

        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }

        public int? ArbiterId { get; set; }

        public virtual Arbiter Arbiter { get; set; }
    }
}