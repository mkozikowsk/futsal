using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    public class Match
    {
        public int Id { get; set; }
        [Display(Name = "Data rozpoczęcia")]
        public DateTime StartTime { get; set; }
        [Display(Name = "Gospodarze")]
        public int HomeTeamId { get; set; }
        [Display(Name = "Goście")]
        public int AwayTeamId { get; set; }
        [Display(Name = "Sędzia")]
        public int? ArbiterId { get; set; }
        [Display(Name = "Sezon")]
        public int SeasonLeagueId { get; set; }

        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
        public virtual Arbiter Arbiter { get; set; }
        public virtual SeasonLeauge SeasonLeauge { get; set; }
    }
}