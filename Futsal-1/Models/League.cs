using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual List<SeasonLeague> SeasonLeagues { get; set; }
    }
}