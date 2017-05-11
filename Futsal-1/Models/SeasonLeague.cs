using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;

namespace Futsal_1.Models
{
    public class SeasonLeague
    {
        public int Id { get; set; }
        public bool Status { get; set; }

        public int SeasonId { get; set; }   
        public int LeagueId { get; set; }

        public virtual Season Season { get; set; }
        public virtual League League { get; set; }
        public virtual List <Match> Matches { get; set; }
    }
}